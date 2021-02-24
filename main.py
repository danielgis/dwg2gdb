# from settings import *
from shapely import speedups

speedups.disable()
import re
import glob
import arcpy
import os
from sklearn.cluster import KMeans
import pandas as pd
import geopandas as gpd
from geopandas import points_from_xy
from geopandas.geodataframe import GeoDataFrame
from datetime import datetime
import uuid

_BASE_DIR = os.path.dirname(__file__)

_NAME_GDB = 'carta_topografica.gdb'
_GDB_PATH = os.path.join(_BASE_DIR, _NAME_GDB)

_MAC_ADREESS = uuid.getnode()
_MAC_ADREESS_HOME = 44225924275944

if _MAC_ADREESS == _MAC_ADREESS_HOME:
    _BASE_DIR = os.path.join(os.path.dirname(_BASE_DIR), 'aed')

_DWG_DIR = os.path.join(_BASE_DIR, 'dwg') # Directorio que debe contener a todos los archivos *.dwg

_SHAPE_DIR = os.path.join(_BASE_DIR, 'shp') # No es necesario que exista ya que se genera en el proceso
if not os.path.exists(_SHAPE_DIR):
    os.mkdir(_SHAPE_DIR)


_DWG_FILES = glob.glob(f"{_DWG_DIR}/**/*.dwg", recursive=True)

_SHAPE_ZONAS = os.path.join(_BASE_DIR, r'base\zonas_geograficas_4326_ingemmet.shp') # Es necesario especificar

_TABLE_TARGET_PL_REFNAME = os.path.join(_GDB_PATH, 'TB_00_clasificacion_pl_refname')
_TABLE_TARGET_PL = os.path.join(_GDB_PATH, 'TB_00_clasificacion_pl')
_TABLE_TARGET_PT_REFNAME = os.path.join(_GDB_PATH, 'TB_00_clasificacion_pt_refname')
_TABLE_TARGET_PT = os.path.join(_GDB_PATH, 'TB_00_clasificacion_pt')

_TABLE_TARGET_PO_REFNAME = os.path.join(_GDB_PATH, 'TB_00_clasificacion_po_refname')
_TABLE_TARGET_PO_LAYER = os.path.join(_GDB_PATH, 'TB_00_clasificacion_po_layer')
_TABLE_TARGET_PO = os.path.join(_GDB_PATH, 'TB_00_clasificacion_po') 

_PSAD_EPSG = 24860
_WGS_EPSG = 32700

_NAME_DATASET = 'DS_0{}_cartografia_{}s'

# Nombre a features
_NAME_FEATURE_PL = 'PL_0{}_{}'
_NAME_FEATURE_PT = 'PT_0{}_{}'
_NAME_FEATURE_AN = 'AN_0{}_anotaciones'
_NAME_FEATURE_PO = 'PO_0{}_{}'

_POINT = 'Point'
_ANNOTATION = 'Annotation'
_POLYLINE = 'Polyline'
_POLYGON = 'Polygon'

_COLOR_FIELD = 'Color'
_LINETYPE_FIELD = 'Linetype'
_BLKCOLOR_FIELD = 'BlkColor'
_LINEWT_FIELD = 'LineWt'
_ENTLINEWT_FIELD = 'EntLineWt'
_REFNAME_FIELD = 'RefName'
_LAYER_FIELD = 'Layer'
_TARGET_FIELD = 'target'
_GEOMETRY_FIELD = 'geometry'

_ZONAS = [17, 18, 19]


def pl_preprocesamiento(gdf):
    """
    Proceso que permiter depurar los datos de lineas para su clasificacion
    :param gdf: geodataframe de lineas
    :return: geodataframe depurado
    """
    gdf = gdf.dropna(subset=[_GEOMETRY_FIELD])  # Elimina geometrias nulas
    gdf = gdf.explode()  # MultilineString a LineString
    gdf = gdf.drop_duplicates(subset=['geometry'], keep='first')  # Remueve duplicados espacialmente
    gdf = pl_eliminar_grillas(gdf)  # Retira las grillas
    return gdf


def pl_eliminar_grillas(gdf):
    """
    Proceso que remueve la grilla de coordenadas que no son de utilidad para
    los fines de la migracion
    :param gdf: geodataframe de lineas
    :return: geodataframe depurado
    """
    columns = gdf.columns
    gdf['x_ini'] = gdf.geometry.apply(lambda i: i.coords.xy[0][0])
    gdf['y_ini'] = gdf.geometry.apply(lambda i: i.coords.xy[1][0])
    gdf['x_fin'] = gdf.geometry.apply(lambda i: i.coords.xy[0][-1])
    gdf['y_fin'] = gdf.geometry.apply(lambda i: i.coords.xy[1][-1])
    vlines = ((gdf['x_ini'] == gdf['x_fin']) & (gdf['y_ini'] != gdf['y_fin']))
    hlines = ((gdf['x_ini'] != gdf['x_fin']) & (gdf['y_ini'] == gdf['y_fin']))
    gdf = gdf[~(vlines | hlines)]
    return gdf[columns]


def pl_clasificacion(gdf, gdf_target):
    """
    Proceso que clasifica los objetos vectoriales tipo linea
    :param gdf: geodataframe de lineas
    :param gdf_target: dataframe de clasificacion
    :return: geodataframe clasificado
    """
    gdf[_LINETYPE_FIELD] = gdf[_LINETYPE_FIELD].str.lower()
    df = pd.merge(gdf, gdf_target, how='left', on=[_COLOR_FIELD, _LINETYPE_FIELD])
    gdf = gpd.GeoDataFrame(df)
    return gdf


def polilineas_a_geodatabase(gdf, zona, df_target, name, cuadricula):
    """
    Migra los datos de lineas en formato *.shp a un *.gdb
    :param gdf: geodataframe de lineas
    :param zona: zona geografica
    :param df_target: dataframe de clasificacion
    :param name: nombre de la hoja
    :return: no aplica
    """
    idx = _ZONAS.index(int(zona)) + 1
    gdf = pl_preprocesamiento(gdf)
    gdf = pl_clasificacion(gdf, df_target)
    gdf = reproyectar_geodataframe(gdf, _PSAD_EPSG + int(zona), _WGS_EPSG + int(zona))
    gdf = gdf[gdf.intersects(cuadricula.geometry[0])]
    gdf['RuleID'] = 1
    for i in gdf[_TARGET_FIELD].unique():
        dataset = _NAME_DATASET.format(idx, zona)
        feature = _NAME_FEATURE_PL.format(idx, i)
        feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        if (not arcpy.Exists(feature_class_path)) or (i is None):
            feature = _NAME_FEATURE_PL.format(idx, 'otros')
            feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        shp_outpath = os.path.join(_SHAPE_DIR, f'pl_{name}_{i}.shp')
        gdf_filter = gdf[gdf[_TARGET_FIELD] == i]
        if not len(gdf_filter):
            continue
        gdf_filter.to_file(shp_outpath)
        arcpy.Append_management(shp_outpath, feature_class_path, 'NO_TEST')


def an_preprocesamiento(gdf):
    """
    Proceso que permiter depurar los datos de anotaciones para su clasificacion
    :param gdf: geodataframe de anotaciones
    :return: geodataframe depurado
    """
    gdf = gdf.dropna(subset=[_GEOMETRY_FIELD])  # Elimina geometrias nulas
    gdf = gdf.explode()  # MultilineString a LineString
    gdf = gdf.drop_duplicates(subset=['geometry'], keep='first')  # Remueve duplicados espacialmente
    gdf['etiqueta'] = gdf['Text'].str.strip()  # Removemos los espacios en blanco (left, right) de la columna Text
    gdf = gdf.dropna(subset=['etiqueta'])  # Removemos los valores nulos en la columna etiqueta
    return gdf


def an_clasificacion(gdf):
    """
    Permite clasificar las anotaciones en base a sus caracteristicas
    :param gdf: geodataframe
    :return: geodatframe categorizado
    """
    gdf = an_preprocesamiento(gdf)
    # Obtenemos todos los textos que son numeros, incluyendo decimales
    gdf_num = gdf[gdf['etiqueta'].str.match('^\d*[.,]?\d*$')]
    # Cota de curvas principales
    gdf_cota = gdf_num[gdf_num['etiqueta'].str.match('^[1-9]+[0-9]*00$')]
    gdf_cota['categoria'] = 'cota'
    # Cotas comprobadas
    gdf_cota_comprobada = gdf_num[~gdf_num['etiqueta'].str.match('^[1-9]+[0-9]*00$')]
    gdf_cota_comprobada['categoria'] = 'cota_comprobada'
    # Obtenemos todos los textos que no son numeros
    gdf_txt = gdf[~gdf['etiqueta'].str.match('^\d*[.,]?\d*$')]
    # Obtenemos la toponimia hidrografica
    gdf_hidrografia = gdf_txt[gdf_txt['Color'] == 5]
    gdf_hidrografia['categoria'] = 'topon_hidrografica'
    # Obtenemos la toponimia no hidrografica
    gdf_toponimia = gdf_txt[gdf_txt['Color'] != 5]
    gdf_toponimia['categoria'] = 'topon_general'
    gdf = pd.concat([gdf_cota, gdf_cota_comprobada, gdf_hidrografia, gdf_toponimia], axis=0)
    return gdf


def anotaciones_a_geodatabase(gdf, zona, name, cuadricula):
    """
    Migra los datos de anotaciones en formato *.shp a un *.gdb
    :param gdf: geodataframe de anotaciones
    :param zona: zona geografica
    :param name: nombre de hoja
    :param cuadricula: cuadricula proyectada en utm
    :return: no aplica
    """
    idx = _ZONAS.index(int(zona)) + 1
    gdf = reproyectar_geodataframe(gdf, _PSAD_EPSG + int(zona), _WGS_EPSG + int(zona))
    gdf = gdf[gdf.intersects(cuadricula.geometry[0])]
    gdf = an_clasificacion(gdf)
    if not len(gdf):
        return
    out_shapefile = os.path.join(_SHAPE_DIR, f'ann_{name}.shp')
    gdf.to_file(out_shapefile)
    dataset = _NAME_DATASET.format(idx, zona)
    feature = _NAME_FEATURE_AN.format(idx)
    feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
    arcpy.Append_management(out_shapefile, feature_class_path, 'NO_TEST')


def pt_preprocesamiento(gdf):
    """
    Proceso que permiter depurar los datos de lineas para su clasificacion
    :param gdf: geodataframe de poligonos
    :return: geodataframe depurado
    """
    gdf = gdf.dropna(subset=[_GEOMETRY_FIELD])  # Elimina geometrias nulas
    gdf = gdf.explode()  # Multipolygon a polygon
    gdf = gdf.drop_duplicates(subset=['geometry'], keep='first')  # Remueve duplicados espacialmente
    return gdf


def pt_clasificacion(gdf, gdf_target_a, gdf_target_b):
    """
    Clasifica los objetos de tipo punto
    :param gdf: geodataframe de puntos
    :param gdf_target_a: geodataframe refname de puntos
    :param gdf_target_b: geodataframe de calisifcaicon target
    :return: geodataframe clasificado
    """
    gdf[_REFNAME_FIELD] = gdf[_REFNAME_FIELD].str.lower()
    gdf_target_a[_REFNAME_FIELD] = gdf_target_a[_REFNAME_FIELD].str.lower()
    gdf[_LINETYPE_FIELD] = gdf[_LINETYPE_FIELD].str.lower()

    df1 = pd.merge(gdf, gdf_target_a, how='left', on=[_REFNAME_FIELD])

    df2 = df1[df1['categoria'].isnull()]
    df2 = df2.drop(_TARGET_FIELD, axis=1)
    df2 = df2.drop('categoria', axis=1)

    fields_merge = [_COLOR_FIELD, _BLKCOLOR_FIELD, _LINETYPE_FIELD, _LINEWT_FIELD, _ENTLINEWT_FIELD]
    df3 = pd.merge(df2, gdf_target_b, how='left', on=fields_merge)
    df4 = pd.concat([df1, df3], axis=0)
    gdf = gpd.GeoDataFrame(df4)
    return gdf


def punto_a_geodatabase(gdf, gdf_target_a, gdf_target_b, zona, name, cuadricula):
    """
    Migra los objetos tipo punto en el archivo dwg a un feature class de punto en una
    geodatabase
    :param gdf: geodataframe de puntos
    :param gdf_target_a:
    :param gdf_target_b:
    :param zona: zona geografica
    :param name: nombre de la hoja
    :param cuadricula: geodataframe de cuadricula proyectada
    :return: no aplica
    """
    idx = _ZONAS.index(int(zona)) + 1
    gdf = reproyectar_geodataframe(gdf, _PSAD_EPSG + int(zona), _WGS_EPSG + int(zona))
    gdf = gdf[gdf.intersects(cuadricula.geometry[0])]
    gdf = pt_preprocesamiento(gdf)
    gdf = pt_clasificacion(gdf, gdf_target_a, gdf_target_b)
    target = gdf[_TARGET_FIELD].unique()
    for i in target:
        dataset = _NAME_DATASET.format(idx, zona)
        feature = _NAME_FEATURE_PT.format(idx, i)
        feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        if (not arcpy.Exists(feature_class_path)) or (i is None):
            feature = _NAME_FEATURE_PT.format(idx, 'otros')
            feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        shp_outpath = os.path.join(_SHAPE_DIR, f'po_{name}_{i}.shp')
        gdf_filter = gdf[gdf[_TARGET_FIELD] == i]
        if not len(gdf_filter):
            continue
        gdf_filter.to_file(shp_outpath)
        arcpy.Append_management(shp_outpath, feature_class_path, 'NO_TEST')


def po_preprocesamiento(gdf):
    """
    Proceso que permiter depurar los datos de puntos para su clasificacion
    :param gdf: geodataframe de poligonos
    :return: geodataframe depurado
    """
    gdf = gdf.dropna(subset=[_GEOMETRY_FIELD])  # Elimina geometrias nulas
    gdf = gdf.explode()  # Multipolygon a polygon
    gdf = gdf[gdf['geometry'].is_valid]
    gdf = gdf.drop_duplicates(subset=['geometry'], keep='first')  # Remueve duplicados espacialmente
    return gdf

def po_clasificacion(gdf, gdf_target):
    gdf[_LINETYPE_FIELD] = gdf[_LINETYPE_FIELD].str.lower()
    gdf[_LAYER_FIELD] = gdf[_LAYER_FIELD].str.lower()
    df = pd.merge(gdf, gdf_target, how='left', on=[_LAYER_FIELD, _COLOR_FIELD, _LINETYPE_FIELD])
    gdf = gpd.GeoDataFrame(df)
    return gdf


def poligonos_a_geodatabase(gdf, gdf_target, zona, name, cuadricula):
    idx = _ZONAS.index(int(zona)) + 1
    # if not len(gdf):
    #     return
    gdf = po_preprocesamiento(gdf)
    gdf = reproyectar_geodataframe(gdf, _PSAD_EPSG + int(zona), _WGS_EPSG + int(zona))
    
    gdf = gdf[gdf.intersects(cuadricula.geometry[0])]
    gdf = po_clasificacion(gdf, gdf_target)
    target = gdf[_TARGET_FIELD].unique()
    for i in target:
        dataset = _NAME_DATASET.format(idx, zona)
        feature = _NAME_FEATURE_PO.format(idx, i)
        feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        if (not arcpy.Exists(feature_class_path)) or (i is None):
            feature = _NAME_FEATURE_PO.format(idx, 'otros')
            feature_class_path = os.path.join(_GDB_PATH, dataset, feature)
        shp_outpath = os.path.join(_SHAPE_DIR, f'po_{name}_{i}.shp')
        gdf_filter = gdf[gdf[_TARGET_FIELD] == i]
        if not len(gdf_filter):
            continue
        gdf_filter.to_file(shp_outpath)
        arcpy.Append_management(shp_outpath, feature_class_path, 'NO_TEST')


def reproyectar_geodataframe(gdf, origen, destino):
    """
    Permite reproyectar un geodataframe
    :param gdf: geodataframe
    :param origen: epsg de origen
    :param destino: epsg de destino
    :return: geodataframe reproyectado
    """
    gdf.set_crs(epsg=origen, inplace=True)  # Definir proyeccion
    gdf.to_crs(epsg=4248, inplace=True)  # Proyectar a geograficas PSAD56
    gdf.to_crs(epsg=4326, inplace=True)  # Proyectar a geograficas WGS84
    gdf.to_crs(epsg=destino, inplace=True)  # Proyectas de salida
    return gdf


def estandarizar_codificacion(code):
    """
    Permite la estandarizacion de codigos de hoja
    :param code: codigo no estandarizado
    :return: codigo estandarizado
    """
    roman_number = {'i': '1', 'ii': '2', 'iii': '3', 'iv': '4'}
    regex_str = '(\d+)(\s*|-)([a-zñ])(\s*|-)([1-5]|i|ii|iii|iv)(\s*|-)(ne|no|se|so)'
    regex_grp = '\\1,\\3,\\5,\\7'
    code_str = re.sub(regex_str, regex_grp, code.lower())
    code_list = code_str.split(',')
    if not code_list[2].isnumeric():
        code_list[2] = roman_number[code_list[2]]
        
    code_list.append(''.join(code_list))
    
    response = dict(zip(['fila', 'columna', 'cuadrante', 'rumbo', 'code'], code_list))
    return response


def codificacion(gdf, **kwargs):
    """
    Asigna la codificacion estndarizada a un geodataframe
    :param gdf: geodataframe
    :param kwargs: **{''fila': , 'columna':, 'cuadrante':, 'rumbo':, }
    :return: geodataframe con las columnas de codigo
    """
    gdf['fila'] = kwargs['fila']
    gdf['columna'] = kwargs['columna']
    gdf['cuadrante'] = kwargs['cuadrante']
    gdf['rumbo'] = kwargs['rumbo']
    gdf['code'] = kwargs['code']
    return gdf


def dwg_a_shapefile_por_geometria(archivo_dwg, directorio_salida, tipo_geometria, code, array_delete_refname=None, array_delete_layer=None):
    """
    Transforma un archivo *.dwg a *.shp
    :param archivo_dwg: ubicacion de archivo en formato *.dwg
    :param directorio_salida: ubicacion del directorio de salida
    :param tipo_geometria: tipo de geometria a rescatar (punto, linea, poligono, anotacion)
    :param code: codigo estandarizado como dict(): {''fila': , 'columna':, 'cuadrante':, 'rumbo':, }
    :param g_cuadricula: geometria de la cuadricula
    :return: geodataframe
    """
    file_name = os.path.basename(archivo_dwg)
    layer_name = f'{file_name.split(".")[0]}_layer'
    make_feature = arcpy.MakeFeatureLayer_management(f'{archivo_dwg}/{tipo_geometria}', layer_name)
    outpath = f'{directorio_salida}/{layer_name}_{tipo_geometria}.shp'
    arcpy.CopyFeatures_management(make_feature, outpath)
    gdf = gpd.read_file(outpath)    
    if array_delete_layer:
        gdf[_LAYER_FIELD] = gdf[_LAYER_FIELD].str.lower()
        gdf = gdf[~gdf[_LAYER_FIELD].isin(array_delete_refname)]
    if array_delete_refname:
        gdf[_REFNAME_FIELD] = gdf[_REFNAME_FIELD].str.lower()
        gdf = gdf[~gdf[_REFNAME_FIELD].isin(array_delete_refname)]
    gdf = codificacion(gdf, **code)
    return gdf


def determinar_zona_geografica(gdf, gdf_zonas):
    """
    Permite definir en que zona geografica se encuentra el archivo *.dwg
    :param gdf: Geodataframe de anotaciones
    :param gdf_zonas:Geodataframe de las zonas geograficas nacional
    :return: zona y geometria de cuadrantes
    """
    pd.options.mode.chained_assignment = None
    _X_FIELD = 'x'
    _Y_FIELD = 'y'
    _TEXT_FIELD = 'Text'
    _TARGET_FIELD = 'target'
    _ZONE_FIELD = 'ZONE'
    _AREA_FIELD = 'g_area'
    _D_FIELD = 'D'
    _DD_FIELD = 'DD'
    _M_FIELD = 'M'
    _S_FIELD = 'S'
    _IDX_FIELD = 'idx'
    _REGEX_PATTERN = '''(\d+)(\s*)(%%186|%%186%%186|%%167|°|15\/64|§)(\s*)(\d*)(\s*)(')(\s*)(\d*)("|'')$'''
    _N_CLUSTER = 4
    gdf = gdf.dropna(subset=[_TEXT_FIELD])
    gdf[_X_FIELD] = gdf.centroid.x
    gdf[_Y_FIELD] = gdf.centroid.y
    
    gdf_regex = gdf[gdf[_TEXT_FIELD].str.match(_REGEX_PATTERN)]
    # gdf_regex[_X_FIELD] = gdf_regex.centroid.x
    # gdf_regex[_Y_FIELD] = gdf_regex.centroid.y
    gdf_regex = gdf_regex[[_X_FIELD, _Y_FIELD, _TEXT_FIELD]].reset_index()
    # Clasificacion no supervizada (algoritmo de clustering)
    kmeans_model = KMeans(n_clusters=_N_CLUSTER)
    target = kmeans_model.fit_predict(gdf_regex[[_X_FIELD, _Y_FIELD]].values)
    df_target = pd.DataFrame(target, columns=[_TARGET_FIELD])
    df_concat = pd.concat([gdf_regex, df_target], axis=1)
    df_concat[_TEXT_FIELD] = df_concat[_TEXT_FIELD].apply(lambda i: re.sub(_REGEX_PATTERN, '\\1,\\5,\\9', i))
    df_concat[[_D_FIELD, _M_FIELD, _S_FIELD]] = df_concat[_TEXT_FIELD].str.split(',', 2, expand=True)
    df_concat[_M_FIELD] = df_concat[_M_FIELD].astype(int) / 60
    df_concat[_S_FIELD] = df_concat[_S_FIELD].astype(int) / 3600
    df_concat[_DD_FIELD] = (df_concat[_D_FIELD].astype(int) + df_concat[_M_FIELD] + df_concat[_S_FIELD]) * -1
    df_concat = df_concat.drop_duplicates(subset=[_TARGET_FIELD, _D_FIELD, _M_FIELD, _S_FIELD], keep='first')

    df_concat.sort_values(by=[_TARGET_FIELD, _DD_FIELD], inplace=True, ignore_index=True)
    df_concat[_IDX_FIELD] = df_concat.groupby(_TARGET_FIELD).cumcount()
    latitude = df_concat[df_concat[_IDX_FIELD] == 1][_DD_FIELD].tolist()
    longitude = df_concat[df_concat[_IDX_FIELD] == 0][_DD_FIELD].tolist()
    df_cuad = pd.DataFrame({'Latitude': latitude, 'Longitude': longitude})
    gdf_cuad = GeoDataFrame(df_cuad, geometry=points_from_xy(df_cuad.Longitude, df_cuad.Latitude))
    cuadrante = gdf_cuad.unary_union.convex_hull
    gdf_cuad_pol = GeoDataFrame(geometry=[cuadrante])

    gdf_cuad_pol.set_crs(epsg=4248, inplace=True)
    gdf_cuad_pol.to_crs(epsg=4326, inplace=True)
    response = gpd.overlay(gdf_zonas, gdf_cuad_pol, how='intersection')
    response.to_crs(epsg=32718, inplace=True)

    response[_AREA_FIELD] = response.area
    response = response.sort_values(_AREA_FIELD, ascending=False).reset_index()
    zona_response = response[_ZONE_FIELD][0]
    cuadrante_proj = gdf_cuad_pol.to_crs(epsg=_WGS_EPSG + int(zona_response))

    # Obteniendo el nombre del cuadrante
    x_cuad = cuadrante_proj.centroid.x[0]
    gdf_title = gdf.sort_values(by=[_Y_FIELD], ascending=False).iloc[:5, :]
    gdf_title['distance'] = abs(gdf_title.x - x_cuad)
    gdf_title.sort_values(by=['distance'], inplace=True)
    name_cuadrante = gdf_title.iloc[0, :][_TEXT_FIELD]
    name_cuadrante = name_cuadrante.upper()

    return zona_response, cuadrante, cuadrante_proj, name_cuadrante


def proceso():
    """
    Proceso principal
    :return: no aplica
    """
    global _DWG_FILES
    arcpy.env.overwriteOutput = True
    cuadrantes = list()
    gdf_zona = gpd.read_file(_SHAPE_ZONAS)

    np_target_pl_refname = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PL_REFNAME, [_REFNAME_FIELD])
    df_target_pl_refname = pd.DataFrame(np_target_pl_refname)
    refname_pl_delete = df_target_pl_refname[_REFNAME_FIELD].tolist()

    np_target = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PL, [_COLOR_FIELD, _LINETYPE_FIELD, _TARGET_FIELD])
    df_target = pd.DataFrame(np_target)

    np_target_a = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PT_REFNAME, [_REFNAME_FIELD, _TARGET_FIELD, 'categoria'])
    df_target_a = pd.DataFrame(np_target_a)

    fields_targe_b = [_COLOR_FIELD, _BLKCOLOR_FIELD, _LINETYPE_FIELD, _LINEWT_FIELD, _ENTLINEWT_FIELD, _TARGET_FIELD,
                      'categoria']
    np_target_b = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PT, fields_targe_b)
    df_target_b = pd.DataFrame(np_target_b)

    np_target_po_refname = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PO_REFNAME, [_REFNAME_FIELD])
    df_target_po_refname = pd.DataFrame(np_target_po_refname)
    refname_po_delete = np_target_po_refname[_REFNAME_FIELD].tolist()

    np_target_po_layer = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PO_LAYER, [_LAYER_FIELD])
    df_target_po_layer= pd.DataFrame(np_target_po_layer)
    layer_po_delete = df_target_po_layer[_LAYER_FIELD].tolist()

    np_target_po = arcpy.da.TableToNumPyArray(_TABLE_TARGET_PO, [_LAYER_FIELD, _COLOR_FIELD, _LINETYPE_FIELD, _TARGET_FIELD])
    df_target_po = pd.DataFrame(np_target_po)

    codes = list()
    # print(_DWG_FILES[7:8])
    # exit()
    # _DWG_FILES = [
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\17\17-e\17e-i-ne.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\22\22k-ii-se.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\22\22k-iii-so.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\24\24-m\24m-iii-se.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\35\35-v\35v-ii-no.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\35\35-v\35v-ii-se.dwg',
        # r'd:\daguado\P03_apoyo_osi\P0301_mapa_topografico_25k\dev\dwg\36\36-v\36v-ii-ne.dwg',
        # r'24m-iii-se.dwg',
        # r'34v-iii-ne.dwg', sin coords
        # r'34v-iii-se.dwg' sin coords,
        # r'22k-iii-so.dwg' procesado pero es un archivo incompleto,
        # r'22k-ii-se.dwg',
        # r'36v-iv-so.dwg',
        # r'36v-iv-no.dwg',
        # r'37v-iv-ne.dwg',
        # r'37v-i-no.dwg'
    # ]

    if _MAC_ADREESS != _MAC_ADREESS_HOME:
        _DWG_FILES = _DWG_FILES[:10]

    for i, dwg in enumerate(_DWG_FILES):
        try:
            row = dict()
            name = os.path.basename(dwg).split('.')[0]
            code = estandarizar_codificacion(name)
            if code['code'] in codes:
                raise RuntimeError(f'Archivo duplicado: {name}')
            gdf_ann = dwg_a_shapefile_por_geometria(dwg, _SHAPE_DIR, _ANNOTATION, code)
            row['zona'], row['geometry'], cuadrante_proj, row['nombre'] = determinar_zona_geografica(gdf_ann, gdf_zona)

            gdf_pli = dwg_a_shapefile_por_geometria(dwg, _SHAPE_DIR, _POLYLINE, code, array_delete_refname=refname_pl_delete)
            gdf_pnt = dwg_a_shapefile_por_geometria(dwg, _SHAPE_DIR, _POINT, code)
            gdf_pol = dwg_a_shapefile_por_geometria(dwg, _SHAPE_DIR, _POLYGON, code, array_delete_refname=refname_po_delete, array_delete_layer=layer_po_delete)

            polilineas_a_geodatabase(gdf_pli, row['zona'], df_target, code['code'], cuadrante_proj)
            punto_a_geodatabase(gdf_pnt, df_target_a, df_target_b, row['zona'], code['code'], cuadrante_proj)
            anotaciones_a_geodatabase(gdf_ann, row['zona'], code['code'], cuadrante_proj)
            poligonos_a_geodatabase(gdf_pol, df_target_po, row['zona'], code['code'], cuadrante_proj)

            cuadrantes.append({**row, **code})
            codes.append(code['code'])
            print(i, code)
        except Exception as e:
            print(i, dwg, e)

    gdf_cuadrantes = gpd.GeoDataFrame(cuadrantes)
    # gdf_cuadrantes = gdf_cuadrantes.drop_duplicates(subset=['geometry'], keep='first')
    gdf_cuadrantes.set_crs(epsg=4248, inplace=True)
    gdf_cuadrantes.to_crs(epsg=4326, inplace=True)
    cuadrantes_shapefile = os.path.join(_SHAPE_DIR, 'cuadrantes.shp')
    gdf_cuadrantes.to_file(cuadrantes_shapefile)
    arcpy.Append_management(cuadrantes_shapefile, os.path.join(_GDB_PATH, 'PO_00_cuadriculas'), 'NO_TEST')
    # arcpy.CopyFeatures_management(cuadrantes_shapefile, os.path.join(_BASE_DIR, _NAME_GDB, 'PO_00_cuadriculas'))
    print('end process')


if __name__ == '__main__':
    ini = datetime.now()
    print(ini)
    proceso()
    print(datetime.now() - ini)

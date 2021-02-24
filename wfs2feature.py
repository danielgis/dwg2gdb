import sys, os
from osgeo import ogr, gdal

gdal.SetConfigOption('GDAL_HTTP_UNSAFESSL', 'YES')

_OUT_DIR = arcpy.GetParameterAsText(0)
_WFS_URL = arcpy.GetParameterAsText(1)
_GEOMETRY = arcpy.GetParameterAsText(2)     # point, line, polygon

_DRIVER_NAME_WFS = 'WFS'
_DRIVER_NAME_SHAPEFILE = 'ESRI Shapefile'

ext = ''
desc = arcpy.Describe(_OUT_DIR)
if desc.datatype.lower() == 'folder':
    ext = '.shp'

driver_wfs = ogr.GetDriverByName(_DRIVER_NAME_WFS)
wfs = driver_wfs.Open(f'{_DRIVER_NAME_WFS}:{_WFS_URL}')

layer_count = wfs.GetLayerCount()

for i in range(layer_count):
    layer = wfs.GetLayerByIndex(i)
    layer_name = layer.GetName()
    driver_shapefile = ogr.GetDriverByName(_DRIVER_NAME_SHAPEFILE)
    out_feature = os.path.join(_OUT_DIR, f'{layer_name}{ext}')
    data_source = driver_shapefile.CreateDataSource(out_feature)
    prj = layer.GetSpatialRef()
    if _GEOMETRY_TYPE == 'point':
        geom = ogr.wkbPoint
    elif _GEOMETRY_TYPE == 'line':
        geom = ogr.wkbLineString
    elif _GEOMETRY_TYPE == 'polygon':
        geom = ogr.wkbPolygon
    layer_new = data_source.CreateLayer(layer_name, prj, geom)
    layer_def = layer.GetLayerDefn()
    for field in range(layer_def.GetFieldCount()):
        field_name = layer_def.GetFieldDefn(field).GetName()
        if field_name in ('SHAPE.STArea__', 'SHAPE.STLength__'):
            continue
        layer_new.CreateField(layer_def.GetFieldDefn(field))
    
    for row in layer:
        layer_new.CreateFeature(row)
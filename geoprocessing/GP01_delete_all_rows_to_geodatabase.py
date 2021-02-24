import arcpy
import os

# geodatabase = arcpy.GetParameterAsText(0)
geodatabase = r'C:\daniel\proyectos\ingemmet\OS13012021\mapa_topografico_25k\dev\carta_topografica.gdb'
arcpy.env.workspace = geodatabase

datasets = arcpy.ListDatasets(feature_type='feature')
datasets = [''] + datasets if datasets is not None else []

for ds in datasets:
    for fc in arcpy.ListFeatureClasses(feature_dataset=ds):
        path = os.path.join(arcpy.env.workspace, ds, fc)
        arcpy.DeleteRows_management(path)
        arcpy.AddMessage(f'Deleting {fc}')

arcpy.AddMessage(f'Compactando {geodatabase}')
arcpy.Compact_management(geodatabase)
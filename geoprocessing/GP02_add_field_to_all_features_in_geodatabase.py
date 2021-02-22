import arcpy
import os

params = list()

arcpy.env.workspace = arcpy.GetParameterAsText(0)

field_name = arcpy.GetParameterAsText(1)
field_name = field_name if field_name else '#'
params.append(field_name)

field_type = arcpy.GetParameterAsText(2)
field_type = field_type if field_type else '#'
params.append(field_type)

field_precision = arcpy.GetParameterAsText(3)
field_precision = field_precision if field_precision else '#'
params.append(field_precision)

field_scale = arcpy.GetParameterAsText(4)
field_scale = field_scale if field_scale else '#'
params.append(field_scale)

field_length = arcpy.GetParameterAsText(5)
field_length = field_length if field_name else '#'
params.append(field_length)

field_alias = arcpy.GetParameterAsText(6)
field_alias = field_alias if field_alias else '#'
params.append(field_alias)

datasets = arcpy.ListDatasets(feature_type='feature')
datasets = [''] + datasets if datasets is not None else []

for ds in datasets:
    for fc in arcpy.ListFeatureClasses(feature_dataset=ds):
        path = os.path.join(arcpy.env.workspace, ds, fc)
        if field_name in [i.name for i in arcpy.ListFields(path)]:
            arcpy.AddMessage(f'the "{field_name}" field already exists in {fc}')
            continue
        params2 = [path] + params
        arcpy.AddField_management(*params2)
        arcpy.AddMessage(f'Create field "{field_name}" to {fc}')
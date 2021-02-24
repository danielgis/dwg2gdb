import os


_BASE_DIR = os.path.dirname(__file__)
_MXD_DIR = os.path.join(_BASE_DIR, 'mxd')
_MXD_17 = os.path.join(_MXD_DIR, 'T0117.mxd')
_MXD_18 = os.path.join(_MXD_DIR, 'T0218.mxd')
_MXD_19 = os.path.join(_MXD_DIR, 'T0319.mxd')

_GDB_DIR = os.path.join(_BASE_DIR, 'carta_topografica.gdb')
_CUADRICULAS_PATH = os.path.join(_GDB_DIR, 'PO_00_cuadriculas')

_ZONAS_GEOGRAFICAS = [17, 18, 19]

# GENERAL FIELDS
_CODE_FIELD = 'code'
_ZONA_FIELD = 'zona'


_SCALE_MAPA_TOPOGRAFICO_25K = 25000
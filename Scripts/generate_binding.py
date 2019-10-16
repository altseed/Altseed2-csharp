import cbg
import ctypes
import sys

# StaticFileクラスと、その依存先
# BaseFileReader, SeekOriginの定義の書き方。

# SeekOrigin (with文を使った書き方。お好みで)
SeekOrigin = cbg.Enum('altseed', 'SeekOrigin')
with SeekOrigin as enum:
    enum.add('Begin')
    enum.add('Current')
    enum.add('End')

# BaseFileReader (with文を使った書き方。お好みで)
BaseFileReader = cbg.Class('altseed', 'BaseFileReader')
with BaseFileReader as class_:
    # with class_.add_constructor() as ctor:
    #     ctor.add_arg(ctypes.c_wchar_p, 'path')

    # with class_.add_func('GetPosition') as func:
    #     func.return_type = long # longは未対応

    # with class_.add_func('GetFullPath') as func:
    #     func.return_type = ctypes.c_wchar_p

    # with class_.add_func('GetSize') as func:
    #     func.return_type = long

    # with class_.add_func('ReadBytes') as func:
    #     func.add_arg(cbg.Vector(byte), 'buffer')    # Vector, byteは未対応
    #     func.add_arg(long, 'count')

    with class_.add_func('ReadUInt32') as func:
        func.return_type = int

    # with class_.add_func('ReadUInt64') as func:
    #     func.return_type = long

    # with class_.add_func('ReadAllBytes') as func:
    #     func.add_arg(cbg.Vector(byte), 'buffer')

    # with class_.add_func('Seek') as func:
    #     func.add_arg(long, 'offset')
    #     func.add_arg(SeekOrigin, 'origin')

    with class_.add_func('GetIsInPackage') as func:
        func.return_type = bool

# StaticFile (with使わない書き方。お好みで)
StaticFile = cbg.Class('altseed', 'StaticFile', True)
# func = StaticFile.add_func('GetBuffer')
# func.return_type = bytes    # bytesは未対応

# func = StaticFile.add_func('GetPath')
# func.return_type = ctypes.c_wchar_p

# func = StaticFile.add_func('GetData')
# func.return_type = ctypes.c_void_p  # const void* は未対応

func = StaticFile.add_func('GetSize')
func.return_type = int

func = StaticFile.add_func('GetIsInPackage')
func.return_type = bool

func = StaticFile.add_func('Reload')
func.return_type = bool

# define
define = cbg.Define()
define.enums.append(SeekOrigin)
define.classes.append(BaseFileReader)
define.classes.append(StaticFile)

# generate
sharedObjectGenerator = cbg.SharedObjectGenerator(define)

sharedObjectGenerator.header = '''
#include "HelloWorld.h"
'''

sharedObjectGenerator.func_name_create_and_add_shared_ptr = 'HelloWorld::CreateAndAddSharedPtr'
sharedObjectGenerator.func_name_add_and_get_shared_ptr = 'HelloWorld::AddAndGetSharedPtr'

sharedObjectGenerator.output_path = 'tests/results/so/so.cpp'
sharedObjectGenerator.generate()

args = sys.argv
lang = 'en'
if len(args) >= 3 and args[1] == '-lang':
    if args[2] in ['ja', 'en']:
        lang = args[2]
    else:
        print('python csharp.py -lang [ja|en]')

bindingGenerator = cbg.BindingGeneratorCSharp(define, lang)
bindingGenerator.output_path = '../Source/Core.cs'
bindingGenerator.dll_name = 'Altseed_Core.dll'
bindingGenerator.namespace = 'asd'
bindingGenerator.generate()
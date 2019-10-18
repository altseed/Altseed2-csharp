import cbg
import ctypes
import sys
import shutil
import os

from bindings.define import define

def createIfNotFound(dir):
    if not os.path.exists(dir):
        os.mkdir(dir)
    
createIfNotFound("../Source")

# generate C# binding
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

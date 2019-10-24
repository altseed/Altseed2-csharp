import os, sys

# move to source directory
os.chdir(os.path.dirname(os.path.abspath(__file__)))

from bindings import define
from bindings.CppBindingGenerator import BindingGeneratorCSharp

# generate C# binding
args = sys.argv
lang = 'en'
if len(args) >= 3 and args[1] == '-lang':
    if args[2] in ['ja', 'en']:
        lang = args[2]
    else:
        print('python csharp.py -lang [ja|en]')

bindingGenerator = BindingGeneratorCSharp(define, lang)
bindingGenerator.output_path = '../src/Altseed2/Core.cs'
bindingGenerator.dll_name = 'Altseed_Core.dll'
bindingGenerator.namespace = 'asd'
bindingGenerator.generate()

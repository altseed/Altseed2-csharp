import os, shutil, ntpath, glob

# move to source directory
os.chdir(os.path.dirname(os.path.abspath(__file__)))

targetPath = '../Core/scripts/bindings'
outputPath = "./bindings"

if os.path.exists(outputPath):
    print('Directory {} exists'.format(outputPath))
    shutil.rmtree(outputPath)
    print('Removed directory {}'.format(outputPath))

shutil.copytree(targetPath, outputPath)
print('Copied directory {} to {}'.format(targetPath, outputPath))
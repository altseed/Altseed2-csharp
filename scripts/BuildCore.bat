echo set current directory
cd /d %~dp0

mkdir ..\Core\build

cd /d ..\Core\build

cmake -A x64 -D BUILD_TEST=OFF USE_MSVC_RUNTIME_LIBRARY_DLL=OFF ../

cmake --build . --config Debug

cmake --build . --config Release

pause
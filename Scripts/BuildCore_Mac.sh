#!/bin/sh

echo set current directory
cd `dirname $0`

mkdir ../Core/build

cd ../Core/build

cmake -D BUILD_TEST=OFF ../ -G "Xcode"

cmake --build . --config Debug

cmake --build . --config Release

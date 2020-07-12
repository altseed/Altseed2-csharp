#!/bin/sh

echo set current directory
cd `dirname $0`

cd ..
git pull
git submodule update --init

cd Core 

git submodule update --init

cd thirdparty/LLGI
git submodule update --init
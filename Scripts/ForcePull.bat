echo set current directory
cd /d %~dp0

cd ..
git fetch
git reset --hard origin/master
git submodule update

cd Core
git reset --hard ORIG_HEAD
pause
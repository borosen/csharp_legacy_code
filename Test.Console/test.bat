cd..

dotnet build

cd Test.Console

echo "start: " %time%

"bin/Debug/netcoreapp3.1/Test.Console.exe" tt0096754 jgorman
"bin/Debug/netcoreapp3.1/Test.Console.exe" tt0060666 jgorman
"bin/Debug/netcoreapp3.1/Test.Console.exe" tt0317303 jgorman

echo "end: " %time%
#! /bin/bash
PRONAME=""
if [ "${1}" == "" ]; then
	dotnet run Program.cs
elif [ "${1}" == "publish" ];then
	for n in *.csproj; do
		PRONAME=${n:0:-7}
		break;
	done
	dotnet publish ${PRONAME}.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
	if [ -d ./bin/Debug/netcoreapp3.1/publish ];then
		if [ ! -d publish ];then 
			mkdir publish 
			mkdir publish/${PRONAME} 
		fi
		cp -r ./bin/Debug/netcoreapp3.1/publish/* publish/${PRONAME}/.
		cd publish
		zip -r ${PRONAME}.zip ${PRONAME}
	fi
fi

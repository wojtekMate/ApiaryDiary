#!/bin/bash
cd src/Bootstrapper/ApiaryDiary.Bootstrapper
sed -i -e "s/passwordMail/$passwordMail/g" appsettings.json
sed -i -e "s/accountMail/$accountMail/g" appsettings.json
sed -i -e "s/connectionStringValue/$connectionStringValue/g" appsettings.json
cat appsettings.json
dotnet restore
dotnet build
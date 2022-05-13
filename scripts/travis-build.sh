#!/bin/bash
cd src/ApiaryDiary.Api
sed -i -e "s/passwordMail/$passwordMail/g" appsettings.json
sed -i -e "s/accountMail/$accountMail/g" appsettings.json
sed -i -e "s/connectionStringValue/$connectionStringValue/g" appsettings.json
dotnet restore
dotnet build
FROM mcr.microsoft.com/dotnet/aspnet:6.0.0
COPY bin/Docker App/
WORKDIR /App
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet ApiaryDiary.Bootstrapper.dll


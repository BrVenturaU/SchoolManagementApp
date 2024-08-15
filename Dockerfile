FROM mcr.microsoft.com/dotnet/sdk:8.0 AS img-build
WORKDIR /app
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore 
COPY . .
FROM img-build AS img-publish
COPY --from=img-build /app /app
RUN dotnet publish ./SchoolManagementApp.Web/SchoolManagementApp.Web.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS img-deploy
COPY --from=img-publish /publish /publish
WORKDIR /publish
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
ENTRYPOINT ["dotnet", "SchoolManagementApp.Web.dll"]
Remove-Item * -Include *.pfx
dotnet dev-certs https -v -ep localhost.pfx -p e8202f07-66e5-4619-be07-72ba76fde97f
cd..
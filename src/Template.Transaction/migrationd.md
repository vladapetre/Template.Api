
dotnet-ef migrations script Initial --project ./src/Template.Persistence --startup-project ./src/Template.Host --idempotent --output ./Context/Migrations/Script/script.sql

dotnet-ef migrations add Initial --project ./src/Template.Persistence --startup-project ./src/Template.Host --output-dir ./Context/Migrations
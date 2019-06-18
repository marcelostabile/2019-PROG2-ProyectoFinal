dotnet aspnet-codegenerator razorpage -m Administrador -dc ApplicationDbContext -udl -outDir Pages\Administradores --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Cliente -dc ApplicationDbContext -udl -outDir Pages\Clientes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Tecnico -dc ApplicationDbContext -udl -outDir Pages\Tecnicos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Solicitud -dc ApplicationDbContext -udl -outDir Pages\Solicitudes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Proyecto -dc ApplicationDbContext -udl -outDir Pages\Proyectos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Rol -dc ApplicationDbContext -udl -outDir Pages\Roles --referenceScriptLibraries

pause

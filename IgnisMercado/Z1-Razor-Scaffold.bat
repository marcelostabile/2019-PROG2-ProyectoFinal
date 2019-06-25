
dotnet aspnet-codegenerator razorpage -m ApplicationUser -dc ApplicationContext -udl -outDir Pages\Usuarios --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Administrador -dc ApplicationContext -udl -outDir Pages\Administradores --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Cliente -dc ApplicationContext -udl -outDir Pages\Clientes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Tecnico -dc ApplicationContext -udl -outDir Pages\Tecnicos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Solicitud -dc ApplicationContext -udl -outDir Pages\Solicitudes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Proyecto -dc ApplicationContext -udl -outDir Pages\Proyectos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Rol -dc ApplicationContext -udl -outDir Pages\Roles --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Costo -dc ApplicationContext -udl -outDir Pages\Costos --referenceScriptLibraries

pause

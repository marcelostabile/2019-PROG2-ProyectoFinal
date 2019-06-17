dotnet aspnet-codegenerator razorpage -m Administrador -dc IgnisContext -udl -outDir Pages\administradores --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Cliente -dc IgnisContext -udl -outDir Pages\clientes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Tecnico -dc IgnisContext -udl -outDir Pages\tecnicos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Solicitud -dc IgnisContext -udl -outDir Pages\solicitudes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m TecnicoSolicitud -dc IgnisContext -udl -outDir Pages\tecnicoSolicitudes --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Proyecto -dc IgnisContext -udl -outDir Pages\proyectos --referenceScriptLibraries

dotnet aspnet-codegenerator razorpage -m Rol -dc IgnisContext -udl -outDir Pages\roles --referenceScriptLibraries

pause

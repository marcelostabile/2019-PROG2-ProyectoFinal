
xxxdotnet aspnet-codegenerator razorpage -m ApplicationUser -dc ApplicationContext -udl -outDir Pages\Usuarios --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Administrador -dc ApplicationContext -udl -outDir Pages\Administradores --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Cliente -dc ApplicationContext -udl -outDir Pages\Clientes --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Tecnico -dc ApplicationContext -udl -outDir Pages\Tecnicos --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Solicitud -dc ApplicationContext -udl -outDir Pages\Solicitudes --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Proyecto -dc ApplicationContext -udl -outDir Pages\Proyectos --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Rol -dc ApplicationContext -udl -outDir Pages\Roles --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m Costo -dc ApplicationContext -udl -outDir Pages\Costos --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m RelacionClienteProyecto -dc ApplicationContext -udl -outDir Pages\RelacionClienteProyectos --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m RelacionProyectoSolicitud -dc ApplicationContext -udl -outDir Pages\RelacionProyectoSolicitudes --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m RelacionTecnicoRol -dc ApplicationContext -udl -outDir Pages\RelacionTecnicoRoles --referenceScriptLibraries

xxxdotnet aspnet-codegenerator razorpage -m RelacionTecnicoSolicitud -dc ApplicationContext -udl -outDir Pages\RelacionTecnicoSolicitudes --referenceScriptLibraries

pause

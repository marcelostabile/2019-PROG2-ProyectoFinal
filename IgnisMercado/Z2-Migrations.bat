dotnet ef migrations add InitialCreate --context ApplicationContext

dotnet ef migrations add Administrador --context ApplicationContext

dotnet ef migrations add Cliente --context ApplicationContext

dotnet ef migrations add Tecnico --context ApplicationContext

dotnet ef migrations add Solicitud --context ApplicationContext

dotnet ef migrations add Proyecto --context ApplicationContext

dotnet ef migrations add Rol --context ApplicationContext

dotnet ef migrations add Costo --context ApplicationContext

dotnet ef migrations add RelacionClienteProyecto --context ApplicationContext

dotnet ef migrations add RelacionProyectoSolicitud --context ApplicationContext

dotnet ef migrations add RelacionTecnicoRol --context ApplicationContext

dotnet ef migrations add RelacionTecnicoSolicitud --context ApplicationContext

pause

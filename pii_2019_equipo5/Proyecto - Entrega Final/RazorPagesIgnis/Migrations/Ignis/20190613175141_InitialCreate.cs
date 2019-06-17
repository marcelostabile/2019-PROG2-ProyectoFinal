using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesIgnis.Migrations.Ignis
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Presentacion = table.Column<string>(nullable: true),
                    Nivel_experiencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proyectos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModoDeContrato = table.Column<int>(nullable: false),
                    RolRequerido = table.Column<string>(nullable: true),
                    HorasContratadas = table.Column<int>(nullable: false),
                    NivelExperiencia = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    TecnicoAsignadoID = table.Column<int>(nullable: true),
                    CostoSolicitud = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ProyectoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyectos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Tecnicos_TecnicoAsignadoID",
                        column: x => x.TecnicoAsignadoID,
                        principalTable: "Tecnicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TecnicoSolicitud",
                columns: table => new
                {
                    tecnicoID = table.Column<int>(nullable: false),
                    solicitudID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicoSolicitud", x => new { x.tecnicoID, x.solicitudID });
                    table.UniqueConstraint("AK_TecnicoSolicitud_solicitudID_tecnicoID", x => new { x.solicitudID, x.tecnicoID });
                    table.ForeignKey(
                        name: "FK_TecnicoSolicitud_Solicitudes_solicitudID",
                        column: x => x.solicitudID,
                        principalTable: "Solicitudes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnicoSolicitud_Tecnicos_tecnicoID",
                        column: x => x.tecnicoID,
                        principalTable: "Tecnicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ClienteID",
                table: "Proyectos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_ProyectoID",
                table: "Solicitudes",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TecnicoAsignadoID",
                table: "Solicitudes",
                column: "TecnicoAsignadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TecnicoSolicitud");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesIgnis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
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
                    table.PrimaryKey("PK_Administrador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
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
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tecnico",
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
                    table.PrimaryKey("PK_Tecnico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
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
                    table.PrimaryKey("PK_Proyecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proyecto_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
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
                    table.PrimaryKey("PK_Solicitud", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Solicitud_Proyecto_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyecto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitud_Tecnico_TecnicoAsignadoID",
                        column: x => x.TecnicoAsignadoID,
                        principalTable: "Tecnico",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TecnicoSolicitud",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tecnicoID = table.Column<int>(nullable: false),
                    solicitudID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicoSolicitud", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TecnicoSolicitud_Solicitud_solicitudID",
                        column: x => x.solicitudID,
                        principalTable: "Solicitud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnicoSolicitud_Tecnico_tecnicoID",
                        column: x => x.tecnicoID,
                        principalTable: "Tecnico",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_ClienteID",
                table: "Proyecto",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_ProyectoID",
                table: "Solicitud",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_TecnicoAsignadoID",
                table: "Solicitud",
                column: "TecnicoAsignadoID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoSolicitud_solicitudID",
                table: "TecnicoSolicitud",
                column: "solicitudID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoSolicitud_tecnicoID",
                table: "TecnicoSolicitud",
                column: "tecnicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TecnicoSolicitud");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Tecnico");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

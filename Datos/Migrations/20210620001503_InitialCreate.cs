using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ambientales",
                columns: table => new
                {
                    CodigoManipulador = table.Column<string>(nullable: false),
                    NombreManipulador = table.Column<string>(nullable: true),
                    Barrio = table.Column<string>(nullable: true),
                    Item1 = table.Column<string>(nullable: true),
                    Item2 = table.Column<string>(nullable: true),
                    Item3 = table.Column<string>(nullable: true),
                    Item4 = table.Column<string>(nullable: true),
                    Item5 = table.Column<string>(nullable: true),
                    Item6 = table.Column<string>(nullable: true),
                    Item7 = table.Column<string>(nullable: true),
                    Item8 = table.Column<string>(nullable: true),
                    Item9 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ambientales", x => x.CodigoManipulador);
                });

            migrationBuilder.CreateTable(
                name: "listaChequeos",
                columns: table => new
                {
                    CodigoRestaurante = table.Column<string>(nullable: false),
                    NombreRestaurante = table.Column<string>(nullable: true),
                    Item1 = table.Column<string>(nullable: true),
                    Item2 = table.Column<string>(nullable: true),
                    Item3 = table.Column<string>(nullable: true),
                    Item4 = table.Column<string>(nullable: true),
                    Item5 = table.Column<string>(nullable: true),
                    Item6 = table.Column<string>(nullable: true),
                    Item7 = table.Column<string>(nullable: true),
                    Item8 = table.Column<string>(nullable: true),
                    Item9 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listaChequeos", x => x.CodigoRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    PaisDeProcedencia = table.Column<string>(nullable: true),
                    NivelEducativo = table.Column<string>(nullable: true),
                    Conocimiento1 = table.Column<string>(nullable: true),
                    Conocimiento2 = table.Column<string>(nullable: true),
                    Conocimiento3 = table.Column<string>(nullable: true),
                    Conocimiento4 = table.Column<string>(nullable: true),
                    Conocimiento5 = table.Column<string>(nullable: true),
                    ConocimientoExplicacion = table.Column<string>(nullable: true),
                    Actitud1 = table.Column<string>(nullable: true),
                    Actitud2 = table.Column<string>(nullable: true),
                    Actitud3 = table.Column<string>(nullable: true),
                    ActitudExplicacion = table.Column<string>(nullable: true),
                    Actitud5 = table.Column<string>(nullable: true),
                    Actitud6 = table.Column<string>(nullable: true),
                    Practica1 = table.Column<string>(nullable: true),
                    Practica2 = table.Column<string>(nullable: true),
                    Practica3 = table.Column<string>(nullable: true),
                    Practica4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "restaurantes",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurantes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "veterinarias",
                columns: table => new
                {
                    CodigoManipulador = table.Column<string>(nullable: false),
                    NombreManipulador = table.Column<string>(nullable: true),
                    Item1 = table.Column<string>(nullable: true),
                    Item2 = table.Column<string>(nullable: true),
                    Item3 = table.Column<string>(nullable: true),
                    Item4 = table.Column<string>(nullable: true),
                    Item5 = table.Column<string>(nullable: true),
                    Item6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarias", x => x.CodigoManipulador);
                });

            migrationBuilder.CreateTable(
                name: "vinculaciones",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    CodigoRestaurante = table.Column<string>(nullable: true),
                    NombreRestaurante = table.Column<string>(nullable: true),
                    CodigoPersona = table.Column<string>(nullable: true),
                    NombrePersona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vinculaciones", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ambientales");

            migrationBuilder.DropTable(
                name: "listaChequeos");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "restaurantes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "veterinarias");

            migrationBuilder.DropTable(
                name: "vinculaciones");
        }
    }
}

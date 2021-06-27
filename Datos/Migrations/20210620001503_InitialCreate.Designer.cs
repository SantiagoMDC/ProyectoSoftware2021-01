﻿// <auto-generated />
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(PersonasContext))]
    [Migration("20210620001503_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Ambiental", b =>
                {
                    b.Property<string>("CodigoManipulador")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barrio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreManipulador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoManipulador");

                    b.ToTable("ambientales");
                });

            modelBuilder.Entity("Entity.ListaChequeo", b =>
                {
                    b.Property<string>("CodigoRestaurante")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Item1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRestaurante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoRestaurante");

                    b.ToTable("listaChequeos");
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Actitud1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actitud2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actitud3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actitud5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Actitud6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActitudExplicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conocimiento1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conocimiento2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conocimiento3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conocimiento4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conocimiento5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConocimientoExplicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NivelEducativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisDeProcedencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practica1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practica2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practica3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practica4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("personas");
                });

            modelBuilder.Entity("Entity.Restaurante", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("restaurantes");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.Veterinaria", b =>
                {
                    b.Property<string>("CodigoManipulador")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Item1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Item6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreManipulador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoManipulador");

                    b.ToTable("veterinarias");
                });

            modelBuilder.Entity("Entity.Vinculacion", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoPersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoRestaurante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRestaurante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("vinculaciones");
                });
#pragma warning restore 612, 618
        }
    }
}

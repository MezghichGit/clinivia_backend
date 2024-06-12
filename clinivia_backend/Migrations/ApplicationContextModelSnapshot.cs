﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using clinivia_backend.Models;

#nullable disable

namespace clinivia_backend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("clinivia_backend.Models.Departement", b =>
                {
                    b.Property<int>("D_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("D_id"));

                    b.Property<DateTime>("D_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("D_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_head")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("D_no")
                        .HasColumnType("int");

                    b.Property<string>("D_status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("D_id");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("clinivia_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("clinivia_backend.Models.Docteur", b =>
                {
                    b.HasBaseType("clinivia_backend.Models.User");

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DepartementId");

                    b.HasDiscriminator().HasValue("Docteur");
                });

            modelBuilder.Entity("clinivia_backend.Models.Patient", b =>
                {
                    b.HasBaseType("clinivia_backend.Models.User");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodPressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Injury")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MartialStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sugger")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("clinivia_backend.Models.Docteur", b =>
                {
                    b.HasOne("clinivia_backend.Models.Departement", "Departement")
                        .WithMany("Docteurs")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("clinivia_backend.Models.Departement", b =>
                {
                    b.Navigation("Docteurs");
                });
#pragma warning restore 612, 618
        }
    }
}

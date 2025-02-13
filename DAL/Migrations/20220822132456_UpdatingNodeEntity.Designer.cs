﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20220822132456_UpdatingNodeEntity")]
    partial class UpdatingNodeEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DAL.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientName")
                        .HasColumnType("text");

                    b.Property<string>("ClientSector")
                        .HasColumnType("text");

                    b.Property<int>("ISPID")
                        .HasColumnType("integer");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DAL.Models.Cluster", b =>
                {
                    b.Property<int>("ClusterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClusterRemainingCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("ClusterRemainingRAM")
                        .HasColumnType("integer");

                    b.Property<int>("ClusterTotalCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("ClusterTotalRAM")
                        .HasColumnType("integer");

                    b.Property<string>("ClusterType")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfNodes")
                        .HasColumnType("integer");

                    b.HasKey("ClusterID");

                    b.ToTable("Clusters");
                });

            modelBuilder.Entity("DAL.Models.Lun", b =>
                {
                    b.Property<int>("LunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LunName")
                        .HasColumnType("text");

                    b.Property<int>("LunRemainingRAM")
                        .HasColumnType("integer");

                    b.Property<int>("LunTotalRAM")
                        .HasColumnType("integer");

                    b.Property<int>("StorageID")
                        .HasColumnType("integer");

                    b.HasKey("LunID");

                    b.HasIndex("StorageID");

                    b.ToTable("Luns");
                });

            modelBuilder.Entity("DAL.Models.Node", b =>
                {
                    b.Property<int>("NodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClusterID")
                        .HasColumnType("integer");

                    b.Property<int>("NodeRemainingCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("NodeRemainingRAM")
                        .HasColumnType("integer");

                    b.Property<int>("NodeTotalCPUCores")
                        .HasColumnType("integer");

                    b.Property<int>("NodeTotalRAM")
                        .HasColumnType("integer");

                    b.HasKey("NodeID");

                    b.HasIndex("ClusterID");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("DAL.Models.Storage", b =>
                {
                    b.Property<int>("StorageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("StorageName")
                        .HasColumnType("text");

                    b.Property<int>("StorageRemainingRAM")
                        .HasColumnType("integer");

                    b.Property<int>("StorageTotalRAM")
                        .HasColumnType("integer");

                    b.Property<string>("StorageType")
                        .HasColumnType("text");

                    b.HasKey("StorageID");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPowerUser")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "mario.abdelmalek7@gmail.com",
                            FirstName = "Mario",
                            HomeAddress = "20 El Nozha Street",
                            IsAdmin = true,
                            IsPowerUser = true,
                            LastName = "Abdelmalek",
                            PassportNumber = "0933478",
                            Password = "Abdelmalek_2000",
                            PhoneNumber = "01273615172",
                            UserName = "Mario_Abdelmalek"
                        });
                });

            modelBuilder.Entity("DAL.Models.Lun", b =>
                {
                    b.HasOne("DAL.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("DAL.Models.Node", b =>
                {
                    b.HasOne("DAL.Models.Cluster", "Cluster")
                        .WithMany()
                        .HasForeignKey("ClusterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cluster");
                });
#pragma warning restore 612, 618
        }
    }
}

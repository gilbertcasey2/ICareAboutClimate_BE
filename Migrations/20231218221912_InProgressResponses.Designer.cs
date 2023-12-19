﻿// <auto-generated />
using System;
using Epistimology_BE.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    [DbContext(typeof(ClimateContext))]
    [Migration("20231218221912_InProgressResponses")]
    partial class InProgressResponses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormQuestionResponse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("FormResponseid")
                        .HasColumnType("int");

                    b.Property<int?>("FormResponseid1")
                        .HasColumnType("int");

                    b.Property<int>("answerIndex")
                        .HasColumnType("int");

                    b.Property<bool?>("isFinalResponse")
                        .HasColumnType("bit");

                    b.Property<int>("questionIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("FormResponseid");

                    b.HasIndex("FormResponseid1");

                    b.ToTable("individualQuestionResponses");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormResponse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("formIndex")
                        .HasColumnType("int");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("storeageID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("formResponses");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormQuestionResponse", b =>
                {
                    b.HasOne("ICareAboutClimateBE.Models.FormResponse", null)
                        .WithMany("inProgressResponses")
                        .HasForeignKey("FormResponseid");

                    b.HasOne("ICareAboutClimateBE.Models.FormResponse", null)
                        .WithMany("responses")
                        .HasForeignKey("FormResponseid1");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormResponse", b =>
                {
                    b.Navigation("inProgressResponses");

                    b.Navigation("responses");
                });
#pragma warning restore 612, 618
        }
    }
}

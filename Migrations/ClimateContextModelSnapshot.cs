﻿// <auto-generated />
using System;
using ICareAboutClimate.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ICareAboutClimateBE.Migrations
{
    [DbContext(typeof(ClimateContext))]
    partial class ClimateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("answerIndex")
                        .HasColumnType("int");

                    b.Property<string>("answerIndexes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("formResponseid")
                        .HasColumnType("int");

                    b.Property<bool?>("isFinalResponse")
                        .HasColumnType("bit");

                    b.Property<bool>("isMultipleChoice")
                        .HasColumnType("bit");

                    b.Property<string>("otherAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("questionIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("formResponseid");

                    b.ToTable("individualQuestionResponses");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormResponse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("arrivalTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("formIndex")
                        .HasColumnType("int");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("storeageID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("formResponses");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.InProgressResponse", b =>
                {
                    b.Property<int>("progressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("progressId"));

                    b.Property<int?>("answerIndex")
                        .HasColumnType("int");

                    b.Property<string>("answerIndexes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("formResponseid")
                        .HasColumnType("int");

                    b.Property<bool?>("isFinalResponse")
                        .HasColumnType("bit");

                    b.Property<bool>("isMultipleChoice")
                        .HasColumnType("bit");

                    b.Property<string>("otherAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("questionIndex")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("progressId");

                    b.HasIndex("formResponseid");

                    b.ToTable("inProgressQuestionResponses");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.FormQuestionResponse", b =>
                {
                    b.HasOne("ICareAboutClimateBE.Models.FormResponse", "formResponse")
                        .WithMany("responses")
                        .HasForeignKey("formResponseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("formResponse");
                });

            modelBuilder.Entity("ICareAboutClimateBE.Models.InProgressResponse", b =>
                {
                    b.HasOne("ICareAboutClimateBE.Models.FormResponse", "formResponse")
                        .WithMany("inProgressResponses")
                        .HasForeignKey("formResponseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("formResponse");
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

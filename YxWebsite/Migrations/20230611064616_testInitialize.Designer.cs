﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YxWebsite.Context;

#nullable disable

namespace YxWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230611064616_testInitialize")]
    partial class testInitialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YxWebsite.Models.JapaneseDictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Meaning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PronunciationHiragana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PronunciationKatakana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Romaji")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbJapaneseDictionary");
                });

            modelBuilder.Entity("YxWebsite.Models.LanguageCottage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishTranslation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Romaji")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbLanguageCottage");
                });
#pragma warning restore 612, 618
        }
    }
}

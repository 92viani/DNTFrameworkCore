﻿// <auto-generated />
using System;
using DNTFrameworkCore.TestAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNTFrameworkCore.TestAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20190621194227_CreateBloggingSchema")]
    partial class CreateBloggingSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DNTFrameworkCore.Caching.Cache", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(449);

                    b.Property<DateTimeOffset?>("AbsoluteExpiration");

                    b.Property<DateTimeOffset>("ExpiresAtTime");

                    b.Property<long?>("SlidingExpirationInSeconds");

                    b.Property<byte[]>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ExpiresAtTime")
                        .HasName("IX_Cache_ExpiresAtTime");

                    b.ToTable("Cache","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Cryptography.ProtectionKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendlyName")
                        .IsRequired();

                    b.Property<string>("XmlValue");

                    b.HasKey("Id");

                    b.HasIndex("FriendlyName")
                        .IsUnique()
                        .HasName("IX_ProtectionKey_FriendlyName");

                    b.ToTable("ProtectionKey","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Logging.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LoggerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<DateTimeOffset>("Timestamp");

                    b.Property<string>("UserBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("UserDisplayName")
                        .HasMaxLength(50);

                    b.Property<string>("UserIP")
                        .HasMaxLength(256);

                    b.Property<long?>("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Level")
                        .HasName("IX_Log_Level");

                    b.HasIndex("LoggerName")
                        .HasName("IX_Log_LoggerName");

                    b.ToTable("Log","dbo");
                });

            modelBuilder.Entity("DNTFrameworkCore.Numbering.NumberedEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<long>("NextNumber");

                    b.HasKey("Id");

                    b.HasIndex("EntityName")
                        .IsUnique()
                        .HasName("UIX_NumberedEntity_EntityName");

                    b.ToTable("NumberedEntity");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Blogging.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasName("Blog_NormalizedTitle");

                    b.ToTable("Blog");
                });
#pragma warning restore 612, 618
        }
    }
}

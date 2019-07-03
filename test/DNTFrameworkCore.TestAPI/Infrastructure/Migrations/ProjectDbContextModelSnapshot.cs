﻿// <auto-generated />
using System;
using DNTFrameworkCore.TestAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNTFrameworkCore.TestAPI.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

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

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsGranted");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Discriminator")
                        .HasName("IX_Permission_Discriminator");

                    b.ToTable("Permission");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Permission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("UIX_Role_NormalizedName");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoggedInDateTime");

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("NormalizedDisplayName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedDisplayName")
                        .IsUnique()
                        .HasName("UIX_User_NormalizedDisplayName");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UIX_User_NormalizedUserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ClaimValue")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<long>("RoleId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("TokenExpirationDateTime");

                    b.Property<string>("TokenHash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TokenHash")
                        .HasName("IX_UserToken_AccessTokenHash");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDateTime");

                    b.Property<string>("CreatorBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("CreatorIp")
                        .HasMaxLength(256);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<DateTimeOffset?>("ModificationDateTime");

                    b.Property<string>("ModifierBrowserName")
                        .HasMaxLength(1024);

                    b.Property<string>("ModifierIp")
                        .HasMaxLength(256);

                    b.Property<long?>("ModifierUserId");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<byte>("State");

                    b.Property<long>("TenantId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedTitle")
                        .IsUnique()
                        .HasName("UIX_Task_NormalizedTitle");

                    b.HasIndex("TenantId")
                        .HasName("IX_Task_TenantId");

                    b.HasIndex("Number", "TenantId")
                        .IsUnique()
                        .HasName("UIX_Task_TenantId_Title_Number");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RolePermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestAPI.Domain.Identity.Permission");

                    b.Property<long>("RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permission");

                    b.HasDiscriminator().HasValue("RolePermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserPermission", b =>
                {
                    b.HasBaseType("DNTFrameworkCore.TestAPI.Domain.Identity.Permission");

                    b.Property<long>("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Permission");

                    b.HasDiscriminator().HasValue("UserPermission");
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RoleClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserClaim", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserToken", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.RolePermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DNTFrameworkCore.TestAPI.Domain.Identity.UserPermission", b =>
                {
                    b.HasOne("DNTFrameworkCore.TestAPI.Domain.Identity.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Linq;
using DNTFrameworkCore.Domain;
using DNTFrameworkCore.Numbering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DNTFrameworkCore.EFCore.Context
{
    // ReSharper disable once InconsistentNaming
    public static class EFCore
    {
        public const string CreatorBrowserName = nameof(CreatorBrowserName);
        public const string CreatorIp = nameof(CreatorIp);
        public const string CreationDateTime = nameof(CreationDateTime);
        public const string CreatorUserId = nameof(CreatorUserId);

        public const string ModifierBrowserName = nameof(ModifierBrowserName);
        public const string ModifierIp = nameof(ModifierIp);
        public const string ModificationDateTime = nameof(ModificationDateTime);
        public const string ModifierUserId = nameof(ModifierUserId);

        public const string UserId = nameof(UserId);
        public const string TenantId = nameof(TenantId);
        public const string IsDeleted = nameof(IsDeleted);
        public const string RowVersion = nameof(RowVersion);

        public static void AddTracking(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(ICreationTracking).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTimeOffset>(CreationDateTime)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                builder.Entity(entityType.ClrType)
                    .Property<string>(CreatorBrowserName).HasMaxLength(1024)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                builder.Entity(entityType.ClrType)
                    .Property<string>(CreatorIp).HasMaxLength(256)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                builder.Entity(entityType.ClrType)
                    .Property<long?>(CreatorUserId)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            }

            foreach (var entityType in types.Where(e => typeof(IModificationTracking).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTimeOffset?>(ModificationDateTime);

                builder.Entity(entityType.ClrType)
                    .Property<string>(ModifierBrowserName).HasMaxLength(1024);

                builder.Entity(entityType.ClrType)
                    .Property<string>(ModifierIp).HasMaxLength(256);

                builder.Entity(entityType.ClrType)
                    .Property<long?>(ModifierUserId);
            }
        }

        public static void AddTenantEntity(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(ITenantEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<long>(TenantId).Metadata
                    .AfterSaveBehavior = PropertySaveBehavior.Ignore;

                builder.Entity(entityType.ClrType)
                    .HasIndex(TenantId)
                    .HasName($"IX_{entityType.ClrType.Name}_{TenantId}");
            }
        }

        public static void AddSoftDeleteEntity(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(ISoftDeleteEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<bool>(IsDeleted);
            }
        }

        public static void AddRowLevelSecurity(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(IHasRowLevelSecurity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<long>(UserId)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            }
        }

        public static void AddRowVersion(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(IHasRowVersion).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property(RowVersion)
                    .IsRowVersion();
            }
        }

        public static void AddNumberedEntity(this ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().ToList();

            foreach (var entityType in types.Where(e => typeof(INumberedEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property(nameof(INumberedEntity.Number)).IsRequired().HasMaxLength(50).Metadata
                    .AfterSaveBehavior = PropertySaveBehavior.Ignore;

                var maybe = entityType.ClrType.FindNumberingOption();
                if (!maybe.HasValue)
                    throw new InvalidOperationException(
                        "INumberedEntity should be decorated with NumberedEntityOptionAttribute");

                var option = maybe.Value;

                var indexName = $"UIX_{entityType.ClrType.Name}_";
                var parameters = new[] {nameof(INumberedEntity.Number)};

                if (typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
                {
                    indexName += $"{TenantId}_";
                    parameters = new[] {nameof(INumberedEntity.Number), TenantId};
                }

                if (!string.IsNullOrEmpty(option.ResetFieldName))
                {
                    indexName += $"{option.ResetFieldName}_{nameof(INumberedEntity.Number)}";
                }
                else
                {
                    indexName += nameof(INumberedEntity.Number);
                }

                builder.Entity(entityType.ClrType)
                    .HasIndex(parameters)
                    .HasName(indexName)
                    .IsUnique();
            }
        }
    }
}
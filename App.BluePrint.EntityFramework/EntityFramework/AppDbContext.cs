using Abp.EntityFramework;
using Abp.UserManagement.EntityFramework;
using App.BluePrint.Administration;
using App.BluePrint.Authorization;
using App.BluePrint.Config;
using App.BluePrint.Metadata;
using App.BluePrint.MultiTenency;
using App.BluePrint.Users;
using System.Data.Entity;

namespace App.BluePrint.EntityFramework
{
    public class AppDbContext : AbpUserManagementDBContext<TenantManagement, RoleManagement, UserManagement>
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<AdminMenu> AdministrationMenus { get; set; }
        public virtual IDbSet<AdminMenuRoleMapper> AdminMenuRoles { get; set; }
        public virtual IDbSet<Lookup> LookupData { get; set; }

        #region -- Metadata Definitions --

        public virtual IDbSet<VersionGenerator> Versioning { get; set; }
        public virtual IDbSet<ExProperties> ExProperties { get; set; }
        public virtual IDbSet<MetadataDefinition> MetadataDefinition { get; set; }
        public virtual IDbSet<MetadataVersion> MetadataVersion { get; set; }

        #endregion

        public AppDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in App.BluePrintDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of App.BluePrintDbContext since ABP automatically handles it.
         */
        public AppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MetadataGroup>()
            //    .HasMany<MetadataSection>().WithRequired(s => s.GroupId).WillCascadeOnDelete(false)

            modelBuilder.Entity<UserManagement>()
                .HasMany<ManagerDefinition>(u => u.Managers)
                .WithOptional(m => m.UserInfo).HasForeignKey(m => m.UserId).WillCascadeOnDelete(true);

            modelBuilder.Entity<ManagerDefinition>()
                .HasRequired(m => m.ManagerInfo)
                .WithMany().HasForeignKey(m => m.ManagerId).WillCascadeOnDelete(false);

            #region -- Metadata Definitions --

            modelBuilder.Entity<MetadataDefinition>()
                .HasMany<MetadataVersion>(m => m.Versions)
                .WithRequired(v => v.Definition).HasForeignKey(v => v.MetadataId).WillCascadeOnDelete(true);

            modelBuilder.Entity<VersionGenerator>()
                .HasRequired<MetadataVersion>(m => m.MetadataVersionInfo)
                .WithRequiredPrincipal(v => v.Version).WillCascadeOnDelete(false);

            modelBuilder.Entity<MetadataVersion>()
                .HasMany<ExtendedProperties>(m => m.ExtendedProperties)
                .WithOptional(x => x.MetadataVersionInfo).HasForeignKey(m => m.MetadataVersionId).WillCascadeOnDelete(false);

            modelBuilder.Entity<ExProperties>()
                .HasOptional<ExtendedProperties>(x => x.PropertyInfo)
                .WithOptionalPrincipal(e => e.Properties).WillCascadeOnDelete(false);

            modelBuilder.Entity<MetadataVersion>()
                .HasMany<MetadataGroup>(m => m.MetadataGroups)
                .WithRequired(g => g.MetadataVersionInfo).HasForeignKey(m => m.MetadataVersionId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MetadataGroup>()
                .HasMany<ExtendedProperties>(m => m.ExtendedProperties)
                .WithOptional(x => x.MetadataGroupInfo).HasForeignKey(m => m.MetadataGroupId).WillCascadeOnDelete(false);

            modelBuilder.Entity<MetadataGroup>()
                .HasMany<MetadataSection>(g => g.Sections)
                .WithRequired(s => s.MetadataGroupInfo).HasForeignKey(s => s.MetadataGroupId).WillCascadeOnDelete(true);

            modelBuilder.Entity<MetadataSection>()
               .HasMany<ExtendedProperties>(m => m.ExtendedProperties)
               .WithOptional(x => x.MetadataSectionInfo).HasForeignKey(m => m.MetadataSectionId).WillCascadeOnDelete(false);

            #endregion
        }
    }
}

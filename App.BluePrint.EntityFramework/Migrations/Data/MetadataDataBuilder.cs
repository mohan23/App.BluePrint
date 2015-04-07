using App.BluePrint.Config;
using App.BluePrint.EntityFramework;
using App.BluePrint.Metadata;
using App.BluePrint.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Migrations.Data
{
    public class MetadataDataBuilder
    {
        private string FormName = "LEAVE";
        private UserManagement currentUser = null;

        public void Build(AppDbContext context, string frmName = "LEAVE" )
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            FormName = frmName;
            var defaultTenant = context.Tenants.FirstOrDefault(t => t.TenancyName == "BASE");
            currentUser = context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");

            CreateExProperties(context);
            //if (context.MetadataDefinition.Any())
            //    context.MetadataDefinition.ToList().ForEach(m => context.MetadataDefinition.Remove(m));
            CreateNewMetaData(context);
            //UpdateMetadataVersion(context);
            UpdateMetadataGroup(context);
            UpdateMetadataGroupSection(context);
        }

        private void UpdateMetadataVersion(AppDbContext context)
        {
            var mdefn = context.MetadataDefinition.First(m => m.InternalName.ToLower() == FormName.ToLower());
            if (mdefn.Versions != null && mdefn.Versions.Any())
            {
                var mVersion = mdefn.Versions.Last();
                mVersion.BehaviourAssembly = "TestBhClass-Updated-est.dll";
                mVersion.BehaviourClass = "TestBhClass.SampleTest2";
                context.SaveChanges();
            }
        }

        private void CreateExProperties(AppDbContext context)
        {
            if (!context.ExProperties.Any())
            {
                context.ExProperties.Add(new Config.ExProperties() { CreatorUserId = currentUser.Id, Name = "FormType", PropertyType = Common.ExPropType.Form, DataType = "System.string", Default = "Application" });
                context.ExProperties.Add(new Config.ExProperties() { CreatorUserId = currentUser.Id, Name = "CompatiableWith", PropertyType = Common.ExPropType.Form, DataType = "System.string", Default = "A" });

                context.ExProperties.Add(new Config.ExProperties() { CreatorUserId = currentUser.Id, Name = "GroupMode", PropertyType = Common.ExPropType.Group, DataType = "System.string", Default = "HT" });

                context.ExProperties.Add(new Config.ExProperties() { CreatorUserId = currentUser.Id, Name = "SectionRows", PropertyType = Common.ExPropType.Section, DataType = "System.Int32", Default = "2" });
                context.ExProperties.Add(new Config.ExProperties() { CreatorUserId = currentUser.Id, Name = "SectionBorders", PropertyType = Common.ExPropType.Section, DataType = "System.bool", Default = "1" });
                context.SaveChanges();
            }
        }

        private List<ExProperties> GetExProps(AppDbContext context, Common.ExPropType propType)
        {
            var exProps = context.ExProperties.Where(e => e.PropertyType == propType);
            if (exProps.Any())
                return exProps.ToList();
            else
                return null;
        }

        private Metadata.MetadataDefinition CreateNewMetaData(AppDbContext context)
        {
            var mDefn = context.MetadataDefinition.FirstOrDefault(m => m.InternalName.ToLower() == FormName.ToLower());
            if (mDefn == null)
            {
                mDefn = context.MetadataDefinition.Add(new Metadata.MetadataDefinition()
                {
                    InternalName = FormName,
                    Name = "Leave Application Form",
                    Description = "Use this form for Apply for Leave",
                    CreatorUserId = currentUser.Id,
                    EffectiveDate = DateTime.Now
                });
                if (mDefn.Versions == null)
                    mDefn.Versions = new List<MetadataVersion>();

                mDefn.Versions.Add(new MetadataVersion()
                {
                    Version = new VersionGenerator() { Major = 0, Minor = 0, Revision = 0, Build = 1, CreatorUserId = currentUser.Id },
                    CreatorUserId = currentUser.Id,
                    BehaviourAssembly = string.Empty,
                    BehaviourClass = string.Empty,
                    VersionDescription = "New Beta Version for this release."
                });

                var mVersion = mDefn.Versions.FirstOrDefault();
                var formExProps = GetExProps(context, Common.ExPropType.Form);
                if (formExProps != null && formExProps.Any())
                {
                    if (mVersion.ExtendedProperties == null)
                        mVersion.ExtendedProperties = new List<ExtendedProperties>();

                    formExProps.ForEach(ex =>
                    {
                        mVersion.ExtendedProperties.Add(new ExtendedProperties() { Properties = ex, MetadataVersionInfo = mVersion });
                    });
                }
                context.SaveChanges();
            }

            return mDefn;
        }

        private void UpdateMetadataGroup(AppDbContext context)
        {
            var mDefn = context.MetadataDefinition.First(m => m.InternalName.ToLower() == FormName.ToLower());
            if (mDefn != null)
            {
                 var currentVersion = mDefn.Versions.Last();
                 if (currentVersion != null)
                 {
                     if (currentVersion.MetadataGroups.FirstOrDefault(m => m.InternalName == "BASE") == null)
                     {
                         currentVersion.MetadataGroups.Add(new MetadataGroup()
                         {
                             InternalName = "BASE",
                             Name = "Leave Application Form",
                             Sequence = 1,
                             CreatorUserId = currentUser.Id
                         });

                         var mdataGroup = currentVersion.MetadataGroups.Last();

                         var formExProps = GetExProps(context, Common.ExPropType.Group);
                         if (formExProps != null && formExProps.Any())
                         {
                             if (mdataGroup.ExtendedProperties == null)
                                 mdataGroup.ExtendedProperties = new List<ExtendedProperties>();

                             formExProps.ForEach(ex =>
                             {
                                 mdataGroup.ExtendedProperties.Add(new ExtendedProperties() { Properties = ex, MetadataVersionInfo = currentVersion, MetadataGroupInfo = mdataGroup });
                             });
                         }
                     }
                 }
            }
        }

        private void UpdateMetadataGroupSection(AppDbContext context)
        {
            var mDefn = context.MetadataDefinition.First(m => m.InternalName.ToLower() == FormName.ToLower());
            if (mDefn != null)
            {
                var currentVersion = mDefn.Versions.Last();
                if (currentVersion != null)
                {
                    if (currentVersion.MetadataGroups.Any())
                    {
                        var mdataGroup = currentVersion.MetadataGroups.FirstOrDefault(m => m.InternalName == "BASE");
                        if (mdataGroup != null)
                        {
                            if (mdataGroup.Sections.FirstOrDefault(s => s.InternalName == "EMPINFO") == null)
                            {
                                mdataGroup.Sections.Add(new MetadataSection()
                                {
                                    InternalName = "EMPINFO",
                                    Name = "Employee Information",
                                    Sequence = 1,
                                    MetadataGroupInfo = mdataGroup,
                                    CreatorUserId = currentUser.Id
                                });

                                var empInfoSection = mdataGroup.Sections.Last();
                                var formExProps = GetExProps(context, Common.ExPropType.Section);
                                if (formExProps != null && formExProps.Any())
                                {
                                    if (empInfoSection.ExtendedProperties == null)
                                        empInfoSection.ExtendedProperties = new List<ExtendedProperties>();

                                    formExProps.ForEach(ex =>
                                    {
                                        empInfoSection.ExtendedProperties.Add(new ExtendedProperties() { Properties = ex, MetadataVersionInfo = currentVersion, MetadataSectionInfo = empInfoSection });
                                    });
                                }
                                context.SaveChanges();
                            }

                            if (mdataGroup.Sections.FirstOrDefault(s => s.InternalName == "LEAVEDETAILS") == null)
                            {
                                mdataGroup.Sections.Add(new MetadataSection()
                                {
                                    InternalName = "LEAVEDETAILS",
                                    Name = "Leave Details",
                                    Sequence = 2,
                                    MetadataGroupInfo = mdataGroup,
                                    CreatorUserId = currentUser.Id
                                });

                                var leaveDetSection = mdataGroup.Sections.Last();
                                var formExProps = GetExProps(context, Common.ExPropType.Section);
                                if (formExProps != null && formExProps.Any())
                                {
                                    if (leaveDetSection.ExtendedProperties == null)
                                        leaveDetSection.ExtendedProperties = new List<ExtendedProperties>();

                                    formExProps.ForEach(ex =>
                                    {
                                        leaveDetSection.ExtendedProperties.Add(new ExtendedProperties() { Properties = ex, MetadataVersionInfo = currentVersion, MetadataSectionInfo = leaveDetSection });
                                    });
                                }
                                context.SaveChanges();
                            }

                            if (mdataGroup.Sections.FirstOrDefault(s => s.InternalName == "AUDIT") == null)
                            {
                                mdataGroup.Sections.Add(new MetadataSection()
                                {
                                    InternalName = "AUDIT",
                                    Name = "Auditing",
                                    Sequence = 3,
                                    MetadataGroupInfo = mdataGroup,
                                    CreatorUserId = currentUser.Id
                                });

                                var auditSection = mdataGroup.Sections.Last();
                                var formExProps = GetExProps(context, Common.ExPropType.Section);
                                if (formExProps != null && formExProps.Any())
                                {
                                    if (auditSection.ExtendedProperties == null)
                                        auditSection.ExtendedProperties = new List<ExtendedProperties>();

                                    formExProps.ForEach(ex =>
                                    {
                                        auditSection.ExtendedProperties.Add(new ExtendedProperties() { Properties = ex, MetadataVersionInfo = currentVersion, MetadataSectionInfo = auditSection });
                                    });
                                }

                                context.SaveChanges();
                            }

                        }
                    }
                }
            }
        }
    }
}

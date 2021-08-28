using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class CompanyMap : EntityTypeConfiguration<Company> 
    {
        public CompanyMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(100);
             Property(o => o.About);
             Property(o => o.Website).HasMaxLength(100);
             Property(o => o.Phone).HasMaxLength(13);
             Property(o => o.Fax).HasMaxLength(15);
             ToTable("Company");
 

        }
    }
}

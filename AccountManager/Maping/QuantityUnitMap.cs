using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class QuantityUnitMap : EntityTypeConfiguration<QuantityUnit>
    {
        public QuantityUnitMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Title).HasMaxLength(100);
            ToTable("QuantityUnit");


        }
    }
}

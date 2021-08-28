using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class ProductMap : EntityTypeConfiguration<Product> 
    {
        public ProductMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(50);
             HasRequired(c => c.CompanyOffice_OfficeId).WithMany(o => o.Product_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             Property(o => o.ProductImage).HasMaxLength(200);
             Property(o => o.BareCode).HasMaxLength(50);
             Property(o => o.Description);
             ToTable("Product");
 

        }
    }
}

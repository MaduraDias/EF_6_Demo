using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    [DbConfigurationType(typeof(Configuration))]
    public class CardAccountDBContext:DbContext
    {
        public CardAccountDBContext():base("CardAccount")
        {
                 
        }

        public DbSet<Account> Account { get; set; }
        
        public DbSet<Cardholder> Cardholder { get; set; }

        public DbSet<Card> Card { get; set; }

        public DbSet<CardDesign> CardDesign { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Account>().MapToStoredProcedures()
                                           .HasKey(x => x.AccountId)
                                           .HasMany(x => x.Cards).WithOptional()
                                           .HasForeignKey(x => x.CardAccountId);
                                          
            
            modelBuilder.Entity<Cardholder>().MapToStoredProcedures()
                                            .HasKey(x=>x.CardholderId);


            modelBuilder.Entity<Card>().MapToStoredProcedures()
                                        .HasKey(x => x.CardId);
                                        

            modelBuilder.Entity<Card>().Property(x => x.CardNumber)
                .IsRequired();


            modelBuilder.Entity<Card>().HasRequired(x => x.Cardholder).WithOptional().Map(x => x.MapKey("CardholderId"));

            modelBuilder.Entity<Card>().HasRequired(X => X.CardDesign).WithOptional().Map(x=>x.MapKey("CardDesignId"));
                                        
                                        

            modelBuilder.Entity<CardDesign>().MapToStoredProcedures()
                                             .HasKey(x=>x.CardDesignId);
        }
    }
}

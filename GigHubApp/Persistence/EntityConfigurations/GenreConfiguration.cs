using System.Data.Entity.ModelConfiguration;
using GigHubApp.Core.Models;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
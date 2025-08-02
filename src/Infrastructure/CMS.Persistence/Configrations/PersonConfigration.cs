using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CMS.Domain.Entities;

namespace CMS.Persistence.Configrations
{
    public class PersonConfigration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

        }
    }
}


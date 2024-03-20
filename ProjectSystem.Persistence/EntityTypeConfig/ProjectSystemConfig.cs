using Microsoft.EntityFrameworkCore;
using ProjectSystem.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ProjectSystem.Persistence.EntityTypeConfig
{
    public class ProjectSystemConfig : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// класс конфигурации модели 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void Configure(EntityTypeBuilder<Customer> modelBuilder)
        {
            // ...
        }
    }
}

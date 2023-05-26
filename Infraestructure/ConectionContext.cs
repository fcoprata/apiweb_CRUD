using api_web.Domain.Model.EmployeeAggregate;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api_web.infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost,1433",
                InitialCatalog = "mybanco",
                UserID = "sa",
                Password = "Sql1234!",
                TrustServerCertificate = true // Ignorar a validação do certificado
            };
            optionsBuilder.UseSqlServer(connectionStringBuilder.ToString());
        }
    }
}

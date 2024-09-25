using Microsoft.EntityFrameworkCore;

namespace APITestes.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } // Adiciona a entidade User

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }

    //comandos para subir as tabelas criadas aqui para o SQL server:
    //dotnet ef migrations add RenameUserIdColumn
    //dotnet ef database update

    //lembre de configurar o appsettings.json para a conexão de banco correta
}

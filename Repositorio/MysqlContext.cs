using Dto;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MysqlContext : DbContext
    {
        public MysqlContext() : base("Database=puc_dot_net; Data Source = localhost; UserId=root;Password=")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MysqlContext>());  //cria o banco se não existir
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();   //remove a pluralização         
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

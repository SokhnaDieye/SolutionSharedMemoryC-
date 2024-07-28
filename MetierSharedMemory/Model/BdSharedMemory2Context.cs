using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace MetierSharedMemory.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSharedMemory2Context:DbContext
    {
        public BdSharedMemory2Context() : base("connSharedmemory") { }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<jury> Jury { get; set; }
        public DbSet<Memoire> Memoire { get; set; }
        public DbSet<JuryMemoire> JuryMemoire { get; set; }
        public DbSet<Td_Erreur> Td_Erreur { get; set; }

    }
}
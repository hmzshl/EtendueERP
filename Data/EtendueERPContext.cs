using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using EtendueERP.Models.EtendueERP;

namespace EtendueERP.Data
{
    public partial class EtendueERPContext : DbContext
    {
        public EtendueERPContext()
        {
        }

        public EtendueERPContext(DbContextOptions<EtendueERPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<EtendueERP.Models.EtendueERP.TTaux> TTauxes { get; set; }
    }
}
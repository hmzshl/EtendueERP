using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtendueERP.Models.EtendueERP
{
    [Table("T_Taux", Schema = "dbo")]
    public partial class TTaux
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

    }
}
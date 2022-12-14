// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EtendueERP.Models.EtendueDB
{
    public partial class T_Societe
    {
        public int id { get; set; }
        public string Intitule { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public decimal Superficie { get; set; }
        public string IdF { get; set; }
        public string ICE { get; set; }
        public string RC { get; set; }
        public string CNSS { get; set; }
        public string IdTVA { get; set; }
        public string Patente { get; set; }
        public decimal Capital { get; set; }
        public int FormeJuridique { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Abrege { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateCreation { get; set; }
        public bool? GestionCommercial { get; set; }
        public bool? Comptabilite { get; set; }
        public bool? Tracabilite { get; set; }
        public string Serveur { get; set; }
        public string Base { get; set; }
        public string Passe { get; set; }
    }
}
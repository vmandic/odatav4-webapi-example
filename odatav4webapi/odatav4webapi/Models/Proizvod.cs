namespace odatav4webapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvod")]
    public partial class Proizvod
    {
        public Proizvod()
        {
            Stavkas = new HashSet<Stavka>();
        }

        [Key]
        public int IDProizvod { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(25)]
        public string BrojProizvoda { get; set; }

        [StringLength(15)]
        public string Boja { get; set; }

        public short MinimalnaKolicinaNaSkladistu { get; set; }

        [Column(TypeName = "money")]
        public decimal CijenaBezPDV { get; set; }

        public int? PotkategorijaID { get; set; }

        [JsonIgnore]
        public virtual Potkategorija Potkategorija { get; set; }

        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}

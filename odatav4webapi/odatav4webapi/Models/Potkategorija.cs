namespace odatav4webapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Potkategorija")]
    public partial class Potkategorija
    {
        public Potkategorija()
        {
            Proizvods = new HashSet<Proizvod>();
        }

        [Key]
        public int IDPotkategorija { get; set; }

        public int KategorijaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [JsonIgnore]
        public virtual Kategorija Kategorija { get; set; }

        public virtual ICollection<Proizvod> Proizvods { get; set; }
    }
}

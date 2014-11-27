namespace odatav4webapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategorija")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Potkategorijas = new HashSet<Potkategorija>();
        }

        [Key]
        public int IDKategorija { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        public virtual ICollection<Potkategorija> Potkategorijas { get; set; }
    }
}

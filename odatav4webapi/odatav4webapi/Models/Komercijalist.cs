namespace odatav4webapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Komercijalist")]
    public partial class Komercijalist
    {
        public Komercijalist()
        {
            Racuns = new HashSet<Racun>();
        }

        [Key]
        public int IDKomercijalist { get; set; }

        [StringLength(50)]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Prezime { get; set; }

        public bool? StalniZaposlenik { get; set; }

        public virtual ICollection<Racun> Racuns { get; set; }
    }
}

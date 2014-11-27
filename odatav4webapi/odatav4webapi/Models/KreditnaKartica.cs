namespace odatav4webapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KreditnaKartica")]
    public partial class KreditnaKartica
    {
        public KreditnaKartica()
        {
            Racuns = new HashSet<Racun>();
        }

        [Key]
        public int IDKreditnaKartica { get; set; }

        [Required]
        [StringLength(50)]
        public string Tip { get; set; }

        [Required]
        [StringLength(25)]
        public string Broj { get; set; }

        public byte IstekMjesec { get; set; }

        public short IstekGodina { get; set; }

        public virtual ICollection<Racun> Racuns { get; set; }
    }
}

namespace odatav4webapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Racun")]
    public partial class Racun
    {
        public Racun()
        {
            Stavkas = new HashSet<Stavka>();
        }

        [Key]
        public int IDRacun { get; set; }

        public DateTime DatumIzdavanja { get; set; }

        [Required]
        [StringLength(25)]
        public string BrojRacuna { get; set; }

        public int KupacID { get; set; }

        public int? KomercijalistID { get; set; }

        public int? KreditnaKarticaID { get; set; }

        [StringLength(128)]
        public string Komentar { get; set; }

        [JsonIgnore]
        public virtual Komercijalist Komercijalist { get; set; }
        [JsonIgnore]
        public virtual KreditnaKartica KreditnaKartica { get; set; }
        [JsonIgnore]
        public virtual Kupac Kupac { get; set; }

        public virtual ICollection<Stavka> Stavkas { get; set; }
    }
}

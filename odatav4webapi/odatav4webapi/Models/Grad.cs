namespace odatav4webapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grad")]
    public partial class Grad
    {
        public Grad()
        {
            Kupacs = new HashSet<Kupac>();
        }

        [Key]
        public int IDGrad { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        public int? DrzavaID { get; set; }

        [JsonIgnore]
        public virtual Drzava Drzava { get; set; }

        public virtual ICollection<Kupac> Kupacs { get; set; }
    }
}

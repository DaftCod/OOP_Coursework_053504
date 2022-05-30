namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Constellation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortName { get; set; }

        public int Square { get; set; }

        public int BrightStarsNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string DiscoveredBy { get; set; }
    }
}

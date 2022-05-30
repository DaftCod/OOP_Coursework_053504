namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int PopulationSize { get; set; }

        public double Square { get; set; }

        [StringLength(150)]
        public string Religions { get; set; }

        public int ScreenPositionX { get; set; }

        public int ScreenPositionY { get; set; }
    }
}

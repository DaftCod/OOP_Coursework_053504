namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string FamilyName { get; set; }

        public double PopulationSize { get; set; }

        public bool IsInRedBook { get; set; }

        public int ScreenPositionX { get; set; }

        public int ScreenPositionY { get; set; }
    }
}

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Star
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameIAU { get; set; }

        [Required]
        [StringLength(10)]
        public string FlemstedBayerCode { get; set; }

        [StringLength(10)]
        public string VisibleSize { get; set; }

        [StringLength(10)]
        public string HR { get; set; }

        [StringLength(10)]
        public string HIP { get; set; }

        [StringLength(10)]
        public string HD { get; set; }

        public int? ScreenPositionX { get; set; }

        public int? ScreenPositionY { get; set; }

        public int? ConnectToStar { get; set; }
    }
}

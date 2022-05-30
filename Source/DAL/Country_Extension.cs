namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country : MapItem
    {

        public override string GetItemInfo()
        {
            string DataText = null;

            DataText = "Name: " + Name + "\n";
            DataText += "PopulationSize: " + Convert.ToString(PopulationSize) + "\n";
            DataText += "Square: " + Convert.ToString(Square) + "\n";
            DataText += "Religions: " + Religions;

            return DataText;
        }
    }
}

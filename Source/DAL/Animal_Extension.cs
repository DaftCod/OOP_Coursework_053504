namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animal : MapItem
    {

        public override string GetItemInfo()
        {
            string DataText = null;

            DataText = "Name: " + Name + "\n";
            DataText += "FamilyName: " + FamilyName + "\n";
            DataText += "PopulationSize: " + Convert.ToString(PopulationSize) + "\n";
            DataText += "IsInRedBook: " + Convert.ToString(IsInRedBook);

            return DataText;
        }
    }
}

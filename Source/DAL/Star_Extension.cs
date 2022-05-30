namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Star: MapItem
    {

        public override string GetItemInfo()
        {
            string DataText = null;

            DataText = "Name: " + NameIAU + "\n";
            DataText += "FlemstedBayerCode: " + FlemstedBayerCode + "\n";
            DataText += "VisibleSize: " + VisibleSize + "\n";
            DataText += "HR: " + HR + "\n";
            DataText += "HIP: " + HIP + "\n";
            DataText += "HD: " + HD;

            return DataText;
        }
    }
}

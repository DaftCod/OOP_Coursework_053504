using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public partial class GeographicalObject : MapItem
    {
        public override string GetItemInfo()
        {
            string DataText = null;

            DataText = "Name: " + Name + "\n";
            DataText += "Type: " + Type;
            DataText += "Location: " + Location;

            return DataText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IMapItem
    {
        int RadiusfDetection { get; }

        int? ScreenPositionX { get; set; }

        int? ScreenPositionY { get; set; }

        bool IsCursorNearby();

        string GetItemInfo();
    }
}

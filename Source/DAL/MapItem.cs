using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MapItem
    {
        int RadiusofDetection { get; }

        public int? ScreenPositionX { get; set; }

        public int? ScreenPositionY { get; set; }

        public MapItem()
        {
            RadiusofDetection = 6;
            ScreenPositionX = 0;
            ScreenPositionY = 0;
        }

        public MapItem(int x, int y, int radius)
        {
            RadiusofDetection = x;
            ScreenPositionX = y;
            ScreenPositionY = radius;
        }

        public bool IsCursorNearby(int cursorX, int cursorY)
        {
            if ((cursorX <= ScreenPositionX + RadiusofDetection && cursorX >= ScreenPositionX - RadiusofDetection) &&
                (cursorY <= ScreenPositionY + RadiusofDetection && cursorY >= ScreenPositionY - RadiusofDetection))
                return true;

            return false;

        }

        public virtual string GetItemInfo()
        {
            return String.Empty; 
        }
    }
}

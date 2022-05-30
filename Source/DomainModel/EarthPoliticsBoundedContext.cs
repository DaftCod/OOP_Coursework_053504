using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Drawing;
using System.Data.Entity;

namespace DomainModel
{
    class EarthPoliticsBoundedContext : EarthBoundedContext
    {
        public virtual List<Country> Countries { get; set; }

        public EarthPoliticsBoundedContext()
        {
            Countries = new List<Country>();
        }

        public override void Initialize(DbContext database)
        {
            base.Initialize(database);

            Countries.Clear();

            foreach (Country c in ((Model1)Database).Countries)
            {
                ((MapItem)c).ScreenPositionX = c.ScreenPositionX;
                ((MapItem)c).ScreenPositionY = c.ScreenPositionY;
                Countries.Add(c);
            }
        }

        public override void Draw(Graphics graphics)
        {
            // Draw map by parent class
            base.Draw(graphics);

            foreach (Country c in Countries)
            {
                //Draw star
                graphics.DrawEllipse(Pens.DarkBlue, new System.Drawing.Rectangle((int)(c.ScreenPositionX), (int)(c.ScreenPositionY), PointSize, PointSize));
                SolidBrush redBrush = new SolidBrush(PointColor);
                graphics.FillEllipse(redBrush, (int)(c.ScreenPositionX), (int)(c.ScreenPositionY), PointSize, PointSize);
            }
        }

        public override object DetectItemNearCursor(int x, int y)
        {
            foreach (Country c in Countries)
            {
                if (c.IsCursorNearby(x, y))
                    return c;
            }

            return null;
        }


    }
}

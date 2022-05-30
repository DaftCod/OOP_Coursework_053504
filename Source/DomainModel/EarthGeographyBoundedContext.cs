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
    class EarthGeographyBoundedContext: EarthBoundedContext
    {
        public List<GeographicalObject> GeographicalObjects { get; set; }
        
        public EarthGeographyBoundedContext()
        {
            GeographicalObjects = new List<GeographicalObject>();
        }

        public override void Initialize(DbContext database)
        {
            base.Initialize(database);

            GeographicalObjects.Clear();

            foreach (GeographicalObject g in ((Model1)Database).GeographicalObjects)
            {
                g.Name = g.Name.Trim();
                g.Type = g.Type.Trim();
                g.Location = g.Location.Trim();

                ((MapItem)g).ScreenPositionX = g.ScreenPositionX;
                ((MapItem)g).ScreenPositionY = g.ScreenPositionY;
                GeographicalObjects.Add(g);
            }

            PointColor = Color.SandyBrown;
            PointSize = 10;
    }

        public override void Draw(Graphics graphics)
        {
            // Draw map by parent class
            base.Draw(graphics);

            foreach (GeographicalObject g in GeographicalObjects)
            {
                //Draw star
                graphics.DrawEllipse(Pens.DarkBlue, new System.Drawing.Rectangle((int)(g.ScreenPositionX), (int)(g.ScreenPositionY), PointSize, PointSize));
                SolidBrush redBrush = new SolidBrush(PointColor);
                graphics.FillEllipse(redBrush, (int)(g.ScreenPositionX), (int)(g.ScreenPositionY), PointSize, PointSize);
            }

        }

        public override object DetectItemNearCursor(int x, int y)
        {
            foreach (GeographicalObject g in GeographicalObjects)
            {
                if (g.IsCursorNearby(x, y))
                    return g;
            }

            return null;
        }

    }
}


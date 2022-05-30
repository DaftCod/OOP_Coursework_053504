using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using System.Drawing;



namespace DomainModel
{
    class EarthBiologyBoundedContext : EarthBoundedContext
    {
        public List<Animal> Animals { get; set; }

        public EarthBiologyBoundedContext()
        {
            Animals = new List<Animal>();
        }

        public override void Initialize(DbContext database)
        {
            base.Initialize(database);

            Animals.Clear();

            foreach (Animal a in ((Model1)Database).Animals)
            {
                a.Name = a.Name.Trim();
                a.FamilyName = a.FamilyName.Trim();
                ((MapItem)a).ScreenPositionX = a.ScreenPositionX;
                ((MapItem)a).ScreenPositionY = a.ScreenPositionY;
                Animals.Add(a);
            }


            PointColor = Color.GreenYellow;
            PointSize = 10;
        }

        public override void Draw(Graphics graphics)
        {
            // Draw map by parent class
            base.Draw(graphics);


            foreach (Animal a in Animals)
            {
                //Draw star
                graphics.DrawEllipse(Pens.DarkBlue, new System.Drawing.Rectangle((int)(a.ScreenPositionX), (int)(a.ScreenPositionY), PointSize, PointSize));
                SolidBrush redBrush = new SolidBrush(PointColor);
                graphics.FillEllipse(redBrush, (int)(a.ScreenPositionX), (int)(a.ScreenPositionY), PointSize, PointSize);
            }

        }

        public override object DetectItemNearCursor(int x, int y)
        {
            foreach (Animal a in Animals)
            {
                if (a.IsCursorNearby(x, y))
                    return a;
            }

            return null;
        }

    }


}

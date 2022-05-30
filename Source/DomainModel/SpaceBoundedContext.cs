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
    class SpaceBoundedContext : BoundedContext
    {
        public List<Star> Stars { get; set; }

        public List<Constellation> Constellations { get; set; }

        public List<ConstellationStar> ConstellationsAndStarsRelation { get; set; }

        public SpaceBoundedContext()
        {
            Stars = new List<Star>();
            Constellations = new List<Constellation>();
            ConstellationsAndStarsRelation = new List<ConstellationStar>();
        }

        public override void Initialize(DbContext database)
        {
            base.Initialize(database);

            Stars.Clear();
            Constellations.Clear();
            ConstellationsAndStarsRelation.Clear();

            foreach (Star s in ((Model1)Database).Stars)
            {
                // Set MapItem.ScreenPositionX & MapItem.ScreenPositionY values

                ((MapItem)s).ScreenPositionX = s.ScreenPositionX;
                ((MapItem)s).ScreenPositionY = s.ScreenPositionY;

                Stars.Add(s);

            }


            foreach (Constellation c in ((Model1)Database).Constellations)
                Constellations.Add(c);

            foreach (ConstellationStar cs in ((Model1)Database).ConstellationStars)
                this.ConstellationsAndStarsRelation.Add(cs);

            PointColor = Color.White;
            PointSize = 5;
        }

        public override void Draw(Graphics graphics)
        {

            graphics.Clear(Color.DarkBlue);

            // Draw stars

            foreach (Star s in Stars)
            {
                //Draw star
                graphics.DrawEllipse(Pens.White, new System.Drawing.Rectangle((int)(s.ScreenPositionX), (int)(s.ScreenPositionY), PointSize, PointSize));
                SolidBrush redBrush = new SolidBrush(PointColor);
                graphics.FillEllipse(redBrush, (int)(s.ScreenPositionX), (int)(s.ScreenPositionY), 5, 5);

                //Draw line to other star
                if (s.ConnectToStar != null)
                {
                    foreach (Star s2 in Stars)
                    {
                        if (s2.Id == s.ConnectToStar)
                        {
                            graphics.DrawLine(Pens.White, (int)(s.ScreenPositionX), (int)(s.ScreenPositionY), (int)(s2.ScreenPositionX), (int)(s2.ScreenPositionY));
                        }
                    }
                }
            }

            // Draw constellation names

            foreach (Constellation c in Constellations)
            {
                DrawConstellationNames(c, graphics);
            }

        }

        protected void DrawConstellationNames(Constellation c, Graphics graphics)
        {

            foreach (ConstellationStar cs in ConstellationsAndStarsRelation)
            {
                if (cs.ConstellationID == c.Id)
                {
                    foreach (Star s in Stars)
                    {
                        if (s.Id == cs.StarID)
                        {
                            graphics.DrawString(c.Name, new Font("Arial", 16), new SolidBrush(Color.White), (int)(s.ScreenPositionX), (int)(s.ScreenPositionY) + 5);
                            return;
                        }
                    }
                }
            }
       
        }

        public override object DetectItemNearCursor(int x, int y)
        {
            foreach (Star s in Stars)
            {
                if (s.IsCursorNearby(x, y))
                    return s;
            }
            
            return null;
        }

    }
}

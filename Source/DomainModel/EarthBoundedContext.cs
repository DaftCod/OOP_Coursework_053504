using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Drawing;

namespace DomainModel
{
    class EarthBoundedContext: BoundedContext
    {
        public override void Initialize(DbContext database)
        {
            base.Initialize(database);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            // Draw map image
            Image backgroundPicture = Image.FromFile("./TheMap.jpg");
            graphics.DrawImage(backgroundPicture, 20, -50);

        }
    }
}

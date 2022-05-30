using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Drawing;

namespace DomainModel
{
    public class BoundedContext: IBoundedContext
    {
        public DbContext Database { get; set; }

        public Color PointColor = Color.DarkBlue;

        public int PointSize = 15;

        public virtual void Initialize(DbContext database)
        {
            this.Database = database;
        }
        
        public virtual void Draw(Graphics graphics)
        {
            graphics.Clear(Color.White);

        }

        public virtual object DetectItemNearCursor(int x, int y)
        {
            return null;
        }
    }
}

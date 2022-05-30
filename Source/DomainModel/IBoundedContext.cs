using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Drawing;

namespace DomainModel
{
    public interface IBoundedContext
    {
        DbContext Database { get; }

        void Initialize(DbContext database);

        void Draw(Graphics graphics);

        object DetectItemNearCursor(int x, int y);

    }

}

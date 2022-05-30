using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text.Json;
using DAL;

namespace DomainModel
{
    public enum BoundedContextType { Space, Biology, Politics, Geography};

    public class DomainModel
    {
        public Model1 database { get; set; }

        public Dictionary<BoundedContextType, IBoundedContext> BoundedContexts { get; set; } 

        public IBoundedContext CurrentBoundedContext { get; set; }

        public Graphics Graphics { get; set; }

        public DomainModel()
        {
            BoundedContexts = new Dictionary<BoundedContextType, IBoundedContext>();
        }

        public void Initialize(Graphics graphics)
        {
            Model1 database = new Model1();
            BoundedContexts.Clear();

            // Load data from database for each bounded context

            // SpaceBoundedContext
            IBoundedContext newContext = new SpaceBoundedContext();
            newContext.Initialize(database);
            BoundedContexts.Add(BoundedContextType.Space, newContext);

            // Animals
            newContext = new EarthBiologyBoundedContext();
            newContext.Initialize(database);
            BoundedContexts.Add(BoundedContextType.Biology, newContext);


            // Geographics
            newContext = new EarthGeographyBoundedContext();
            newContext.Initialize(database);
            BoundedContexts.Add(BoundedContextType.Geography, newContext);

            // Politics
            newContext = new EarthPoliticsBoundedContext();
            newContext.Initialize(database);
            BoundedContexts.Add(BoundedContextType.Politics, newContext);

            this.Graphics = graphics;
            
        }


        public void Draw()
        {
            Pen pen = new Pen(Color.Black);

            CurrentBoundedContext.Draw(Graphics);
        }

    }
}

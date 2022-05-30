using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using DomainModel;

namespace MVC
{
    public class Controller
    {
        private ViewModel viewModel = null;

        private DomainModel.DomainModel domainModel = null;

        private View view = null;
        
        public Controller(ViewModel appModel, DomainModel.DomainModel domainModel, View view)
        {
            this.viewModel = appModel;
            this.domainModel = domainModel;
            this.view = view;
        }

        public void Initialize()
        {
            viewModel.Initialize();
        }

        public void StartUp()
        {
            SetBoundedContext(BoundedContextType.Space);
            view.Update(false);
        }


        public void MouseDown(int x, int y)
        {
//            view.Update(true);
        }

        public void MouseMove(int x, int y)
        {
            viewModel.CursorPositionX = x;
            viewModel.CursorPositionY = y;

            object o = domainModel.CurrentBoundedContext.DetectItemNearCursor(x, y);

            if (o != null)
            {
                viewModel.MouseHintText = ((DAL.MapItem)o).GetItemInfo();
                viewModel.IsMouseHintTextVisible = true;
                view.Update(false);
            }
            else 
            {
                viewModel.IsMouseHintTextVisible = false;
                view.Update(false);
            }
        }

        public void MouseUp()
        {

  //          view.Update(true);
        }

        public void ReloadData()
        {
            Graphics g = domainModel.Graphics;
            domainModel.Initialize(g);
            domainModel.CurrentBoundedContext = domainModel.BoundedContexts[viewModel.ActiveTool];
            view.Update(true);
        }
        public void SetBoundedContext(BoundedContextType selectedContextType)
        {
            domainModel.CurrentBoundedContext = domainModel.BoundedContexts[selectedContextType];
            viewModel.ActiveTool = selectedContextType;
            view.Update(true);
        }
    }
}

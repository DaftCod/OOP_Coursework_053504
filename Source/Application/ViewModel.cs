using System;
using System.Drawing;
using DomainModel;

namespace MVC
{
    public class ViewModel
    {
        public String FormTitle { get; set; }

        public int CursorPositionX { get; set; }

        public int CursorPositionY { get; set; }

        public String MouseHintText{ get; set; }

        public bool IsMouseHintTextVisible{ get; set; }

        public BoundedContextType ActiveTool { get; set; }

        public void Initialize()
        {
            FormTitle = "Энциклопедия";
            MouseHintText = String.Empty;
            IsMouseHintTextVisible = false;
            ActiveTool = BoundedContextType.Space;
        }
    }
}

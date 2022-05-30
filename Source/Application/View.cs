using Laba2;
using System.Drawing;
using System.Windows.Forms;

namespace MVC
{
    public class View
    {
        private Form1 MainForm = null;

        private Form HintWindow = null;

        private Label HintWindowtextLabel = null;

        protected ViewModel ViewModel = null;
        public Graphics Graphics { get; set; }

        public View()
        {
            Graphics = null;
        }

        public Form1 GetMainForm()
        {
            return MainForm;
        }
        public void Update(bool redraw)
        {
            UpdateForm();
            if(redraw)
                MainForm.Invalidate();
        }

        protected void UpdateForm()
        {
            // Update title
            MainForm.Text = ViewModel.ActiveTool.ToString(); ;

            // Update hint
            if (ViewModel.IsMouseHintTextVisible)
            {
                HintWindow.Location = new Point(ViewModel.CursorPositionX - 235, ViewModel.CursorPositionY + 120);
                HintWindowtextLabel.Text = ViewModel.MouseHintText;
                HintWindow.Show();

            }
            else 
            {
                HintWindow.Hide();
            }

            MainForm.CheckMenuItem(ViewModel.ActiveTool);

        }

        public void Initialize(ViewModel viewModel)
        {
            this.ViewModel = viewModel;
            MainForm = new Form1();
            this.Graphics = MainForm.CreateGraphics();

            // Creating hint window
            HintWindow = new Form()
            {
                Width = 500,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "",
                StartPosition = FormStartPosition.Manual
            };

            HintWindow.ControlBox = false;
            HintWindowtextLabel = new Label() { Left = 10, Top = 20, Width = 200, Height = 150, Text = "" };
            HintWindow.Controls.Add(HintWindowtextLabel);

        }

    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;

namespace Laba2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Controller.MouseDown(e.X, e.Y);       
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Controller.MouseUp();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Program.Controller.MouseMove(e.X, e.Y);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Program.DomainModel.Draw();

//            base.OnPaint(e);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                //Reload data from database
                Program.Controller.ReloadData();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Space menu item click
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.Controller.SetBoundedContext(DomainModel.BoundedContextType.Space);

        }

        //Biology menu item click
        private void animalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.SetBoundedContext(DomainModel.BoundedContextType.Biology);
        }


        // Politics menu item click
        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.SetBoundedContext(DomainModel.BoundedContextType.Politics);
        }

        // Geography menu item click
        private void geographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.SetBoundedContext(DomainModel.BoundedContextType.Geography);
        }

        public void CheckMenuItem(DomainModel.BoundedContextType type)
        {
            this.geographyToolStripMenuItem.Checked = false;
            this.countriesToolStripMenuItem.Checked = false;
            this.animalsToolStripMenuItem.Checked = false;
            this.toolStripMenuItem2.Checked = false;

            switch (type)
            {
                case BoundedContextType.Biology:
                    this.animalsToolStripMenuItem.Checked = true;
                    
                    break;

                case BoundedContextType.Geography:
                    this.geographyToolStripMenuItem.Checked = true;
                    break;

                case BoundedContextType.Politics:
                    this.countriesToolStripMenuItem.Checked = true;
                    break;


                case BoundedContextType.Space:
                    this.toolStripMenuItem2.Checked = true;
                    break;


            }

        }
    }
}

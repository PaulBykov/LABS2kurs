using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harmony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // high freq optimization
            SetStyle(ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.UserPaint, true);
        }

        // Form dragging
        private bool currentlyDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private protected void ChangeFormWindowState() 
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }


        // --------------------------------------------------------------------
        // System required code
        // --------------------------------------------------------------------

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ---------------------------------------------------------------------
 

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            ChangeFormWindowState();
        }

        private void header_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeFormWindowState();
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            currentlyDragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            currentlyDragging &= false;
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (!currentlyDragging) 
            {
                return;
            }

            Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
            this.Location = Point.Add(dragFormPoint, new Size(dif));
        }


        private void TopMenuIcon_MouseHover(object sender, EventArgs e) {
            IconButton _target = (IconButton)sender;
            _target.IconColor = Settings.ActiveButtonColor;
        }

        private void TopMenuIcon_MouseLeave(object sender, EventArgs e)
        {
            IconButton _target = (IconButton)sender;
            _target.IconColor = Settings.NotActiveButtonColor;
        }
    }
}

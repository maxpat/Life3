using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Max migration from Borland Studio 2015-09-23

    // to pulish to master-test1 branch

namespace Life
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Panel myPanel;

        private System.Drawing.Graphics myGraphics;
        private System.Drawing.Pen myPen = new System.Drawing.Pen(Color.Black, 3);
        private System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Black);

        public const int MAXMATWIDTH = 150;
        public const int MAXMATHEIGHT = 100;
        int[,] Matrix = new int[MAXMATWIDTH, MAXMATHEIGHT];
        int[,] MatrixT = new int[MAXMATWIDTH, MAXMATHEIGHT];
        int MatWidth = MAXMATWIDTH;
        int MatHeight = MAXMATHEIGHT;
        bool genCalc = false;
        Bitmap offscreen;

        Int32 GenerationCount = 0;
        Int32 PopulationCount = 0;
        bool AnyChange = false;

        int LastXMouse = 0;
        int LastYMouse = 0;

        // Graphics myGraphics;
        Graphics myPanelGraphics;

        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button nextGenButton;
        private System.Windows.Forms.Button next10GenButton;
        private System.Windows.Forms.Button next100GenButton;
        private System.Windows.Forms.Button next1000GenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RandomSeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Density;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GenerationCounter;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.TextBox PopulationCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearGrid;
        private System.Windows.Forms.CheckBox AutoRefresh;

        public Form1()
        {
            InitializeComponent();
            Bitmap formbackground = new Bitmap(this.Width, this.Height, 
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            //			myPen.DashStyle= System.Drawing.Drawing2D.DashStyle.Solid;
            //			myBrush.Color= Color.LightGray;
            Graphics formGraphics = Graphics.FromImage(formbackground);
            formGraphics.Clear(Color.LightSteelBlue);
            formGraphics.DrawImage(formbackground, 0, 0,
                this.Width, this.Height);

            offscreen = new Bitmap(myPanel.Width,
                myPanel.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            myGraphics = Graphics.FromImage(offscreen);
            //			using (Graphics myGraphics = Graphics.FromImage( offscreen))
            {
                myGraphics.Clear(Color.LightSteelBlue);
            }
            myPanelGraphics = this.myPanel.CreateGraphics();
            //			using (Graphics myPanelGraphics= this.myPanel.CreateGraphics())
            {
                myPanelGraphics.DrawImage(offscreen, 0, 0,
                    myPanel.Width, myPanel.Height);
            }

        }

 
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!genCalc)
            {
                Graphics gfx = pevent.Graphics;

                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                // Dispose of brush resources after use
                using (SolidBrush myBrush = new System.Drawing.SolidBrush(this.BackColor))
                    gfx.FillRectangle(myBrush, rect);
            }
            //			ControlPaint.DrawBorder3D(gfx,rect,b3dstyle);
        }

        private int XToCellx(int X)
        {
            if (X >= myPanel.Width) X = myPanel.Width;
            if (X < 0) X = 0;

            return (X * MatWidth) / myPanel.Width;

        }

        private int YToCelly(int Y)
        {
            if (Y >= myPanel.Height) Y = myPanel.Width;
            if (Y < 0) Y = 0;

            return (Y * MatHeight) / myPanel.Height;
        }

        private void RePaintGridCell(int x, int y, bool RedrawCell)
        {
            int x0 = (x * myPanel.Width) / MatWidth;
            int x1 = ((x + 1) * myPanel.Width) / MatWidth - 1;
            int y0 = (y * myPanel.Height) / MatHeight;
            int y1 = ((y + 1) * myPanel.Height) / MatHeight - 1;

            MatrixT[x, y] = 2; // force background redraw

            if ((MatrixT[x, y] == 2))
            {
                myBrush.Color = Color.LightSteelBlue;   // blank board
                myGraphics.FillRectangle(myBrush, x0, y0, x1 - x0 + 1, y1 - y0 + 1);
            }

            if ((Matrix[x, y] == 1) && (MatrixT[x, y] != 1))
            {
                myBrush.Color = Color.Red;
                myGraphics.FillRectangle(myBrush, x0, y0, x1 - x0 + 1, y1 - y0 + 1);
            }

            if ((Matrix[x, y] == 0) && (MatrixT[x, y] == 1))
            {
                myBrush.Color = Color.LightBlue;    // dead cells
                myGraphics.FillRectangle(myBrush, x0, y0, x1 - x0 + 1, y1 - y0 + 1);
            }

            if (RedrawCell)
            {
                //			myPanelGraphics.DrawImage(offscreen, x0, y0, x1-x0+1, y1-y0+1);
                myPanelGraphics.DrawImage(offscreen, 0, 0, myPanel.Width, myPanel.Height);
            }
        }

        private void RePaintGrid()
        {
            for (int x = 0; x < MatWidth; x++)
                for (int y = 0; y < MatHeight; y++)
                {
                    RePaintGridCell(x, y, false); // no individual cell redraw
                }
            myPanelGraphics.DrawImage(offscreen, 0, 0, myPanel.Width, myPanel.Height);

        }

        private void RePaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            RePaintGrid();
        }

        private void myPanel_Resize(object sender, System.EventArgs e)
        {
            if (offscreen != null)
            {
                offscreen.Dispose();
                offscreen = new Bitmap(myPanel.Width,
                    myPanel.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            }

            if (myGraphics != null)
            {
                myGraphics.Dispose();
                myGraphics = Graphics.FromImage(offscreen);
                myGraphics.Clear(Color.LightSteelBlue);
            }

            if (myPanelGraphics != null)
            {
                myPanelGraphics.Dispose();
                myPanelGraphics = this.myPanel.CreateGraphics();
                myPanelGraphics.DrawImage(offscreen, 0, 0,
                    myPanel.Width, myPanel.Height);
            }

            RePaintGrid();
        }

        private void Init_Matrix(float Density, int RandSeed)
        {
            if (RandomSeed.Text == "") RandomSeed.Text = "0";
            System.Random Rand = new System.Random(RandSeed);

            PopulationCount = 0;

            for (int x = 0; x < MatWidth; x++)
                for (int y = 0; y < MatHeight; y++)
                {
                    if (Rand.Next(10000) <= 10000 * Density)
                    {
                        Matrix[x, y] = 1;
                        PopulationCount++;
                    }
                    else Matrix[x, y] = 0;
                    MatrixT[x, y] = 2;
                }
            genCalc = false;
            GenerationCount = 0;
            GenerationCounter.Text = (GenerationCount).ToString();
            GenerationCounter.Update();
            PopulationCounter.Text = (PopulationCount).ToString();
            PopulationCounter.Update();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.myPanel.Refresh();
            this.statsPanel.Refresh();
        }

        private void NextGeneration()
        {
            int Neighbors;
            int xn, yn, z;
            AnyChange = false;
            for (int x = 0; x < MatWidth; x++)
                for (int y = 0; y < MatHeight; y++)
                {
                    if (Matrix[x, y] == 1) Neighbors = -1; // don't count self
                    else Neighbors = 0;
                    MatrixT[x, y] = Matrix[x, y];
                    for (int xi = -1; xi <= 1; xi++)
                        for (int yi = -1; yi <= 1; yi++)
                        {
                            xn = x + xi; yn = y + yi;
                            if (xn < 0) xn = xn + MatWidth;
                            if (yn < 0) yn = yn + MatHeight;
                            if (xn >= MatWidth) xn = xn - MatWidth;
                            if (yn >= MatHeight) yn = yn - MatHeight;
                            if (Matrix[xn, yn] == 1) Neighbors++;
                        }
                    if ((Matrix[x, y] == 1) && (Neighbors != 2 && Neighbors != 3))
                    {
                        MatrixT[x, y] = 0;
                        PopulationCount--;
                        AnyChange = true;
                    }
                    else
                        if ((Matrix[x, y] == 0) && (Neighbors == 3))
                    {
                        MatrixT[x, y] = 1;
                        PopulationCount++;
                        AnyChange = true;
                    }
                }
            for (int x = 0; x < MatWidth; x++)
                for (int y = 0; y < MatHeight; y++)
                {
                    z = Matrix[x, y];
                    Matrix[x, y] = MatrixT[x, y];
                    MatrixT[x, y] = z;
                }
        }

        private void initButton_Click(object sender, System.EventArgs e)
        {
            if (RandomSeed.Text == "") RandomSeed.Text = "0";
            if (int.Parse(RandomSeed.Text) == 0) RandomSeed.Text = "0";
            if (float.Parse(Density.Text) > 1) Density.Text = "1.0";
            if (float.Parse(Density.Text) <= 0) Density.Text = "0.0";
            if (Density.Text == "") Density.Text = "0.2";
            Init_Matrix(float.Parse(Density.Text), int.Parse(RandomSeed.Text));
        }

        private void genCalculate()
        {
            NextGeneration();
            if (AutoRefresh.Checked) myPanel.Refresh();
            GenerationCount++;
        }

        private void nextGenButton_Click(object sender, System.EventArgs e)
        {
            genCalc = true;
            genCalculate();
            GenerationCounter.Text = (GenerationCount).ToString();
            GenerationCounter.Update();
            PopulationCounter.Text = (PopulationCount).ToString();
            PopulationCounter.Update();
            if (!AutoRefresh.Checked) myPanel.Refresh();
            genCalc = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            genCalc = true;
            for (int i = 0; i < 10; i++)
            {
                genCalculate();
                GenerationCounter.Text = (GenerationCount).ToString();
                GenerationCounter.Update();
                PopulationCounter.Text = (PopulationCount).ToString();
                PopulationCounter.Update();
                if (PopulationCount == 0 || !AnyChange) break;
            }
            if (!AutoRefresh.Checked) myPanel.Refresh();
            genCalc = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            genCalc = true;
            for (int i = 0; i < 100; i++)
            {
                genCalculate();
                if (GenerationCount % 10 == 0)
                {
                    GenerationCounter.Text = (GenerationCount).ToString();
                    GenerationCounter.Update();
                    PopulationCounter.Text = (PopulationCount).ToString();
                    PopulationCounter.Update();
                }
                if (PopulationCount == 0 || !AnyChange) break;
            }
            GenerationCounter.Text = (GenerationCount).ToString();
            GenerationCounter.Update();
            PopulationCounter.Text = (PopulationCount).ToString();
            PopulationCounter.Update();
            if (!AutoRefresh.Checked) myPanel.Refresh();
            genCalc = false;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            genCalc = true;
            for (int i = 0; i < 1000; i++)
            {
                genCalculate();
                if (GenerationCount % 20 == 0)
                {
                    GenerationCounter.Text = (GenerationCount).ToString();
                    GenerationCounter.Update();
                    PopulationCounter.Text = (PopulationCount).ToString();
                    PopulationCounter.Update();
                }
                if (PopulationCount == 0 || !AnyChange) break;
            }
            GenerationCounter.Text = (GenerationCount).ToString();
            GenerationCounter.Update();
            PopulationCounter.Text = (PopulationCount).ToString();
            PopulationCounter.Update();
            if (!AutoRefresh.Checked) myPanel.Refresh();
            genCalc = false;
        }

        private void quitButton_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void Change_GridXY(int X, int Y)
        {
            if ((X >= myPanel.Width) || (Y >= myPanel.Height)) return;
            if ((X < 0) || (Y < 0)) return;

            int x = XToCellx(X);
            int y = YToCelly(Y);
            MatrixT[x, y] = Matrix[x, y]; ;
            Matrix[x, y] = 1; // to invert, use 1 - Matrix[x, y];
            if (MatrixT[x, y] != 1) PopulationCount++; else return;
            // else PopulationCount--;
            PopulationCounter.Text = (PopulationCount).ToString();
            PopulationCounter.Update();

            RePaintGridCell(x, y, true);
            //			myPanel.Focus();
            //			myPanel.Invalidate();
        }

        private void myPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the mouse path with the mouse information
            Point mouseDownLocation = new Point(e.X, e.Y);

            string eventString = null;
            switch (e.Button)
            {
                case MouseButtons.Left: eventString = "L"; break;
                case MouseButtons.Right: eventString = "R"; break;
                case MouseButtons.Middle: eventString = "M"; break;
                case MouseButtons.XButton1: eventString = "X1"; break;
                case MouseButtons.XButton2: eventString = "X2"; break;
                case MouseButtons.None: default: break;
            }

            if ( (eventString == "L") && (LastXMouse != e.X || LastYMouse != e.Y))
                if ((e.X < myPanel.Width) && (e.Y < myPanel.Height))
                {
                    Change_GridXY(e.X, e.Y);
                    LastXMouse = e.X; LastYMouse = e.Y;
                }

            //			myPanel.Focus();
            //			myPanel.Invalidate();
        }

        private void clearGrid_Click(object sender, System.EventArgs e)
        {
            Init_Matrix(0, 0);
        }

        private void myPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if ((e.X < this.Width) && (e.Y < this.Height))
                    if ((XToCellx(LastXMouse) != XToCellx(e.X))
                         || (YToCelly(LastYMouse) != YToCelly(e.Y)))
                    {
                        Change_GridXY(e.X, e.Y);
                        LastXMouse = e.X; LastYMouse = e.Y;
                    }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

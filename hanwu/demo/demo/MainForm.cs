using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class MainForm : Form
    {
        private List<DrawTools.DrawObject> mDrawObjs = new List<DrawTools.DrawObject>(3);

        private Random mRandomX = new Random();
        private Random mRandomY = new Random();
        private Random mRandomW = new Random();
        private Random mRandomH = new Random();
        //private Random mRandomR = new Random(500);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DrawTools.DrawRectangle mRect = new DrawTools.DrawRectangle(100, 50, 20, 20);
            mRect.Color = Color.Blue;
            mRect.PenWidth = 5;
            DrawTools.DrawEllipse mEllipse = new DrawTools.DrawEllipse(400, 300, 10, 10);
            mEllipse.Color = Color.Coral;
            mEllipse.PenWidth = 2;
            DrawTools.DrawEllipse mCircle = new DrawTools.DrawEllipse(200, 200, 10, 10);
            mCircle.Color = Color.Green;
            mCircle.PenWidth = 3;

            mDrawObjs.Add(mRect);
            mDrawObjs.Add(mEllipse);
            mDrawObjs.Add(mCircle);

            //
            dataGridView1.Rows.Add(new object[] { "1", "斑点", "圆形污点", "100.79", "150.54", "3000", "0.3" });
            dataGridView1.Rows.Add(new object[] { "2", "斑点", "线性污点", "1230.43", "1621.52", "3000", "0.7" });
            dataGridView1.Rows.Add(new object[] { "3", "斑点", "非圆形污点", "577.000", "20003.64", "3000", "0.8" });
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnalize_Click(object sender, EventArgs e)
        {
            //分析,进度条...
        }

        private void panelDrawPaint(object sender, PaintEventArgs e)
        {
            int n = mRandomH.Next(0, 3);
            for (int i = n; i < 3; i++)
            {
                mDrawObjs[i].Draw(e.Graphics);
            }
       }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //随机产生位置与大小
            mDrawObjs[0].SetRectangle(mRandomX.Next(0, panelDraw.Width), mRandomY.Next(0, panelDraw.Height), mRandomW.Next(2, 10), mRandomH.Next(3, 8));
            mDrawObjs[1].SetRectangle(mRandomX.Next(0, panelDraw.Width), mRandomY.Next(0, panelDraw.Height), mRandomW.Next(2, 10), mRandomH.Next(3, 8));
            int r = mRandomH.Next(3, 8);
            mDrawObjs[2].SetRectangle(mRandomX.Next(0, panelDraw.Width), mRandomY.Next(0, panelDraw.Height), r, r);

            this.panelDraw.Refresh();
        }

    }
}

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Hi.Client
{
    public partial class FrmTrail : Form
    {
        public FrmTrail()
        {
            InitializeComponent();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            bool blResult = IBLL.HiInstanceBll.TrailBll().TrailUpdate(SetDetail());
            MessageBox.Show(!blResult ? "Fail!" : "Success");
        }

        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        private Model.BasTrail SetDetail()
        {
            //从画面取值
            var model = new Model.BasTrail
                {
                    OrgName  = textBox1.Text.Trim(),
                    ParentId = textBox2.Text.Trim()
                };

            return model;
        }

        #region 线状图

        //Render是图形大标题，图开小标题，图形宽度，图形长度，饼图的数据集和饼图的数据集 
        public Image Render(string title, int width, int height, DataTable chartTable)
        {
            var bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            const int top = 30;
            const int left = 35;
            if (width < left * 2 || height < top * 2)
            {
                g.DrawString("绘图区域太小", new Font("Tahoma", 8),
                    Brushes.Blue, new PointF(0, 0));
                return bm;
            }

            if (chartTable == null)
            {
                g.DrawString("没有数据", new Font("Tahoma", 7),
                    Brushes.Blue, new PointF(0, 0));
                return bm;
            }

            DataTable dt = chartTable;
            //计算最高的点 
            float highPoint = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (highPoint < Convert.ToSingle(dr[0]))
                {
                    highPoint = Convert.ToSingle(dr[0]);
                }
                if (highPoint < Convert.ToSingle(dr[1]))
                {
                    highPoint = Convert.ToSingle(dr[1]);
                }
            }
            //建立一个Graphics对象实例 
            try
            {
                //画大标题 
                g.DrawString(title, new Font("Tahoma", 12), Brushes.Black, new PointF(2, 2));
                var drawFormat = new StringFormat {FormatFlags = StringFormatFlags.DirectionVertical};
                g.DrawString(string.Format("[红--{0}]", dt.Columns[0]), new Font("Tahoma", 8), Brushes.Red, new PointF(2, top), drawFormat);
                g.DrawString(string.Format("[蓝--{0}]", dt.Columns[1]), new Font("Tahoma", 8), Brushes.Blue, new PointF(17, top), drawFormat);
                //画条形图 
                float barWidth = (Convert.ToSingle(width) - left) / (dt.Rows.Count + 1);
                var barOrigin = new PointF(left + barWidth, 0);
                const float topFontSize = 7;
                const float bottomFontSize = 7;
                var pt1 = new PointF[dt.Rows.Count];
                var pt2 = new PointF[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //底部字体的大小
                    float barHeight = Convert.ToSingle(dt.Rows[i][0]) * (height - 2 * top) / highPoint * 1;
                    barOrigin.Y = height - barHeight - top;
                    g.FillEllipse(new SolidBrush(Color.Red), barOrigin.X - 3, barOrigin.Y - 3, 6, 6);
                    pt1[i] = new PointF(barOrigin.X, barOrigin.Y);
                    //顶部
                    g.DrawString(dt.Rows[i][0].ToString(), new Font("Tahoma", topFontSize), Brushes.Red,
                        new PointF(barOrigin.X, barOrigin.Y - 4 * topFontSize / 2));
                    barHeight = Convert.ToSingle(dt.Rows[i][1]) * (height - 2 * top) / highPoint * 1;
                    barOrigin.Y = height - barHeight - top;
                    g.FillEllipse(new SolidBrush(Color.Blue), barOrigin.X - 3, barOrigin.Y - 3, 6, 6);
                    pt2[i] = new PointF(barOrigin.X, barOrigin.Y);
                    //顶部
                    g.DrawString(dt.Rows[i][1].ToString(), new Font("Tahoma", topFontSize), Brushes.Blue,
                        new PointF(barOrigin.X, barOrigin.Y - 4 * topFontSize / 2));
                    barOrigin.X = barOrigin.X + barWidth;
                }
                if (dt.Rows.Count > 10)
                {
                    int dis = dt.Rows.Count / 10;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i % dis == 0)
                        {
                            g.DrawLine(new Pen(Color.Blue, 2), new PointF(left + (i + 1) * barWidth, height -
top + 5),
                                new PointF(left + (i + 1) * barWidth, height - top - 3));
                            //底部
                            g.DrawString(dt.Rows[i][2].ToString(), new Font("Tahoma", bottomFontSize),
Brushes.Black,
                                new PointF(left + (i + 1) * barWidth, height - top));
                        }
                        else
                        {
                            g.DrawLine(new Pen(Color.Gray, 1), new PointF(left + (i + 1) * barWidth, height -
top + 3),
                                new PointF(left + (i + 1) * barWidth, height - top - 3));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        g.DrawLine(new Pen(Color.Gray, 1), new PointF(left + (i + 1) * barWidth, height - top
+ 3),
                            new PointF(left + (i + 1) * barWidth, height - top - 3));
                    }
                }
                //绘制曲线
                g.DrawLines(new Pen(new SolidBrush(Color.Red), 1), pt1);
                g.DrawLines(new Pen(new SolidBrush(Color.Blue), 1), pt2);
                //设置边 
                g.DrawLine(new Pen(Color.Blue, 2), new Point(left, top),
                    new Point(left, height - top));
                g.DrawLine(new Pen(Color.Blue, 2), new Point(left, height - top),
                    new Point(left + width, height - top));
                g.Dispose();
                return bm;
            }
            catch
            {
                return bm;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        Model model;
        TrackBar tbSize;
        TrackBar tbRoll;
        TrackBar tbPitch;
        TrackBar tbYaw;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            Size = new Size(600, 600);

            tbSize = new TrackBar { Parent = this, Maximum = 300, Left = 0, Value = 130, Minimum = 1 };
            tbRoll = new TrackBar { Parent = this, Maximum = 120, Left = 110, Value = 0 };
            tbPitch = new TrackBar { Parent = this, Maximum = 170, Minimum = 145, Left = 220, Value = 160 };
            tbYaw = new TrackBar { Parent = this, Maximum = 340, Left = 330, Value = 0 };

            tbSize.ValueChanged += tb_ValueChanged;
            tbRoll.ValueChanged += tb_ValueChanged;
            tbPitch.ValueChanged += tb_ValueChanged;
            tbYaw.ValueChanged += tb_ValueChanged;

            tb_ValueChanged(null, EventArgs.Empty);


            //загружаем модель из .obj
            model = new Model();
            model.LoadFromObj(new StreamReader("untitled.obj"));
        }

        void tb_ValueChanged(object sender, EventArgs e)
        {
            scale = tbSize.Value / 70f;
            pitch = (float)(tbPitch.Value * Math.PI / 180);
            roll = (float)(tbRoll.Value * Math.PI / 180);
            yaw = (float)(tbYaw.Value * Math.PI / 180);

            textBox1.Text = tbPitch.Value.ToString();

            Invalidate();
        }

        float yaw = 0;
        float pitch = 0;
        float roll = 0;
        float scale = 1;
        Vector3 position = new Vector3(300, 300, 200);

        protected override void OnPaint(PaintEventArgs e)
        {
            //матрица масштабирования
            var scaleM = Matrix4x4.CreateScale(scale);
            //матрица вращения
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(yaw, pitch, roll);
            //матрица переноса
            var translateM = Matrix4x4.CreateTranslation(position);
            //результирующая матрица
            var m = scaleM * rotateM * translateM;

            //умножаем вектора на матрицу
            var vertexes = model.Vertexes.Select(v => Vector3.Transform(v, m)).ToList();

            //сортируем грани по удаленности
            Sort(model.Fig, vertexes);

            //создаем graphicsPath
            using (var brush = new SolidBrush(Color.Black))
            using (var path = new GraphicsPath())
            {
                //создаем грани
                foreach (var f in model.Fig)
                {
                    //полигон
                    var prev = vertexes[f.Vertexes[0]];
                    for (int i = 1; i < f.Vertexes.Length; i++)
                    {
                        var v = vertexes[f.Vertexes[i]];
                        path.AddLine(prev.X, prev.Y, v.X, v.Y);
                        prev = v;
                    }
                    path.CloseFigure();

                    //освещение
                    var p = vertexes[f.Vertexes[0]];
                    var dir1 = vertexes[f.Vertexes[1]] - p;//направляющяя
                    var dir2 = vertexes[f.Vertexes[2]] - p;//направляющяя
                    var n = Vector3.Cross(dir1, dir2);//нормаль
                    n = 10 * Vector3.Normalize(n);
                    var light = 1 - 0.8f * new Vector3(n.X, n.Y, 0).Length() / n.Length();//1 - cos(a)

                    //заливаем грань
                    var gray = (int)(255 * light);
                    brush.Color = Color.FromArgb(gray, gray, gray);
                    e.Graphics.FillPath(brush, path); 
                    //e.Graphics.DrawPath(Pens.Black, path);//wireframe
                    //e.Graphics.DrawLine(Pens.Red, p.X, p.Y, p.X + n.X, p.Y + n.Y);//normal

                    path.Reset();
                }
            }
        }

        private void Sort(List<Figure> figs, List<Vector3> vertexes)
        {
            foreach (var f in figs)
            {
                f.Distance = vertexes[f.Vertexes[0]].Z;
                for (int i = 1; i < f.Vertexes.Length; i++)
                {
                    var v = vertexes[f.Vertexes[i]];
                    if (f.Distance > v.Z) f.Distance = v.Z;
                }
            }

            figs.Sort((f1, f2) => f1.Distance.CompareTo(f2.Distance));
        }
    }

    public class Model
    {
        public List<Vector3> Vertexes = new List<Vector3>();
        public List<Figure> Fig = new List<Figure>();

        public void LoadFromObj(TextReader tr)
        {
            string line;
            Vertexes.Clear();
            Vertexes.Add(Vector3.Zero);

            while ((line = tr.ReadLine()) != null)
            {
                var parts = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;
                switch (parts[0])
                {
                    case "v":
                        Vertexes.Add(new Vector3(float.Parse(parts[1], CultureInfo.InvariantCulture),
                  float.Parse(parts[2], CultureInfo.InvariantCulture),
                  float.Parse(parts[3], CultureInfo.InvariantCulture)));
                        break;
                    case "f":
                        var f = new Figure { Vertexes = new int[parts.Length - 1] };
                        for (int i = 1; i < parts.Length; i++)
                            f.Vertexes[i - 1] = int.Parse(parts[i].Split('/')[0]);
                        Fig.Add(f);
                        break;
                }
            }
        }
    }

    public class Figure
    {
        public int[] Vertexes { get; set; }
        public float Distance { get; set; }
    }
}

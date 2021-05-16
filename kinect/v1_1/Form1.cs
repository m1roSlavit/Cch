using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v1_1
{
    public partial class Form1 : Form, IObserver
    {
        Panel LeftPanel;
        Panel RightPanel;
        PictureBox HandCursorPictureBox;
        PictureBox InteractionPictureBox;
        float CursorLoaderAngel = 0;
        int CursorLoaderIndex = -1;
        List<IButtonControl> InteractiveElements = new List<IButtonControl>();
        KinectSkeletObservable KinectSkelet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KinectSkelet = new KinectSkeletObservable();
            KinectSkelet.Subscribe(this);
            Width = 1250;
            Height = 800;
            LeftPanel = new Panel
            {
                Width = 450,
                Height = 800,
                Top = 0,
                Left = 0,
                BackColor = Color.LightBlue,
            };
            RightPanel = new Panel
            {
                Width = 800,
                Height = 800,
                Top = 0,
                Left = 450,
                BackColor = Color.AliceBlue
            };

            HandCursorPictureBox = new PictureBox
            {
                Width = 20,
                Height = 20,
                BackColor = Color.DeepSkyBlue,
            };
            InteractionPictureBox = new PictureBox
            {
                Width = 50,
                Height = 50,
                Left = LeftPanel.Width - 100,
                Top = LeftPanel.Height - 150,
            };
            RightPanel.Controls.Add(HandCursorPictureBox);
            LeftPanel.Controls.Add(InteractionPictureBox);

            Controls.Add(LeftPanel);
            Controls.Add(RightPanel);

            Panel GamePanel1 = CreateNewGamePanel(50, 10, RightPanel.Width - 100, GameCatch.Title, GameCatch.Description, (object sender3, EventArgs e3) => {
                Form TempForm = new Form();
                TempForm.WindowState = FormWindowState.Maximized;
                TempForm.Show();
                GameCatch TempGameObject = new GameCatch(TempForm);
                TempForm.FormClosed += (object sender2, FormClosedEventArgs e2) =>
                {
                    KinectSkelet.Unsubscribe(TempGameObject);
                    KinectSkelet.Subscribe(this);
                    this.Show();
                };
                KinectSkelet.Unsubscribe(this);
                KinectSkelet.Subscribe(TempGameObject);
                this.Hide();
            });

            RightPanel.Controls.Add(GamePanel1);

            Panel GamePanel2 = CreateNewGamePanel(50, 220, RightPanel.Width - 100, GameEvade2.Title, GameEvade2.Description, (object sender3, EventArgs e3) => {
                Form TempForm = new Form();
                TempForm.WindowState = FormWindowState.Maximized;
                TempForm.Show();
                GameEvade2 TempGameObject = new GameEvade2(TempForm);
                TempForm.FormClosed += (object sender2, FormClosedEventArgs e2) =>
                {
                    KinectSkelet.Unsubscribe(TempGameObject);
                    KinectSkelet.Subscribe(this);
                    this.Show();
                };
                KinectSkelet.Unsubscribe(this);
                KinectSkelet.Subscribe(TempGameObject);
                this.Hide();
            });

            RightPanel.Controls.Add(GamePanel2);
        }

        private Panel CreateNewGamePanel(int left, int top, int width, string title, string description, EventHandler buttonClicFunc)
        {
            Panel GamePanel = new Panel
            {
                Left = left,
                Top = top,
                Width = width,
                BackColor = Color.Coral,
                Height = 200,
            };
            Label Title = new Label
            {
                Text = title,
                Top = 5,
                Left = 10,
                MinimumSize = new Size(1, 35),
                MaximumSize = new Size(150, 150),
                BackColor = Color.Green,
                Font = new Font("Arial", 22),
            };
            Label Description = new Label
            {
                Top = 50,
                Left = 10,
                MinimumSize = new Size(1, 25),
                MaximumSize = new Size(150, 150),
                BackColor = Color.CadetBlue,

                Text = description,
                Font = new Font("Arial", 16),
            };
            Button GButton = new Button
            {
                Top = 200 - 70,
                Left = width - 100,
                Width = 80,
                Height = 50,
                Font = new Font("Arial", 14),
                BackColor = Color.White,
                Text = "Грати",
            };
            GButton.Click += buttonClicFunc;
            GamePanel.Controls.Add(Title);
            GamePanel.Controls.Add(Description);
            GamePanel.Controls.Add(GButton);

            InteractiveElements.Add(GButton);
            return GamePanel;
        }
        private bool HitBox(Point point, Point control, int wwidth, int hheight)
        {
            if (point.X + 5 < control.X || point.X - 5 > control.X + wwidth) return false;
            if (point.Y + 5 < control.Y || point.Y - 5 > control.Y + hheight) return false;
            return true;
        }
        private void HandCursorUpdate()
        {
            Pen myPen = new Pen(Color.Green, 10);
            using (Graphics g = InteractionPictureBox.CreateGraphics())
            {

                g.DrawArc(myPen, new Rectangle(5, 5, 40, 40), CursorLoaderAngel, CursorLoaderAngel + (float)3);
                CursorLoaderAngel += (float)3;
            }
        }

        private void HandCursorChanged()
        {
            for (int i = 0; i < InteractiveElements.Count; i++)
            {
                Control InteractiveElement = (InteractiveElements[i] as Control);
                if ((HitBox(new Point(HandCursorPictureBox.Left, HandCursorPictureBox.Top), new Point(InteractiveElement.Left, InteractiveElement.Top + i*200), InteractiveElement.Width, InteractiveElement.Height)) && CursorLoaderAngel < 183) //TimeNow < 5
                {
                    HandCursorUpdate();
                    if (CursorLoaderAngel >= 183)
                    {
                        CursorLoaderAngel = 0;
                        InvokeOnClick(InteractiveElement, EventArgs.Empty);
                    }
                    return;
                }

            }
            using (Graphics g = InteractionPictureBox.CreateGraphics())
            {
                g.Clear(LeftPanel.BackColor);
            }
        }

        public void DrawHandCursor(Point[] points)
        {
            Point HandCursorPoint = points[8];
            HandCursorPictureBox.Left = Convert.ToInt32((HandCursorPoint.X - 100) * 1.5 * 1.6667);
            HandCursorPictureBox.Top = Convert.ToInt32(HandCursorPoint.Y * 1.5 * 1.25);
        }

        public void DrawStickMan(Point[] points)
        {
            using (Graphics g = LeftPanel.CreateGraphics())
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].X = Convert.ToInt32(points[i].X * 0.70);
                    points[i].Y += 0;
                }
                g.Clear(Color.LightBlue);
                Pen MyPen = new Pen(Color.Black, 6);
                SolidBrush brush = new SolidBrush(Color.Black);
                //head
                float RHead = (float)Math.Pow(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2), 0.5) / 2;
                g.FillEllipse(brush, points[0].X - RHead, points[0].Y - RHead, RHead * 2, RHead * 2);
                g.DrawLine(MyPen, points[0], points[1]);
                //left hand
                g.DrawLine(MyPen, points[1], points[2]);
                g.DrawLine(MyPen, points[2], points[4]);
                g.DrawLine(MyPen, points[4], points[6]);
                g.DrawLine(MyPen, points[6], points[8]);
                //right end
                g.DrawLine(MyPen, points[1], points[3]);
                g.DrawLine(MyPen, points[3], points[5]);
                g.DrawLine(MyPen, points[5], points[7]);
                g.DrawLine(MyPen, points[7], points[9]);
                //body
                g.DrawLine(MyPen, points[1], points[11]);
                //left foot
                g.DrawLine(MyPen, points[11], points[12]);
                g.DrawLine(MyPen, points[12], points[14]);
                g.DrawLine(MyPen, points[14], points[16]);
                g.DrawLine(MyPen, points[16], points[18]);
                //righ foot
                g.DrawLine(MyPen, points[11], points[13]);
                g.DrawLine(MyPen, points[13], points[15]);
                g.DrawLine(MyPen, points[15], points[17]);
                g.DrawLine(MyPen, points[17], points[19]);
            }

        }

        public void Update(Point[] points)
        {
            DrawStickMan(points);
            DrawHandCursor(points);
            HandCursorChanged();
        }
    }
    class GameEvade2 : IObserver
    {
        public static string Title
        {
            get
            {
                return "Ухиляйся і виживай";
            }
        }
        public static string Description
        {
            get
            {
                return "На екрані буде зявлятись тінь падаючих обєктів і ти повинен ухилятись від них, бо якщо вони впадуть і задінуть тебе то ти програєш";
            }
        }

        Random rand = new Random(DateTime.Now.Millisecond);
        private int TimeImmortal = 0;
        private Control ParentControl;
        private List<PictureBox> DropedObj = new List<PictureBox>();
        private int TimeSleep = 0;
        private int MaxNumberFalling;
        public GameEvade2(Control parentControl)
        {
            ParentControl = parentControl;
            MaxNumberFalling = 6;
        }
        private void DrawStickMan(Point[] points)
        {
            using (Graphics g = ParentControl.CreateGraphics())
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].X += 500;
                    points[i].Y += 200;
                }
                g.Clear(Color.White);
                Pen MyPen = new Pen(Color.Blue, 6);
                SolidBrush brush = new SolidBrush(Color.Blue);
                //head
                float RHead = (float)Math.Pow(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2), 0.5) / 2;
                g.FillEllipse(brush, points[0].X - RHead, points[0].Y - RHead, RHead * 2, RHead * 2);
                g.DrawLine(MyPen, points[0], points[1]);
                //left hand
                g.DrawLine(MyPen, points[1], points[2]);
                g.DrawLine(MyPen, points[2], points[4]);
                g.DrawLine(MyPen, points[4], points[6]);
                g.DrawLine(MyPen, points[6], points[8]);
                //right end
                g.DrawLine(MyPen, points[1], points[3]);
                g.DrawLine(MyPen, points[3], points[5]);
                g.DrawLine(MyPen, points[5], points[7]);
                g.DrawLine(MyPen, points[7], points[9]);
                //body
                g.DrawLine(MyPen, points[1], points[11]);
                //left foot
                g.DrawLine(MyPen, points[11], points[12]);
                g.DrawLine(MyPen, points[12], points[14]);
                g.DrawLine(MyPen, points[14], points[16]);
                g.DrawLine(MyPen, points[16], points[18]);
                //righ foot
                g.DrawLine(MyPen, points[11], points[13]);
                g.DrawLine(MyPen, points[13], points[15]);
                g.DrawLine(MyPen, points[15], points[17]);
                g.DrawLine(MyPen, points[17], points[19]);

            }

        }

        private void DrawFallingObj(PictureBox picture)
        {
            if ((int)picture.Tag < 255)
            {
                picture.BackColor = Color.FromArgb(255 - (int)picture.Tag, 255 - (int)picture.Tag, 255 - (int)picture.Tag);
                picture.Tag = (int)picture.Tag + 5;

            }
            else
            {
                picture.BackColor = Color.Red;
                picture.Tag = (int)picture.Tag + 5;

            }

        }

        private void GenerateFalling()
        {
            TimeSleep = rand.Next(20, 40);
            int number = rand.Next(2, 5);
            int RangeOfDroped = 600 / number;
            for (int i = 0; i < number; i++)
            {
                PictureBox NewObj = new PictureBox
                {
                    Tag = 0,
                    Width = 50,
                    Height = 50,
                    Left = rand.Next(500 + i * RangeOfDroped, 480 + (i + 1) * RangeOfDroped),
                    Top = rand.Next(100, 700),
                    BackColor = Color.White,
                };
                DropedObj.Add(NewObj);
                ParentControl.Controls.Add(DropedObj[DropedObj.Count - 1]);
            }
        }

        private void Droped(Point[] points)
        {
            if (TimeSleep == 0)
            {
                GenerateFalling();
            }
            else
            {
                TimeSleep--;
            }
            DropedObj.ForEach(x => DrawFallingObj(x));
            RemoveObj(ref DropedObj);
            TakeDamage(points);
        }

        private void RemoveObj(ref List<PictureBox> boxes)
        {
            List<int> RemoveList = new List<int>();
            for (int i = 0; i < boxes.Count; i++)
            {
                if ((int)boxes[i].Tag > 260)
                {
                    ParentControl.Controls.Remove(boxes[i]);
                    RemoveList.Add(i);
                }
            }
            for (int i = 0; i < RemoveList.Count; i++)
            {
                boxes.RemoveAt(RemoveList[i] - i);
            }
        }

        private void TakeDamage(Point[] points)
        {
            for (int i = 0; i < DropedObj.Count; i++)
            {
                if (((int)DropedObj[i].Tag > 255) && HitBox(points[0], DropedObj[i], 25))
                {
                    Dead();
                    return;
                }
                for (int j = 0; j < points.Length; j++)
                {
                    if (((int)DropedObj[i].Tag > 255) && HitBox(points[j], DropedObj[i], 5))
                    {
                        Dead();
                        return;
                    }
                }
            }
        }



        public bool HitBox(Point point, Control control, int range)
        {
            if (point.X + range < control.Left || point.X - range > control.Left + control.Width) return false;
            if (point.Y + range < control.Top || point.Y - range > control.Top + control.Height) return false;
            return true;
        }
        private void Dead()
        {
            MessageBox.Show("Dead");
        }

        public void Update(Point[] points)
        {
            DrawStickMan(points);
            Droped(points);
        }
    }
    class GameCatch : IObserver
    {
        public static string Title
        {
            get
            {
                return "Злови зірку!";
            }
        }
        public static string Description
        {
            get
            {
                return "Вам потрібно зловити якнайбільше зіркок і ухилятися від червоних перепон";
            }
        }
        private int TimeImmortal = 0;
        private Control ParentControl;
        private List<PictureBox> DropedStar = new List<PictureBox>();
        private List<PictureBox> DropedBarrier = new List<PictureBox>();
        private int TimeSleep = 0;

        Random rand = new Random(DateTime.Now.Millisecond);

        private Label ScoreCount = new Label
        {
            Left = 100,
            Top = 130,
            Text = "0"
        };

        private Label Score = new Label
        {
            Left = 50,
            Top = 130,
            MaximumSize = new Size(50, 30),
            Text = "Score: "
        };

        private Label LifeCount = new Label
        {
            Left = 100,
            Top = 100,
            Text = "1"
        };

        private Label Life = new Label
        {
            Left = 50,
            Top = 100,
            MaximumSize = new Size(50, 30),
            Text = "Life: "
        };

        private PictureBox Star = new PictureBox
        {
            Width = 50,
            Height = 50,
            BackColor = Color.Yellow
        };

        private PictureBox Barrier = new PictureBox
        {
            Width = 50,
            Height = 50,
            BackColor = Color.Red
        };

        public GameCatch(Control parentControl)
        {
            ParentControl = parentControl;
            ParentControl.Controls.Add(Life);
            ParentControl.Controls.Add(LifeCount);
            ParentControl.Controls.Add(Score);
            ParentControl.Controls.Add(ScoreCount);
        }

        private void DrawStickMan(Point[] points)
        {
            using (Graphics g = ParentControl.CreateGraphics())
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].X += 500;
                    points[i].Y += 200;
                }
                g.Clear(Color.White);
                Pen MyPen = new Pen(TimeImmortal == 0 ? Color.Black : Color.Gray, 6);
                SolidBrush brush = new SolidBrush(TimeImmortal == 0 ? Color.Black : Color.Gray);
                //head
                float RHead = (float)Math.Pow(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2), 0.5) / 2;
                g.FillEllipse(brush, points[0].X - RHead, points[0].Y - RHead, RHead * 2, RHead * 2);
                g.DrawLine(MyPen, points[0], points[1]);
                //left hand
                g.DrawLine(MyPen, points[1], points[2]);
                g.DrawLine(MyPen, points[2], points[4]);
                g.DrawLine(MyPen, points[4], points[6]);
                g.DrawLine(MyPen, points[6], points[8]);
                //right end
                g.DrawLine(MyPen, points[1], points[3]);
                g.DrawLine(MyPen, points[3], points[5]);
                g.DrawLine(MyPen, points[5], points[7]);
                g.DrawLine(MyPen, points[7], points[9]);
                //body
                g.DrawLine(MyPen, points[1], points[11]);
                //left foot
                g.DrawLine(MyPen, points[11], points[12]);
                g.DrawLine(MyPen, points[12], points[14]);
                g.DrawLine(MyPen, points[14], points[16]);
                g.DrawLine(MyPen, points[16], points[18]);
                //righ foot
                g.DrawLine(MyPen, points[11], points[13]);
                g.DrawLine(MyPen, points[13], points[15]);
                g.DrawLine(MyPen, points[15], points[17]);
                g.DrawLine(MyPen, points[17], points[19]);

            }

        }

        private void GenerateFallingObj()
        {
            TimeSleep = rand.Next(20, 50);
            int number = rand.Next(1, 4);
            int RangeOfDroped = 600 / number;
            for (int i = 0; i < number; i++)
            {
                if (rand.Next(0, 8) < 6)
                {
                    PictureBox NewStar = new PictureBox
                    {
                        Width = 50,
                        Height = 50,
                        BackColor = Color.Yellow
                    };
                    NewStar.Left = rand.Next(500 + i * RangeOfDroped, 480 + (i + 1) * RangeOfDroped);
                    NewStar.Top = rand.Next(-150, -60);

                    DropedStar.Add(NewStar);
                    ParentControl.Controls.Add(DropedStar[DropedStar.Count - 1]);
                }
                else
                {
                    PictureBox NewBarrier = new PictureBox
                    {
                        Width = 50,
                        Height = 50,
                        BackColor = Color.Red
                    };
                    NewBarrier.Left = rand.Next(500 + i * RangeOfDroped, 500 + (i + 1) * RangeOfDroped);
                    NewBarrier.Top = rand.Next(-150, -60);

                    DropedBarrier.Add(NewBarrier);
                    ParentControl.Controls.Add(DropedBarrier[DropedBarrier.Count - 1]);
                }
            }
        }

        private void Droped(Point[] points)
        {
            if (TimeSleep == 0)
            {
                GenerateFallingObj();
            }
            else
            {
                TimeSleep--;
            }
            DropedStar.ForEach(x => x.Top += 10);
            DropedBarrier.ForEach(x => x.Top += 10);
            RemoveObj(ref DropedStar, true);
            RemoveObj(ref DropedBarrier);
            TakeStar(points);
            TakeDamage(points);
        }

        private void RemoveObj(ref List<PictureBox> boxes, bool isStart = false)
        {
            List<int> RemoveList = new List<int>();
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Top > 1100)
                {
                    ParentControl.Controls.Remove(boxes[i]);
                    RemoveList.Add(i);
                }
            }
            if (isStart)
            {
                ScoreCount.Text = Convert.ToString(Convert.ToInt32(ScoreCount.Text) - RemoveList.Count);
            }
            for (int i = 0; i < RemoveList.Count; i++)
            {
                boxes.RemoveAt(RemoveList[i] - i);
            }
        }

        public bool HitBox(Point point, Control control, int range)
        {
            if (point.X + range < control.Left || point.X - range > control.Left + control.Width) return false;
            if (point.Y + range < control.Top || point.Y - range > control.Top + control.Height) return false;
            return true;
        }

        private void TakeStar(Point[] points)
        {
            for (int i = 0; i < DropedStar.Count; i++)
            {
                if (HitBox(points[8], DropedStar[i], 5) || HitBox(points[9], DropedStar[i], 5))
                {
                    ScoreCount.Text = $"{Convert.ToInt32(ScoreCount.Text) + 1}";
                    ParentControl.Controls.Remove(DropedStar[i]);
                    DropedStar.RemoveAt(i);
                    return;
                }
            }
        }

        private void TakeDamage(Point[] points)
        {
            if (TimeImmortal == 0)
            {
                for (int i = 0; i < DropedBarrier.Count; i++)
                {
                    if (HitBox(points[0], DropedBarrier[i], 20))
                    {
                        if (Convert.ToInt32(LifeCount.Text) == 1)
                        {
                            Dead();
                            return;
                        }
                        else
                        {
                            LifeCount.Text = $"{Convert.ToInt32(LifeCount.Text) - 1}";
                            TimeImmortal = 150;
                            return;
                        }

                    }
                }
            }
            else
            {
                TimeImmortal--;
            }
        }

        private void Dead()
        {
            (ParentControl as Form).Close();
        }

        public void Update(Point[] points)
        {
            DrawStickMan(points);
            Droped(points);
        }
    }
}

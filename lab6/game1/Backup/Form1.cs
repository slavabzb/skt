// Decompiled with JetBrains decompiler
// Type: WindowsFormsApplication1.Form1
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9F606FF-DAED-4A08-8703-7BB1647F385A
// Assembly location: F:\ЗИвПС\Начало\lab2\game1.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public class Form1 : Form
  {
    private int element = 1;
    private int[,] arr = new int[3, 3];
    private double micsek = 0.0;
    private double msek = 0.0;
    private int sek = 0;
    private IContainer components = (IContainer) null;
    private bool bDragStatys;
    private Point ClickPoint;
    private int MouseX;
    private int MouseY;
    private Label label1;
    private Timer timer1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem играToolStripMenuItem;
    private ToolStripMenuItem выходToolStripMenuItem;
    private ToolStripMenuItem новаяToolStripMenuItem;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private Timer timer2_GameMetod;
    private Label label2;
    private Timer timer2;
    private ToolStripMenuItem настройкиToolStripMenuItem;
    private ToolStripMenuItem ходToolStripMenuItem;
    private ToolStripMenuItem интеллектИИToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem слабыйToolStripMenuItem1;
    private ToolStripMenuItem сильныйToolStripMenuItem1;
    private ToolStripTextBox toolStripTextBox1;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripTextBox toolStripTextBox2;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripSeparator toolStripSeparator2;
    private Timer timer3;
    private ToolStripMenuItem правилаToolStripMenuItem;

    public Form1()
    {
      this.InitializeComponent();
      this.TransparencyKey = Color.White;
      this.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      this.menuStrip1.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      this.label1.Image = (Image) new Bitmap(this.GetType(), "fonTimer.png");
      this.pictureBox1.Image = (Image) new Bitmap(this.GetType(), "Close.png");
      this.pictureBox2.Image = (Image) new Bitmap(this.GetType(), "Svernut.png");
      this.label2.Image = (Image) new Bitmap(this.GetType(), "fonLabel.png");
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void LineGor(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "LineGor.png");
      graphics.DrawImage(image, x, y, 150, 50);
      graphics.Dispose();
    }

    private void LineVer(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "LineVer.png");
      graphics.DrawImage(image, x, y, 50, 150);
      graphics.Dispose();
    }

    private void Line45(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Line45.png");
      graphics.DrawImage(image, x, y, 150, 150);
      graphics.Dispose();
    }

    private void Line_45(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Line-45.png");
      graphics.DrawImage(image, x, y, 150, 150);
      graphics.Dispose();
    }

    private void Setka(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Setca.png");
      graphics.DrawImage(image, x, y, 150, 150);
      graphics.Dispose();
    }

    private void Krestic(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Krest.png");
      graphics.DrawImage(image, x, y, 50, 50);
      graphics.Dispose();
    }

    private void Nolic(int x, int y)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Nol.png");
      graphics.DrawImage(image, x, y, 50, 50);
      graphics.Dispose();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.NewGame();
    }

    private int Proverka()
    {
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 1 && this.arr[0, 2] == 1)
      {
        this.LineGor(50, 50);
        return 1;
      }
      if (this.arr[1, 0] == 1 && this.arr[1, 1] == 1 && this.arr[1, 2] == 1)
      {
        this.LineGor(50, 100);
        return 1;
      }
      if (this.arr[2, 0] == 1 && this.arr[2, 1] == 1 && this.arr[2, 2] == 1)
      {
        this.LineGor(50, 150);
        return 1;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 0] == 1 && this.arr[2, 0] == 1)
      {
        this.LineVer(50, 50);
        return 1;
      }
      if (this.arr[0, 1] == 1 && this.arr[1, 1] == 1 && this.arr[2, 1] == 1)
      {
        this.LineVer(100, 50);
        return 1;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 2] == 1 && this.arr[2, 2] == 1)
      {
        this.LineVer(150, 50);
        return 1;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 1] == 1 && this.arr[2, 2] == 1)
      {
        this.Line_45(50, 50);
        return 1;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 1] == 1 && this.arr[2, 0] == 1)
      {
        this.Line45(50, 50);
        return 1;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 2 && this.arr[0, 2] == 2)
      {
        this.LineGor(50, 50);
        return 2;
      }
      if (this.arr[1, 0] == 2 && this.arr[1, 1] == 2 && this.arr[1, 2] == 2)
      {
        this.LineGor(50, 100);
        return 2;
      }
      if (this.arr[2, 0] == 2 && this.arr[2, 1] == 2 && this.arr[2, 2] == 2)
      {
        this.LineGor(50, 150);
        return 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[1, 0] == 2 && this.arr[2, 0] == 2)
      {
        this.LineVer(50, 50);
        return 2;
      }
      if (this.arr[0, 1] == 2 && this.arr[1, 1] == 2 && this.arr[2, 1] == 2)
      {
        this.LineVer(100, 50);
        return 2;
      }
      if (this.arr[0, 2] == 2 && this.arr[1, 2] == 2 && this.arr[2, 2] == 2)
      {
        this.LineVer(150, 50);
        return 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[1, 1] == 2 && this.arr[2, 2] == 2)
      {
        this.Line_45(50, 50);
        return 2;
      }
      if (this.arr[0, 2] == 2 && this.arr[1, 1] == 2 && this.arr[2, 0] == 2)
      {
        this.Line45(50, 50);
        return 2;
      }
      return this.arr[0, 0] != 0 && this.arr[0, 1] != 0 && (this.arr[0, 2] != 0 && this.arr[1, 0] != 0) && (this.arr[1, 1] != 0 && this.arr[1, 2] != 0 && (this.arr[2, 0] != 0 && this.arr[2, 1] != 0)) && this.arr[2, 2] != 0 ? 3 : 0;
    }

    private void NewGame()
    {
      this.timer2_GameMetod.Stop();
      this.MouseX = 0;
      this.MouseY = 0;
      this.msek = 0.0;
      this.sek = 0;
      this.timer1.Start();
      this.timer2_GameMetod.Start();
      this.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      int length1 = this.arr.GetLength(0);
      int length2 = this.arr.GetLength(1);
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
          this.arr[index1, index2] = 0;
      }
      if (this.ходToolStripMenuItem.CheckState == CheckState.Checked)
        this.element = 2;
      if (this.интеллектИИToolStripMenuItem.CheckState != CheckState.Checked)
        return;
      this.element = 1;
    }

    private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      this.timer2.Enabled = true;
    }

    private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.NewGame();
    }

    private void Form1_MouseDown_1(object sender, MouseEventArgs e)
    {
      if (e.X > 50 && e.X < 100)
        this.MouseX = 50;
      if (e.X > 100 && e.X < 150)
        this.MouseX = 100;
      if (e.X > 150 && e.X < 200)
        this.MouseX = 150;
      if (e.Y > 50 && e.Y < 100)
        this.MouseY = 50;
      if (e.Y > 100 && e.Y < 150)
        this.MouseY = 100;
      if (e.Y <= 150 || e.Y >= 200)
        return;
      this.MouseY = 150;
    }

    private void timer1_Tick_1(object sender, EventArgs e)
    {
      ++this.msek;
      if (this.msek == 9.0)
      {
        this.msek = 0.0;
        ++this.sek;
      }
      this.label1.Text = " " + Convert.ToString(this.sek) + "." + Convert.ToString(this.msek);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      this.timer2.Enabled = true;
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.bDragStatys = true;
        this.ClickPoint = new Point(e.X, e.Y);
      }
      else
        this.bDragStatys = false;
    }

    private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.bDragStatys)
        return;
      Point screen = this.PointToScreen(new Point(e.X, e.Y));
      screen.Offset(-this.ClickPoint.X, -this.ClickPoint.Y);
      this.Location = screen;
    }

    private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
    {
      this.bDragStatys = false;
    }

    private void AiLow()
    {
      if (this.arr[1, 1] == 0 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.element != 1)
        return;
      Random random = new Random();
      int index1 = random.Next(0, 3);
      int index2 = random.Next(0, 3);
      int x = 0;
      int y = 0;
      if (index1 == 0)
        x = 50;
      if (index1 == 1)
        x = 100;
      if (index1 == 2)
        x = 150;
      if (index2 == 0)
        y = 50;
      if (index2 == 1)
        y = 100;
      if (index2 == 2)
        y = 150;
      if (this.arr[index2, index1] == 0)
      {
        this.arr[index2, index1] = 2;
        this.Nolic(x, y);
        this.element = 2;
      }
    }

    private void AiHard()
    {
      if (this.element != 1)
        return;
      if (this.arr[0, 0] == 2 && this.arr[1, 1] == 2 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[1, 1] == 2 && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[2, 0] == 2 && this.arr[1, 1] == 2 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 2] == 2 && this.arr[1, 1] == 2 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 2 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 2] == 2 && this.arr[0, 1] == 2 && this.arr[0, 0] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[1, 0] == 2 && this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[1, 0] == 0 && this.arr[1, 1] == 2 && this.arr[1, 2] == 2 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[2, 0] == 2 && this.arr[2, 1] == 2 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[2, 2] == 2 && this.arr[2, 1] == 2 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[1, 0] == 2 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[2, 0] == 2 && this.arr[1, 0] == 2 && this.arr[0, 0] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 1] == 2 && this.arr[1, 1] == 2 && this.arr[2, 1] == 0 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[2, 1] == 2 && this.arr[1, 1] == 2 && this.arr[0, 1] == 0 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 2] == 2 && this.arr[1, 2] == 2 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[2, 2] == 2 && this.arr[1, 2] == 2 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 0 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 2) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 2 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
        int num = (int) MessageBox.Show("5");
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 2 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 2)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 2) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 2 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 2 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 2)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 2) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 2 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 2 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 2)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 2 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 2 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 2 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 2 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 0 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 1 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 1 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 1 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 1)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 0) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 1 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 2 && this.arr[0, 1] == 0 && (this.arr[0, 2] == 0 && this.arr[1, 0] == 1) && (this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && (this.arr[2, 0] == 0 && this.arr[2, 1] == 0)) && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[2, 2] == 1 && this.arr[1, 1] == 1 && this.arr[0, 0] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 1] == 1 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 1] == 1 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[2, 0] == 1 && this.arr[1, 1] == 1 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 1 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 2] == 1 && this.arr[0, 1] == 1 && this.arr[0, 0] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[1, 0] == 1 && this.arr[1, 1] == 1 && this.arr[1, 2] == 0 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      if (this.arr[1, 2] == 1 && this.arr[1, 1] == 1 && this.arr[1, 0] == 0 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[2, 0] == 1 && this.arr[2, 1] == 1 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[2, 2] == 1 && this.arr[2, 1] == 1 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 0] == 1 && this.arr[2, 0] == 0 && this.element == 1)
      {
        this.arr[2, 0] = 2;
        this.Nolic(50, 150);
        this.element = 2;
      }
      if (this.arr[2, 0] == 1 && this.arr[1, 0] == 1 && this.arr[0, 0] == 0 && this.element == 1)
      {
        this.arr[0, 0] = 2;
        this.Nolic(50, 50);
        this.element = 2;
      }
      if (this.arr[0, 1] == 1 && this.arr[1, 1] == 1 && this.arr[2, 1] == 0 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[2, 1] == 1 && this.arr[1, 1] == 1 && this.arr[0, 1] == 0 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 2] == 1 && this.arr[2, 2] == 0 && this.element == 1)
      {
        this.arr[2, 2] = 2;
        this.Nolic(150, 150);
        this.element = 2;
      }
      if (this.arr[2, 2] == 1 && this.arr[1, 2] == 1 && this.arr[0, 2] == 0 && this.element == 1)
      {
        this.arr[0, 2] = 2;
        this.Nolic(150, 50);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 1] == 0 && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 1] == 0 && this.arr[2, 0] == 1 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[0, 1] == 0 && this.arr[0, 2] == 1 && this.element == 1)
      {
        this.arr[0, 1] = 2;
        this.Nolic(100, 50);
        this.element = 2;
      }
      if (this.arr[1, 0] == 1 && this.arr[1, 1] == 0 && this.arr[1, 2] == 1 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.arr[2, 0] == 1 && this.arr[2, 1] == 0 && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[2, 1] = 2;
        this.Nolic(100, 150);
        this.element = 2;
      }
      if (this.arr[0, 0] == 1 && this.arr[1, 0] == 0 && this.arr[2, 0] == 1 && this.element == 1)
      {
        this.arr[1, 0] = 2;
        this.Nolic(50, 100);
        this.element = 2;
      }
      if (this.arr[0, 1] == 1 && this.arr[1, 1] == 0 && this.arr[2, 1] == 1 && this.element == 1)
      {
        this.arr[1, 1] = 2;
        this.Nolic(100, 100);
        this.element = 2;
      }
      if (this.arr[0, 2] == 1 && this.arr[1, 2] == 0 && this.arr[2, 2] == 1 && this.element == 1)
      {
        this.arr[1, 2] = 2;
        this.Nolic(150, 100);
        this.element = 2;
      }
      this.AiLow();
    }

    private void timer2_GameMetod_Tick(object sender, EventArgs e)
    {
      int x = this.MouseX;
      int y = this.MouseY;
      if (this.слабыйToolStripMenuItem1.CheckState == CheckState.Checked)
        this.AiLow();
      if (this.сильныйToolStripMenuItem1.CheckState == CheckState.Checked)
        this.AiHard();
      if (this.element == 2)
        this.label2.Text = "Ходит крестик";
      if (this.element == 1)
        this.label2.Text = "Ходит нолик";
      if (this.element == 2 && (x > 0 && x < 200 && y > 0 && y < 200))
      {
        if (x == 50 && y == 50 && this.arr[0, 0] == 0)
        {
          this.arr[0, 0] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 100 && y == 50 && this.arr[0, 1] == 0)
        {
          this.arr[0, 1] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 150 && y == 50 && this.arr[0, 2] == 0)
        {
          this.arr[0, 2] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 50 && y == 100 && this.arr[1, 0] == 0)
        {
          this.arr[1, 0] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 100 && y == 100 && this.arr[1, 1] == 0)
        {
          this.arr[1, 1] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 150 && y == 100 && this.arr[1, 2] == 0)
        {
          this.arr[1, 2] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 50 && y == 150 && this.arr[2, 0] == 0)
        {
          this.arr[2, 0] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 100 && y == 150 && this.arr[2, 1] == 0)
        {
          this.arr[2, 1] = 1;
          this.Krestic(x, y);
          this.element = 1;
          x = 0;
          y = 0;
        }
        if (x == 150 && y == 150 && this.arr[2, 2] == 0)
        {
          this.arr[2, 2] = 1;
          this.Krestic(x, y);
          this.element = 1;
        }
      }
      int num = this.Proverka();
      if (num == 1)
      {
        this.timer2_GameMetod.Stop();
        this.timer2_GameMetod.Dispose();
        this.timer1.Stop();
        this.label2.Text = "Выйграли крестики";
      }
      if (num == 2)
      {
        this.timer2_GameMetod.Stop();
        this.timer2_GameMetod.Dispose();
        this.timer1.Stop();
        this.label2.Text = "Выйграли нолики";
      }
      if (num != 3)
        return;
      this.timer2_GameMetod.Stop();
      this.timer2_GameMetod.Dispose();
      this.timer1.Stop();
      this.label2.Text = "Ничья";
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.Opacity -= 0.1;
      if (this.Opacity > 0.0)
        return;
      this.Close();
    }

    private void ходToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ходToolStripMenuItem.CheckState != CheckState.Checked)
        return;
      this.интеллектИИToolStripMenuItem.CheckState = CheckState.Unchecked;
      this.NewGame();
    }

    private void интеллектИИToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
      if (this.интеллектИИToolStripMenuItem.CheckState != CheckState.Checked)
        return;
      this.ходToolStripMenuItem.CheckState = CheckState.Unchecked;
      this.NewGame();
    }

    private void слабыйToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.слабыйToolStripMenuItem1.CheckState != CheckState.Checked)
        return;
      this.сильныйToolStripMenuItem1.CheckState = CheckState.Unchecked;
      this.NewGame();
    }

    private void сильныйToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.сильныйToolStripMenuItem1.CheckState != CheckState.Checked)
        return;
      this.слабыйToolStripMenuItem1.CheckState = CheckState.Unchecked;
      this.NewGame();
    }

    private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики). Первый, выстроивший в ряд 3 своих фигур по вертикали, горизонтали или диагонали, выигрывает. В настройках игры можно менять уровень интеллекта Искуственного Разума.");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.label1 = new Label();
      this.timer1 = new Timer(this.components);
      this.menuStrip1 = new MenuStrip();
      this.играToolStripMenuItem = new ToolStripMenuItem();
      this.новаяToolStripMenuItem = new ToolStripMenuItem();
      this.выходToolStripMenuItem = new ToolStripMenuItem();
      this.настройкиToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripTextBox2 = new ToolStripTextBox();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.ходToolStripMenuItem = new ToolStripMenuItem();
      this.интеллектИИToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripTextBox1 = new ToolStripTextBox();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.слабыйToolStripMenuItem1 = new ToolStripMenuItem();
      this.сильныйToolStripMenuItem1 = new ToolStripMenuItem();
      this.pictureBox1 = new PictureBox();
      this.pictureBox2 = new PictureBox();
      this.timer2_GameMetod = new Timer(this.components);
      this.label2 = new Label();
      this.timer2 = new Timer(this.components);
      this.timer3 = new Timer(this.components);
      this.правилаToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.label1.BackColor = Color.WhiteSmoke;
      this.label1.Font = new Font("Segoe Script", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label1.ForeColor = Color.Blue;
      this.label1.Location = new Point(10, 200);
      this.label1.MaximumSize = new Size(0, 100);
      this.label1.MinimumSize = new Size(100, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(100, 25);
      this.label1.TabIndex = 0;
      this.timer1.Enabled = true;
      this.timer1.Tick += new EventHandler(this.timer1_Tick_1);
      this.menuStrip1.BackColor = Color.WhiteSmoke;
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.играToolStripMenuItem,
        (ToolStripItem) this.настройкиToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(250, 31);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.MouseUp += new MouseEventHandler(this.menuStrip1_MouseUp);
      this.menuStrip1.MouseDown += new MouseEventHandler(this.menuStrip1_MouseDown);
      this.menuStrip1.MouseMove += new MouseEventHandler(this.menuStrip1_MouseMove);
      this.играToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.новаяToolStripMenuItem,
        (ToolStripItem) this.правилаToolStripMenuItem,
        (ToolStripItem) this.выходToolStripMenuItem
      });
      this.играToolStripMenuItem.Font = new Font("Segoe Print", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.играToolStripMenuItem.ForeColor = Color.Blue;
      this.играToolStripMenuItem.Name = "играToolStripMenuItem";
      this.играToolStripMenuItem.Size = new Size(56, 27);
      this.играToolStripMenuItem.Text = "Игра";
      this.новаяToolStripMenuItem.ForeColor = Color.Blue;
      this.новаяToolStripMenuItem.Name = "новаяToolStripMenuItem";
      this.новаяToolStripMenuItem.Size = new Size(158, 28);
      this.новаяToolStripMenuItem.Text = "Новая Игра";
      this.новаяToolStripMenuItem.Click += new EventHandler(this.новаяToolStripMenuItem_Click);
      this.выходToolStripMenuItem.ForeColor = Color.Blue;
      this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      this.выходToolStripMenuItem.Size = new Size(158, 28);
      this.выходToolStripMenuItem.Text = "Выход";
      this.выходToolStripMenuItem.Click += new EventHandler(this.выходToolStripMenuItem_Click_1);
      this.настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripTextBox2,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.ходToolStripMenuItem,
        (ToolStripItem) this.интеллектИИToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripTextBox1,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.слабыйToolStripMenuItem1,
        (ToolStripItem) this.сильныйToolStripMenuItem1
      });
      this.настройкиToolStripMenuItem.Font = new Font("Segoe Script", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.настройкиToolStripMenuItem.ForeColor = Color.Blue;
      this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
      this.настройкиToolStripMenuItem.Size = new Size(105, 27);
      this.настройкиToolStripMenuItem.Text = "Настройки";
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(159, 6);
      this.toolStripTextBox2.BorderStyle = BorderStyle.None;
      this.toolStripTextBox2.ForeColor = Color.Blue;
      this.toolStripTextBox2.Name = "toolStripTextBox2";
      this.toolStripTextBox2.ReadOnly = true;
      this.toolStripTextBox2.Size = new Size(100, 16);
      this.toolStripTextBox2.Text = "Первый ход";
      this.toolStripTextBox2.TextBoxTextAlign = HorizontalAlignment.Center;
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(159, 6);
      this.ходToolStripMenuItem.Checked = true;
      this.ходToolStripMenuItem.CheckOnClick = true;
      this.ходToolStripMenuItem.CheckState = CheckState.Checked;
      this.ходToolStripMenuItem.ForeColor = Color.Blue;
      this.ходToolStripMenuItem.Name = "ходToolStripMenuItem";
      this.ходToolStripMenuItem.Size = new Size(162, 24);
      this.ходToolStripMenuItem.Text = "Человек";
      this.ходToolStripMenuItem.CheckedChanged += new EventHandler(this.ходToolStripMenuItem_CheckedChanged);
      this.интеллектИИToolStripMenuItem.CheckOnClick = true;
      this.интеллектИИToolStripMenuItem.ForeColor = Color.Blue;
      this.интеллектИИToolStripMenuItem.Name = "интеллектИИToolStripMenuItem";
      this.интеллектИИToolStripMenuItem.Size = new Size(162, 24);
      this.интеллектИИToolStripMenuItem.Text = "Компьютер";
      this.интеллектИИToolStripMenuItem.CheckedChanged += new EventHandler(this.интеллектИИToolStripMenuItem_CheckedChanged);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(159, 6);
      this.toolStripTextBox1.ForeColor = Color.Blue;
      this.toolStripTextBox1.Name = "toolStripTextBox1";
      this.toolStripTextBox1.ReadOnly = true;
      this.toolStripTextBox1.Size = new Size(100, 23);
      this.toolStripTextBox1.Tag = (object) "";
      this.toolStripTextBox1.Text = "Интеллект";
      this.toolStripTextBox1.TextBoxTextAlign = HorizontalAlignment.Center;
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(159, 6);
      this.слабыйToolStripMenuItem1.Checked = true;
      this.слабыйToolStripMenuItem1.CheckOnClick = true;
      this.слабыйToolStripMenuItem1.CheckState = CheckState.Checked;
      this.слабыйToolStripMenuItem1.ForeColor = Color.Blue;
      this.слабыйToolStripMenuItem1.Name = "слабыйToolStripMenuItem1";
      this.слабыйToolStripMenuItem1.Size = new Size(162, 24);
      this.слабыйToolStripMenuItem1.Text = "Слабый";
      this.слабыйToolStripMenuItem1.CheckedChanged += new EventHandler(this.слабыйToolStripMenuItem1_CheckedChanged);
      this.сильныйToolStripMenuItem1.CheckOnClick = true;
      this.сильныйToolStripMenuItem1.ForeColor = Color.Blue;
      this.сильныйToolStripMenuItem1.Name = "сильныйToolStripMenuItem1";
      this.сильныйToolStripMenuItem1.Size = new Size(162, 24);
      this.сильныйToolStripMenuItem1.Text = "Сильный";
      this.сильныйToolStripMenuItem1.CheckedChanged += new EventHandler(this.сильныйToolStripMenuItem1_CheckedChanged);
      this.pictureBox1.Location = new Point(225, 5);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(20, 20);
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.pictureBox2.Location = new Point(205, 5);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(20, 20);
      this.pictureBox2.TabIndex = 3;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
      this.timer2_GameMetod.Enabled = true;
      this.timer2_GameMetod.Interval = 20;
      this.timer2_GameMetod.Tick += new EventHandler(this.timer2_GameMetod_Tick);
      this.label2.Font = new Font("Segoe Script", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.label2.ForeColor = Color.Blue;
      this.label2.Location = new Point(25, 230);
      this.label2.MaximumSize = new Size(0, 200);
      this.label2.MinimumSize = new Size(200, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(200, 25);
      this.label2.TabIndex = 4;
      this.label2.Text = "label2";
      this.timer2.Interval = 50;
      this.timer2.Tick += new EventHandler(this.timer2_Tick);
      this.timer3.Interval = 50;
      this.правилаToolStripMenuItem.ForeColor = Color.Blue;
      this.правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
      this.правилаToolStripMenuItem.Size = new Size(158, 28);
      this.правилаToolStripMenuItem.Text = "Правила";
      this.правилаToolStripMenuItem.Click += new EventHandler(this.правилаToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(250, 260);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.menuStrip1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new EventHandler(this.Form1_Load);
      this.Paint += new PaintEventHandler(this.Form1_Paint);
      this.MouseDown += new MouseEventHandler(this.Form1_MouseDown_1);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

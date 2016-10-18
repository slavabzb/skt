// Decompiled with JetBrains decompiler
// Type: WindowsFormsApplication1.Form1
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3EF4DAD-8681-4EF5-8DA7-E991D37A0FDE
// Assembly location: F:\ЗИвПС\Начало\lab\game.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public class Form1 : Form
  {
    private int a1 = 1;
    private int[,] b1 = new int[3, 3];
    private double c1 = 0.0;
    private double d1 = 0.0;
    private int e1 = 0;
    private IContainer j1 = (IContainer) null;
    private bool f1;
    private Point g1;
    private int h1;
    private int i1;
    private Label k1;
    private Timer l1;
    private MenuStrip m1;
    private ToolStripMenuItem n;
    private ToolStripMenuItem o;
    private ToolStripMenuItem p;
    private PictureBox q;
    private PictureBox r;
    private Timer s;
    private Label t;
    private Timer u;
    private ToolStripMenuItem v;
    private ToolStripMenuItem w;
    private ToolStripMenuItem x;
    private ToolStripSeparator y;
    private ToolStripMenuItem z;
    private ToolStripMenuItem aa;
    private ToolStripTextBox ab;
    private ToolStripSeparator ac;
    private ToolStripTextBox ad;
    private ToolStripSeparator ae;
    private ToolStripSeparator af;
    private Timer ag;
    private ToolStripMenuItem ah;

    public Form1()
    {
      this.a();
      this.TransparencyKey = Color.White;
      this.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      this.m1.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      this.k1.Image = (Image) new Bitmap(this.GetType(), "fonTimer.png");
      this.q.Image = (Image) new Bitmap(this.GetType(), "Close.png");
      this.r.Image = (Image) new Bitmap(this.GetType(), "Svernut.png");
      this.t.Image = (Image) new Bitmap(this.GetType(), "fonLabel.png");
    }

    private void a(object A_0, PaintEventArgs A_1)
    {
    }

    private void g(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "LineGor.png");
      graphics.DrawImage(image, A_0, A_1, 150, 50);
      graphics.Dispose();
    }

    private void f(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "LineVer.png");
      graphics.DrawImage(image, A_0, A_1, 50, 150);
      graphics.Dispose();
    }

    private void e(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Line45.png");
      graphics.DrawImage(image, A_0, A_1, 150, 150);
      graphics.Dispose();
    }

    private void d(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Line-45.png");
      graphics.DrawImage(image, A_0, A_1, 150, 150);
      graphics.Dispose();
    }

    private void c(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Setca.png");
      graphics.DrawImage(image, A_0, A_1, 150, 150);
      graphics.Dispose();
    }

    private void b(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Krest.png");
      graphics.DrawImage(image, A_0, A_1, 50, 50);
      graphics.Dispose();
    }

    private void a(int A_0, int A_1)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      Image image = (Image) new Bitmap(this.GetType(), "Nol.png");
      graphics.DrawImage(image, A_0, A_1, 50, 50);
      graphics.Dispose();
    }

    private void m(object A_0, EventArgs A_1)
    {
      this.d();
    }

    private int e()
    {
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 1 && this.b1[0, 2] == 1)
      {
        this.g(50, 50);
        return 1;
      }
      if (this.b1[1, 0] == 1 && this.b1[1, 1] == 1 && this.b1[1, 2] == 1)
      {
        this.g(50, 100);
        return 1;
      }
      if (this.b1[2, 0] == 1 && this.b1[2, 1] == 1 && this.b1[2, 2] == 1)
      {
        this.g(50, 150);
        return 1;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 0] == 1 && this.b1[2, 0] == 1)
      {
        this.f(50, 50);
        return 1;
      }
      if (this.b1[0, 1] == 1 && this.b1[1, 1] == 1 && this.b1[2, 1] == 1)
      {
        this.f(100, 50);
        return 1;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 2] == 1 && this.b1[2, 2] == 1)
      {
        this.f(150, 50);
        return 1;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 1] == 1 && this.b1[2, 2] == 1)
      {
        this.d(50, 50);
        return 1;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 1] == 1 && this.b1[2, 0] == 1)
      {
        this.e(50, 50);
        return 1;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 2 && this.b1[0, 2] == 2)
      {
        this.g(50, 50);
        return 2;
      }
      if (this.b1[1, 0] == 2 && this.b1[1, 1] == 2 && this.b1[1, 2] == 2)
      {
        this.g(50, 100);
        return 2;
      }
      if (this.b1[2, 0] == 2 && this.b1[2, 1] == 2 && this.b1[2, 2] == 2)
      {
        this.g(50, 150);
        return 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[1, 0] == 2 && this.b1[2, 0] == 2)
      {
        this.f(50, 50);
        return 2;
      }
      if (this.b1[0, 1] == 2 && this.b1[1, 1] == 2 && this.b1[2, 1] == 2)
      {
        this.f(100, 50);
        return 2;
      }
      if (this.b1[0, 2] == 2 && this.b1[1, 2] == 2 && this.b1[2, 2] == 2)
      {
        this.f(150, 50);
        return 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[1, 1] == 2 && this.b1[2, 2] == 2)
      {
        this.d(50, 50);
        return 2;
      }
      if (this.b1[0, 2] == 2 && this.b1[1, 1] == 2 && this.b1[2, 0] == 2)
      {
        this.e(50, 50);
        return 2;
      }
      return this.b1[0, 0] != 0 && this.b1[0, 1] != 0 && (this.b1[0, 2] != 0 && this.b1[1, 0] != 0) && (this.b1[1, 1] != 0 && this.b1[1, 2] != 0 && (this.b1[2, 0] != 0 && this.b1[2, 1] != 0)) && this.b1[2, 2] != 0 ? 3 : 0;
    }

    private void d()
    {
      this.s.Stop();
      this.h1 = 0;
      this.i1 = 0;
      this.d1 = 0.0;
      this.e1 = 0;
      this.l1.Start();
      this.s.Start();
      this.BackgroundImage = (Image) new Bitmap(this.GetType(), "FonSetka.png");
      int length1 = this.b1.GetLength(0);
      int length2 = this.b1.GetLength(1);
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
          this.b1[index1, index2] = 0;
      }
      if (this.w.CheckState == CheckState.Checked)
        this.a1 = 2;
      if (this.x.CheckState != CheckState.Checked)
        return;
      this.a1 = 1;
    }

    private void l(object A_0, EventArgs A_1)
    {
      this.u.Enabled = true;
    }

    private void k(object A_0, EventArgs A_1)
    {
      this.d();
    }

    private void d(object A_0, MouseEventArgs A_1)
    {
      if (A_1.X > 50 && A_1.X < 100)
        this.h1 = 50;
      if (A_1.X > 100 && A_1.X < 150)
        this.h1 = 100;
      if (A_1.X > 150 && A_1.X < 200)
        this.h1 = 150;
      if (A_1.Y > 50 && A_1.Y < 100)
        this.i1 = 50;
      if (A_1.Y > 100 && A_1.Y < 150)
        this.i1 = 100;
      if (A_1.Y <= 150 || A_1.Y >= 200)
        return;
      this.i1 = 150;
    }

    private void j(object A_0, EventArgs A_1)
    {
      ++this.d1;
      if (this.d1 == 9.0)
      {
        this.d1 = 0.0;
        ++this.e1;
      }
      this.k1.Text = " " + Convert.ToString(this.e1) + "." + Convert.ToString(this.d1);
    }

    private void i(object A_0, EventArgs A_1)
    {
      this.u.Enabled = true;
    }

    private void h(object A_0, EventArgs A_1)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void c(object A_0, MouseEventArgs A_1)
    {
      if (A_1.Button == MouseButtons.Left)
      {
        this.f1 = true;
        this.g1 = new Point(A_1.X, A_1.Y);
      }
      else
        this.f1 = false;
    }

    private void b(object A_0, MouseEventArgs A_1)
    {
      if (!this.f1)
        return;
      Point screen = this.PointToScreen(new Point(A_1.X, A_1.Y));
      screen.Offset(-this.g1.X, -this.g1.Y);
      this.Location = screen;
    }

    private void a(object A_0, MouseEventArgs A_1)
    {
      this.f1 = false;
    }

    private void c()
    {
      if (this.b1[1, 1] == 0 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.a1 != 1)
        return;
      Random random = new Random();
      int index1 = random.Next(0, 3);
      int index2 = random.Next(0, 3);
      int A_0 = 0;
      int A_1 = 0;
      if (index1 == 0)
        A_0 = 50;
      if (index1 == 1)
        A_0 = 100;
      if (index1 == 2)
        A_0 = 150;
      if (index2 == 0)
        A_1 = 50;
      if (index2 == 1)
        A_1 = 100;
      if (index2 == 2)
        A_1 = 150;
      if (this.b1[index2, index1] == 0)
      {
        this.b1[index2, index1] = 2;
        this.a(A_0, A_1);
        this.a1 = 2;
      }
    }

    private void b()
    {
      if (this.a1 != 1)
        return;
      if (this.b1[0, 0] == 2 && this.b1[1, 1] == 2 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[1, 1] == 2 && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 2 && this.b1[1, 1] == 2 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 2 && this.b1[1, 1] == 2 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 2 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 2 && this.b1[0, 1] == 2 && this.b1[0, 0] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[1, 0] == 2 && this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[1, 0] == 0 && this.b1[1, 1] == 2 && this.b1[1, 2] == 2 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 2 && this.b1[2, 1] == 2 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 2] == 2 && this.b1[2, 1] == 2 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[1, 0] == 2 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 2 && this.b1[1, 0] == 2 && this.b1[0, 0] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 1] == 2 && this.b1[1, 1] == 2 && this.b1[2, 1] == 0 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 1] == 2 && this.b1[1, 1] == 2 && this.b1[0, 1] == 0 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 2 && this.b1[1, 2] == 2 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 2] == 2 && this.b1[1, 2] == 2 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 0 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 2) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 2 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
        int num = (int) MessageBox.Show("5");
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 2 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 2)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 2) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 2 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 2 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 2)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 2) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 2 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 2 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 2)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 2 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 2 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 2 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 2 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 0 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 1 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 1 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 1 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 1)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 0) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 1 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 2 && this.b1[0, 1] == 0 && (this.b1[0, 2] == 0 && this.b1[1, 0] == 1) && (this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && (this.b1[2, 0] == 0 && this.b1[2, 1] == 0)) && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[2, 2] == 1 && this.b1[1, 1] == 1 && this.b1[0, 0] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 1] == 1 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 1] == 1 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 1 && this.b1[1, 1] == 1 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 1 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 1 && this.b1[0, 1] == 1 && this.b1[0, 0] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[1, 0] == 1 && this.b1[1, 1] == 1 && this.b1[1, 2] == 0 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      if (this.b1[1, 2] == 1 && this.b1[1, 1] == 1 && this.b1[1, 0] == 0 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 1 && this.b1[2, 1] == 1 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 2] == 1 && this.b1[2, 1] == 1 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 0] == 1 && this.b1[2, 0] == 0 && this.a1 == 1)
      {
        this.b1[2, 0] = 2;
        this.a(50, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 1 && this.b1[1, 0] == 1 && this.b1[0, 0] == 0 && this.a1 == 1)
      {
        this.b1[0, 0] = 2;
        this.a(50, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 1] == 1 && this.b1[1, 1] == 1 && this.b1[2, 1] == 0 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 1] == 1 && this.b1[1, 1] == 1 && this.b1[0, 1] == 0 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 2] == 1 && this.b1[2, 2] == 0 && this.a1 == 1)
      {
        this.b1[2, 2] = 2;
        this.a(150, 150);
        this.a1 = 2;
      }
      if (this.b1[2, 2] == 1 && this.b1[1, 2] == 1 && this.b1[0, 2] == 0 && this.a1 == 1)
      {
        this.b1[0, 2] = 2;
        this.a(150, 50);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 1] == 0 && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 1] == 0 && this.b1[2, 0] == 1 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[0, 1] == 0 && this.b1[0, 2] == 1 && this.a1 == 1)
      {
        this.b1[0, 1] = 2;
        this.a(100, 50);
        this.a1 = 2;
      }
      if (this.b1[1, 0] == 1 && this.b1[1, 1] == 0 && this.b1[1, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.b1[2, 0] == 1 && this.b1[2, 1] == 0 && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[2, 1] = 2;
        this.a(100, 150);
        this.a1 = 2;
      }
      if (this.b1[0, 0] == 1 && this.b1[1, 0] == 0 && this.b1[2, 0] == 1 && this.a1 == 1)
      {
        this.b1[1, 0] = 2;
        this.a(50, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 1] == 1 && this.b1[1, 1] == 0 && this.b1[2, 1] == 1 && this.a1 == 1)
      {
        this.b1[1, 1] = 2;
        this.a(100, 100);
        this.a1 = 2;
      }
      if (this.b1[0, 2] == 1 && this.b1[1, 2] == 0 && this.b1[2, 2] == 1 && this.a1 == 1)
      {
        this.b1[1, 2] = 2;
        this.a(150, 100);
        this.a1 = 2;
      }
      this.c();
    }

    private void g(object A_0, EventArgs A_1)
    {
      int A_0_1 = this.h1;
      int A_1_1 = this.i1;
      if (this.z.CheckState == CheckState.Checked)
        this.c();
      if (this.aa.CheckState == CheckState.Checked)
        this.b();
      if (this.a1 == 2)
        this.t.Text = "Ходит крестик";
      if (this.a1 == 1)
        this.t.Text = "Ходит нолик";
      if (this.a1 == 2 && (A_0_1 > 0 && A_0_1 < 200 && A_1_1 > 0 && A_1_1 < 200))
      {
        if (A_0_1 == 50 && A_1_1 == 50 && this.b1[0, 0] == 0)
        {
          this.b1[0, 0] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 100 && A_1_1 == 50 && this.b1[0, 1] == 0)
        {
          this.b1[0, 1] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 150 && A_1_1 == 50 && this.b1[0, 2] == 0)
        {
          this.b1[0, 2] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 50 && A_1_1 == 100 && this.b1[1, 0] == 0)
        {
          this.b1[1, 0] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 100 && A_1_1 == 100 && this.b1[1, 1] == 0)
        {
          this.b1[1, 1] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 150 && A_1_1 == 100 && this.b1[1, 2] == 0)
        {
          this.b1[1, 2] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 50 && A_1_1 == 150 && this.b1[2, 0] == 0)
        {
          this.b1[2, 0] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 100 && A_1_1 == 150 && this.b1[2, 1] == 0)
        {
          this.b1[2, 1] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
          A_0_1 = 0;
          A_1_1 = 0;
        }
        if (A_0_1 == 150 && A_1_1 == 150 && this.b1[2, 2] == 0)
        {
          this.b1[2, 2] = 1;
          this.b(A_0_1, A_1_1);
          this.a1 = 1;
        }
      }
      int num = this.e();
      if (num == 1)
      {
        this.s.Stop();
        this.s.Dispose();
        this.l1.Stop();
        this.t.Text = "Выйграли крестики";
      }
      if (num == 2)
      {
        this.s.Stop();
        this.s.Dispose();
        this.l1.Stop();
        this.t.Text = "Выйграли крестики";
      }
      if (num != 3)
        return;
      this.s.Stop();
      this.s.Dispose();
      this.l1.Stop();
      this.t.Text = "Выйграли крестики";
    }

    private void f(object A_0, EventArgs A_1)
    {
      this.Opacity -= 0.1;
      if (this.Opacity > 0.0)
        return;
      this.Close();
    }

    private void e(object A_0, EventArgs A_1)
    {
      if (this.w.CheckState != CheckState.Checked)
        return;
      this.x.CheckState = CheckState.Unchecked;
      this.d();
    }

    private void d(object A_0, EventArgs A_1)
    {
      if (this.x.CheckState != CheckState.Checked)
        return;
      this.w.CheckState = CheckState.Unchecked;
      this.d();
    }

    private void c(object A_0, EventArgs A_1)
    {
      if (this.z.CheckState != CheckState.Checked)
        return;
      this.aa.CheckState = CheckState.Unchecked;
      this.d();
    }

    private void b(object A_0, EventArgs A_1)
    {
      if (this.aa.CheckState != CheckState.Checked)
        return;
      this.z.CheckState = CheckState.Unchecked;
      this.d();
    }

    private void a(object A_0, EventArgs A_1)
    {
      int num = (int) MessageBox.Show("Игроки по очереди ставят на свободные клетки поля 3х3 знаки (один всегда крестики, другой всегда нолики). Первый, выстроивший в ряд 3 своих фигур по вертикали, горизонтали или диагонали, выигрывает. В настройках игры можно менять уровень интеллекта Искуственного Разума.");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.j1 != null)
        this.j1.Dispose();
      base.Dispose(disposing);
    }

    private void a()
    {
      this.j1 = (IContainer) new Container();
      this.k1 = new Label();
      this.l1 = new Timer(this.j1);
      this.m1 = new MenuStrip();
      this.n = new ToolStripMenuItem();
      this.p = new ToolStripMenuItem();
      this.o = new ToolStripMenuItem();
      this.v = new ToolStripMenuItem();
      this.ac = new ToolStripSeparator();
      this.ad = new ToolStripTextBox();
      this.ae = new ToolStripSeparator();
      this.w = new ToolStripMenuItem();
      this.x = new ToolStripMenuItem();
      this.y = new ToolStripSeparator();
      this.ab = new ToolStripTextBox();
      this.af = new ToolStripSeparator();
      this.z = new ToolStripMenuItem();
      this.aa = new ToolStripMenuItem();
      this.q = new PictureBox();
      this.r = new PictureBox();
      this.s = new Timer(this.j1);
      this.t = new Label();
      this.u = new Timer(this.j1);
      this.ag = new Timer(this.j1);
      this.ah = new ToolStripMenuItem();
      this.m1.SuspendLayout();
      ((ISupportInitialize) this.q).BeginInit();
      ((ISupportInitialize) this.r).BeginInit();
      this.SuspendLayout();
      this.k1.BackColor = Color.WhiteSmoke;
      this.k1.Font = new Font("Segoe Script", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.k1.ForeColor = Color.Blue;
      this.k1.Location = new Point(10, 200);
      this.k1.MaximumSize = new Size(0, 100);
      this.k1.MinimumSize = new Size(100, 0);
      this.k1.Name = "label1";
      this.k1.Size = new Size(100, 25);
      this.k1.TabIndex = 0;
      this.l1.Enabled = true;
      this.l1.Tick += new EventHandler(this.j);
      this.m1.BackColor = Color.WhiteSmoke;
      this.m1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.n,
        (ToolStripItem) this.v
      });
      this.m1.Location = new Point(0, 0);
      this.m1.Name = "menuStrip1";
      this.m1.Size = new Size(250, 31);
      this.m1.TabIndex = 1;
      this.m1.Text = "menuStrip1";
      this.m1.MouseUp += new MouseEventHandler(this.a);
      this.m1.MouseDown += new MouseEventHandler(this.c);
      this.m1.MouseMove += new MouseEventHandler(this.b);
      this.n.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.p,
        (ToolStripItem) this.ah,
        (ToolStripItem) this.o
      });
      this.n.Font = new Font("Segoe Print", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.n.ForeColor = Color.Blue;
      this.n.Name = "играToolStripMenuItem";
      this.n.Size = new Size(56, 27);
      this.n.Text = "Игра";
      this.p.ForeColor = Color.Blue;
      this.p.Name = "новаяToolStripMenuItem";
      this.p.Size = new Size(158, 28);
      this.p.Text = "Новая Игра";
      this.p.Click += new EventHandler(this.k);
      this.o.ForeColor = Color.Blue;
      this.o.Name = "выходToolStripMenuItem";
      this.o.Size = new Size(158, 28);
      this.o.Text = "Выход";
      this.o.Click += new EventHandler(this.l);
      this.v.DropDownItems.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.ac,
        (ToolStripItem) this.ad,
        (ToolStripItem) this.ae,
        (ToolStripItem) this.w,
        (ToolStripItem) this.x,
        (ToolStripItem) this.y,
        (ToolStripItem) this.ab,
        (ToolStripItem) this.af,
        (ToolStripItem) this.z,
        (ToolStripItem) this.aa
      });
      this.v.Font = new Font("Segoe Script", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.v.ForeColor = Color.Blue;
      this.v.Name = "настройкиToolStripMenuItem";
      this.v.Size = new Size(105, 27);
      this.v.Text = "Настройки";
      this.ac.Name = "toolStripSeparator3";
      this.ac.Size = new Size(159, 6);
      this.ad.BorderStyle = BorderStyle.None;
      this.ad.ForeColor = Color.Blue;
      this.ad.Name = "toolStripTextBox2";
      this.ad.ReadOnly = true;
      this.ad.Size = new Size(100, 16);
      this.ad.Text = "Первый ход";
      this.ad.TextBoxTextAlign = HorizontalAlignment.Center;
      this.ae.Name = "toolStripSeparator4";
      this.ae.Size = new Size(159, 6);
      this.w.Checked = true;
      this.w.CheckOnClick = true;
      this.w.CheckState = CheckState.Checked;
      this.w.ForeColor = Color.Blue;
      this.w.Name = "ходToolStripMenuItem";
      this.w.Size = new Size(162, 24);
      this.w.Text = "Человек";
      this.w.CheckedChanged += new EventHandler(this.e);
      this.x.CheckOnClick = true;
      this.x.ForeColor = Color.Blue;
      this.x.Name = "интеллектИИToolStripMenuItem";
      this.x.Size = new Size(162, 24);
      this.x.Text = "Компьютер";
      this.x.CheckedChanged += new EventHandler(this.d);
      this.y.Name = "toolStripSeparator1";
      this.y.Size = new Size(159, 6);
      this.ab.ForeColor = Color.Blue;
      this.ab.Name = "toolStripTextBox1";
      this.ab.ReadOnly = true;
      this.ab.Size = new Size(100, 23);
      this.ab.Tag = (object) "";
      this.ab.Text = "Интеллект";
      this.ab.TextBoxTextAlign = HorizontalAlignment.Center;
      this.af.Name = "toolStripSeparator2";
      this.af.Size = new Size(159, 6);
      this.z.Checked = true;
      this.z.CheckOnClick = true;
      this.z.CheckState = CheckState.Checked;
      this.z.ForeColor = Color.Blue;
      this.z.Name = "слабыйToolStripMenuItem1";
      this.z.Size = new Size(162, 24);
      this.z.Text = "Слабый";
      this.z.CheckedChanged += new EventHandler(this.c);
      this.aa.CheckOnClick = true;
      this.aa.ForeColor = Color.Blue;
      this.aa.Name = "сильныйToolStripMenuItem1";
      this.aa.Size = new Size(162, 24);
      this.aa.Text = "Сильный";
      this.aa.CheckedChanged += new EventHandler(this.b);
      this.q.Location = new Point(225, 5);
      this.q.Name = "pictureBox1";
      this.q.Size = new Size(20, 20);
      this.q.TabIndex = 2;
      this.q.TabStop = false;
      this.q.Click += new EventHandler(this.i);
      this.r.Location = new Point(205, 5);
      this.r.Name = "pictureBox2";
      this.r.Size = new Size(20, 20);
      this.r.TabIndex = 3;
      this.r.TabStop = false;
      this.r.Click += new EventHandler(this.h);
      this.s.Enabled = true;
      this.s.Interval = 20;
      this.s.Tick += new EventHandler(this.g);
      this.t.Font = new Font("Segoe Script", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
      this.t.ForeColor = Color.Blue;
      this.t.Location = new Point(25, 230);
      this.t.MaximumSize = new Size(0, 200);
      this.t.MinimumSize = new Size(200, 0);
      this.t.Name = "label2";
      this.t.Size = new Size(200, 25);
      this.t.TabIndex = 4;
      this.t.Text = "label2";
      this.u.Interval = 50;
      this.u.Tick += new EventHandler(this.f);
      this.ag.Interval = 50;
      this.ah.ForeColor = Color.Blue;
      this.ah.Name = "правилаToolStripMenuItem";
      this.ah.Size = new Size(158, 28);
      this.ah.Text = "Правила";
      this.ah.Click += new EventHandler(this.a);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(250, 260);
      this.Controls.Add((Control) this.t);
      this.Controls.Add((Control) this.r);
      this.Controls.Add((Control) this.q);
      this.Controls.Add((Control) this.k1);
      this.Controls.Add((Control) this.m1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MainMenuStrip = this.m1;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new EventHandler(this.m);
      this.Paint += new PaintEventHandler(this.a);
      this.MouseDown += new MouseEventHandler(this.d);
      this.m1.ResumeLayout(false);
      this.m1.PerformLayout();
      ((ISupportInitialize) this.q).EndInit();
      ((ISupportInitialize) this.r).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

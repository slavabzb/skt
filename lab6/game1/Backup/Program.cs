// Decompiled with JetBrains decompiler
// Type: WindowsFormsApplication1.Program
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9F606FF-DAED-4A08-8703-7BB1647F385A
// Assembly location: F:\ЗИвПС\Начало\lab2\game1.exe

using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}

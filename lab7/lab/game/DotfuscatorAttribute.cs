// Decompiled with JetBrains decompiler
// Type: DotfuscatorAttribute
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3EF4DAD-8681-4EF5-8DA7-E991D37A0FDE
// Assembly location: F:\ЗИвПС\Начало\lab\game.exe

using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Assembly)]
[ComVisible(false)]
public sealed class DotfuscatorAttribute : Attribute
{
  private string a1;
  private int c1;

  public string A
  {
    get
    {
      return this.a1;
    }
  }

  public int C
  {
    get
    {
      return this.c1;
    }
  }

  public DotfuscatorAttribute(string a, int c)
  {
    DotfuscatorAttribute dotfuscatorAttribute = this;
    // ISSUE: explicit constructor call
    // dotfuscatorAttribute.\u002Ector();
    string str = a;
    dotfuscatorAttribute.a1 = str;
    this.c1 = c;
  }

  public string a()
  {
    return this.a1;
  }

  public int c()
  {
    return this.c1;
  }
}

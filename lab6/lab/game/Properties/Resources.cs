// Decompiled with JetBrains decompiler
// Type: WindowsFormsApplication1.Properties.Resources
// Assembly: WindowsFormsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3EF4DAD-8681-4EF5-8DA7-E991D37A0FDE
// Assembly location: F:\ЗИвПС\Начало\lab\game.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowsFormsApplication1.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager a;
    private static CultureInfo b;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) WindowsFormsApplication1.Properties.Resources.a, (object) null))
          WindowsFormsApplication1.Properties.Resources.a = new ResourceManager("WindowsFormsApplication1.Properties.Resources", typeof (WindowsFormsApplication1.Properties.Resources).Assembly);
        return WindowsFormsApplication1.Properties.Resources.a;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return WindowsFormsApplication1.Properties.Resources.b;
      }
      set
      {
        WindowsFormsApplication1.Properties.Resources.b = value;
      }
    }

    internal Resources()
    {
    }
  }
}

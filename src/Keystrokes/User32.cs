using System.Runtime.InteropServices;

namespace Keystrokes
{
    internal static class User32
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
    }
}
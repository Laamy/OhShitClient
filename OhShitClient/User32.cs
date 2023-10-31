using System.Runtime.InteropServices;
using System;

class User32
{
    [DllImport("User32.dll")]
    public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

    [DllImport("User32.dll")]
    public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
}
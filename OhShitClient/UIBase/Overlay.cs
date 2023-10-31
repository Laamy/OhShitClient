using System;
using System.Windows.Forms;
using System.Drawing;

using static User32;
using static Debug;

class Overlay : Form
{
    public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

    public Overlay()
    {
        Log("Initializing UI..");

        InitializeComponents();

        Log("Initializing Paint Hooks..");
        Paint += OnUpdate;

        Focus(); // bring the overlay window into focus

        // click through
        int initStyle = GetWindowLong(Handle, -20);
        SetWindowLong(Handle, -20, initStyle | 0x80000 | 0x20);
    }

    public void OnUpdate(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        int centerX = e.ClipRectangle.Width / 2;
        int centerY = e.ClipRectangle.Height / 2;

        Pen pen = new Pen(Color.Red, 2);

        g.DrawLine(pen, centerX - 10, centerY, centerX + 10, centerY);

        g.DrawLine(pen, centerX, centerY - 10, centerX, centerY + 10);
    }

    public void InitializeComponents()
    {
        // initialize winform here
        TopMost = true; // not needed
        TransparencyKey = BackColor;

        Text = "Rust";

        DoubleBuffered = true; // no tearing cuz this is gay

        // fuck borderl
        FormBorderStyle = FormBorderStyle.None;

        // maximize
        WindowState = FormWindowState.Maximized;

        // fullscreen
        Size = Screen.PrimaryScreen.Bounds.Size;
    }
}
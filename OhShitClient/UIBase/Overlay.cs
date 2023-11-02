using System.Windows.Forms;
using System.Drawing;

using static User32;
using static Debug;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

class Overlay : Form
{
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

        //+ crosshair
        g.DrawLine(pen, centerX - 10, centerY, centerX + 10, centerY);
        g.DrawLine(pen, centerX, centerY - 10, centerX, centerY + 10);

        //simple mandmade sight
        //Point imageDimsensions = new Point(309 / 8, 294 / 8);

        //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        //using (Bitmap image = new Bitmap("Data\\Assets\\SimpleHandmadeSight.png"))
        //{
        //    for (int x = 0; x < image.Width; x++)
        //    {
        //        for (int y = 0; y < image.Height; y++)
        //        {
        //            Color pixel = image.GetPixel(x, y);

        //            if (pixel.A < 255)
        //                image.SetPixel(x, y, Color.Transparent); // delete bad pixels
        //        }
        //    }

        //    Rectangle sightRect =
        //        new Rectangle(new Point(centerX - (imageDimsensions.X / 2), centerY - (imageDimsensions.Y / 2)),
        //        new Size(imageDimsensions.X, imageDimsensions.Y));
        //    g.DrawImage(image, sightRect);
        //}
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

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Overlay
            // 
            this.ClientSize = new System.Drawing.Size(276, 240);
            this.Name = "Overlay";
            this.ResumeLayout(false);

    }
}
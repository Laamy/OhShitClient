using System.Windows.Forms;

class Program
{
    static void Main(string[] args)
    {
        // just gonna start it cuz we're not injecting anything so no need for multi-thread
        Application.Run(new Overlay());
    }
}
using System;
using Xwt;

namespace NewApp
{
    class Program
    {
        static void Main (string[] args)
        {
            Application.Initialize ();
            new MainWindow () { ScreenBounds = new Rectangle (0, 0, 300, 200) }
                .Show ();
            Application.Run ();
        }
    }
}

using System;
using Gtk;

namespace gBigRocks
{
    internal class Program
    {
        public static void Main()
        {
            Application.Init();

            MainWindow win = MainWindow.Create();
            win.Show();
            Application.Run();
        }
    }
}
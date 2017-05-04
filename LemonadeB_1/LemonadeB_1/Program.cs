using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LemonadeB_1
{
    static class Program
    {
        public static StartNewGameForm form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new StartNewGameForm();
            Application.Run(form);
        }
    }
}

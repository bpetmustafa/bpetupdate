using BPET_PORTAL.borsauygulamasi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool autoStart = args.Contains("auto");

            if (autoStart)
            {
                Application.Run(new mainpage("test"));
            }
            else
            {
                Application.Run(new loginpage());

            }
        }
    }
}
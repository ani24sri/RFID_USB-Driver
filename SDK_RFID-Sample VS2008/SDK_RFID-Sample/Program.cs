using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SDK_RFID_Sample
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new SDK_Demo());
           
        }
    }
}

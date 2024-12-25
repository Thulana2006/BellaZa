﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaZa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Customer customer = new Customer();
            Properties.Settings.Default["User"] = customer;
            Properties.Settings.Default.Save();

            System.Windows.Forms.Application.Run(new Startup());
        }
    }
}

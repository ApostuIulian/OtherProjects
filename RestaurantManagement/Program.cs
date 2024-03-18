using Assignment1.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Database db = Database.Instance;
            Queries q = new Queries();
            db.creareBazaDate();
            db.creareTabele();
            db.populeazaTabele();
            db.creazaProceduri();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
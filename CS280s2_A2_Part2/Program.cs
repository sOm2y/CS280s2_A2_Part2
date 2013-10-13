/*********************************************
 * 
 * CS280s2_A2_Part2
 * Author:Yue Yin
 * UPI:yyin888
 * student ID:5398177
 * Due Date: 14/ Oct /2013
 * ----------DO NOT COPY THE CODE-----------
 * 
 *********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS280s2_A2_Part2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        
    }
}

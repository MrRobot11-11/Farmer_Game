using System;
using System.Collections.Generic;
using System.Text;
/*Steven Lantz
ITDEV-115-501
Fall 2019
Farmer Game*/

namespace Lantz_FarmerGame
{
    class Information
    {

        public void MyInfo(string currentAssignment)
        {
            string barrier = "********************************************************";
            Console.WriteLine(barrier);
            Console.WriteLine("\nName: \t\tSteve Lantz");
            Console.WriteLine("Course: \tITDEV-115-501");
            Console.WriteLine("Instructor:\tJanese Christie");
            Console.WriteLine("Assignment:\t" + currentAssignment);
            Console.WriteLine("Date:\t\t" + System.DateTime.Today.ToShortDateString() + "\n");
            Console.WriteLine(barrier);

        }




    }
}

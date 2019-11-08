using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Classes
{
    public static class AnnouncementData
    {
        public static int count = 0;
        public static bool wasPreviousButtonClicked = false;
        public static int arrlength = AnnouncementWindow.getCount();
        public static String announcementTitle = "Template Announcement";
        public static String announcementDetails =
            "This is a template announcement for all the students of all the departments." +
            "There is a template workshop being conducted in our college by CSE department in association with TEMP." +
            "\nInterested students are supposed to fill the form on the given link:" +
            "\nLink : bit.ly/tempLate" +
            "\n\n    Venue : Seminar Hall 1" +
            "\n     Date : 26th October 2019 to 4th November 2019" +
            "\n     Time : 9:00 AM to 4:00 PM" +
            "\n\n For more information, contact the co-ordinator: " +
            "\n Co-ordinator Name : Template Name" +
            "\n Contact Number    : +9999999999";

                                                //  CSE /  ISE  / ECE /  EEE  /  ME  / Civil 
        public static bool[] departmentsAllowed = {false, false, false, false, false, false};
        public static bool noDepartmentSelected = true;
  
        public static string eligibleBranches()
        {
            string temp = "";
            for(int i=0; i<6; i++)
            {
                if (departmentsAllowed[i])
                    temp += 't';
                else temp += 'f';
            }
            return temp;
        }

        public static void calculateErrors()
        {
            for (int i = 0; i< 6; i++) {
                if (departmentsAllowed[i])
                {
                    noDepartmentSelected = false; return;
                }
                else noDepartmentSelected = true;
            }
        }
    }
}

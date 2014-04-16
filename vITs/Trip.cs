using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vITs
{
    public class Trip
    {

        public string startdate { get; set; }
        public string enddate { get; set; }
        public string transit { get; set; }
        public int breakfast;
        public int lunch;
        public int dinner;
        public int mission { get; set; }
        public int vacationdays { get; set; }
        public int traktamente { get; set; }


        public Trip(string startdate, string enddate, string transit, int breakfast, int lunch, int dinner, int mission, int vacationdays, int traktamente)
        {
            this.startdate = startdate;
            this.enddate = enddate;
            this.transit = transit;
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
            this.mission = mission;
            this.vacationdays = vacationdays;
            this.traktamente = traktamente;
        }
    }
}
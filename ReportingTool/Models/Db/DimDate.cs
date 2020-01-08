using System;
using System.Collections.Generic;

namespace Reportingtool.Models.Db
{
    public partial class DimDate
    {
        public int DateKey { get; set; }
        public DateTime Date { get; set; }
        public byte Day { get; set; }
        public string DaySuffix { get; set; }
        public byte Weekday { get; set; }
        public string WeekDayName { get; set; }
        public byte IsoweekOfYear { get; set; }
        public byte Month { get; set; }
        public string MonthName { get; set; }
        public byte Quarter { get; set; }
        public int Year { get; set; }
    }
}

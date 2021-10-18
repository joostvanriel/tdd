﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSearcher
{
    public class FuzzyDate
    {
        private DateTime startDate;
        private DateTime endDate;

        public enum Quarters
        {
            Q1,
            Q2,
            Q3,
            Q4
        }

        public enum YearType
        {
            Start,
            Halfway,
            End
        }

        public FuzzyDate()
        {
            startDate = new DateTime(0);
            endDate = new DateTime(0);
        }

        public FuzzyDate(string str)
        {
            if (str == "now")
            {
                startDate = DateTime.Now;
                endDate = DateTime.Now;
            }
        }

        public FuzzyDate(Quarters quart, int year)
        {
            switch (quart)
            {
                case Quarters.Q1:
                    startDate = new DateTime(year, 1, 1);
                    endDate = new DateTime(year, 3, 31);
                    break;
                case Quarters.Q2:
                    startDate = new DateTime(year, 4, 1);
                    endDate = new DateTime(year, 6, 30);
                    break;
                case Quarters.Q3:
                    startDate = new DateTime(year, 7, 1);
                    endDate = new DateTime(year, 9, 30);
                    break;
                case Quarters.Q4:
                    startDate = new DateTime(year, 10, 1);
                    endDate = new DateTime(year, 12, 31);
                    break;
            }
        }

        public FuzzyDate(YearType type, int year)
        {
            switch (type)
            {
                case YearType.Start:
                    startDate = new DateTime(year, 1, 1);
                    endDate = new DateTime(year, 4, 30);
                    break;
                case YearType.Halfway:
                    startDate = new DateTime(year, 5, 1);
                    endDate = new DateTime(year, 8, 31);
                    break;
                case YearType.End:
                    startDate = new DateTime(year, 9, 1);
                    endDate = new DateTime(year, 12, 31);
                    break;
            }
        }

        public DateTime GetFuzzyStart()
        {
            return startDate;
        }

        public DateTime GetFuzzyEnd()
        {
            return endDate;
        }

        public DateTime GetFuzzyRange()
        {
            return new DateTime(endDate.Ticks - startDate.Ticks);
        }

        public bool Contains(DateTime lookUpDate)
        {
            bool startContains = startDate.CompareTo(lookUpDate) <= 0;
            bool endContains = endDate.CompareTo(lookUpDate) >= 0;
            return (startContains && endContains);
        }
    }
}

using System;
using System.Collections.Generic;
using BigRocks.Domain.SharedKernel;

namespace BigRocks.Domain.ValueObjects
{
    public class PlanDate : ValueObject
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public PlanDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Year;
            yield return Month;
            yield return Day;
        }

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }
    }
}
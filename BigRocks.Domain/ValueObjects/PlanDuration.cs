using System;
using System.Collections.Generic;
using BigRocks.Domain.SharedKernel;

namespace BigRocks.Domain.ValueObjects
{
    
    /// <summary>
    /// Duration/Dauer für einen BigRock
    /// </summary>
    public class PlanDuration : ValueObject
    {
        public int LengthInDays { get; private set; }

        public PlanDuration(int lengthInDays)
        {
            if (lengthInDays <= 0)
                throw new ArgumentException("lengthInDays must be positive");
            
            LengthInDays = lengthInDays;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LengthInDays;
        }

        PlanDuration ChangeLength(int newLengthInDays)
        {
            return new PlanDuration(newLengthInDays);
        }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromDays(LengthInDays);
        }
    }
}
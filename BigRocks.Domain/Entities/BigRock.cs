using BigRocks.Domain.SharedKernel;
using BigRocks.Domain.ValueObjects;

namespace BigRocks.Domain.Entities
{
    /// <summary>
    /// ganz großes Thema
    /// </summary>
    public class BigRock : BaseEntity
    {
        public string Name { get; private set; }

        public PlanDate StartDate { get; private set; }

        public PlanDuration Duration { get; private set; }
    }
}
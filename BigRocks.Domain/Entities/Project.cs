using BigRocks.Domain.SharedKernel;
using BigRocks.Domain.ValueObjects;

namespace BigRocks.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; }
        public PlanDate Startdate { get; private set; }

        public Project(string name, PlanDate startdate)
        {
            Name = name;
            Startdate = startdate;
        }
    }
}
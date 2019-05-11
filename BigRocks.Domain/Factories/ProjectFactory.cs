using BigRocks.Domain.Entities;
using BigRocks.Domain.Interfaces;
using BigRocks.Domain.ValueObjects;

namespace BigRocks.Domain.Factories
{
    public class ProjectFactory
    {
        private IRepository<Project> _repository;

        public ProjectFactory(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public Project Create(string name, PlanDate startdate)
        {
            Project newProject = new Project(name, startdate);
            _repository.Add(newProject);
            return newProject;
        }
    }
}
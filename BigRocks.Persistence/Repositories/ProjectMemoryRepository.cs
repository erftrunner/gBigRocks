using System;
using System.Collections.Generic;
using System.Linq;
using BigRocks.Domain.Entities;
using BigRocks.Domain.Interfaces;
using BigRocks.Domain.SharedKernel;
using BigRocks.Domain.ValueObjects;

namespace BigRocks.Persistence.Repositories
{
    public class ProjectMemoryRepository : IRepository<Project>
    {
        private Dictionary<Guid, Project> _projects = new Dictionary<Guid, Project>()
            ;
        public Project GetById(Guid id)
        {
            Project project;
            if (_projects.TryGetValue(id, out project))
                return project;

            return null;
        }

        public IEnumerable<Project> GetAll(Predicate<Project> predicate)
        {
            return new List<Project>();
        }

        public void Add(Project entity)
        {
            _projects[entity.Id] = entity;
        }

        public void Update(Project entity)
        {
            _projects[entity.Id] = entity;
        }

        public void Delete(Project entity)
        {
            _projects.Remove(entity.Id);
        }

        public void DeleteById(Guid id)
        {
            _projects.Remove(id);
        }
    }
}
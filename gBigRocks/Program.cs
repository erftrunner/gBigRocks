using System;
using BigRocks.Domain.Entities;
using BigRocks.Domain.Factories;
using BigRocks.Domain.Interfaces;
using BigRocks.Persistence.Repositories;
using Gtk;

namespace gBigRocks
{
    internal class Program
    {
        public static void Main()
        {
            IRepository<Project> projectRepository = new ProjectMemoryRepository(); 
            ProjectFactory projectFactory = new ProjectFactory(projectRepository);
            Application.Init();

            MainWindow win = MainWindow.Create(projectFactory, projectRepository);
            win.Show();
            Application.Run();
        }
    }
}
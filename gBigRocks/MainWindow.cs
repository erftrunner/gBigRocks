
using System;
using BigRocks.Domain.Entities;
using BigRocks.Domain.Factories;
using BigRocks.Domain.Interfaces;
using gBigRocks.Commands;
using gBigRocks.Dialogs;
using Gdk;
using Gtk;
using Window = Gtk.Window;

namespace gBigRocks
{
    internal class MainWindow : Window
    {
        private ProjectFactory _projectFactory;
        private IRepository<Project> _projectRepository;
        
        private Builder _builder;
        
        public static MainWindow Create(ProjectFactory projectfactory, IRepository<Project> projectRepository) {
            
            Builder builder = new Builder(null, "gBigRocks.glade.MainWindow.glade", null);
            return new MainWindow(builder, builder.GetObject("MainWindow").Handle, projectfactory, projectRepository);
        }
        
        protected MainWindow(Builder builder, IntPtr handle, ProjectFactory projectFactory, IRepository<Project> projectRepository) : base(handle)
        {
            _projectFactory = projectFactory;
            _projectRepository = projectRepository;
            _builder = builder;
            builder.Autoconnect(this);
        }

        protected override bool OnDeleteEvent(Event evnt)
        {
            new ApplicationQuitCommand(this).Invoke();
            return true;
        }

        void on_menuQuit_activate(object sender, EventArgs args)
        {
            new ApplicationQuitCommand(this).Invoke();
        }
        
        void on_menuNew_activate(object sender, EventArgs args)
        {
            ProjectDialog dlg = ProjectDialog.Create(_projectFactory);
            dlg.Show();
        }
        
        void on_menuOpen_activate(object sender, EventArgs args)
        {
            ProjectOpenDialog dlg = ProjectOpenDialog.Create(_projectRepository);
            dlg.ShowAll();
        }
    }
}
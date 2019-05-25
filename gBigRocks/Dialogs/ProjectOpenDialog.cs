using System;
using BigRocks.Domain.Entities;
using BigRocks.Domain.Factories;
using BigRocks.Domain.Interfaces;
using BigRocks.Domain.ValueObjects;
using Gtk;

namespace gBigRocks.Dialogs
{
    public class ProjectOpenDialog : Dialog
    {
        private IRepository<Project> _reposiory;

        public Guid SelectedProjectid { get; private set; } = Guid.Empty;

        [Builder.Object]
        public  TreeView projectList = new TreeView();
        
        private Builder _builder;
        
        public static ProjectOpenDialog Create(IRepository<Project> repository) {
            
            Builder builder = new Builder(null, "gBigRocks.glade.ProjectOpenDialog.glade", null);
            return new ProjectOpenDialog(builder, builder.GetObject("ProjectOpenDialog").Handle, repository);
        }
        
        protected ProjectOpenDialog(Builder builder, IntPtr handle, IRepository<Project> reppsitory) : base(handle)
        {
            projectList.Data[1] = 5;
            _reposiory = _reposiory;
            _builder = builder;
            builder.Autoconnect(this);
            
            TreeViewColumn nameColumn = new TreeViewColumn();
            nameColumn.Title = "Name";
            
            TreeViewColumn startdateColumn = new TreeViewColumn();
            startdateColumn.Title = "Startdatum";
            projectList.AppendColumn(nameColumn);
            projectList.AppendColumn(startdateColumn);
            
            CellRendererText nameCell = new CellRendererText();
            nameColumn.PackStart(nameCell, true);
            
            CellRendererText startdateCell = new CellRendererText();
            startdateColumn.PackStart(startdateCell, true);
            
            nameColumn.AddAttribute(nameCell, "text", 0);
            startdateColumn.AddAttribute(startdateCell, "text", 1);
            
            Gtk.ListStore projectStore = new Gtk.ListStore (typeof (string), typeof (string), typeof(Project));

            foreach (var p in reppsitory.GetAll())
            {
                // Add some data to the store
                TreeIter iter = projectStore.AppendValues(p.Name, p.Startdate.ToDateTime().ToShortDateString(), p);
            }
            
            // Assign the model to the TreeView
            projectList.Model = projectStore;
        } 
        
        void on_btnOk_clicked(object sender, EventArgs args)
        {
            var s = projectList.Selection;
            ITreeModel tm;
            TreeIter it;
            s.GetSelected(out tm, out it);
            Project v = (Project)tm.GetValue(it, 2);
            SelectedProjectid = v.Id;
            Destroy();
        }

        void on_btnCancel_clicked(object sender, EventArgs args)
        {
            Destroy();
        }
    }
}
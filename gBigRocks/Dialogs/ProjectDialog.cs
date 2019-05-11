using System;
using BigRocks.Domain.Factories;
using BigRocks.Domain.ValueObjects;
using Gtk;

namespace gBigRocks.Dialogs
{
    public class ProjectDialog : Dialog
    {
        private ProjectFactory _factory;
        
        [Builder.Object]
        public Entry projektName = new Entry();
        
        [Builder.Object]
        public Calendar calStartdate = new Calendar();
        
        private Builder _builder;
        
        public static ProjectDialog Create(ProjectFactory factory) {
            
            Builder builder = new Builder(null, "gBigRocks.glade.ProjektDialog.glade", null);
            return new ProjectDialog(builder, builder.GetObject("ProjektDialog").Handle, factory);
        }
        
        protected ProjectDialog(Builder builder, IntPtr handle, ProjectFactory factory) : base(handle)
        {
            _factory = factory;
            _builder = builder;
            builder.Autoconnect(this);
        } 
        
        void on_btnOk_clicked(object sender, EventArgs args)
        {
            string t = projektName.Text;
            PlanDate startdate = new PlanDate(calStartdate.Day, calStartdate.Month, calStartdate.Year);
            _factory.Create(t, startdate);
            Destroy();
        }

        void on_btnCancel_clicked(object sender, EventArgs args)
        {
            Destroy();
        }
    }
}
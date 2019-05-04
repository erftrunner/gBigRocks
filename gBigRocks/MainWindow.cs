
using System;
using Gtk;

namespace gBigRocks
{
    internal class MainWindow : Window
    {
        private Builder _builder;
        
        public static MainWindow Create() {
            Builder builder = new Builder(null, "gBigRocks.glade.MainWindow.glade", null);
            return new MainWindow(builder, builder.GetObject("MainWindow").Handle);
        }

        /// <summary> Specialised constructor for use only by derived class. </summary>
        /// <param name="builder"> The builder. </param>
        /// <param name="handle">  The handle. </param>
        protected MainWindow(Builder builder, IntPtr handle) : base(handle) {
            _builder = builder;
            builder.Autoconnect(this);
        }
    }
}
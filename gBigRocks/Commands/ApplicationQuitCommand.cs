using BigRocks.Application.Interfaces;
using gBigRocks.Dialogs;
using Gtk;

namespace gBigRocks.Commands
{
    public class ApplicationQuitCommand : ICommand
    {
        private Window _parent;
        public ApplicationQuitCommand(Window parent)
        {
            _parent = parent;
        }

        public void Invoke()
        {
            MessageDialog msg = new MessageDialog(_parent, DialogFlags.DestroyWithParent, MessageType.Question,
                ButtonsType.YesNo, "Wollen Sie gBigRocks wirklich beenden?");
            msg.Response += (o, args2) =>
            { 
                if (args2.ResponseId == ResponseType.Yes)
                    Application.Quit();
            };
            msg.Run();
            msg.Destroy();
        }
    }
}
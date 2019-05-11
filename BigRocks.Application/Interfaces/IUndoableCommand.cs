namespace BigRocks.Application.Interfaces
{
    public interface IUndoableCommand : ICommand
    {
        void Undo();
    }
}
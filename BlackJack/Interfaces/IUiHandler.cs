namespace BlackJack
{
    public interface IUiHandler
    {
        string ReadInput();
        void WriteMessage(string message);

        void WriteLine();

        void Write(string message);
    }
}
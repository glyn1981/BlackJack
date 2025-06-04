
namespace BlackJack
{
    public class UiHandler : IUiHandler
    {

        public void WriteMessage(string message)
        {
              Console.WriteLine(message);
        }
        public string ReadInput()
        {
            return Console.ReadLine() ?? String.Empty;
        }
    }
}

using System.Drawing;

namespace PixelPlusPro.Command
{

    public interface ICommand
    {
        void Execute();
    }


    public interface ISaveCommand : ICommand
    {
        void Save(string filePath);
    }


    public class CommandInvoker
    {
        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }

    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
        {
        }
    }

}
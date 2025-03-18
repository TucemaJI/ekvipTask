using ekvipTask.ClassLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        const string GREETING = "Hello, user! Enter Your number please!";
        const string NUMBER_NULL_OR_EMPTY = "Number must not be null of empty";
        const string NOT_NUMBER = "Please enter the number";
        const string COMMAND_REQUEST = "Please enter your command";
        const string COMMAND_NULL_OR_EMPTY = "Your command must contain more, than 0 letter";
        const string COMMAND_NOT_VALID = "Please, enter a valid command";

        var increment = new Increment();
        var decrement = new Decrement();
        var multiply = new Multiply();
        var randomAdd = new RandomAdd();
        var undo = new Undo();

        bool goodParsed = false;
        long value = long.MinValue;

        Console.WriteLine(GREETING);
        while (!goodParsed)
        {
            string? result = Console.ReadLine();

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine(NUMBER_NULL_OR_EMPTY);
                continue;
            }

            goodParsed = long.TryParse(result, out value);

            if (!goodParsed)
            {
                Console.WriteLine(NOT_NUMBER);
                continue;
            }
        }

        undo.Do(value);

        while (true)
        {
            Console.WriteLine(COMMAND_REQUEST);
            string? command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine(COMMAND_NULL_OR_EMPTY);
                continue;
            }

            if (command.Equals(Command.Exit.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            if (command.Equals(Command.Increment.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = DoAction(increment, undo, value);
                continue;
            }

            if (command.Equals(Command.Decrement.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = DoAction(decrement, undo, value);
                continue;
            }

            if (command.Equals(Command.Double.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = DoAction(multiply, undo, value);
                continue;
            }

            if (command.Equals(Command.Randadd.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = DoAction(randomAdd, undo, value);
                continue;
            }

            if (command.Equals(Command.Undo.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                value = DoAction(undo, undo, value);
                continue;
            }
            Console.WriteLine(COMMAND_NOT_VALID);
        }

    }
    private static long DoAction(IAction action, Undo undo, long value)
    {
        if (action is Undo)
        {
            value = undo.RemoveFromList();
            Console.WriteLine(value);
            return value;
        }

        value = action.Do(value);
        undo.Do(value);
        Console.WriteLine(value);
        return value;
    }
}
namespace ekvipTask.ClassLibrary
{
    public class Undo:IAction
    {
        private Stack<long> ValuesList { get; set; } = [];

        public long Do(long value)
        {
            ValuesList.Push(value);
            return value;
        }

        public long RemoveFromList()
        {
            if (ValuesList.Count == 0) return 0;
            ValuesList.Pop();

            if (ValuesList.Count == 0) return 0;
            return ValuesList.Peek();
        }
    }
}

namespace ekvipTask.ClassLibrary
{
    public class Multiply: IAction
    {
        public long Multiplying(long value, long multiplyBy = 2) => value * multiplyBy;
        public long Do(long value)
        {
            return Multiplying(value);
        }
    }
}

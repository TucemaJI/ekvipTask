namespace ekvipTask.ClassLibrary
{
    public class RandomAdd: IAction
    {
        public long Do(long value) => new Random().NextInt64(long.MinValue, long.MaxValue);
    }
}

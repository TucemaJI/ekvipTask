namespace ekvipTask.ClassLibrary
{
    public class Increment: IAction
    {
        public long Do(long value) => ++value;
    }
}

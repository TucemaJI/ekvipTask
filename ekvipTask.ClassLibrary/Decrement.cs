namespace ekvipTask.ClassLibrary
{
    public class Decrement: IAction
    {
        public long Do(long value) => --value;
    }
}

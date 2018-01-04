namespace Anarkanoid.Core
{
    public class Pair<T, P>
    {
        public T First { get; set; }

        public P Second { get; set; }

        public Pair(T first, P second)
        {
            First = first;
            Second = second;
        }
    }
}
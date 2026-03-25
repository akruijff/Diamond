namespace Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cursor cursor = new Cursor(x: 3, y: 5);
            // do somthing
        }
    }

    public interface IReadonlyCursor
    {
        public int X { get; }
        public int Y { get; }
    }

    public interface ICursor : IReadonlyCursor
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal class ReadonlyCursor(int x, int y) : IReadonlyCursor
    {
        public int X => x; // The intent is to expand with a setter
        public int Y => y;
    }

    internal class Cursor(int x, int y) : ReadonlyCursor(x, y), ICursor
    {
        public int X { get => x; set => field = x; } // caused by double declaration
        public int Y { get => x; set => field = y; }
    }
}

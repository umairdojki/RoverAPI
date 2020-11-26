namespace RoverAPI
{
    public class Coordinates
    {
        public int X { get; internal set; }

        public int Y { get; internal set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
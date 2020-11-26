namespace RoverAPI
{
    public class Position
    {
        public Coordinates Coordinates { get; internal set; }
        public Direction Direction { get; internal set; }

        public Position(int x, int y, Direction direction)
        {
            Coordinates = new Coordinates(x, y);
            Direction = direction;
        }
    }
}
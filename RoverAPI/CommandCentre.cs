namespace RoverAPI
{
    public class CommandCentre
    {
        private Rover _rover;
        private Grid _grid;
    
        public CommandCentre(Rover rover, Grid grid)
        {
            _rover = rover;
            _grid = grid;
        }

        public Position NavigateRover(string commands)
        {
            foreach (var command in commands.ToCharArray())
            {
                switch (command)
                {
                    case 'F':
                        MoveForwardOrWrap();
                        break;
                    case 'B':
                        MoveBackwardsOrWrap();
                        break;
                    case 'R':
                        _rover.TurnRight();
                        break;
                    case 'L':
                        _rover.TurnLeft();
                        break;
                    default:
                        throw new InvalidCommandException(command);
                }
            }

            return _rover.Position;
        }

        private void MoveBackwardsOrWrap()
        {
            var position = _rover.Position;

            switch(position.Direction)
            {
                case Direction.N:
                    if (position.Coordinates.Y == 0)
                        _rover.WrapAlongYAxis(_grid.Columns - 1);
                    else
                        _rover.MoveBackwards();
                    break;
                case Direction.S:
                    if (position.Coordinates.Y == _grid.Columns - 1)
                        _rover.WrapAlongYAxis(0);
                    else
                        _rover.MoveBackwards();
                    break;
                case Direction.E:
                    if (position.Coordinates.X == 0)
                        _rover.WrapAlongXAxis(_grid.Rows - 1);
                    else
                        _rover.MoveBackwards();
                    break;
                case Direction.W:
                    if (position.Coordinates.X == _grid.Rows - 1)
                        _rover.WrapAlongXAxis(0);
                    else
                        _rover.MoveBackwards();
                    break;
            }
        }

        private void MoveForwardOrWrap()
        {
            var position = _rover.Position;

            switch (position.Direction)
            {
                case Direction.N:
                    if (position.Coordinates.Y == _grid.Columns - 1)
                        _rover.WrapAlongYAxis(0);
                    else
                        _rover.MoveForward();
                    break;
                case Direction.S:
                    if (position.Coordinates.Y == 0)
                        _rover.WrapAlongYAxis(_grid.Columns - 1);
                    else
                        _rover.MoveForward();
                    break;
                case Direction.E:
                    if (position.Coordinates.X == _grid.Rows - 1)
                        _rover.WrapAlongXAxis(0);
                    else
                        _rover.MoveForward();
                    break;
                case Direction.W:
                    if (position.Coordinates.X == 0)
                        _rover.WrapAlongXAxis(_grid.Rows - 1);
                    else
                        _rover.MoveForward();
                    break;
            }
        }
    }
}

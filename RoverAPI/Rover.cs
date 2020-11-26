using System;

namespace RoverAPI
{
    public class Rover
    {
        public Position Position { get; private set; }
    
        public Rover(Position position)
        {
            Position = position;
        }

        public void TurnRight()
        {
            Direction newDirection = Position.Direction;
            
            switch (Position.Direction)
            {
                case Direction.N:
                    newDirection = Direction.E;
                    break;
                case Direction.E:
                    newDirection = Direction.S;
                    break;
                case Direction.S:
                    newDirection = Direction.W;
                    break;
                case Direction.W:
                    newDirection = Direction.N;
                    break;
            }

            Position = new Position(Position.Coordinates.X,
                                    Position.Coordinates.Y,
                                    newDirection);
        }

        public void TurnLeft()
        {
            Direction newDirection = Position.Direction;

            switch (Position.Direction)
            {
                case Direction.N:
                    newDirection = Direction.W;
                    break;
                case Direction.W:
                    newDirection = Direction.S;
                    break;
                case Direction.S:
                    newDirection = Direction.E;
                    break;
                case Direction.E:
                    newDirection = Direction.N;
                    break;
            }

            Position = new Position(Position.Coordinates.X,
                                    Position.Coordinates.Y,
                                    newDirection);
        }

        public void WrapAlongYAxis(int wrapCoordinate)
        {
            Position = new Position(Position.Coordinates.X, wrapCoordinate, Position.Direction); 
        }

        public void WrapAlongXAxis(int wrapCoordinate)
        {
            Position = new Position(wrapCoordinate, Position.Coordinates.Y, Position.Direction);
        }

        public void MoveBackwards()
        {
            int newX = Position.Coordinates.X;
            int newY = Position.Coordinates.Y;

            switch (Position.Direction)
            {
                case Direction.N:
                    newY--;
                    break;
                case Direction.S:
                    newY++;
                    break;
                case Direction.E:
                    newX--;
                    break;
                case Direction.W:
                    newX++;
                    break;
            }

            Position = new Position(newX, newY, Position.Direction);
        }

        public void MoveForward()
        {
            int newX = Position.Coordinates.X;
            int newY = Position.Coordinates.Y;

            switch (Position.Direction)
            {
                case Direction.N:
                    newY++;
                    break;
                case Direction.S:
                    newY--;
                    break;
                case Direction.E:
                    newX++;
                    break;
                case Direction.W:
                    newX--;
                    break;
            }

            Position = new Position(newX, newY, Position.Direction);
        }
    }
}
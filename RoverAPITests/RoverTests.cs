using NUnit.Framework;
using RoverAPI;
using FluentAssertions;

namespace RoverAPITests
{
    public class RoverTests
    {
        private Rover _rover;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(Direction.N, 1, 1, 1, 2)]
        [TestCase(Direction.S, 1, 1, 1, 0)]
        [TestCase(Direction.E, 1, 1, 2, 1)]
        [TestCase(Direction.W, 1, 1, 0, 1)]

        public void ForwardMovement(Direction direction, int currentX, int currentY, int newX, int newY)
        {
            // given
            Position currentPosition = new Position(currentX, currentY, direction);
            _rover = new Rover(currentPosition);

            // when
            _rover.MoveForward();

            // then
            Position newPosition = new Position(newX, newY, direction);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }

        [TestCase(Direction.N, 1, 1, 1, 0)]
        [TestCase(Direction.S, 1, 1, 1, 2)]
        [TestCase(Direction.E, 1, 1, 0, 1)]
        [TestCase(Direction.W, 1, 1, 2, 1)]
        public void BackwardsMovement(Direction direction, int currentX, int currentY, int newX, int newY)
        {
            // given
            Position currentPosition = new Position(currentX, currentY, direction);
            _rover = new Rover(currentPosition);

            // when
            _rover.MoveBackwards();

            // then
            Position newPosition = new Position(newX, newY, direction);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }

        [TestCase(Direction.N, Direction.E)]
        [TestCase(Direction.E, Direction.S)]
        [TestCase(Direction.S, Direction.W)]
        [TestCase(Direction.W, Direction.N)]
        public void RightTurn(Direction currentDirection, Direction newDirection)
        {
            // given
            Position currentPosition = new Position(1, 1, currentDirection);
            _rover = new Rover(currentPosition);

            // when
            _rover.TurnRight();

            // then
            Position newPosition = new Position(1, 1, newDirection);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }

        [TestCase(Direction.N, Direction.W)]
        [TestCase(Direction.W, Direction.S)]
        [TestCase(Direction.S, Direction.E)]
        [TestCase(Direction.E, Direction.N)]
        public void LeftTurn(Direction currentDirection, Direction newDirection)
        {
            // given
            Position currentPosition = new Position(1, 1, currentDirection);
            _rover = new Rover(currentPosition);

            // when
            _rover.TurnLeft();

            // then
            Position newPosition = new Position(1, 1, newDirection);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }

        [Test]
        public void WrapAlongYAxis()
        {
            // given
            Position currentPosition = new Position(1, 99, Direction.N);
            _rover = new Rover(currentPosition);

            // when
            _rover.WrapAlongYAxis(0);

            // then
            Position newPosition = new Position(1, 0, Direction.N);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }

        [Test]
        public void WrapAlongXAxis()
        {
            // given
            Position currentPosition = new Position(99, 1, Direction.N);
            _rover = new Rover(currentPosition);

            // when
            _rover.WrapAlongXAxis(0);

            // then
            Position newPosition = new Position(0, 1, Direction.N);
            _rover.Position.Should().BeEquivalentTo(newPosition);
        }
    }
}
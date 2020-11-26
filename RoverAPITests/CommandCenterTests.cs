using NUnit.Framework;
using RoverAPI;
using FluentAssertions;

namespace RoverAPITests
{
    public class CommandCenterTests
    {
        private CommandCentre _commandCentre;
        private Rover _rover;

        [SetUp]
        public void Setup()
        {
            var startingPosition = new Position(10, 10, Direction.N);
            _rover = new Rover(startingPosition);
        }

        [TestCase("FFRFF", 12, 12, Direction.E)]
        [TestCase("FFLFF", 8, 12, Direction.W)]
        [TestCase("BBRBB", 8, 8, Direction.E)]
        [TestCase("BBLBB", 12, 8, Direction.W)]
        public void Rover_Navigates_Correctly_On_Valid_Commands(string commands, int newX, int newY, Direction newDirection)
        {
            // given
            var grid = new Grid(100, 100);
            _commandCentre = new CommandCentre(_rover, grid);

            // when
            var roverPosition = _commandCentre.IssueCommandsToRover(commands);

            // then
            var newPosition = new Position(newX, newY, newDirection);
            roverPosition.Should().BeEquivalentTo(newPosition);
        }

        [TestCase("FFRFF", 0, 0, Direction.E)]
        [TestCase("FFLFF", 8, 0, Direction.W)]
        [TestCase("BBRBB", 8, 8, Direction.E)]
        [TestCase("BBLBB", 0, 8, Direction.W)]
        public void Rover_Wraps_Correctly_On_Valid_Commands(string commands, int newX, int newY, Direction newDirection)
        {
            // given

            var grid = new Grid(12, 12);
            _commandCentre = new CommandCentre(_rover, grid);

            // when
            var roverPosition = _commandCentre.IssueCommandsToRover(commands);

            // then
            var newPosition = new Position(newX, newY, newDirection);
            roverPosition.Should().BeEquivalentTo(newPosition);
        }
    }
}
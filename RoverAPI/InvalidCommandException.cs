using System;

namespace RoverAPI
{
    public class InvalidCommandException : Exception
    {  
        public InvalidCommandException(char command) : base($"Invalid command {command}")
        {
        }
    }
}
using System;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// 
/// </summary>
public class InvalidInstructionsEx : MartianRobotsEx
{
    public InvalidInstructionsEx()
        : base("Invalid instruction format!")
    {
    }
}

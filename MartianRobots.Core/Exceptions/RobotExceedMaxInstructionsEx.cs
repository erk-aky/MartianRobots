using System;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// 
/// </summary>
public class RobotExceedMaxInstructionsEx : MartianRobotsEx
{
    public RobotExceedMaxInstructionsEx(string message)
        : base(message)
    {
    }
}

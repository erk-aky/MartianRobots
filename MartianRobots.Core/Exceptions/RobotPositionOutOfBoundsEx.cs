using System;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// RobotPositionOutOfBoundsEx
/// </summary>
public class RobotPositionOutOfBoundsEx : MartianRobotsEx
{
    public RobotPositionOutOfBoundsEx()
        : base("Robot position is not within the planet boundaries!")
    {
    }
}

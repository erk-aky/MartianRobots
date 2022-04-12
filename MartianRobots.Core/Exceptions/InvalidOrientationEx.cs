using System;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// 
/// </summary>
public class InvalidOrientation : MartianRobotsEx
{
    public InvalidOrientation()
        : base("Invalid orientations code! Valid orientation codes: N, W, E, S")
    {
    }
}

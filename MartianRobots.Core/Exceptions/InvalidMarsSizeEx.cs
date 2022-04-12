using System;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// 
/// </summary>
public class InvalidMarsSizeEx : MartianRobotsEx
{
    public InvalidMarsSizeEx()
        : base("Exceed Mars maximum size: 50x50")
    {
    }
}

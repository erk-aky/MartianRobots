using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core.Exceptions;

/// <summary>
/// 
/// </summary>
public class MartianRobotsEx : Exception
{
    public MartianRobotsEx(string message)
        : base(message)
    {
    }
}

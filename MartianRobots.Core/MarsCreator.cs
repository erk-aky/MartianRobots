using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.Core.Exceptions;
using MartianRobots.Core.Entities;
using MartianRobots.Core.Parser;

namespace MartianRobots.Core;

/// <summary>
/// 
/// </summary>
public class MarsCreator
{
    /// <summary>
    /// 
    /// </summary>
    public List<Robot> CreateMars(MarsData marsData)
    {
        List<Robot> robots = new List<Robot>();
        
        Mars mars = new Mars(marsData.UpperX, marsData.UpperY);

        foreach (RobotData robotData in marsData.Robots)
        {
            Robot robot = new Robot(mars, robotData.PositionX, robotData.PositionY,
                    robotData.Orientation, robotData.Instruction);

            robots.Add(robot);
        }

        return robots;
    }
}
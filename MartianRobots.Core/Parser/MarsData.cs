using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core;

/// <summary>
/// 
/// </summary>
public class MarsData
{
    /// <summary>
    /// 
    /// </summary>
    public int UpperX { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int UpperY { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<RobotData> Robots { get; set; } = new List<RobotData>();
}
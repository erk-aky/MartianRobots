using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core.Entities;

/// <summary>
/// 
/// </summary>
public class Position
{
    /// <summary>
    /// 
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Position(int x, int y)
    {
        X = x; Y = y; HasScent = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public bool HasScent { get; set; }
}
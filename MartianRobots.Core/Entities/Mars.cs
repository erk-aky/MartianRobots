using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core.Entities;

/// <summary>
/// 
/// </summary>
public class Mars
{
    /// <summary>
    /// 
    /// </summary>
    public readonly int UpperX;

    /// <summary>
    /// 
    /// </summary>
    public readonly int UpperY;

    /// <summary>
    /// 
    /// </summary>
    public Surface Surface { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Mars(int x, int y)
    {
        UpperX = x;
        UpperY = y;
        Surface = new Surface(x, y);
    }
}

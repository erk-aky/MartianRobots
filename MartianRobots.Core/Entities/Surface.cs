using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core.Entities;

/// <summary>
/// 
/// </summary>
public class Surface
{
    /// <summary>
    /// 
    /// </summary>
    private Position[,] surface { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Surface(int x, int y)
    {
        surface = new Position[x + 1, y + 1];

        for (int i = 0; i <= x; i++)
        {
            for (int j = 0; j <= y; j++)
            {
                surface[i, j] = new Position(i, j);
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Position this[int x, int y]
    {
        get
        {
            return surface[x, y];
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public Position this[Position position]
    {
        get
        {
            return surface[position.X, position.Y];
        }
    }
}

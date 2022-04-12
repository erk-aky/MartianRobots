using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Core;

/// <summary>
/// 
/// </summary>
public class Orientation
{
    public Directions Name { get; set; }
    public Orientation(Directions direction)
    {
        Name = direction;
    }
    public override string ToString()
    {
        return Name.ToString();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.App;

/// <summary>
/// Input Reader class
/// </summary>
public static class InputReader
{
    /// <summary>
    /// Read input from command line
    /// </summary>
    /// <returns>Mars and Robots data</returns>
    public static string ReadInput()
    {
        var userInput = new StringBuilder();
        
        Console.WriteLine("Sample Input: ");
        Console.WriteLine("-----------------");
        Console.WriteLine("| 5 3            |");
        Console.WriteLine("| 1 1 E          |");
        Console.WriteLine("| RFRFRFRF       |");
        Console.WriteLine("| 3 2 N          |");
        Console.WriteLine("| FRRFLLFFRRFLL  |");
        Console.WriteLine("| 0 3 W          |");
        Console.WriteLine("| LLFFFLFLFL     |");
        Console.WriteLine("-----------------");
        Console.WriteLine("Enter line by line respectively; Mars coordinates, Robot positions, and Robot instructions. [ENTER][ENTER] ");

        int nNewlines = 0;
        string line;
        do
        {
            line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                nNewlines = 0;
                userInput.AppendLine(line);
            }
            else
                nNewlines++;

        } while (nNewlines < 1);

        return userInput.ToString();
    }
}

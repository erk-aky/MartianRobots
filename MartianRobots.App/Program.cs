using System;
using System.Text;
using MartianRobots.Core;
using MartianRobots.Core.Exceptions;
using MartianRobots.Core.Entities;
using MartianRobots.Core.Parser;

namespace MartianRobots.App;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder report = new StringBuilder(System.Environment.NewLine);
        try
        {
            string input = InputReader.ReadInput();
            MarsData marsData = new InputDataParser().Parse(input);
            List<Robot> robots = new MarsCreator().CreateMars(marsData);

            foreach (Robot robot in robots)
            {
                robot.ExecuteCommands();                
                report.Append(robot.GetReport() + System.Environment.NewLine);
            }
        }
        catch (MartianRobotsEx ex)
        {
            report.Append(ex.Message + System.Environment.NewLine);
        }
        catch (Exception ex)
        {
            report.Append("Unhandled Exception: " + ex.Message + System.Environment.NewLine);
        }
        
        LogReport(report.ToString());
    }

    static void LogReport(string report){
        Console.WriteLine(report);
    }
}
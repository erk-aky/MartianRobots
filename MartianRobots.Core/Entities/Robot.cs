using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Core.Exceptions;

namespace MartianRobots.Core.Entities;

/// <summary>
/// Robot
/// </summary>
public class Robot
{
    /// <summary>
    /// 
    /// </summary>
    public Position CurrentPosition { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public Orientation CurrentOrientation { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string InstructionString { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public Mars Mars { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsLost { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mars"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="orientation"></param>
    /// <param name="instructionString"></param>
    /// <exception cref="InvalidOrientation"></exception>
    /// <exception cref="RobotPositionOutOfBoundsEx"></exception>
    public Robot(Mars mars, int x, int y, string orientation, string instructionString)
    {
        try
        {
            Mars = mars;
            CurrentPosition = mars.Surface[x, y];
            InstructionString = instructionString;
            switch ((Directions)char.Parse(orientation))
            {
                case Directions.North:
                    CurrentOrientation = OrientationsHandler.North;
                    break;
                case Directions.South:
                    CurrentOrientation = OrientationsHandler.South;
                    break;
                case Directions.West:
                    CurrentOrientation = OrientationsHandler.West;
                    break;
                case Directions.East:
                    CurrentOrientation = OrientationsHandler.East;
                    break;
                default:
                    throw new InvalidOrientation();
            }
        }
        catch (IndexOutOfRangeException)
        {
            throw new RobotPositionOutOfBoundsEx();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ExecuteCommands()
    {
        foreach (char command in InstructionString)
        {
            switch ((Commands)command)
            {
                case Commands.Left:
                    CurrentOrientation = OrientationsHandler.TurnLeft(CurrentOrientation);
                    break;
                case Commands.Right:
                    CurrentOrientation = OrientationsHandler.TurnRight(CurrentOrientation);
                    break;
                case Commands.Forward:
                    bool willFall = WillFall(CurrentPosition, CurrentOrientation);
                    if (Mars.Surface[CurrentPosition].HasScent && willFall)
                        break;
                    else if (willFall)
                    {
                        this.IsLost = true;
                        Mars.Surface[CurrentPosition].HasScent = true;
                        return;
                    }
                    else
                    {
                        if (CurrentOrientation == OrientationsHandler.North)
                        {
                            CurrentPosition.Y++;
                        }
                        else if (CurrentOrientation == OrientationsHandler.East)
                        {
                            CurrentPosition.X++;
                        }
                        else if (CurrentOrientation == OrientationsHandler.South)
                        {
                            CurrentPosition.Y--;
                        }
                        else if (CurrentOrientation == OrientationsHandler.West)
                        {
                            CurrentPosition.X--;
                        }
                        break;
                    }
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    public void ExecuteCommands(string command)
    {
        InstructionString = command;
        ExecuteCommands();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="CurrentPosition"></param>
    /// <param name="CurrentOrientation"></param>
    /// <returns></returns>
    private bool WillFall(Position CurrentPosition, Orientation CurrentOrientation)
    {
        bool willFall = false;
        if (
            (CurrentOrientation == OrientationsHandler.North && CurrentPosition.Y == Mars.UpperY)
            || (CurrentOrientation == OrientationsHandler.East && CurrentPosition.X == Mars.UpperX)
            || (CurrentOrientation == OrientationsHandler.South && CurrentPosition.Y == 0)
            || (CurrentOrientation == OrientationsHandler.West && CurrentPosition.X == 0)
            )
        {
            willFall = true;
        }

        return willFall;
    }

    public string GetReport()
    {
        return String.Format("{0} {1} {2}{3}", CurrentPosition.X,
                CurrentPosition.Y, CurrentOrientation.ToString()[0], ((IsLost) ? " LOST" : string.Empty));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MartianRobots.Core.Exceptions;

namespace MartianRobots.Core.Parser;

/// <summary>
/// 
/// </summary>
public class InputDataParser
{
    public const int MaxInstructionLength = 100;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="InvalidInstructionsEx"></exception>
    public MarsData Parse(string input)
    {
        return ParseMarsData(input);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="InvalidInstructionsEx"></exception>
    private MarsData ParseMarsData(string input)
    {
        Regex reg = new Regex(@"\s*(?<UPPER_X>\d{1,})\s+(?<UPPER_Y>\d{1,})\s*");
        Match match = reg.Match(input);

        if (match.Captures.Count == 0)
            throw new InvalidInstructionsEx();

        int upperX = int.Parse(match.Groups["UPPER_X"].Value);
        int upperY = int.Parse(match.Groups["UPPER_Y"].Value);

        if (upperX < 0 || upperX > 50 || upperY < 0 || upperY > 50)
            throw new InvalidMarsSizeEx();

        List<RobotData> robotDatas = ParsesRobotData(input);
        return new MarsData { UpperX = upperX, UpperY = upperY, Robots = robotDatas };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidInstructionsEx"></exception>
    private List<RobotData> ParsesRobotData(string input)
    {
        Regex reg = new Regex(@"\s*(?<ROBOT_X>\d{1,})\s+(?<ROBOT_Y>\d{1,})\s+(?<ROBOT_ORIENTATION>[N|W|E|S]{1,})\s*[\r\n]*(?<ROBOT_INSTRUCTION>.+)", RegexOptions.IgnoreCase);
        MatchCollection matches = reg.Matches(input);

        List<RobotData> robotDatas = new List<RobotData>();

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                if (match.Captures.Count == 0)
                    throw new InvalidInstructionsEx();

                var positionX = int.Parse(match.Groups["ROBOT_X"].Value);
                var positionY = int.Parse(match.Groups["ROBOT_Y"].Value);
                string orientation = match.Groups["ROBOT_ORIENTATION"].Value;
                string instruction = match.Groups["ROBOT_INSTRUCTION"].Value;

                if (instruction.Length > MaxInstructionLength)
                    throw new RobotExceedMaxInstructionsEx($"Exceed Max Robot instructions length of {MaxInstructionLength}.");
                
                RobotData robotData = new RobotData()
                {
                    PositionX = positionX,
                    PositionY = positionY,
                    Orientation = orientation,
                    Instruction = instruction
                };
                robotDatas.Add(robotData);
            }
        }
        else throw new InvalidInstructionsEx();

        return robotDatas;
    }
}

using NUnit.Framework;
using MartianRobots.Core;
using MartianRobots.Core.Entities;

namespace MartianRobots.Tests;

public class RobotsTest
{
    [TestCase(Commands.Right, 1, Directions.East)]
    [TestCase(Commands.Right, 2, Directions.South)]
    [TestCase(Commands.Right, 3, Directions.West)]
    [TestCase(Commands.Right, 4, Directions.North)]
    [TestCase(Commands.Left, 1, Directions.West)]
    [TestCase(Commands.Left, 2, Directions.South)]
    [TestCase(Commands.Left, 3, Directions.East)]
    [TestCase(Commands.Left, 4, Directions.North)]
    public void ReOrientation(Commands command, int timesRotate, Directions orientation)
    {
        //arrange
        var mars = new Mars(5, 3);
        var robot = new Robot(mars, 0, 0, char.ToString((char)Directions.North), char.ToString((char)command));

        //act
        for (int i = 0; i < timesRotate; i++)
            robot.ExecuteCommands();

        //assert
        Assert.AreEqual(orientation, robot.CurrentOrientation.Name);
        Assert.AreEqual(0, robot.CurrentPosition.X);
        Assert.AreEqual(0, robot.CurrentPosition.Y);
    }

    [TestCase(Directions.North, 1, 2)]
    [TestCase(Directions.South, 1, 0)]
    [TestCase(Directions.East, 2, 1)]
    [TestCase(Directions.West, 0, 1)]
    public void Movement(Directions orientation, int x, int y)
    {
        //arrange
        var mars = new Mars(5, 3);
        var robot = new Robot(mars, 1, 1, char.ToString((char)orientation), char.ToString((char)Commands.Forward));

        //act
        robot.ExecuteCommands();

        //assert
        Assert.AreEqual(x, robot.CurrentPosition.X);
        Assert.AreEqual(y, robot.CurrentPosition.Y);
    }

    [TestCase(Directions.North, 3, true, TestName = "LostInTheNorth")]
    [TestCase(Directions.North, 2, false, TestName = "EdgeOfTheNorth")]
    [TestCase(Directions.East, 5, true, TestName = "LostInTheEast")]
    [TestCase(Directions.East, 4, false, TestName = "EdgeOfTheEast")]
    [TestCase(Directions.South, 2, true, TestName = "LostInTheSouth")]
    [TestCase(Directions.South, 1, false, TestName = "EdgeOfTheSouth")]
    [TestCase(Directions.West, 2, true, TestName = "LostInTheWest")]
    [TestCase(Directions.West, 1, false, TestName = "EdgeOfTheWest")]
    public void Boundaries(Directions orientation, int timesForward, bool shouldBeLost)
    {
        //arrange
        var mars = new Mars(5, 3);
        var robot = new Robot(mars, 1, 1, char.ToString((char)orientation), char.ToString((char)Commands.Forward));

        //act
        for (int i = 0; i < timesForward; i++)
            robot.ExecuteCommands();

        //assert
        Assert.AreEqual(shouldBeLost, robot.IsLost);
    }
}
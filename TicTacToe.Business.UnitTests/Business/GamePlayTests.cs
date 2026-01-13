using TicTacToe.Enums;
using Xunit.Abstractions;
using System.Text;
using TicTacToe.Business.Business;

namespace TicTacToe.Business.UnitTests.Business;

public class GamePlayTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper output = output;

    #region Constructor

    [Fact]
    public void GamePlay_Constructor()
    {
        var gamePLay = GetGamePlay;

        Assert.NotNull(gamePLay);
    }

    [Fact]
    public void GamePlay_Constructor_Fail()
    {
        try
        {
            var gamePlay = new GamePlay(null);
            Assert.Fail();
        }
        catch
        {
            // should fail
        }
    }

    #endregion Constructor

    #region Methods

    #region CheckBestChoice

    [Fact]
    public void GamePlay_CheckBestChoice_0()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[0] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.CenterTop || result == SquarePosition.RightTop);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_1()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[0] = XorO.X_Visible;
        gamePlay.Board[1] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_2()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[0] = XorO.X_Visible;
        gamePlay.Board[2] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_3()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[1] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.LeftTop || result == SquarePosition.RightTop);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_4()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[1] = XorO.X_Visible;
        gamePlay.Board[0] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_5()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[1] = XorO.X_Visible;
        gamePlay.Board[2] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_6()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[2] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.LeftTop || result == SquarePosition.CenterTop);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_7()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[2] = XorO.X_Visible;
        gamePlay.Board[0] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_8()
    {
        var gamePlay = GetGamePlay;
        gamePlay.Board[2] = XorO.X_Visible;
        gamePlay.Board[1] = XorO.X_Visible;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlay_CheckBestChoice_9()
    {
        var gamePlay = GetGamePlay;

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = gamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.Invalid);
    }

    #endregion CheckBestChoice

    #region CheckShouldPlay

    [Fact]
    public void GamePlay_CheckShouldPlay_0()
    {
        var gamePlay = GetGamePlay;
        PlayAgainClick(gamePlay);

        gamePlay.Board[0] = XorO.X_Visible;
        gamePlay.Board[1] = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = gamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlay_CheckShouldPlay_1()
    {
        var gamePlay = GetGamePlay;
        PlayAgainClick(gamePlay);

        gamePlay.Board[0] = XorO.X_Visible;
        gamePlay.Board[2] = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = gamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlay_CheckShouldPlay_2()
    {
        var gamePlay = GetGamePlay;
        PlayAgainClick(gamePlay);

        gamePlay.Board[1] = XorO.X_Visible;
        gamePlay.Board[2] = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = gamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlay_CheckShouldPlay_3()
    {
        var gamePlay = GetGamePlay;
        PlayAgainClick(gamePlay);

        gamePlay.Board[2] = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = gamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.True(result == SquarePosition.Invalid);
    }

    #endregion CheckShouldPlay

    #region CheckIfComputerPlay

    [Theory]
    [InlineData(false, false, false, XorO.None, true)]
    [InlineData(false, false, false, XorO.X_Visible, false)]
    [InlineData(false, false, false, XorO.O_Visible, true)]
    [InlineData(false, false, true, XorO.None, true)]
    [InlineData(false, false, true, XorO.X_Visible, true)]
    [InlineData(false, false, true, XorO.O_Visible, false)]
    [InlineData(true, false, false, XorO.X_Visible, false)]
    [InlineData(true, false, false, XorO.O_Visible, false)]
    [InlineData(true, false, true, XorO.X_Visible, false)]
    [InlineData(true, false, true, XorO.O_Visible, false)]
    [InlineData(false, true, false, XorO.X_Visible, false)]
    [InlineData(false, true, false, XorO.O_Visible, false)]
    [InlineData(false, true, true, XorO.X_Visible, false)]
    [InlineData(false, true, true, XorO.O_Visible, false)]
    [InlineData(true, true, false, XorO.X_Visible, false)]
    [InlineData(true, true, false, XorO.O_Visible, false)]
    [InlineData(true, true, true, XorO.X_Visible, false)]
    [InlineData(true, true, true, XorO.O_Visible, false)]
    public void GamePlay_CheckIfComputerPlay(bool twoPlayer, bool gameOver, bool isX, XorO computerChoice, bool expected)
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = twoPlayer;
        gamePlay.ViewModel.GameOver = gameOver;
        gamePlay.IsX = isX;
        gamePlay.ComputerChoice = computerChoice;

        var result = gamePlay.CheckIfComputerPlay();

        Assert.True(result == expected);
    }


    #endregion CheckIfComputerPlay

    #region IsComputersTurn

    [Fact]
    public void GamePlay_IsComputersTurn_X_False()
    {
        var gamePlay = GetGamePlay;
        gamePlay.IsX = true;
        gamePlay.ComputerChoice = XorO.O_Visible;
        Assert.False(gamePlay.IsComputersTurn);
    }

    [Fact]
    public void GamePlay_IsComputersTurn_Y_False()
    {
        var gamePlay = GetGamePlay;
        gamePlay.IsX = false;
        gamePlay.ComputerChoice = XorO.X_Visible;
        Assert.False(gamePlay.IsComputersTurn);
    }

    [Fact]
    public void GamePlay_IsComputersTurn_X_True()
    {
        var gamePlay = GetGamePlay;
        gamePlay.IsX = true;
        gamePlay.ComputerChoice = XorO.O_Visible;
        Assert.False(gamePlay.IsComputersTurn);
    }

    [Fact]
    public void GamePlay_IsComputersTurn_Y_True()
    {
        var gamePlay = GetGamePlay;
        gamePlay.IsX = false;
        gamePlay.ComputerChoice = XorO.X_Visible;
        Assert.False(gamePlay.IsComputersTurn);
    }

    #endregion IsComputersTurn

    #region RandomChoice

    [Fact]
    public void GamePLay_RandomChoice()
    {
        var gamePlay = GetGamePlay;

        bool isOne = false;
        bool isTwo = false;
        bool isThree = false;

        foreach (var _ in Enumerable.Range(0, 100))
        {
            int result = gamePlay.RandomChoice([1, 2, 3]);

            if (result == 1)
                isOne = true;
            else if (result == 2)
                isTwo = true;
            else if (result == 3)
                isThree = true;
            else
                Assert.Fail("RandomChoice returned invalid value");
        }

        Assert.True(isOne);
        Assert.True(isTwo);
        Assert.True(isThree);
    }

    #endregion RandomChoice

    #region LetComputerPlayTurn

    [Fact]
    public void GamePlay_LetComputerPlayTurn_ComputerVsComputer()
    {
        const int cNumberOfGames = 100_000;

        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        for (int replay = 0; replay < cNumberOfGames; replay++)
        {
            var trackBoard = "";

            PlayAgainClick(gamePlay);
            int i = 8;
            do
            {
                gamePlay.LetComputerPlayTurn();
                trackBoard += StoreBoard(gamePlay, i);

                var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
                Assert.True(count == i);

                gamePlay.CheckIfWinnerOrDraw();

                i--;
            }
            while (i >= 0 && !gamePlay.ViewModel.GameOver);

            if (gamePlay.ViewModel.HasWinner)
            {
                output.WriteLine($"Failed on attempt number {replay}");
                output.WriteLine(trackBoard);
            }

            Assert.True(gamePlay.ViewModel.GameOver);
            Assert.False(gamePlay.ViewModel.HasWinner);  // should always end in a tie
        }
    }

    [Fact]
    public void GamePlay_LetComputerPlayTurn_RandomVsComputer()
    {
        const int cNumberOfGames = 1_000_000;

        Random rnd = new();

        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        for (int replay = 0; replay < cNumberOfGames; replay++)
        {
            var trackBoard = "";

            PlayAgainClick(gamePlay);
            int i = 8;
            do
            {
                // randomly pick open spot
                int index = 0;
                int choice = rnd.Next(i + 1);
                foreach (SquarePosition position in Enum.GetValues(typeof(SquarePosition)))
                {
                    if (position == SquarePosition.Invalid)
                        continue;

                    if (gamePlay.Board[position.ToInt()].Equals(XorO.None))
                    {
                        if (index == choice)
                        {
                            gamePlay.Play(position);
                            trackBoard += StoreBoard(gamePlay, i);
                            break;
                        }

                        index++;
                    }
                }

                i--;

                gamePlay.CheckIfWinnerOrDraw();

                if (i <= 0 || gamePlay.ViewModel.GameOver)
                    break;

                // let the computer play
                gamePlay.LetComputerPlayTurn();
                trackBoard += StoreBoard(gamePlay, i);

                var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
                Assert.True(count == i);

                gamePlay.CheckIfWinnerOrDraw();

                i--;
            }
            while (i >= 0 && !gamePlay.ViewModel.GameOver);

            Assert.True(gamePlay.ViewModel.GameOver);

            if (gamePlay.ViewModel.HasWinner)  // The computer should always win or tie
            {
                var winner = gamePlay.Board[gamePlay._winningCombinations[gamePlay.WinningSelection].First().ToInt()];

                if (gamePlay.ViewModel.HasWinner && winner != XorO.X_Visible)
                {
                    output.WriteLine($"Failed on attempt number {replay}");
                    output.WriteLine(trackBoard);
                }

                Assert.True(winner.Equals(XorO.X_Visible));
            }

        }
    }

    #endregion LetComputerPlayTurn

    #region Play

    [Fact]
    public void GamePlay_LetPlay_0()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.LeftTop);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[0]);
    }

    [Fact]
    public void GamePlay_LetPlay_1()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.CenterTop);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[1]);
    }

    [Fact]
    public void GamePlay_LetPlay_2()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.RightTop);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[2]);
    }

    [Fact]
    public void GamePlay_LetPlay_3()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.LeftMiddle);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[3]);
    }

    [Fact]
    public void GamePlay_LetPlay_4()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.CenterMiddle);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[4]);
    }

    [Fact]
    public void GamePlay_LetPlay_5()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.RightMiddle);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[5]);
    }

    [Fact]
    public void GamePlay_LetPlay_6()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.LeftBottom);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[6]);
    }

    [Fact]
    public void GamePlay_LetPlay_7()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.CenterBottom);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[7]);
    }

    [Fact]
    public void GamePlay_LetPlay_8()
    {
        var gamePlay = GetGamePlay;
        gamePlay.ViewModel.TwoPlayer = true;

        gamePlay.Play(SquarePosition.RightBottom);

        var count = gamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, gamePlay.Board[8]);
    }

    #endregion Play

    #region Helper

    /// <summary>
    /// Leave a trail that can be reproduced if the computer doesn't win
    /// </summary>
    /// <param name="gamePlay">Reference to the GamePlay.</param>
    /// <param name="index">Current play index counting down from 8.</param>
    private void DebugBoard(GamePlay gamePlay, int index)
    {
        output.WriteLine($"{index}: {DisplayXorO(gamePlay.Board[0])} {DisplayXorO(gamePlay.Board[1])} {DisplayXorO(gamePlay.Board[2])}");
        output.WriteLine($"   {DisplayXorO(gamePlay.Board[3])} {DisplayXorO(gamePlay.Board[4])} {DisplayXorO(gamePlay.Board[5])}");
        output.WriteLine($"   {DisplayXorO(gamePlay.Board[6])} {DisplayXorO(gamePlay.Board[7])} {DisplayXorO(gamePlay.Board[8])}");
        output.WriteLine("");
    }

    /// <summary>
    /// Store the a trail in string format that can be reproduced if the computer doesn't win
    /// </summary>
    /// <param name="gamePlay">Reference to the GamePlay.</param>
    /// <param name="index">Current play index counting down from 8.</param>
    private string StoreBoard(GamePlay gamePlay, int index)
    {
        StringBuilder sb = new();

        sb.AppendLine($"{index}: {DisplayXorO(gamePlay.Board[0])} {DisplayXorO(gamePlay.Board[1])} {DisplayXorO(gamePlay.Board[2])}");
        sb.AppendLine($"   {DisplayXorO(gamePlay.Board[3])} {DisplayXorO(gamePlay.Board[4])} {DisplayXorO(gamePlay.Board[5])}");
        sb.AppendLine($"   {DisplayXorO(gamePlay.Board[6])} {DisplayXorO(gamePlay.Board[7])} {DisplayXorO(gamePlay.Board[8])}");
        sb.AppendLine("");

        return sb.ToString();
    }

    private static char DisplayXorO(XorO value)
    {
        if (value == 0)
            return '-';

        if (value == XorO.X_Visible)
            return 'X';

        return 'O';
    }

    private static GamePlay GetGamePlay
    {
        get
        {

            var gamePlayViewModel = new GamePlayViewModelTest();
            var gamePlay = new GamePlay(gamePlayViewModel);
            gamePlayViewModel.GamePlay = gamePlay;

            return gamePlay;
        }
    }

    private void PlayAgainClick(GamePlay gamePlay)
    {
        gamePlay.IsX = false;
        gamePlay.ComputerChoice = XorO.O_Visible;
        gamePlay.ViewModel.HasWinner = false;
        gamePlay.ViewModel.GameOver = false;

        for (int i = 0; i < gamePlay.Board.Count(); i++)
        {
            gamePlay.Board[i] = XorO.None;
        }
        gamePlay.UpdateInstructions();
        CheckIfComputerCanPlay(gamePlay);
    }

    private void CheckIfComputerCanPlay(GamePlay gamePlay)
    {
        if (gamePlay.CheckIfComputerPlay())
        {
            Thread.Sleep(200);  // add delay to computer response;
            gamePlay.LetComputerPlayTurn();
        }
    }

    #endregion Helper

    #endregion Methods
}

class A
{
    public virtual string GetValue() => "A";

    //private abstract void MyMethod() { }

}

sealed class B : A
{
    public override string GetValue() => "B";

}

public class TestClass
{
    [Fact]
    public void TestMethod()
    {
        A a = new B();
        Console.WriteLine(a.GetValue());
    }
}

public abstract class BaseClass
{
    public BaseClass(string test)
    {
        Print();
    }

    public string MyString => "test";

    public virtual void Print()
    {
        Console.WriteLine("Base");
    }

    public async Task<int> GetValueAsync()
    {
        return await Task.FromResult(5);
    }
}

public interface IMyInterface
{
    int Value { get; }

    void Write() => Console.WriteLine("Log");
}

public class MyClass : IMyInterface
{
    public int Value => 3;

}


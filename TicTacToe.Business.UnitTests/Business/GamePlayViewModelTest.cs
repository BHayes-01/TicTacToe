using TicTacToe.Business.Business;
using TicTacToe.Enums;

namespace TicTacToe.Business.UnitTests.Business;

public class GamePlayViewModelTest : IGamePlayViewModel, IDisposable
{
    public GamePlayViewModelTest()
    {
        GamePlay = new GamePlay();
        GamePlay.ComputerPlayed += GamePlay_ComputerPlayed;
    }

    
    public void Dispose()
    {
        // Unregister to prevent memory leaks
        GamePlay.ComputerPlayed -= GamePlay_ComputerPlayed;
    }


    public IGamePlay GamePlay { get; set; }

    public bool ComputerStarts { get; set; }

    public bool GameOver { get; set; }

    public bool HasWinner { get; set; }

    public string Instructions { get; set; } = string.Empty;

    public bool TwoPlayer { get; set; }

    public int WinningSelection { get; set; }

    public XorO LeftTopChoice
    {
        get => GamePlay.Board[SquarePosition.LeftTop.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.LeftTop.ToInt()] != XorO.None)
                throw new InvalidOperationException();

            GamePlay.Board[SquarePosition.LeftTop.ToInt()] = value;
        }
    }

    public XorO CenterTopChoice
    {
        get => GamePlay.Board[SquarePosition.CenterTop.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.CenterTop.ToInt()] != XorO.None)
                throw new InvalidOperationException();

            GamePlay.Board[SquarePosition.CenterTop.ToInt()] = value;
        }
    }

    public XorO RightTopChoice
    {
        get => GamePlay.Board[SquarePosition.RightTop.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.RightTop.ToInt()] != XorO.None)
                throw new InvalidOperationException();

            GamePlay.Board[SquarePosition.RightTop.ToInt()] = value;
        }
    }

    public XorO LeftMiddleChoice
    {
        get => GamePlay.Board[SquarePosition.LeftMiddle.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.LeftMiddle.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.LeftMiddle.ToInt()] = value;
        }
    }

    public XorO CenterMiddleChoice
    {
        get => GamePlay.Board[SquarePosition.CenterMiddle.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.CenterMiddle.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.CenterMiddle.ToInt()] = value;
        }
    }

    public XorO RightMiddleChoice
    {
        get => GamePlay.Board[SquarePosition.RightMiddle.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.RightMiddle.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.RightMiddle.ToInt()] = value;
        }
    }

    public XorO LeftBottomChoice
    {
        get => GamePlay.Board[SquarePosition.LeftBottom.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.LeftBottom.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.LeftBottom.ToInt()] = value;
        }
    }

    public XorO CenterBottomChoice
    {
        get => GamePlay.Board[SquarePosition.CenterBottom.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.CenterBottom.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.CenterBottom.ToInt()] = value;
        }
    }

    public XorO RightBottomChoice
    {
        get => GamePlay.Board[SquarePosition.RightBottom.ToInt()];
        set
        {
            if (value != XorO.None && GamePlay.Board[SquarePosition.RightBottom.ToInt()] != XorO.None)
                throw new InvalidOperationException();
            GamePlay.Board[SquarePosition.RightBottom.ToInt()] = value;
        }
    }


    public void CenterBottomClick()
    {
        GamePlay.Board[SquarePosition.CenterBottom.ToInt()] = LeftTopChoice;
    }

    public void CenterMiddleClick()
    {
        GamePlay.Board[SquarePosition.CenterMiddle.ToInt()] = CenterMiddleChoice;
    }

    public void CenterTopClick()
    {
        GamePlay.Board[SquarePosition.CenterTop.ToInt()] = CenterTopChoice;
    }

    public void LeftBottomClick()
    {
        GamePlay.Board[SquarePosition.LeftBottom.ToInt()] = LeftBottomChoice;
    }

    public void LeftMiddleClick()
    {
        GamePlay.Board[SquarePosition.LeftMiddle.ToInt()] = LeftMiddleChoice;
    }

    public void LeftTopClick()
    {
        GamePlay.Board[SquarePosition.LeftTop.ToInt()] = LeftTopChoice;
    }

    public void PlayAgainClick()
    {
        for (int i = 0; i < 8; i++)
        {
            GamePlay.Board[i] = XorO.None;
        }
    }

    public void QuitClick()
    {
        // do nothing
    }

    public void RightBottomClick()
    {
        GamePlay.Board[SquarePosition.RightBottom.ToInt()] = RightBottomChoice;
    }

    public void RightMiddleClick()
    {
        GamePlay.Board[SquarePosition.RightMiddle.ToInt()] = RightMiddleChoice;
    }

    public void RightTopClick()
    {
        GamePlay.Board[SquarePosition.RightTop.ToInt()] = RightTopChoice;
    }

    public void RunOnMainThread(Action action)
    {
        action();
    }

    public void UpdateWinningLine()
    {
        // do nothing
    }

    private void GamePlay_ComputerPlayed(object sender, ComputerChoiceEventArgs e)
    {
        switch (e.Square)
        {
            case SquarePosition.LeftTop:
                {
                    LeftTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterTop:
                {
                    CenterTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightTop:
                {
                    RightTopChoice = e.Choice;
                    break;
                }
            case SquarePosition.LeftMiddle:
                {
                    LeftMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterMiddle:
                {
                    CenterMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightMiddle:
                {
                    RightMiddleChoice = e.Choice;
                    break;
                }
            case SquarePosition.LeftBottom:
                {
                    LeftBottomChoice = e.Choice;
                    break;
                }
            case SquarePosition.CenterBottom:
                {
                    CenterBottomChoice = e.Choice;
                    break;
                }
            case SquarePosition.RightBottom:
                {
                    RightBottomChoice = e.Choice;
                    break;
                }

            case SquarePosition.Invalid:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }

}

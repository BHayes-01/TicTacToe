using TicTacToe.Enums;
using System.ComponentModel;

namespace TicTacToe.Business.Business
{
    public interface IGamePlay : INotifyPropertyChanged
    {
        event EventHandler<ComputerChoiceEventArgs>? ComputerPlayed;

        XorO[] Board { get; }
        XorO CenterBottomChoice { get; set; }
        XorO CenterMiddleChoice { get; set; }
        XorO CenterTopChoice { get; set; }
        XorO ComputerChoice { get; set; }
        bool ComputerStarts { get; set; }
        int DelayMilliseconds { get; set; }
        bool GameOver { get; set; }
        bool HasWinner { get; set; }
        string Instructions { get; set; }
        bool IsX { get; set; }
        XorO LeftBottomChoice { get; set; }
        XorO LeftMiddleChoice { get; set; }
        XorO LeftTopChoice { get; set; }
        XorO RightBottomChoice { get; set; }
        XorO RightMiddleChoice { get; set; }
        XorO RightTopChoice { get; set; }
        bool TwoPlayer { get; set; }
        int WinningSelection { get; set; }

        bool CheckIfComputerPlay();
        void PlayAgain();
        void UpdateInstructions();
        void UpdateInstructionsReverse();
    }
}
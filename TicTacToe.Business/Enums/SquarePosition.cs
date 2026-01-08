namespace TicTacToe.Enums;

///  0 | 1 | 2
///  ---------
///  3 | 4 | 5
///  ---------
///  6 | 7 | 8
public enum SquarePosition : int
{
    Invalid = -1,
    LeftTop = 0,
    CenterTop = 1,
    RightTop = 2,
    LeftMiddle = 3,
    CenterMiddle = 4,
    RightMiddle = 5,
    LeftBottom = 6,
    CenterBottom = 7,
    RightBottom = 8,
}

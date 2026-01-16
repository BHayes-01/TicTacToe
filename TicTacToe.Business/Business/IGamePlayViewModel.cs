using TicTacToe.Enums;

namespace TicTacToe.Business.Business;

public interface IGamePlayViewModel
{

    #region Auto Properties From Fields

    GamePlay GamePlay { get; set; }

    #endregion Auto Properties From Fields

    #region Tic-Tac-Toe Square Auto Generated Relay Commands

    /// <summary>
    /// [0] Handles the click event for the left side top square
    /// </summary>
    void LeftTopClick();

    /// <summary>
    /// [1] Handles the click event for the center top square
    /// </summary>
    void CenterTopClick();

    /// <summary>
    /// [2] Handles the click event for the right side top square
    /// </summary>
    void RightTopClick();

    /// <summary>
    /// [3] Handles the click event for the left side middle square
    /// </summary>
    void LeftMiddleClick();

    /// <summary>
    /// [4] Handles the click event for the center square
    /// </summary>
    void CenterMiddleClick();

    /// <summary>
    /// [5] Handles the click event for the right side middle square
    /// </summary>
    void RightMiddleClick();

    /// <summary>
    /// [6] Handles the click event for the left side bottom square
    /// </summary>
    void LeftBottomClick();

    /// <summary>
    /// [7] Handles the click event for the center bottom square
    /// </summary>
    void CenterBottomClick();

    /// <summary>
    /// [8] Handles the click event for the right side bottom square
    /// </summary>
    void RightBottomClick();

    #endregion Tic-Tac-Toe Square Relay Commands

    #region Tic-Tac-Toe Square Properties

    /// <summary>
    /// [0] The current value of the left side top square
    /// </summary>
    XorO LeftTopChoice { get; set; }

    /// <summary>
    /// [1] The current value of the center top square
    /// </summary>
    XorO CenterTopChoice { get; set; }

    /// <summary>
    /// [2] The current value of the right side top square
    /// </summary>
    XorO RightTopChoice { get; set; }

    /// <summary>
    /// [3] The current value of the left side middle square
    /// </summary>
    XorO LeftMiddleChoice { get; set; }

    /// <summary>
    /// [4] The current value of the center square
    /// </summary>
    XorO CenterMiddleChoice { get; set; }

    /// <summary>
    /// [5] The current value of the right side middle square
    /// </summary>
    XorO RightMiddleChoice { get; set; }

    /// <summary>
    /// [6] The current value of the left side bottom square
    /// </summary>
    XorO LeftBottomChoice { get; set; }

    /// <summary>
    /// [7] The current value of the center bottom square
    /// </summary>
    XorO CenterBottomChoice { get; set; }

    /// <summary>
    /// [8] The current value of the right side bottom square
    /// </summary>
    XorO RightBottomChoice { get; set; }

    #endregion Tic-Tac-Toe Square Properties

    #region UI Properties

    /// <summary>
    /// Run the action on the main thread.
    /// </summary>
    /// <param name="action"></param>
    void RunOnMainThread(Action action);

    /// <summary>
    /// Update the position of the winning line.
    /// </summary>
    void UpdateWinningLine();

    #endregion UI Properties


}

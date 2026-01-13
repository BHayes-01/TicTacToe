using CommunityToolkit.Mvvm.Input;
using TicTacToe.ViewModels;
using TicTacToe.Enums;
using Xunit.Abstractions;
using System.Text;

namespace TicTacToe.MAUI.UnitTests.ViewModels;

public class GamePlayViewModelUnitTests(ITestOutputHelper output)
{

    private readonly ITestOutputHelper output = output;

    #region Constructor

    [Fact]
    public void GamePlayViewModel_Constructor()
    {
        var vm = new GamePlayViewModel();

        Assert.NotNull(vm);
    }

    [Fact]
    public void GamePlayViewModel_ApplyQueryAttributes_Constructor_Pass()
    {
        Dictionary<string, object> args = new() { { nameof(GamePlayViewModel.TwoPlayer), true }, { nameof(GamePlayViewModel.ComputerStarts), true } };

        var vm = new GamePlayViewModel();
        vm.ApplyQueryAttributes(args);

        Assert.True(vm.TwoPlayer);
        Assert.True(vm.ComputerStarts);
    }

    [Fact]
    public void GamePlayViewModel_ApplyQueryAttributes_Constructor_Fail_Values()
    {
        Dictionary<string, object> args = new() { { nameof(GamePlayViewModel.TwoPlayer), 3 }, { nameof(GamePlayViewModel.ComputerStarts), false } };

        var vm = new GamePlayViewModel();
        vm.ApplyQueryAttributes(args);

        Assert.False(vm.TwoPlayer);
        Assert.False(vm.ComputerStarts);
    }

    [Fact]
    public void GamePlayViewModel_ApplyQueryAttributes_Constructor_Fail_Names()
    {
        Dictionary<string, object> args = new() { { "2Player", true }, { "ComputerRun", true } };

        var vm = new GamePlayViewModel();
        vm.ApplyQueryAttributes(args);

        Assert.False(vm.TwoPlayer);
        Assert.False(vm.ComputerStarts);
    }

    #endregion Constructor

    #region Tic-Tac-Tow Square Relay Commands

    /// <summary>
    /// [0]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftTopClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.LeftTopClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.LeftTopChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.LeftTopChoice);
    }

    /// <summary>
    /// [1]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterTopClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.CenterTopClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.CenterTopChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.CenterTopChoice);
    }

    /// <summary>
    /// [2]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightTopClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.RightTopClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.RightTopChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.RightTopChoice);
    }

    /// <summary>
    /// [3]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftMiddleClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.LeftMiddleClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.LeftMiddleChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.LeftMiddleChoice);
    }

    /// <summary>
    /// [4]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterMiddleClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.CenterMiddleClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.CenterMiddleChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.CenterMiddleChoice);
    }

    /// <summary>
    /// [5]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightMiddleClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.RightMiddleClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.RightMiddleChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.RightMiddleChoice);
    }

    /// <summary>
    /// [6]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftBottomClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.LeftBottomClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.LeftBottomChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.LeftBottomChoice);
    }

    /// <summary>
    /// [7]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterBottomClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.CenterBottomClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.CenterBottomChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.CenterBottomChoice);
    }

    /// <summary>
    /// [8]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightBottomClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.RightBottomClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));

        Assert.Equal(XorO.None, vm.RightBottomChoice);
        cmd.Execute(null);
        Assert.NotEqual(XorO.None, vm.RightBottomChoice);
    }

    #endregion Tic-Tac-Tow Square Relay Commands

    #region Button Relay Commands

    [Fact]
    public void GamePlayViewModel_PlayAgainClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.PlayAgainClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));
    }

    [Fact]
    public void GamePlayViewModel_QuitClick()
    {
        // arrange
        var vm = new GamePlayViewModel();

        // act
        var cmd = vm.QuitClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(RelayCommand));
    }

    #endregion Button Relay Commands

    #region Tic-Tac-Tow Square Properties

    /// <summary>
    /// [0]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftTopChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.LeftTopChoice = XorO.None;
        Assert.Equal(XorO.None, vm.LeftTopChoice);

        vm.PlayAgainClick();
        vm.LeftTopChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.LeftTopChoice);

        vm.PlayAgainClick();
        vm.LeftTopChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.LeftTopChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [1]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterTopChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.CenterTopChoice = XorO.None;
        Assert.Equal(XorO.None, vm.CenterTopChoice);

        vm.PlayAgainClick();
        vm.CenterTopChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.CenterTopChoice);

        vm.PlayAgainClick();
        vm.CenterTopChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.CenterTopChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [2]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightTopChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.RightTopChoice = XorO.None;
        Assert.Equal(XorO.None, vm.RightTopChoice);

        vm.PlayAgainClick();
        vm.RightTopChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.RightTopChoice);

        vm.PlayAgainClick();
        vm.RightTopChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.RightTopChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [3]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftMiddleChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.LeftMiddleChoice = XorO.None;
        Assert.Equal(XorO.None, vm.LeftMiddleChoice);

        vm.PlayAgainClick();
        vm.LeftMiddleChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.LeftMiddleChoice);

        vm.PlayAgainClick();
        vm.LeftMiddleChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.LeftMiddleChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [4]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterMiddleChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.CenterMiddleChoice = XorO.None;
        Assert.Equal(XorO.None, vm.CenterMiddleChoice);

        vm.PlayAgainClick();
        vm.CenterMiddleChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.CenterMiddleChoice);

        vm.PlayAgainClick();
        vm.CenterMiddleChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.CenterMiddleChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [5]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightMiddleChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.RightMiddleChoice = XorO.None;
        Assert.Equal(XorO.None, vm.RightMiddleChoice);

        vm.PlayAgainClick();
        vm.RightMiddleChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.RightMiddleChoice);

        vm.PlayAgainClick();
        vm.RightMiddleChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.RightMiddleChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [6]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_LeftBottomChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.LeftBottomChoice = XorO.None;
        Assert.Equal(XorO.None, vm.LeftBottomChoice);

        vm.PlayAgainClick();
        vm.LeftBottomChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.LeftBottomChoice);

        vm.PlayAgainClick();
        vm.LeftBottomChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.LeftBottomChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [7]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_CenterBottomChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.CenterBottomChoice = XorO.None;
        Assert.Equal(XorO.None, vm.CenterBottomChoice);

        vm.PlayAgainClick();
        vm.CenterBottomChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.CenterBottomChoice);

        vm.PlayAgainClick();
        vm.CenterBottomChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.CenterBottomChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    /// <summary>
    /// [8]
    /// </summary>
    [Fact]
    public void GamePlayViewModel_RightBottomChoice()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        vm.RightBottomChoice = XorO.None;
        Assert.Equal(XorO.None, vm.RightBottomChoice);

        vm.PlayAgainClick();
        vm.RightBottomChoice = XorO.X_Visible;
        Assert.Equal(XorO.X_Visible, vm.RightBottomChoice);

        vm.PlayAgainClick();
        vm.RightBottomChoice = XorO.O_Visible;
        Assert.Equal(XorO.O_Visible, vm.RightBottomChoice);

        Assert.True(propertyChangedCount >= 2);
    }

    #endregion Tic-Tac-Tow Square Properties

    #region Properties

    [Fact]
    public void GamePlayViewModel_ComputerStarts()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.ComputerStarts;
        vm.ComputerStarts = true;
        Assert.True(vm.ComputerStarts);

        vm.ComputerStarts = false;
        Assert.False(vm.ComputerStarts);
        vm.ComputerStarts = origValue;

        Assert.True(propertyChangedCount >= 2);
    }

    [Fact]
    public void GamePlayViewModel_GameOver()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.GameOver;
        vm.GameOver = true;
        Assert.True(vm.GameOver);

        vm.GameOver = false;
        Assert.False(vm.GameOver);
        vm.GameOver = origValue;

        Assert.True(propertyChangedCount >= 2);
    }

    [Fact]
    public void GamePlayViewModel_GridSize()
    {
        const double cTestValue1 = 102.0;
        const double cTestValue2 = 202.0;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.GridSize;
        vm.GridSize = cTestValue1;
        Assert.True(Math.Abs(vm.GridSize - cTestValue1) < 0.01);
        vm.GridSize = cTestValue2;
        Assert.True(Math.Abs(vm.GridSize - cTestValue2) < 0.01);
        vm.GridSize = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    [Fact]
    public void GamePlayViewModel_HasWinner()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.HasWinner;
        vm.HasWinner = true;
        Assert.True(vm.HasWinner);

        vm.HasWinner = false;
        Assert.False(vm.HasWinner);
        vm.HasWinner = origValue;

        Assert.True(propertyChangedCount >= 2);
    }

    [Fact]
    public void GamePlayViewModel_Instructions()
    {
        const string cTestValue = "Test Winner";

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.Instructions;
        vm.Instructions = cTestValue;
        Assert.Equal(cTestValue, vm.Instructions);

        vm.Instructions = origValue;

        Assert.True(propertyChangedCount >= 2);
    }

    [Fact]
    public void GamePlayViewModel_IsComputersTurn_False()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true }; // prevent the computer from playing 
        vm.PlayAgainClick();
        Assert.False(vm.GamePlay.IsComputersTurn);
    }

    [Fact]
    public void GamePlayViewModel_IsComputersTurn_True()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true }; // prevent the computer from playing 
        vm.PlayAgainClick();
        vm.LeftTopClickCommand.Execute(XorO.None);
        Assert.True(vm.GamePlay.IsComputersTurn);
    }

    [Fact]
    public void GamePlayViewModel_TwoPlayer()
    {
        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.TwoPlayer;
        vm.TwoPlayer = true;
        Assert.True(vm.TwoPlayer);

        vm.TwoPlayer = false;
        Assert.False(vm.TwoPlayer);
        vm.TwoPlayer = origValue;

        Assert.True(propertyChangedCount >= 2);
    }

    [Fact]
    public void GamePlayViewModel_WinningSelection()
    {
        const int cTestValue1 = 1;
        const int cTestValue2 = 3;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.WinningSelection;
        vm.WinningSelection = cTestValue1;
        Assert.Equal(cTestValue1, vm.WinningSelection);
        vm.WinningSelection = cTestValue2;
        Assert.Equal(cTestValue2, vm.WinningSelection);
        vm.WinningSelection = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    [Fact]
    public void GamePlayViewModel_WinningX1()
    {
        const double cTestValue1 = 22.0;
        const double cTestValue2 = 202.0;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.WinningX1;
        vm.WinningX1 = cTestValue1;
        Assert.True(Math.Abs(vm.WinningX1 - cTestValue1) < 0.01);
        vm.WinningX1 = cTestValue2;
        Assert.True(Math.Abs(vm.WinningX1 - cTestValue2) < 0.01);
        vm.WinningX1 = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    [Fact]
    public void GamePlayViewModel_WinningX2()
    {
        const double cTestValue1 = 22.0;
        const double cTestValue2 = 202.0;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.WinningX2;
        vm.WinningX2 = cTestValue1;
        Assert.True(Math.Abs(vm.WinningX2 - cTestValue1) < 0.01);
        vm.WinningX2 = cTestValue2;
        Assert.True(Math.Abs(vm.WinningX2 - cTestValue2) < 0.01);
        vm.WinningX2 = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    [Fact]
    public void GamePlayViewModel_WinningY1()
    {
        const double cTestValue1 = 22.0;
        const double cTestValue2 = 202.0;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.WinningY1;
        vm.WinningY1 = cTestValue1;
        Assert.True(Math.Abs(vm.WinningY1 - cTestValue1) < 0.01);
        vm.WinningY1 = cTestValue2;
        Assert.True(Math.Abs(vm.WinningY1 - cTestValue2) < 0.01);
        vm.WinningY1 = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    [Fact]
    public void GamePlayViewModel_WinningY2()
    {
        const double cTestValue1 = 22.0;
        const double cTestValue2 = 202.0;

        int propertyChangedCount = 0;
        var vm = new GamePlayViewModel();
        vm.PropertyChanged += (obj, PropertyChangedEventArgs) => propertyChangedCount++;

        var origValue = vm.WinningY2;
        vm.WinningY2 = cTestValue1;
        Assert.True(Math.Abs(vm.WinningY2 - cTestValue1) < 0.01);
        vm.WinningY2 = cTestValue2;
        Assert.True(Math.Abs(vm.WinningY2 - cTestValue2) < 0.01);
        vm.WinningY2 = origValue;

        Assert.True(propertyChangedCount >= 3);
    }

    #endregion Properties

    #region Methods

    #region CheckBestChoice

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_0()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.CenterTop || result == SquarePosition.RightTop);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_1()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible,
            CenterTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_2()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible,
            RightTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_3()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            CenterTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.LeftTop || result == SquarePosition.RightTop);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_4()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            CenterTopChoice = XorO.X_Visible,
            LeftTopChoice = XorO.X_Visible
        };

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_5()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            CenterTopChoice = XorO.X_Visible,
            RightTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_6()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.LeftTop || result == SquarePosition.CenterTop);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_7()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.X_Visible,
            LeftTopChoice = XorO.X_Visible
        };

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_8()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.X_Visible,
            CenterTopChoice = XorO.X_Visible
        };
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckBestChoice_9()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };
        var result = vm.GamePlay.CheckBestChoice(threeChoices, XorO.X_Visible);
        Assert.True(result == SquarePosition.Invalid);
    }

    #endregion CheckBestChoice

    #region CheckShouldPlay

    [Fact]
    public void GamePlayViewModel_CheckShouldPlay_0()
    {
        var vm = new GamePlayViewModel();
        vm.PlayAgainClick();

        vm.LeftTopChoice = XorO.X_Visible;
        vm.CenterTopChoice = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = vm.GamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.RightTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckShouldPlay_1()
    {
        var vm = new GamePlayViewModel();
        vm.PlayAgainClick();

        vm.LeftTopChoice = XorO.X_Visible;
        vm.RightTopChoice = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = vm.GamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.CenterTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckShouldPlay_2()
    {
        var vm = new GamePlayViewModel();
        vm.PlayAgainClick();

        vm.CenterTopChoice = XorO.X_Visible;
        vm.RightTopChoice = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = vm.GamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.Equal(SquarePosition.LeftTop, result);
    }

    [Fact]
    public void GamePlayViewModel_CheckShouldPlay_3()
    {
        var vm = new GamePlayViewModel();
        vm.PlayAgainClick();

        vm.RightTopChoice = XorO.X_Visible;
        var threeChoices = new SquarePosition[] { SquarePosition.LeftTop, SquarePosition.CenterTop, SquarePosition.RightTop };

        var result = vm.GamePlay.CheckShouldPlay(threeChoices, XorO.X_Visible);

        Assert.True(result == SquarePosition.Invalid);
    }

    #endregion CheckShouldPlay

    #region CheckIfWinnerOrDraw

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win0_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterTopChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightTopChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(0, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win0_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterTopChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightTopChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(0, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win1_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftMiddleChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(1, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win1_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftMiddleChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(1, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win2_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftBottomChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(2, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win2_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftBottomChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(2, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win3_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(3, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win3_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(3, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win4_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            CenterTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(4, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win4_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            CenterTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(4, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win5_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(5, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win5_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(5, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win6_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(6, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win6_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            LeftTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.RightBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(6, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win7_X()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.X_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftBottomChoice = XorO.X_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(7, vm.WinningSelection);
    }

    [Fact]
    public void GamePlayViewModel_CheckIfWinnerOrDraw_Win7_O()
    {
        var vm = new GamePlayViewModel
        {
            TwoPlayer = true,
            RightTopChoice = XorO.O_Visible
        };
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.CenterMiddleChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.True(vm.WinningSelection == -1);

        vm.LeftBottomChoice = XorO.O_Visible;
        vm.GamePlay.CheckIfWinnerOrDraw();
        Assert.Equal(7, vm.WinningSelection);
    }

    #endregion CheckIfWinnerOrDraw

    #region LetComputerPlayTurn

    [Fact]
    public void GamePlayViewModel_LetComputerPlayTurn_ComputerVsComputer()
    {
        const int cNumberOfGames = 100_000;

        var vm = new GamePlayViewModel { TwoPlayer = true };

        for (int replay = 0; replay < cNumberOfGames; replay++)
        {
            var trackBoard = "";

            vm.PlayAgainClick();
            int i = 8;
            do
            {
                vm.GamePlay.LetComputerPlayTurn();
                trackBoard += StoreBoard(vm, i);

                var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
                Assert.True(count == i);

                i--;
            }
            while (i >= 0 && !vm.GameOver);

            if (vm.HasWinner)
            {
                output.WriteLine($"Failed on attempt number {replay}");
                output.WriteLine(trackBoard);
            }

            Assert.True(vm.GameOver);
            Assert.False(vm.HasWinner);  // should always end in a tie
        }
    }

    [Fact]
    public void GamePlayViewModel_LetComputerPlayTurn_RandomVsComputer()
    {
        const int cNumberOfGames = 1_000_000;

        Random rnd = new();

        var vm = new GamePlayViewModel { TwoPlayer = true };

        for (int replay = 0; replay < cNumberOfGames; replay++)
        {
            var trackBoard = "";

            vm.PlayAgainClick();
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

                    if (vm.GamePlay.Board[position.ToInt()].Equals(XorO.None))
                    {
                        if (index == choice)
                        {
                            vm.GamePlay.Play(position);
                            trackBoard += StoreBoard(vm, i);
                            break;
                        }

                        index++;
                    }
                }

                i--;

                if (i <= 0 || vm.GameOver)
                    break;

                // let the computer play
                vm.GamePlay.LetComputerPlayTurn();
                trackBoard += StoreBoard(vm, i);

                var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
                Assert.True(count == i);

                i--;
            }
            while (i >= 0 && !vm.GameOver);

            Assert.True(vm.GameOver);

            if (vm.HasWinner)  // The computer should always win or tie
            {
                var winner = vm.GamePlay.Board[vm._winningCombinations[vm.WinningSelection].First().ToInt()];

                if (vm.HasWinner && winner != XorO.X_Visible)
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
    public void GamePlayViewModel_LetPlay_0()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.LeftTop);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.LeftTopChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_1()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.CenterTop);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.CenterTopChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_2()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.RightTop);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.RightTopChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_3()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.LeftMiddle);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.LeftMiddleChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_4()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.CenterMiddle);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.CenterMiddleChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_5()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.RightMiddle);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.RightMiddleChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_6()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.LeftBottom);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.LeftBottomChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_7()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.CenterBottom);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.CenterBottomChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_8()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.RightBottom);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.RightBottomChoice);
    }

    [Fact]
    public void GamePlayViewModel_LetPlay_CatchFail()
    {
        var vm = new GamePlayViewModel { TwoPlayer = true };

        vm.GamePlay.Play(SquarePosition.LeftTop);

        var count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.NotEqual(XorO.None, vm.LeftTopChoice);
        var value = vm.LeftTopChoice;

        vm.GamePlay.Play(SquarePosition.LeftTop);

        count = vm.GamePlay.Board.Count(o => o.Equals(XorO.None));
        Assert.Equal(8, count);

        Assert.Equal(vm.LeftTopChoice, value);
    }

    #endregion Play

    #region UpdateInstructions

    [Fact]
    public void GamePlayViewModel_UpdateInstructions_O()
    {
        const string cExpected = $"'O' goes next.";
        var vm = new GamePlayViewModel { TwoPlayer = true };
        vm.GamePlay.UpdateInstructions();
        var instructions = vm.Instructions;

        Assert.True(string.Equals(cExpected, instructions, StringComparison.InvariantCultureIgnoreCase));
    }

    [Fact]
    public void GamePlayViewModel_UpdateInstructions_X()
    {
        const string cExpected = $"'X' goes next.";
        var vm = new GamePlayViewModel { TwoPlayer = true };
        vm.GamePlay.LetComputerPlayTurn();
        vm.GamePlay.UpdateInstructions();
        var instructions = vm.Instructions;

        Assert.True(string.Equals(cExpected, instructions, StringComparison.InvariantCultureIgnoreCase));
    }

    #endregion UpdateInstructions

    #region Helper

    /// <summary>
    /// Leave a trail that can be reproduced if the computer doesn't win
    /// </summary>
    /// <param name="vm">Reference to the GamePlayViewModel.</param>
    /// <param name="index">Current play index counting down from 8.</param>
    private void DebugBoard(GamePlayViewModel vm, int index)
    {
        output.WriteLine($"{index}: {DisplayXorO(vm.GamePlay.Board[0])} {DisplayXorO(vm.GamePlay.Board[1])} {DisplayXorO(vm.GamePlay.Board[2])}");
        output.WriteLine($"   {DisplayXorO(vm.GamePlay.Board[3])} {DisplayXorO(vm.GamePlay.Board[4])} {DisplayXorO(vm.GamePlay.Board[5])}");
        output.WriteLine($"   {DisplayXorO(vm.GamePlay.Board[6])} {DisplayXorO(vm.GamePlay.Board[7])} {DisplayXorO(vm.GamePlay.Board[8])}");
        output.WriteLine("");
    }

    /// <summary>
    /// Store the a trail in string format that can be reproduced if the computer doesn't win
    /// </summary>
    /// <param name="vm">Reference to the GamePlayViewModel.</param>
    /// <param name="index">Current play index counting down from 8.</param>
    private string StoreBoard(GamePlayViewModel vm, int index)
    {
        StringBuilder sb = new();

        sb.AppendLine($"{index}: {DisplayXorO(vm.GamePlay.Board[0])} {DisplayXorO(vm.GamePlay.Board[1])} {DisplayXorO(vm.GamePlay.Board[2])}");
        sb.AppendLine($"   {DisplayXorO(vm.GamePlay.Board[3])} {DisplayXorO(vm.GamePlay.Board[4])} {DisplayXorO(vm.GamePlay.Board[5])}");
        sb.AppendLine($"   {DisplayXorO(vm.GamePlay.Board[6])} {DisplayXorO(vm.GamePlay.Board[7])} {DisplayXorO(vm.GamePlay.Board[8])}");
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

    #endregion Helper

    #endregion Methods

}

using CommunityToolkit.Mvvm.Input;
using TicTacToe.ViewModels;
using TicTacToe.Enums;
using Xunit.Abstractions;

namespace TicTacToeUnitTests.ViewModels
{
    public class GamePlayViewModelUnitTests
    {

        private readonly ITestOutputHelper output;

        public GamePlayViewModelUnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

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
            Dictionary<string, object> args = new() { { nameof(GamePlayViewModel.TwoPlayer), 3 }, { nameof(GamePlayViewModel.ComputerStarts), null } };

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

            Assert.True(vm.LeftTopChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.LeftTopChoice != XorO.None);
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

            Assert.True(vm.CenterTopChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.CenterTopChoice != XorO.None);
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

            Assert.True(vm.RightTopChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.RightTopChoice != XorO.None);
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

            Assert.True(vm.LeftMiddleChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.LeftMiddleChoice != XorO.None);
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

            Assert.True(vm.CenterMiddleChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.CenterMiddleChoice != XorO.None);
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

            Assert.True(vm.RightMiddleChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.RightMiddleChoice != XorO.None);
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

            Assert.True(vm.LeftBottomChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.LeftBottomChoice != XorO.None);
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

            Assert.True(vm.CenterBottomChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.CenterBottomChoice != XorO.None);
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

            Assert.True(vm.RightBottomChoice == XorO.None);
            cmd.Execute(null);
            Assert.True(vm.RightBottomChoice != XorO.None);
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
            Assert.True(vm.LeftTopChoice == XorO.None);

            vm.PlayAgainClick();
            vm.LeftTopChoice = XorO.X_Visible;
            Assert.True(vm.LeftTopChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.LeftTopChoice = XorO.O_Visible;
            Assert.True(vm.LeftTopChoice == XorO.O_Visible);

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
            Assert.True(vm.CenterTopChoice == XorO.None);

            vm.PlayAgainClick();
            vm.CenterTopChoice = XorO.X_Visible;
            Assert.True(vm.CenterTopChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.CenterTopChoice = XorO.O_Visible;
            Assert.True(vm.CenterTopChoice == XorO.O_Visible);

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
            Assert.True(vm.RightTopChoice == XorO.None);

            vm.PlayAgainClick();
            vm.RightTopChoice = XorO.X_Visible;
            Assert.True(vm.RightTopChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.RightTopChoice = XorO.O_Visible;
            Assert.True(vm.RightTopChoice == XorO.O_Visible);

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
            Assert.True(vm.LeftMiddleChoice == XorO.None);

            vm.PlayAgainClick();
            vm.LeftMiddleChoice = XorO.X_Visible;
            Assert.True(vm.LeftMiddleChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.LeftMiddleChoice = XorO.O_Visible;
            Assert.True(vm.LeftMiddleChoice == XorO.O_Visible);

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
            Assert.True(vm.CenterMiddleChoice == XorO.None);

            vm.PlayAgainClick();
            vm.CenterMiddleChoice = XorO.X_Visible;
            Assert.True(vm.CenterMiddleChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.CenterMiddleChoice = XorO.O_Visible;
            Assert.True(vm.CenterMiddleChoice == XorO.O_Visible);

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
            Assert.True(vm.RightMiddleChoice == XorO.None);

            vm.PlayAgainClick();
            vm.RightMiddleChoice = XorO.X_Visible;
            Assert.True(vm.RightMiddleChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.RightMiddleChoice = XorO.O_Visible;
            Assert.True(vm.RightMiddleChoice == XorO.O_Visible);

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
            Assert.True(vm.LeftBottomChoice == XorO.None);

            vm.PlayAgainClick();
            vm.LeftBottomChoice = XorO.X_Visible;
            Assert.True(vm.LeftBottomChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.LeftBottomChoice = XorO.O_Visible;
            Assert.True(vm.LeftBottomChoice == XorO.O_Visible);

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
            Assert.True(vm.CenterBottomChoice == XorO.None);

            vm.PlayAgainClick();
            vm.CenterBottomChoice = XorO.X_Visible;
            Assert.True(vm.CenterBottomChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.CenterBottomChoice = XorO.O_Visible;
            Assert.True(vm.CenterBottomChoice == XorO.O_Visible);

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
            Assert.True(vm.RightBottomChoice == XorO.None);

            vm.PlayAgainClick();
            vm.RightBottomChoice = XorO.X_Visible;
            Assert.True(vm.RightBottomChoice == XorO.X_Visible);

            vm.PlayAgainClick();
            vm.RightBottomChoice = XorO.O_Visible;
            Assert.True(vm.RightBottomChoice == XorO.O_Visible);

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
            Assert.True(string.Equals(vm.Instructions, cTestValue, StringComparison.Ordinal));

            vm.Instructions = origValue;

            Assert.True(propertyChangedCount >= 2);
        }

        [Fact]
        public void GamePlayViewModel_IsComputersTurn_False()
        {
            var vm = new GamePlayViewModel();
            vm.TwoPlayer = true; // prevent the computer from playing
            vm.PlayAgainClick();
            Assert.False(vm.IsComputersTurn);
        }

        [Fact]
        public void GamePlayViewModel_IsComputersTurn_True()
        {
            var vm = new GamePlayViewModel();
            vm.TwoPlayer = true;  // prevent the computer from playing, but the value will be set anyway
            vm.PlayAgainClick();
            vm.LeftTopClickCommand.Execute(XorO.None);
            Assert.True(vm.IsComputersTurn);
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
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 1 || result == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_1()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            vm.CenterTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_2()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_3()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.CenterTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 0 || result == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_4()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.CenterTopChoice = XorO.X_Visible;
            vm.LeftTopChoice = XorO.X_Visible;

            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_5()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.CenterTopChoice = XorO.X_Visible;
            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 0);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_6()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 0 || result == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_7()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.X_Visible;
            vm.LeftTopChoice = XorO.X_Visible;

            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_8()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.X_Visible;
            vm.CenterTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == 0);
        }

        [Fact]
        public void GamePlayViewModel_CheckBestChoice_9()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            var threeChoices = new int[] { 0, 1, 2 };
            var result = vm.CheckBestChoice(threeChoices, XorO.X_Visible);
            Assert.True(result == -1);
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
            var threeChoices = new int[] { 0, 1, 2 };

            var result = vm.CheckShouldPlay(threeChoices, XorO.X_Visible);

            Assert.True(result == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckShouldPlay_1()
        {
            var vm = new GamePlayViewModel();
            vm.PlayAgainClick();

            vm.LeftTopChoice = XorO.X_Visible;
            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };

            var result = vm.CheckShouldPlay(threeChoices, XorO.X_Visible);

            Assert.True(result == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckShouldPlay_2()
        {
            var vm = new GamePlayViewModel();
            vm.PlayAgainClick();

            vm.CenterTopChoice = XorO.X_Visible;
            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };

            var result = vm.CheckShouldPlay(threeChoices, XorO.X_Visible);

            Assert.True(result == 0);
        }

        [Fact]
        public void GamePlayViewModel_CheckShouldPlay_3()
        {
            var vm = new GamePlayViewModel();
            vm.PlayAgainClick();

            vm.RightTopChoice = XorO.X_Visible;
            var threeChoices = new int[] { 0, 1, 2 };

            var result = vm.CheckShouldPlay(threeChoices, XorO.X_Visible);

            Assert.True(result == -1);
        }

        #endregion CheckShouldPlay

        #region CheckIfWinnerOrDraw

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win0_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 0);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win0_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 0);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win1_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win1_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 1);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win2_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win2_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 2);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win3_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 3);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win3_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 3);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win4_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.CenterTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 4);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win4_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.CenterTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 4);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win5_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 5);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win5_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 5);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win6_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 6);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win6_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.LeftTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.RightBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 6);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win7_X()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftBottomChoice = XorO.X_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 7);
        }

        [Fact]
        public void GamePlayViewModel_CheckIfWinnerOrDraw_Win7_O()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.RightTopChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.CenterMiddleChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == -1);

            vm.LeftBottomChoice = XorO.O_Visible;
            vm.CheckIfWinnerOrDraw();
            Assert.True(vm.WinningSelection == 7);
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
                vm.PlayAgainClick();
                int i = 8;
                do
                {
                    vm.LetComputerPlayTurn();
                    //DebugBoard(vm, i);

                    var count = vm._board.Count(o => o.Equals(XorO.None));
                    Assert.True(count == i);

                    i--;
                }
                while (i >= 0 && !vm.GameOver);

                Assert.True(vm.GameOver);
                Assert.False(vm.HasWinner);  // should always end in a tie
            }
        }

        [Fact]
        public void GamePlayViewModel_LetComputerPlayTurn_RandomVsComputer()
        {
            const int cNumberOfGames = 100_000;

            var rnd = new Random();

            var vm = new GamePlayViewModel { TwoPlayer = true };

            for (int replay = 0; replay < cNumberOfGames; replay++)
            {
                vm.PlayAgainClick();
                int i = 8;
                do
                {
                    // randomly pick open spot
                    int index = 0;
                    int choice = rnd.Next(i + 1);
                    for (int j = 0; j <= 8; j++)
                    {
                        if (vm._board[j].Equals(XorO.None))
                        {
                            if (index == choice)
                            {
                                vm.Play(j);
                                DebugBoard(vm, i);
                                break;
                            }

                            index++;
                        }
                    }

                    i--;

                    if (i <= 0 || vm.GameOver)
                        break;

                    // let the computer play
                    vm.LetComputerPlayTurn();
                    DebugBoard(vm, i);
                                        
                    var count = vm._board.Count(o => o.Equals(XorO.None));
                    Assert.True(count == i);

                    i--;
                }
                while (i >= 0 && !vm.GameOver);

                Assert.True(vm.GameOver);

                if (vm.HasWinner)  // The computer should always win or tie
                {
                    var winner = vm._board[vm._winningCombinations[vm.WinningSelection].First()];
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

            vm.Play(0);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.LeftTopChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_1()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(1);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.CenterTopChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_2()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(2);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.RightTopChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_3()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(3);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.LeftMiddleChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_4()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(4);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.CenterMiddleChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_5()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(5);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.RightMiddleChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_6()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(6);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.LeftBottomChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_7()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(7);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.CenterBottomChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_8()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(8);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.RightBottomChoice != XorO.None);
        }

        [Fact]
        public void GamePlayViewModel_LetPlay_CatchFail()
        {
            var vm = new GamePlayViewModel { TwoPlayer = true };

            vm.Play(0);

            var count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.LeftTopChoice != XorO.None);
            var value = vm.LeftTopChoice;

            vm.Play(0);

            count = vm._board.Count(o => o.Equals(XorO.None));
            Assert.True(count == 8);

            Assert.True(vm.LeftTopChoice == value);
        }

        #endregion Play

        #region UpdateInstructions

        [Fact]
        public void GamePlayViewModel_UpdateInstructions_O()
        {
            const string cExpected = $"'O' goes next.";
            var vm = new GamePlayViewModel { TwoPlayer = true };
            vm.UpdateInstructions();
            var instructions = vm.Instructions;

            Assert.True(string.Equals(cExpected, instructions, StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void GamePlayViewModel_UpdateInstructions_X()
        {
            const string cExpected = $"'X' goes next.";
            var vm = new GamePlayViewModel { TwoPlayer = true };
            vm.LetComputerPlayTurn();
            vm.UpdateInstructions();
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
            output.WriteLine($"{index}: {DisplayXorO(vm._board[0])} {DisplayXorO(vm._board[1])} {DisplayXorO(vm._board[2])}");
            output.WriteLine($"   {DisplayXorO(vm._board[3])} {DisplayXorO(vm._board[4])} {DisplayXorO(vm._board[5])}");
            output.WriteLine($"   {DisplayXorO(vm._board[6])} {DisplayXorO(vm._board[7])} {DisplayXorO(vm._board[8])}");
            output.WriteLine("");
        }

        private char DisplayXorO(XorO value)
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

}

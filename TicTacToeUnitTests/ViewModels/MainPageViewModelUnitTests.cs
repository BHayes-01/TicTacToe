using CommunityToolkit.Mvvm.Input;
using TicTacToe.ViewModels;

namespace TicTacToeUnitTests.ViewModels
{
    public class MainPageViewModelUnitTests
    {

        [Fact]
        public void MainPageViewModel_Constructor()
        {
            var vm = new MainPageViewModel();

            Assert.NotNull(vm);
        }

        [Fact]
        public void MainPageViewModel_ComputerStarts()
        {
            int propertyChangedCount = 0;
            var vm = new MainPageViewModel();
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
        public void MainPageViewModel_TwoPlayer()
        {
            int propertyChangedCount = 0;
            var vm = new MainPageViewModel();
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
        public void MainPageViewModel_StartClick()
        {
            // arrange
            var vm = new MainPageViewModel();

            // act
            var cmd = vm.StartClickCommand;   // test relay command

            //assert
            Assert.NotNull(cmd);
            Assert.True(cmd.GetType() == typeof(RelayCommand));
        }

    }

}

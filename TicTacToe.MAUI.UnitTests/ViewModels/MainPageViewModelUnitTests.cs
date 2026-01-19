using CommunityToolkit.Mvvm.Input;
using TicTacToe.Business.Business;
using TicTacToe.ViewModels;

namespace TicTacToe.MAUI.UnitTests.ViewModels;

public class MainPageViewModelUnitTests
{

    [Fact]
    public void MainPageViewModel_Constructor()
    {
        var vm = GetViewModel();

        Assert.NotNull(vm);
    }

    [Fact]
    public void MainPageViewModel_ComputerStarts()
    {
        int propertyChangedCount = 0;
        MainPageViewModel vm = GetViewModel();
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
        MainPageViewModel vm = GetViewModel();
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
        var vm = GetViewModel();

        // act
        var cmd = vm.StartClickCommand;   // test relay command

        //assert
        Assert.NotNull(cmd);
        Assert.True(cmd.GetType() == typeof(AsyncRelayCommand));
    }

    private MainPageViewModel GetViewModel()
    {
        return new MainPageViewModel(new GamePlay());
    }

}

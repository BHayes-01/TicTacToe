using TicTacToe.ViewModels;

namespace TicTacToeUnitTests.ViewModels
{
    public class AboutViewModelUnitTests
    {

        [Fact]
        public void AboutViewModel_Constructor()
        {
            var vm = new AboutViewModel();

            Assert.NotNull(vm);
        }

        [Fact]
        public void AboutViewModel_Author()
        {
            var vm = new AboutViewModel();

            Assert.False(string.IsNullOrEmpty(vm.Author));
        }

        [Fact]
        public void AboutViewModel_Version()
        {
            var vm = new AboutViewModel();

            Assert.False(string.IsNullOrEmpty(vm.Version));
        }

    }
}

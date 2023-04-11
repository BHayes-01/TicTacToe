using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace TicTacToe.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
        }

        #region Relay Commands

        /// <summary>
        /// Handles the button "About" click.
        /// </summary>
        public ICommand LicenseClick => new RelayCommand<string>(async (url) => await Launcher.OpenAsync(url));

        #endregion Relay Commands


        #region Properties

        /// <summary>
        /// Return the current version number
        /// </summary>
        public string Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #endregion Properties

    }
}

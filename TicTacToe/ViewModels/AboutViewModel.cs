using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using System.Windows.Input;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This class is used by the about view to display information.
    /// </summary>
    public partial class AboutViewModel : ObservableObject
    {

        #region Auto Relay Commands from Methods

        /// <summary>
        /// Handles the button "About" click.
        /// </summary>
        [RelayCommand]
        internal async Task UrlClick(string url)
        {
            await Launcher.OpenAsync(url);
        }

        #endregion Relay Commands

        #region Properties

        /// <summary>
        /// Get the author's name
        /// </summary>
        public string Author => "Charles B. Hayes";

        /// <summary>
        /// Return the current version number
        /// </summary>
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #endregion Properties

    }
}

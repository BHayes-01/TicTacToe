using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// This class contains common algorithms for view models.
    /// </summary>
    /// <remarks>
    /// Currently only the notify property changed logic is here, but more may be added.
    /// </remarks>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Helpers for Property Changed

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        /// <param name="name">The calling member's name will be used as the parameter.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Sets the value of a property and raises the property changes event when necessary.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="origValue">The original value.</param>
        /// <param name="newValue">The new Value.</param>
        /// <param name="name">The name of the calling method/property.</param>
        /// <returns>Returns <c>true</c> if the value was different; otherwise, <c>false</c>.</returns>
        public bool SetProperty<T>(ref T origValue, T newValue, [CallerMemberName] string name = null)
        {
            if (Equals(origValue, newValue))
            {
                return false;
            }

            origValue = newValue;
            OnPropertyChanged(name);
            return true;
        }

        #endregion Helpers for Property Changed

    }
}

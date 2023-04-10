using CommonServiceLocator;

namespace TicTacToe.Resources.ViewModels
{

    /// <summary>
    /// Use a locator to initial the single instance view models
    /// </summary>
    public class ViewModelLocator
    {

        public AboutViewModel AboutViewModel =>  GetInstance<AboutViewModel>();

        public GamePlayViewModel GamePlayViewModel => GetInstance<GamePlayViewModel>();

        public GameOverViewModel GameOverViewModel => GetInstance<GameOverViewModel>();

        public GameStartViewModel GameStartViewModel => GetInstance<GameStartViewModel>();


        private static T GetInstance<T>()
        {
            try
            {
                return ServiceLocator.Current.GetInstance<T>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to get an instance of {typeof(T).Name}.\r\n" + ex.Message);
            }
        }

    }
}

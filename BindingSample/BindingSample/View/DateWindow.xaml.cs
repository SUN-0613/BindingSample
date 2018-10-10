using System.Windows;

namespace BindingSample.View
{
    /// <summary>
    /// View
    /// </summary>
    public partial class DateWindow : Window
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        private ViewModel.DateWindow _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        public DateWindow()
        {

            InitializeComponent();

            _ViewModel = new ViewModel.DateWindow();
            DataContext = _ViewModel;

        }
    }
}

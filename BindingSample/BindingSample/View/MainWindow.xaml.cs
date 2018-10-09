using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BindingSample.View
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        ViewModel.MainWindow _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();

            _ViewModel = new ViewModel.MainWindow();
            this.DataContext = _ViewModel;

        }

        /// <summary>
        /// this.ContentRendered
        /// </summary>
        public void this_ContentRendered(object sender, EventArgs e)
        {
            MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }

        /// <summary>
        /// TextBox.GotFocus
        /// </summary>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            this.Dispatcher.InvokeAsync(() =>
            {
                Task.Delay(0);
                ((TextBox)sender).SelectAll();
            });

        }

        /// <summary>
        /// Enterキーでフォーカス移動
        /// </summary>
        private void EnterKeyFocusMove(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Enter:

                    var direction = Keyboard.Modifiers == ModifierKeys.Shift ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next;
                    (FocusManager.GetFocusedElement(this) as FrameworkElement).MoveFocus(new TraversalRequest(direction));

                    e.Handled = true;
                    break;

                default:
                    break;

            }

        }

    }
}

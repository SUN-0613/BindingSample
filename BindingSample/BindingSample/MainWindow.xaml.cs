using System;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BindingSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        MainWindowViewModel _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();

            _ViewModel = new MainWindowViewModel();
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
        /// ボタンクリック
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ViewModel.Calc();
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
        /// TextBox.PreviewKeyDown
        /// </summary>
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyFocusMove(e);
        }

        /// <summary>
        /// ComboBox.PreviewKeyDown
        /// </summary>
        private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyFocusMove(e);
        }

        /// <summary>
        /// Button.PreviewKeyDown
        /// </summary>
        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyFocusMove(e);
        }

        /// <summary>
        /// Enterキーでフォーカス移動
        /// </summary>
        private void EnterKeyFocusMove(KeyEventArgs e)
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

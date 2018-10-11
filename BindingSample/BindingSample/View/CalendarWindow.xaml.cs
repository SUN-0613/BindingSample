using System;
using System.Windows;
using System.ComponentModel;

namespace BindingSample.View
{
    /// <summary>
    /// CalendarWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CalendarWindow : Window, IDisposable
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        private ViewModel.CalendarWindow _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        /// <param name="SelectDate">現在選択日付</param>
        public CalendarWindow(DateTime SelectDate)
        {

            InitializeComponent();

            _ViewModel = new ViewModel.CalendarWindow();
            DataContext = _ViewModel;

            _ViewModel.SelectedDate = SelectDate;

            _ViewModel.PropertyChanged += OnPropertyChanged;

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            _ViewModel.PropertyChanged -= OnPropertyChanged;
        }

        /// <summary>
        /// ViewModelプロパティ変更通知イベント
        /// </summary>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {

                case "Result":
                    DialogResult = _ViewModel.Result;
                    break;

                default:
                    break;

            }

        }

        /// <summary>
        /// 選択日付を返す
        /// </summary>
        /// <returns>選択日付</returns>
        public DateTime ReturnSelectDate()
        {
            return _ViewModel.SelectedDate;
        }

    }

}

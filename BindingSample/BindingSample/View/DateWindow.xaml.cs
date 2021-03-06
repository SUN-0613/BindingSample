﻿using System.Windows;
using System.ComponentModel;
using System;

namespace BindingSample.View
{
    /// <summary>
    /// View
    /// </summary>
    public partial class DateWindow : Window, IDisposable
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

                case "CalendarDate":    //カレンダダイアログ表示

                    View.CalendarWindow Dialog = new View.CalendarWindow(_ViewModel.CalendarDate);
                    bool? Result = Dialog.ShowDialog();

                    if (Result.HasValue && Result.Value == true)
                    {

                        _ViewModel.UpdateDate(Dialog.ReturnSelectDate());

                    }

                    Dialog.Dispose();
                    Dialog = null;

                    break;

                default:
                    break;

            }

        }

    }
}

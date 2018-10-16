using System;
using System.Windows;

namespace BindingSample.View
{
    /// <summary>
    /// SelectMeal.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectMeal : Window, IDisposable
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        private ViewModel.SelectMeal _ViewModel;

        /// <summary>
        /// new
        /// </summary>
        public SelectMeal()
        {

            InitializeComponent();

            _ViewModel = new ViewModel.SelectMeal();
            DataContext = _ViewModel;

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            _ViewModel.Dispose();
            _ViewModel = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSample.ViewModel
{
    /// <summary>
    /// Calendar.ViewModel
    /// </summary>
    class CalendarWindow : Common.ViewModelBase
    {

        /// <summary>
        /// Model
        /// </summary>
        private Model.CalendarWindow _Model;

        /// <summary>
        /// 日付選択コマンド
        /// </summary>
        private Common.DelegateCommand _SelectDateCommand;

        /// <summary>
        /// 選択日付
        /// </summary>
        private DateTime _SelectedDate = DateTime.Parse("1900/01/01");

        /// <summary>
        /// 選択日付プロパティ
        /// </summary>
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                if (!_SelectedDate.Equals(value))
                {
                    _SelectedDate = value;
                    CallPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 開始日付
        /// </summary>
        public DateTime StartDate { get { return _Model.StartDate(); } }

        /// <summary>
        /// 終了日付
        /// </summary>
        public DateTime FinishDate { get { return _Model.FinishDate(); } }

        /// <summary>
        /// 戻り値
        /// </summary>
        private bool _Result = false;

        /// <summary>
        /// 戻り値プロパティ
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                CallPropertyChanged();
            }
        }

        /// <summary>
        /// new
        /// </summary>
        public CalendarWindow()
        {
            _Model = new Model.CalendarWindow();
        }

        /// <summary>
        /// 日付選択コマンドプロパティ
        /// </summary>
        public Common.DelegateCommand SelectDateCommand
        {
            get
            {

                if (_SelectDateCommand == null)
                {
                    _SelectDateCommand = new Common.DelegateCommand(
                        () => { Result = true; },
                        () => true);
                }

                return _SelectDateCommand;

            }
        }

    }

}

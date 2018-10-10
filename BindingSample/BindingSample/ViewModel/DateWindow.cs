using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace BindingSample.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    class DateWindow : Common.ViewModelBase
    {

        private Model.DateWindow Model;

        /// <summary>
        /// 年プロパティ
        /// </summary>
        public ObservableCollection<string> Year { get; set; }

        /// <summary>
        /// 月プロパティ
        /// </summary>
        public ObservableCollection<string> Month { get; set; }

        /// <summary>
        /// 日プロパティ
        /// </summary>
        public ObservableCollection<string> Day { get; set; }

        /// <summary>
        /// 年SelectedIndex
        /// </summary>
        private Int32 _SelectedIndexYear = -1;

        /// <summary>
        /// 月SelectedIndex
        /// </summary>
        private Int32 _SelectedIndexMonth = -1;

        /// <summary>
        /// 日SelectedIndex
        /// </summary>
        private Int32 _SelectedIndexDay = -1;

        /// <summary>
        /// 年SelectedIndexプロパティ
        /// </summary>
        public Int32 SelectedIndexYear
        {
            get { return _SelectedIndexYear; }
            set
            {
                if (!_SelectedIndexYear.Equals(value))
                {
                    _SelectedIndexYear = value;

                    //2月が選択中の場合、閏年により日リストを再取得
                    if (!_SelectedIndexYear.Equals(-1) && (_SelectedIndexMonth + 1).Equals(2) && !_SelectedIndexDay.Equals(-1))
                    {

                        Int32 Tmp = _SelectedIndexDay;
                        SelectedIndexDay = -1;

                        Day.Clear();
                        Model.GetDay(Year[_SelectedIndexYear], Month[_SelectedIndexMonth]).ForEach(Data => { Day.Add(Data); });

                        if (Day.Count <= Tmp)
                        {
                            Tmp = Day.Count - 1;
                        }

                        SelectedIndexDay = Tmp;

                    }

                    CallPropertyChanged();

                    if (!_SelectedIndexYear.Equals(-1) 
                        && !_SelectedIndexMonth.Equals(-1)
                        && !_SelectedIndexDay.Equals(-1))
                    {

                        Answer = Model.MakeDateString(Year[_SelectedIndexYear]
                            , Month[_SelectedIndexMonth]
                            , Day[_SelectedIndexDay]);
                    }

                }
            }
        }

        /// <summary>
        /// 月SelectedIndexプロパティ
        /// </summary>
        public Int32 SelectedIndexMonth
        {
            get { return _SelectedIndexMonth; }
            set
            {
                if (!_SelectedIndexMonth.Equals(value))
                {
                    _SelectedIndexMonth = value;

                    if (!_SelectedIndexYear.Equals(-1) && !_SelectedIndexMonth.Equals(-1))
                    {

                        Int32 Tmp = _SelectedIndexDay;
                        SelectedIndexDay = -1;

                        Day.Clear();
                        Model.GetDay(Year[_SelectedIndexYear], Month[_SelectedIndexMonth]).ForEach(Data => { Day.Add(Data); });

                        if (Day.Count <= Tmp)
                        {
                            Tmp = Day.Count - 1;
                        }

                        SelectedIndexDay = Tmp;

                    }

                    CallPropertyChanged();

                    if (!_SelectedIndexYear.Equals(-1)
                        && !_SelectedIndexMonth.Equals(-1)
                        && !_SelectedIndexDay.Equals(-1))
                    {

                        Answer = Model.MakeDateString(Year[_SelectedIndexYear]
                            , Month[_SelectedIndexMonth]
                            , Day[_SelectedIndexDay]);
                    }

                }
            }
        }

        /// <summary>
        /// 日SelectedIndexプロパティ
        /// </summary>
        public Int32 SelectedIndexDay
        {
            get { return _SelectedIndexDay; }
            set
            {
                if (!_SelectedIndexDay.Equals(value))
                {
                    _SelectedIndexDay = value;
                    CallPropertyChanged();

                    if (!_SelectedIndexYear.Equals(-1)
                        && !_SelectedIndexMonth.Equals(-1)
                        && !_SelectedIndexDay.Equals(-1))
                    {

                        Answer = Model.MakeDateString(Year[_SelectedIndexYear]
                            , Month[_SelectedIndexMonth]
                            , Day[_SelectedIndexDay]);
                    }


                }
            }
        }

        /// <summary>
        /// 変換後出力値
        /// </summary>
        private string _Answer;

        /// <summary>
        /// 変換後出力値プロパティ
        /// </summary>
        public string Answer
        {
            get { return _Answer; }
            set
            {
                _Answer = value;
                CallPropertyChanged();
            }
        }

        /// <summary>
        /// new
        /// </summary>
        public DateWindow()
        {

            Model = new Model.DateWindow();

            Year = new ObservableCollection<string>();
            Month = new ObservableCollection<string>();
            Day = new ObservableCollection<string>();

            Model.GetYear().ForEach(Data => { Year.Add(Data); });
            SelectedIndexYear = 10;                         //今年

            Model.GetMonth().ForEach(Data => { Month.Add(Data); });
            SelectedIndexMonth = DateTime.Now.Month - 1;    //今月

            //Day = Model.GetDay(); //SelectedIndexMonthにて日リスト作成済
            SelectedIndexDay = DateTime.Now.Day - 1;        //今日

        }



    }

}

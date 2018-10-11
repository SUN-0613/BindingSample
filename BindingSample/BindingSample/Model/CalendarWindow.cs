using System;
using System.Text;

namespace BindingSample.Model
{

    /// <summary>
    /// Calendar.Model
    /// </summary>
    class CalendarWindow
    {

        /// <summary>
        /// new
        /// </summary>
        public CalendarWindow()
        {
        }

        /// <summary>
        /// 開始日付の取得
        /// </summary>
        /// <returns>開始日付</returns>
        public DateTime StartDate()
        {

            string Year = (DateTime.Now.Year - 10).ToString();
            string Month = "01";
            string Day = "01";

            return MakeDateTime(Year, Month, Day);

        }

        /// <summary>
        /// 終了日付の取得
        /// </summary>
        /// <returns>終了日付</returns>
        public DateTime FinishDate()
        {

            string Year = (DateTime.Now.Year + 10).ToString();
            string Month = "12";
            string Day = "31";

            return MakeDateTime(Year, Month, Day);

        }

        /// <summary>
        /// 文字列から日付型作成
        /// </summary>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <param name="Day">日</param>
        /// <returns>作成した日付型</returns>
        private DateTime MakeDateTime(string Year, string Month, string Day)
        {

            StringBuilder Str = new StringBuilder();
            DateTime Return;

            Str.Clear();
            Str.Append(Year.ToString()).Append("/").Append(Month).Append("/").Append(Day);

            if (!DateTime.TryParse(Str.ToString(), out Return))
            {
                Return = DateTime.Parse("1900/01/01");
            }

            Str.Clear();
            Str = null;

            return Return;


        }

    }

}

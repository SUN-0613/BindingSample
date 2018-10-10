using System;
using System.Collections.Generic;
using System.Text;

namespace BindingSample.Model
{
    /// <summary>
    /// Model
    /// </summary>
    class DateWindow
    {

        /// <summary>
        /// new
        /// </summary>
        public DateWindow()
        {

        }

        /// <summary>
        /// 年リスト取得
        /// </summary>
        /// <returns>年リスト</returns>
        public List<string> GetYear()
        {

            List<string> Return = new List<string>();
            Int32 ThisYear = DateTime.Now.Year;

            Return.Clear();

            for (Int32 iLoop = ThisYear - 10; iLoop <= ThisYear + 10; iLoop++)
            {
                Return.Add(iLoop.ToString("0000"));
            }

            return Return;

        }

        /// <summary>
        /// 月リスト取得
        /// </summary>
        /// <returns>月リスト</returns>
        public List<string> GetMonth()
        {

            List<string> Return = new List<string>();

            Return.Clear();

            for (Int32 iLoop = 1; iLoop <= 12; iLoop++)
            {
                Return.Add(iLoop.ToString("00"));
            }

            return Return;

        }

        /// <summary>
        /// 日リスト取得
        /// </summary>
        /// <param name="Year">該当年</param>
        /// <param name="Month">該当月</param>
        /// <returns>日リスト</returns>
        public List<string> GetDay(string Year, string Month)
        {

            List<string> Return = new List<string>();
            Int32 MaxDay = DateTime.DaysInMonth(Int32.Parse(Year), Int32.Parse(Month));

            Return.Clear();

            for (Int32 iLoop = 1; iLoop <= MaxDay; iLoop++)
            {
                Return.Add(iLoop.ToString("00"));
            }

            return Return;

        }

        /// <summary>
        /// Comboboxで選択した日付を文字列に変換
        /// </summary>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <param name="Day">日</param>
        /// <returns></returns>
        public string MakeDateString(string Year, string Month, string Day)
        {

            StringBuilder Str = new StringBuilder();
            DateTime Return;

            Str.Clear();
            Str.Append(Year).Append("/").Append(Month).Append("/").Append(Day);

            if (!DateTime.TryParse(Str.ToString(), out Return))
            {
                Return = DateTime.Parse("1900/01/01");
            }

            Str.Clear();
            Str = null;

            return Return.ToString("yyyy/MM/dd");

        }

    }
}

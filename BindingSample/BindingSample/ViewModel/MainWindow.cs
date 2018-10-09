using System;
using BindingSample.Base;

namespace BindingSample.ViewModel
{

    /// <summary>
    /// ViewModel
    /// </summary>
    class MainWindow : ViewModelBase
    {

        /// <summary>
        /// Model
        /// </summary>
        private Model.MainWindow Model;

        /// <summary>
        /// new
        /// </summary>
        public MainWindow()
        {

            Model = new Model.MainWindow();

        }

        /// <summary>
        /// 左辺プロパティ
        /// </summary>
        public string Number1
        {
            get
            {
                return Model.Number1.ToString();
            }
            set
            {

                if (TryParse(value, ref Model.Number1))
                {
                    CallPropertyChanged();
                }

            }
        }

        /// <summary>
        /// 四則演算プロパティ
        /// 0:加算
        /// 1:減算
        /// 2:乗算
        /// 3:除算
        /// </summary>
        public Int32 Arithmetic
        {
            get
            {
                return Model.Arithmetic;
            }
            set
            {
                if (!Model.Arithmetic.Equals(value))
                {
                    Model.Arithmetic = value;
                    CallPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 右辺プロパティ
        /// </summary>
        public string Number2
        {
            get
            {
                return Model.Number2.ToString();
            }
            set
            {

                if (TryParse(value, ref Model.Number2))
                {
                    CallPropertyChanged();
                }

            }
        }

        /// <summary>
        /// 答えプロパティ
        /// </summary>
        public string Answer
        {

            get
            {

                return Model.Calc().ToString();

            }

        }

        /// <summary>
        /// 計算実行
        /// </summary>
        public void Calc()
        {
            //計算イベントを実行
            CallPropertyChanged("Answer");
        }

        /// <summary>
        /// string -> double変換
        /// </summary>
        /// <param name="Value">変換文字</param>
        /// <param name="ErrorReturn">エラー時の戻り値</param>
        /// <returns>変換後実数値</returns>
        private bool TryParse(string Value, ref double Return)
        {

            if (double.TryParse(Value, out double dTmp))
            {

                if (!Return.Equals(dTmp))
                {
                    Return = dTmp;
                    return true;
                }

            }

            return false;

        }

    }
}

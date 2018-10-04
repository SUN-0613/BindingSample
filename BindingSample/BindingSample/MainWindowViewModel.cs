using System;

namespace BindingSample
{

    /// <summary>
    /// ViewModel
    /// </summary>
    class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// 四則演算
        /// </summary>
        private enum ArithmeticEnum
        {
            /// <summary>
            /// 加算
            /// </summary>
            Plus = 0,
            /// <summary>
            /// 減算
            /// </summary>
            Minus,
            /// <summary>
            /// 乗算
            /// </summary>
            Multi,
            /// <summary>
            /// 除算
            /// </summary>
            Division
        }

        /// <summary>
        /// 左辺
        /// </summary>
        private double _Number1;

        /// <summary>
        /// 四則演算
        /// 0:加算
        /// 1:減算
        /// 2:乗算
        /// 3:除算
        /// </summary>
        private Int32 _Arithmetic;

        /// <summary>
        /// 右辺
        /// </summary>
        private double _Number2;

        /// <summary>
        /// 答え
        /// </summary>
        private double _Answer;

        /// <summary>
        /// new
        /// </summary>
        public MainWindowViewModel()
        {

            /*
            _Number1 = -1.0d;
            _Arithmetic = -1;
            _Number2 = -1.0d;
            _Answer = -1.0d;

            Number1 = "0";
            Arithmetic = 0;
            Number2 = "0";
            Answer = "0";
            */

        }

        /// <summary>
        /// 演算
        /// </summary>
        /// <param name="Number1">左辺</param>
        /// <param name="Number2">右辺</param>
        /// <param name="Arithmetic">四則演算</param>
        /// <returns>演算結果</returns>
        public void Calc()
        {

            double Ans;

            switch ((ArithmeticEnum)_Arithmetic)
            {

                case ArithmeticEnum.Plus:
                    Ans = _Number1 + _Number2;
                    break;

                case ArithmeticEnum.Minus:
                    Ans = _Number1 - _Number2;
                    break;

                case ArithmeticEnum.Multi:
                    Ans = _Number1 * _Number2;
                    break;

                case ArithmeticEnum.Division:
                    Ans = _Number2 == 0d ? 0d : _Number1 / _Number2;
                    break;

                default:
                    Ans = 0d;
                    break;

            }

            Answer = Ans.ToString();

        }

        /// <summary>
        /// 左辺プロパティ
        /// </summary>
        public string Number1
        {
            get
            {
                return _Number1.ToString();
            }
            set
            {

                if (TryParse(value, ref _Number1))
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
                return _Arithmetic;
            }
            set
            {
                if (!_Arithmetic.Equals(value))
                {
                    _Arithmetic = value;
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
                return _Number2.ToString();
            }
            set
            {

                if (TryParse(value, ref _Number2))
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

                return _Answer.ToString();

            }
            set
            {

                if (TryParse(value, ref _Answer))
                {
                    CallPropertyChanged();
                }

            }

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

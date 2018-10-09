using System;

namespace BindingSample.Model
{

    /// <summary>
    /// 四則演算
    /// </summary>
    enum ArithmeticEnum
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
    /// Model
    /// </summary>
    class MainWindow
    {

        /// <summary>
        /// 左辺
        /// </summary>
        public double Number1;

        /// <summary>
        /// 四則演算
        /// 0:加算
        /// 1:減算
        /// 2:乗算
        /// 3:除算
        /// </summary>
        public Int32 Arithmetic;

        /// <summary>
        /// 右辺
        /// </summary>
        public double Number2;

        /// <summary>
        /// new
        /// </summary>
        public MainWindow()
        {

            Number1 = 0d;
            Arithmetic = (Int32)ArithmeticEnum.Plus;
            Number2 = 0d;

        }

        /// <summary>
        /// 演算
        /// </summary>
        /// <param name="Number1">左辺</param>
        /// <param name="Number2">右辺</param>
        /// <param name="Arithmetic">四則演算</param>
        /// <returns>演算結果</returns>
        public double Calc()
        {

            switch ((ArithmeticEnum)Arithmetic)
            {

                case ArithmeticEnum.Plus:
                    return Number1 + Number2;

                case ArithmeticEnum.Minus:
                    return Number1 - Number2;

                case ArithmeticEnum.Multi:
                    return Number1 * Number2;

                case ArithmeticEnum.Division:
                    return Number2 == 0d ? 0d : Number1 / Number2;

                default:
                    return 0d;

            }

        }



    }
}

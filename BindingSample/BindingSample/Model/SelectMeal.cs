using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Model
/// </summary>
namespace BindingSample.Model
{
    class SelectMeal : IDisposable
    {

        /// <summary>
        /// 食事型式
        /// </summary>
        public enum MealEnum
        {

            /// <summary>
            /// 朝食
            /// </summary>
            Breakfast,

            /// <summary>
            /// 昼食
            /// </summary>
            Lunch,

            /// <summary>
            /// 夕食
            /// </summary>
            Dinner

        }

        /// <summary>
        /// 食事
        /// </summary>
        public MealEnum Meal;

        /// <summary>
        /// new
        /// </summary>
        public SelectMeal()
        {
            Meal = MealEnum.Breakfast;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            
        }

    }
}

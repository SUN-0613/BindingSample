using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ViewModel
/// </summary>
namespace BindingSample.ViewModel
{
    class SelectMeal : Common.ViewModelBase, IDisposable
    {

        /// <summary>
        /// 食事
        /// </summary>
        public Model.SelectMeal.MealEnum Meal
        {
            get
            {
                return _Model.Meal;
            }
            set
            {
                _Model.Meal = value;
                CallPropertyChanged();
            }
            
        }

        /// <summary>
        /// Model
        /// </summary>
        private Model.SelectMeal _Model;

        /// <summary>
        /// new
        /// </summary>
        public SelectMeal()
        {
            _Model = new Model.SelectMeal();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {
            _Model.Dispose();
            _Model = null;
        }

    }
}

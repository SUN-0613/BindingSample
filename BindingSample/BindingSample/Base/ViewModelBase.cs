﻿using System.ComponentModel;
using System.Diagnostics;

namespace BindingSample.Base
{

    /// <summary>
    /// ViewModel基幹
    /// </summary>
    class ViewModelBase : INotifyPropertyChanged
    {

        /// <summary>
        /// Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged()呼び出し
        /// </summary>
        /// <param name="PropertyName">Changedイベントを発生させたいプロパティ名</param>
        protected void CallPropertyChanged(string PropertyName = "")
        {

            //プロパティ名が指定されていない場合は呼び出し元メソッド名とする
            if (PropertyName.Length.Equals(0))
            {
                StackFrame Caller = new StackFrame(1);                      //呼び出し元メソッド情報
                string[] MethodName = Caller.GetMethod().Name.Split('_');   //呼び出し元メソッド名
                PropertyName = MethodName[MethodName.Length - 1];
            }

            //イベント発生
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));

        }

    }
}

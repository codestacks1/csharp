using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Xiaowen.Windows.Video.Model;

namespace Xiaowen.Windows.Video.ViewModels
{
    /// <summary>
    /// BindableBase 实现了INotifyPropertyChanged
    /// </summary>
    public class QuestionnaireViewModel : BindableBase
    {
        private Questionnaire questionnaire;
        public Questionnaire Questionnaire
        {
            get { return questionnaire; }
            set { SetProperty(ref questionnaire, value); }//设置整个Model
        }

        public IEnumerable<string> AllColors { get; private set; }

        public ICommand SubmitCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }

        /// <summary>
        /// ViewModel有两种方式可以初始化，
        /// 1、在页面xaml中实例化
        ///     d:DataContext="{d:DesignInstance viewModels:QuestionnaireViewModel,IsDesignTimeCreatable=True}"
        /// 2、在其他要使用到该类的函数中
        /// 
        /// 还要注意在Window中实现IView接口
        /// </summary>
        public QuestionnaireViewModel()
        {
            this.Questionnaire = new Questionnaire();
            this.AllColors = new[] { "Red", "Grey", "Blue" };

            this.SubmitCommand = new DelegateCommand<object>(this.OnSubmint);
            this.ResetCommand = new DelegateCommand<object>(this.OnReset);
        }

        private void OnSubmint(object obj)
        {
            MessageBox.Show(this.BuildResultString());
        }

        private void OnReset(object obj)
        {
            this.Questionnaire = new Questionnaire();
        }

        private string BuildResultString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: ");
            builder.Append(this.Questionnaire.Name);
            builder.Append("\nAge: ");
            builder.Append(this.Questionnaire.Age);
            builder.Append("\nQuestion 1: ");
            builder.Append(this.Questionnaire.Quest);
            builder.Append("\nQuestion 2: ");
            builder.Append(this.Questionnaire.FavoriteColor);
            return builder.ToString();
        }
    }
}

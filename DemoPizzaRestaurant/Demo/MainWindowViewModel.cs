using Prism.Commands;
using Prism.Mvvm;

namespace DemoPizzaRestaurant.Demo
{
    public class MainWindowViewModel : BindableBase
    {
        public string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value, "Title");
        }

        public DelegateCommand RunTestCommand { get; set; }
        private void RunTest()
        {
            System.Diagnostics.Debug.WriteLine("Title=" + Title);
        }
        public MainWindowViewModel()
        {
            Title = "窗口标题测试";
            RunTestCommand = new DelegateCommand(new System.Action(RunTest));
        }
    }
}

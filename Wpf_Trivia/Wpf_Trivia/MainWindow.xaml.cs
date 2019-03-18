using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Trivia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HttpApi.InitClient();
        }

        private async Task Load()
        {
            var data = await DataProcessor.LoadData();
            QuestionTextBox.Text = data.Question;
            label1.Content = data.CorrectAnswer;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Load();
        }
    }
}

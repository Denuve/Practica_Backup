using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Trivia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> PossibleAnswers = new List<string>();
        Data TriviaData;

        int QuestionNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            HttpApi.InitClient();
        }

        private async Task Load()
        {
         
            var data = await DataProcessor.LoadData();
           

            IList<JToken> results = data["results"].Children().ToList();

            if (QuestionNumber == results.Count)
            {
                QuestionNumber = 0;
            }

                var length = results[QuestionNumber]["incorrect_answers"].Count<JToken>();

                TriviaData = new Data();

                for (int i = 0; i < length; i++)
                {
                    PossibleAnswers.Add((string)results[QuestionNumber]["incorrect_answers"][i]);
                }

                TriviaData.Question = (string)results[QuestionNumber]["question"];
                TriviaData.CorrectAnswer = (string)results[QuestionNumber]["correct_answer"];
                PossibleAnswers.Add((string)results[QuestionNumber]["correct_answer"]);

                TriviaData.Category = (string)results[QuestionNumber]["category"];
                TriviaData.Difficulty = (string)results[QuestionNumber]["difficulty"];

                AnswerLabel1.Content = PossibleAnswers[0];
                AnswerLabel2.Content = PossibleAnswers[1];
                AnswerLabel3.Content = PossibleAnswers[2];
                AnswerLabel4.Content = PossibleAnswers[3];

                CorrectAnswersLabel.Content = "Corect Answers:" + TriviaData.TotalCorrectAnswers;

                QuestionTextBox.Text = TriviaData.Question;


                CategoryLabel.Content = "Category: " + TriviaData.Category;
                DifficultyLabel.Content = "Difficulty: " + TriviaData.Difficulty;
            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Load();
        }

        private void Answer1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((string)AnswerLabel1.Content == TriviaData.CorrectAnswer)
            {
                TriviaData.TotalCorrectAnswers = TriviaData.TotalCorrectAnswers + 1;
            }
        }

        private void Answer2_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((string)AnswerLabel2.Content == TriviaData.CorrectAnswer)
            {
                TriviaData.TotalCorrectAnswers = TriviaData.TotalCorrectAnswers + 1;
            }
        }

        private void Answer3_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((string)AnswerLabel3.Content == TriviaData.CorrectAnswer)
            {
                TriviaData.TotalCorrectAnswers = TriviaData.TotalCorrectAnswers + 1;
            }
        }

        private void Answer4_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((string)AnswerLabel4.Content == TriviaData.CorrectAnswer)
            {
                TriviaData.TotalCorrectAnswers = TriviaData.TotalCorrectAnswers + 1;
            }
        }

        private async void Button_MouseDoubleClickAsync(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            QuestionNumber = QuestionNumber + 1;
            await Load();
        }
    }
}

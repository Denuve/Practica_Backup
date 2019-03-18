namespace Wpf_Trivia
{
    class Data
    {
        public string Category { get; set; }

        public string QType { get; set; }

        public string CorrectAnswer { get; set; }

        public string Difficulty { get; set; }

        public string Question { get; set; }

        public Incorrect_Answer Incorrect { get; set; }

        public struct Incorrect_Answer
        {
            string incorrect1;
            string incorrect2;
            string incorrect3;
        }
    }
}

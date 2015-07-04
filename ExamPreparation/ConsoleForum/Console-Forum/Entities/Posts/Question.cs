namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class Question : Post, IQuestion
    {
        private string title;

        public Question(int id, string title, string body, IUser aouthor) 
            : base(id, body, aouthor)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("title", "The title cannot be empty!");
                }

                this.title = value;
            }
        }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("[ Question ID: {0} ]", this.Id));
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("Question Title: {0}", this.Title));
            sb.AppendLine(string.Format("Question Body: {0}", this.Body));
            sb.AppendLine(new string('=', 20));

            if (this.Answers.Any())
            {
                sb.AppendLine("Answers:");

                var bestAnswer = this.GetBestAnswer();

                if (bestAnswer != null)
                {
                    sb.AppendLine(bestAnswer.ToString());
                }

                var regularAnswers = this.GetRegularAnswersSortedById();

                foreach (var regularAnswer in regularAnswers)
                {
                    sb.AppendLine(regularAnswer.ToString());
                }
            }
            else
            {
                sb.AppendLine("No answers");
            }

            return sb.ToString().Trim();
        }

        private IAnswer GetBestAnswer()
        {
            var bestAnswer = this.Answers.FirstOrDefault(answer => answer is BestAnswer);

            return bestAnswer;
        }

        private List<IAnswer> GetRegularAnswersSortedById()
        {
            var answers = this.Answers
                .Where(answer => !(answer is BestAnswer))
                .OrderBy(answer => answer.Id)
                .ToList();

            return answers;
        } 
    }
}

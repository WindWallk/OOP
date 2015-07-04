namespace ConsoleForum.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;

            this.Forum.CurrentQuestion = null;

            if (!questions.Any())
            {
                throw new CommandException(Messages.NoQuestions);
            }

            var sortedQuestions = questions.OrderBy(question => question.Id);

            this.Forum.Output.Append(this.AggregateQuestionsToPrint(sortedQuestions));
        }

        private string AggregateQuestionsToPrint(IEnumerable<IQuestion> sortedQuestions)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var sortedQuestion in sortedQuestions)
            {
                sb.AppendLine(sortedQuestion.ToString());
            }

            return sb.ToString();
        }
    }
}

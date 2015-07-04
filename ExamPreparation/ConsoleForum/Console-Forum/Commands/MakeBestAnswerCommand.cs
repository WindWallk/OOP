namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Entities.Posts;

    public class MakeBestAnswerCommand : LoggedUserCommand
    {
        public MakeBestAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            base.Execute();

            var question = this.Forum.CurrentQuestion;

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int answerId = int.Parse(this.Data[1]);

            var answer = question.Answers
                .FirstOrDefault(a => a.Id == answerId);

            if (answer == null)
            {
                throw  new CommandException(Messages.NoAnswer);
            }

            var user = this.Forum.CurrentUser;

            var hasUserPermissionToAddBestAnswer = this.HasUserPermissionToAddBestAnswer(question, user);

            if (!hasUserPermissionToAddBestAnswer)
            {
                throw new CommandException(Messages.NoPermission);
            }

            this.MakeAnswerBestAnswer(question, answer);

            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, answer.Id));
        }

        private void MakeAnswerBestAnswer(IQuestion question, IAnswer answer)
        {
            this.RemoveAnswerFromDatabase(question, answer);
            var bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);
            this.AddAnswerToDatabase(question, bestAnswer);
        }

        private void AddAnswerToDatabase(IQuestion question, BestAnswer bestAnswer)
        {
            question.Answers.Add(bestAnswer);
            this.Forum.Answers.Add(bestAnswer);
        }

        private void RemoveAnswerFromDatabase(IQuestion question, IAnswer answer)
        {
            question.Answers.Remove(answer);
            this.Forum.Answers.Remove(answer);

        }

        private bool HasUserPermissionToAddBestAnswer(IQuestion question, IUser user)
        {
            bool hasUserPermissionToAddBestAnswer = user is IAdministrator || user.Username == question.Author.Username;

            return hasUserPermissionToAddBestAnswer;
        }
    }
}

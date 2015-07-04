namespace ConsoleForum
{
    using System;
    using System.Text;
    using System.Linq;
    using Entities.Posts;

    public class ExtendedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            string welcomeMessage = this.GetWelcomeMessage();

            this.Output.Clear();
            this.Output.AppendLine(welcomeMessage);

            Console.Write(this.Output);

            base.ExecuteCommandLoop();
        }

        private string GetWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendLine(new string('~', 20));

            if (!this.IsLogged)
            {
                welcomeMessage.AppendLine(Messages.GuestWelcomeMessage);
            }
            else
            {
                welcomeMessage.AppendLine(string.Format(
                    Messages.UserWelcomeMessage,
                    this.CurrentUser.Username));
            }

            int countOfHotQuestions = this.GetCountOfHotQuestions();
            int countOfActiveUsers = this.GetCountOfActiveUsers();

            welcomeMessage.AppendLine(string.Format(
                Messages.GeneralHeaderMessage,
                countOfHotQuestions,
                countOfActiveUsers));

            welcomeMessage.AppendLine(new string('~', 20));

            return welcomeMessage.ToString().Trim();
        }

        private int GetCountOfActiveUsers()
        {
            const int MinNumberOfPostsForActiveUsers = 3;

            int countOfActiveUsers = this.Users
                .Select(user => this.Answers
                    .Count(answer => answer.Author == user))
                .Count(usersWithAnswers => usersWithAnswers >= MinNumberOfPostsForActiveUsers);

            return countOfActiveUsers;
        }

        private int GetCountOfHotQuestions()
        {
            int countOfHotQuestions = this.Questions
                .Count(question => question.Answers
                    .Any(answer => answer is BestAnswer));

            return countOfHotQuestions;
        }
    }
}

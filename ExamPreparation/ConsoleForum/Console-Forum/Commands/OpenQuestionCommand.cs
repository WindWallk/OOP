namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);

            var questionToOppen = this.Forum.Questions
                .FirstOrDefault(question => question.Id == questionId);

            if (questionToOppen == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = questionToOppen;

            this.Forum.Output.AppendLine(questionToOppen.ToString());
        }
    }
}

namespace ConsoleForum.Commands
{
    using Contracts;

    public class LoggedUserCommand : AbstractCommand
    {
        public LoggedUserCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}

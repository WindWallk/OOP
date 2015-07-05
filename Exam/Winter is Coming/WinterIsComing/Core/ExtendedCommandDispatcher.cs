namespace WinterIsComing.Core
{
    using Commands;

    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void DispatchCommand(string[] commandArgs)
        {
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);

            base.DispatchCommand(commandArgs);
        }
    }
}

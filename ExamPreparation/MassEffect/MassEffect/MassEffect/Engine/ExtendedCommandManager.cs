namespace MassEffect.Engine
{
    using Commands;

    public class ExtendedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);

            base.SeedCommands();
        }
    }
}

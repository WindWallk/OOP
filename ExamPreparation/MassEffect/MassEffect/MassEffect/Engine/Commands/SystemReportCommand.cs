namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using GameObjects.Locations;
    using Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            StarSystem location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);

            var intactShips = this.GameEngine.Starships
                .Where(s => s.Location == location && s.Health > 0)
                .OrderByDescending(s => s.Health)
                .ThenByDescending(s => s.Shields);

            var destroyedShips = this.GameEngine.Starships
                .Where(s => s.Location == location && s.Health <= 0)
                .OrderBy(s => s.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Intact ships:");
            sb.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            sb.AppendLine("Destroyed ships:");
            sb.AppendLine(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}

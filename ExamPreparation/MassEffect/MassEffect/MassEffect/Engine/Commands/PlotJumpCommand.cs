namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destination = commandArgs[2];

            var ship = this.GetShipByName(shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            var starSystem = this.GameEngine.Galaxy.GetStarSystemByName(destination);

            if (previousLocation.Name == destination)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destination));
            }

            this.GameEngine.Galaxy.TravelTo(ship, starSystem);
            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destination);
        }
    }
}

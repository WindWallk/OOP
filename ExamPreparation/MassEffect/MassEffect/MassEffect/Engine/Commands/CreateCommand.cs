namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Exceptions;
    using GameObjects.Enhancements;
    using GameObjects.Ships;
    using Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string location = commandArgs[3];

            bool starshipExists = this.GameEngine.Starships
                .Any(s => s.Name == shipName);

            if (starshipExists)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var starSystem = this.GameEngine.Galaxy.GetStarSystemByName(location);
            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), type);

            var ship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, starSystem);
            this.GameEngine.Starships.Add(ship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)
                    Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                ship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}

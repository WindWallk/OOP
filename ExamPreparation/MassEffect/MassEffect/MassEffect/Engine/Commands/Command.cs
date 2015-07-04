namespace MassEffect.Engine.Commands
{
    using System.Linq;
    using Exceptions;
    using Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected IStarship GetShipByName(string name)
        {
            return this.GameEngine.Starships
                .First(s => s.Name == name);
        }

        protected void ValidateAlive(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
        }

    }
}

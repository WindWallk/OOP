namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            var attackShip = this.GetShipByName(attackerName);
            var targetShip = this.GetShipByName(targetName);

            this.ProcessStarshipBattle(attackShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attackShip, IStarship targetShip)
        {
            this.ValidateAlive(attackShip);
            this.ValidateAlive(targetShip);

            var battleLocation = attackShip.Location;

            if (battleLocation != targetShip.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            var attack = attackShip.ProduceAttack();
            targetShip.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health < 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}

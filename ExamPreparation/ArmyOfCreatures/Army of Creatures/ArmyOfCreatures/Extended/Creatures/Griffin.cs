namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int GriffinDoubleDefenceWhenDefendingRounds = 5;
        private const int GriffinAddDefenceWhenSkip = 3;


        public Griffin()
            : base(
                  DefaultGriffinAttack,
                  DefaultGriffinDefense,
                  DefaultGriffinHealth,
                  DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDoubleDefenceWhenDefendingRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinAddDefenceWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}

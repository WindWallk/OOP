namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        private const int BlizzardDefaultEnergyCost = 40;

        public Blizzard(int damage)
            : base(damage, BlizzardDefaultEnergyCost)
        {
        }
    }
}

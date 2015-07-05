namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        private const int CleaveDefaultEnergyCost = 15;

        public Cleave(int damage)
            : base(damage, CleaveDefaultEnergyCost)
        {
        }
    }
}

namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        private const int StompDefaultEnergyCost = 10;

        public Stomp(int damage)
            : base(damage, StompDefaultEnergyCost)
        {
        }
    }
}

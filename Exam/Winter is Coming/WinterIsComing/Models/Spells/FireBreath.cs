namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int FireBreathDefaultEnergyCost = 30;
        public FireBreath(int damage)
            : base(damage, FireBreathDefaultEnergyCost)
        {
        }
    }
}

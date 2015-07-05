namespace WinterIsComing.Models.Units
{
    using Contracts;

    public class Mage : Unit
    {
        private const int MageDefaultAttackPoints = 80;
        private const int MageDefaultDefensePoints = 40;
        private const int MageDefaultEnergyPoints = 120;
        private const int MageDefautHealthPoints = 80;
        private const int MageDefaultRange = 2;

        private int spellPicker = 1;

        public Mage(string name, int x, int y) 
            : base(
                  MageDefaultAttackPoints, 
                  MageDefaultDefensePoints,
                  MageDefaultEnergyPoints,
                  MageDefautHealthPoints,
                  name, 
                  MageDefaultRange,
                  x,
                  y)
        {
            this.SpellPicker = this.spellPicker;
        }

        public int SpellPicker { get; set; }
    }
}

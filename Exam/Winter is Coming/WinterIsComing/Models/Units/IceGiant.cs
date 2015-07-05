namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        private const int IceGiantDefaultAttackPoints = 150;
        private const int IceGiantDefaultDefensePoints = 60;
        private const int IceGiantDefaultEnergyPoints = 50;
        private const int IceGiantDefautHealthPoints = 300;
        private const int IceGiantDefaultRange = 1;

        public IceGiant(string name, int x, int y) 
            : base(
                  IceGiantDefaultAttackPoints, 
                  IceGiantDefaultDefensePoints,
                  IceGiantDefaultEnergyPoints, 
                  IceGiantDefautHealthPoints,
                  name,
                  IceGiantDefaultRange,
                  x,
                  y)
        {
        }
    }
}

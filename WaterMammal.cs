namespace CRUMGame
{
    public class WaterMammal : AAquaticAnimal
    {
        const string DefFamily = "Cetacio";
        public const int ValueOfX = 25;

        public WaterMammal(int nRescue, int afectionRate, float weight, string name,
                                string species, string family, string location, string dateRescue) :
                            base(nRescue, afectionRate, weight, name, species, family, location, dateRescue)
        {

        }
        public WaterMammal(int nRescue, int afectionRate) : base(nRescue, afectionRate, DefFamily)
        {

        }
        public override void CalcNewAR(int option)
        {
            int xValue = option == (int)RescueType.treat ? ValueOfX : 0;
            AfectionRate = Convert.ToInt32(AfectionRate * (Math.Log(AfectionRate,10)) - xValue);
        }
    }
}
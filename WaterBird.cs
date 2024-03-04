namespace CRUMGame
{
    public class WaterBird : AAquaticAnimal
    {
        const string DefFamily = "Aves marinas";
        public const int ValueOfX = 5;

        public WaterBird(int nRescue, int afectionRate, float weight, string name,
                                string species, string family, string location, string dateRescue) :
                            base(nRescue, afectionRate, weight, name, species, family, location, dateRescue)
        {

        }
        public WaterBird(int nRescue, int afectionRate) : base(nRescue, afectionRate, DefFamily)
        {

        }
        public override void CalcNewAR(int option)
        {
            int xValue = option == (int)RescueType.treat ? ValueOfX : 0;
            AfectionRate = Convert.ToInt32(AfectionRate * (Math.Pow(AfectionRate,2)+xValue));
        }
    }
}
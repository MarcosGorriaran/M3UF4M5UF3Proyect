namespace CRUMGame
{
    public class MarineTurtle:AAquaticAnimal
    {
        const string DefFamily = "Tortuga marina";
        public const int ValueOfX= 5;

        public MarineTurtle(int nRescue, int afectionRate, float weight, string name,
                                string species, string family, string location, string dateRescue):
                            base(nRescue, afectionRate, weight, name, species, family, location, dateRescue)
        {

        }
        public MarineTurtle(int nRescue, int afectionRate) : base(nRescue, afectionRate,DefFamily)
        {

        }
        public override void CalcNewAR(int option)
        {
            AfectionRate = AfectionRate * ((AfectionRate - 2)*(2 * AfectionRate + 3)) - ValueOfX;
        }
    }
}

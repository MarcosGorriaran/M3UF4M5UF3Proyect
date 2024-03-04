using ConsoleTable;
namespace CRUMGame
{
    public abstract class AAquaticAnimal
    {
        const string StartNRescueSeq = "RES";
        const string WeightFormat = "KG";
        const string RescueTableTitle = "Rescate";
        const string InfoTableTitle = "Fixa";
        const string NRescueColTitle = "# Rescate";
        const string DateColTitle = "Fecha rescate";
        const string SpeciesColTitle = "Especie";
        const string ARColTitle = "GA";
        const string LocationColTitle = "Localizacion";
        const string NameColTitle = "# Nombre";
        const string FamilyColTitle = "Superfamilia";
        const string WeightColTitle = "Peso aproximado";
        const string DefDateRescue = "01/01/1970";
        const string DefLocation = "Somewhere";
        const string DefSpecies = "LeFish";
        const string DefName = "Someone";
        const float DefWeight = 20.5f;
        const int DefAfectionRate = 0;
        const int DefNRescue = 0;
        public const int IDMinLimit = 0;
        public const int IDMaxLimit = 999;
        public const int ARMinLimit = 0;
        public const int ARMaxLimit = 99;
        public enum RescueType:int
        {
            toCRUM=0,
            treat=1

        }

        private string dateRescue;
        private string location;
        private string family;
        private string species;
        private string name;
        private float weight;
        private int afectionRate;
        private int nRescue;

        public AAquaticAnimal(int nRescue, int afectionRate,float weight, string name, 
                                string species, string family, string location, string dateRescue)
        {
            this.DateRescue = dateRescue;
            this.Location = location;
            this.Family = family;
            this.Species = species;
            this.Name = name;
            this.Weight = weight;
            this.AfectionRate = afectionRate;
            this.NRescue = nRescue;
        }
        public AAquaticAnimal(int nRescue, int afectionRate, string family):this(nRescue, afectionRate, DefWeight,
                                                                                DefName, DefSpecies, family, DefLocation,
                                                                                DefDateRescue)
        {

        }

        public abstract void CalcNewAR(int option);

        public Table BuildRescueTable()
        {
            Cell[,] tableContent = new Cell[,]
            {
                {
                    new Cell(NRescueColTitle,true),
                    new Cell(DateColTitle,true),
                    new Cell(FamilyColTitle,true),
                    new Cell(ARColTitle,true),
                    new Cell(LocationColTitle,true)
                },
                {
                    new Cell(StartNRescueSeq+NRescue,false),
                    new Cell(DateRescue,false),
                    new Cell(Family,false),
                    new Cell(AfectionRate+"",false),
                    new Cell(Location,false),
                }
            };
            return new Table(tableContent, RescueTableTitle);
        }
        public Table BuildInfoTable()
        {
            Cell[,] tableContent = new Cell[,]
            {
                {
                    new Cell(NameColTitle,true),
                    new Cell(FamilyColTitle,true),
                    new Cell(SpeciesColTitle,true),
                    new Cell(WeightColTitle,true)
                },
                {
                    new Cell(Name,false),
                    new Cell(Family,false),
                    new Cell(Species,false),
                    new Cell(Weight+"",false),
                }
            };
            return new Table(tableContent, InfoTableTitle);
        }
        public string DateRescue
        {
            get { return dateRescue; }
            set { dateRescue = value; }
        }
        
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Family
        {
            get { return family; }
            set { family = value; }
        }
        public string Species
        {
            get { return species; }
            set { species = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Weight
        {
            get { return weight; }
            set {  weight = value; }
        }
        public int AfectionRate
        {
            get { return afectionRate; }
            set 
            {
                if(value < ARMinLimit || value > ARMaxLimit)
                {
                    throw new Exception();
                }

                afectionRate = value; 
            }
        }
        public int NRescue
        {
            get { return nRescue; }
            set 
            {
                if(value<IDMinLimit || value > IDMaxLimit)
                {
                    throw new Exception();
                }
                nRescue = value; 
            }
        }
    }
}

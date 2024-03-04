

namespace CRUMGame
{
    /// <summary>
    /// Class Responsible of keeping track of the player's stats and info
    /// </summary>
    public class Player
    {
        public const string TechRole = "Tecnico";
        public const string VetRole = "Veterinario";
        public const int PositiveFeedback = 50;
        public const int NegativeFeedback = -20;
        private string name;
        private string role;
        private int xp;
        
        public Player(string name, string role, int xp)
        {
            this.Name = name;
            this.Role = role;
            this.XP = xp;
        }
        public Player(string name, string role) : this(name, role, 0)
        {

        }
        public Player() : this("", "")
        {

        }

        /// <summary>
        /// The method will either add 50 XP points or substract 20 XP points depending on what feedback si provided in the form of a boolean
        /// </summary>
        /// <param name="isPositive">This boolean dictates if the feedbaack is positive(True) or negative(False)</param>
        public void XPFeedback(bool isPositive)
        {
            XP += isPositive ? PositiveFeedback : NegativeFeedback;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public int XP
        {
            get { return xp; }
            set { xp = value; }
        }
    }
}

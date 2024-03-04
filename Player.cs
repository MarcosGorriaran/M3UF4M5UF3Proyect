﻿

namespace CRUMGame
{
    public class Player
    {
        const int PositiveFeedback = 50;
        const int NegativeFeedback = -20;
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

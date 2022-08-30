namespace PlayingCard
{
    abstract class Suit
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Suit(string name)
        {
            Name = name;
        }
    }
}
namespace PlayingCard
{
    internal class Card
    {
        private string suitName;
        private short number;

        public short Number
        {
            get { return number; }
            set { number = value; }
        }


        public string SuitName
        {
            get { return suitName; }
            set { suitName = value; }
        }

        public Card(Suit suit, short number)
        {
            SuitName = suit.Name;
            Number = number;
        }

        public override string ToString()
        {
            string answer = String.Empty;
            if (Number == 11)
                answer = "Jack";
            else if (Number == 12)
                answer = "Queen";
            else if (Number == 13)
                answer = "King";
            else if (Number == 14)
                answer = "Ace";
            else
                answer = Convert.ToString(Number);
            return $"{answer} of {SuitName}";
        }

    }
}
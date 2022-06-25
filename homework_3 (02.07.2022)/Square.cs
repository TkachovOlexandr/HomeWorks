using System;

namespace Figure
{
    internal class Square
    {
        private char userChar;
        private short length;

        public char UserChar
        {
            get { return userChar; }
            set { userChar = value; }
        }
        public short Length
        {
            get { return length; }
            set { length = value; }
        }

        public Square()
        {
            UserChar = '*';
            Length = 0;
        }

        public Square(char user_char, short user_length)
        {
            this.UserChar = user_char;
            this.Length = user_length;
        }

        public Square(Square square)
        {
            this.UserChar = square.UserChar;
            this.Length = square.Length;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                    Console.Write(UserChar);
                Console.WriteLine();
            }
        }
    }
}

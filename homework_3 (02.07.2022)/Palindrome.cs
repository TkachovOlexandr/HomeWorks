using System;

namespace Number
{
    internal class Palindrome
    {
        private int userNumber;

        public int UserNumber
        {
            get { return userNumber; }
            set { userNumber = value; }
        }

        public Palindrome()
        {
            UserNumber = 0;
        }

        public Palindrome(int user_number)
        {
            this.UserNumber = user_number;
        }

        public Palindrome(Palindrome palindrome)
        {
            this.UserNumber = palindrome.UserNumber;
        }

        public bool IsPalindrome()
        {
            int num_1 = this.userNumber;
            short numOfDigits = 0;
            while (num_1 > 0)
            {
                num_1 /= 10;
                numOfDigits++;
            }
            short[] digitsOfNum = new short[numOfDigits];
            int num_2 = this.userNumber;
            for (short i = 0; i < numOfDigits; i++)
            {
                digitsOfNum[i] = Convert.ToInt16(num_2 % 10);
                num_2 /= 10;
            }
            for (short i = 0; i < numOfDigits / 2; i++)
            {
                if (digitsOfNum[i] != digitsOfNum[numOfDigits - i - 1])
                    return false;
            }
            return true;
        }

        public string CompleteAnswer()
        {
            string yesOrNo = String.Empty;
            if (this.IsPalindrome())
                yesOrNo = new String("is");
            else
                yesOrNo = new String("isn't");
            return $"{this.UserNumber} {yesOrNo} a palindrome";
        }
    }
}

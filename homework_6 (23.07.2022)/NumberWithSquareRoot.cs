namespace Algebra
{
    internal class NumberWithSquareRoot
    {
        private float beforeRoot;
        private float underRoot;

        public float BeforeRoot
        {
            get { return beforeRoot; }
            set { beforeRoot = value; }
        }
        public float UnderRoot
        {
            get { return underRoot; }
            set { underRoot = value; }
        }

        public NumberWithSquareRoot()
        {
            BeforeRoot = 0;
            UnderRoot = 0;
        }
        public NumberWithSquareRoot(float beforeRoot, float underRoot)
        {
            this.BeforeRoot = beforeRoot;
            this.UnderRoot = underRoot;
            for (int i = 2; i <= UnderRoot / 2; i++)
            {
                if (underRoot < i)
                    break;
                short tmp = 0;
                while (underRoot % i == 0)
                {
                    underRoot /= i;
                    tmp++;
                    if (tmp % 2 == 0 && tmp != 0)
                        BeforeRoot *= i;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            NumberWithSquareRoot? nwsr = obj as NumberWithSquareRoot;
            if (nwsr != null)
            {
                if (this.BeforeRoot == nwsr.BeforeRoot && this.UnderRoot == nwsr.UnderRoot)
                    return true;
                else
                {
                    float tmp_1 = this.BeforeRoot * this.BeforeRoot * this.UnderRoot;
                    float tmp_2 = nwsr.BeforeRoot * nwsr.BeforeRoot * nwsr.UnderRoot;
                    //Console.WriteLine(tmp_1 - tmp_2);
                    if (tmp_1 - tmp_2 >= -15 && tmp_1 - tmp_2 <= 15)
                        return true;
                }
            }
            return false;
        }
    }
}

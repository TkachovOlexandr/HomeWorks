using System;

namespace ArrayOperation
{
    internal class Filtration
    {
        private short mainArrayLength;
        private short[] mainArray;
        private short filtrationArrayLength;
        private short[] filtrationArray;

        public short MainArrayLength
        {
            get { return mainArrayLength; }
            set { mainArrayLength = value; }
        }
        public short[] MainArray
        {
            get { return mainArray; }
            set { mainArray = value; }
        }
        public short FiltrationArrayLength
        {
            get { return filtrationArrayLength; }
            set { filtrationArrayLength = value; }
        }
        public short[] FiltrationArray
        {
            get { return filtrationArray; }
            set { filtrationArray = value; }
        }

        public Filtration()
        {
            MainArrayLength = 0;
            MainArray = new short[MainArrayLength];
            FiltrationArrayLength = 0;
            FiltrationArray = new short[FiltrationArrayLength];
        }

        public Filtration(short[] main_array, short[] filtration_array)
        {
            this.MainArrayLength = Convert.ToInt16(main_array.Length);
            this.MainArray = new short[MainArrayLength];
            for (short i = 0; i < MainArrayLength; i++)
                this.MainArray[i] = main_array[i];
            this.FiltrationArrayLength = Convert.ToInt16(filtration_array.Length);
            this.FiltrationArray = new short[FiltrationArrayLength];
            for (short i = 0; i < FiltrationArrayLength; i++)
                this.FiltrationArray[i] = filtration_array[i];
        }

        public Filtration(Filtration filtration)
        {
            this.MainArrayLength = filtration.MainArrayLength;
            this.MainArray = new short[MainArrayLength];
            for (short i = 0; i < MainArrayLength; i++)
                this.MainArray[i] = filtration.MainArray[i];
            this.FiltrationArrayLength = filtration.FiltrationArrayLength;
            this.FiltrationArray = new short[FiltrationArrayLength];
            for (short i = 0; i < FiltrationArrayLength; i++)
                this.FiltrationArray[i] = filtration.FiltrationArray[i];
        }

        public void Add(short? to_main_array, short? to_filtration_array)
        {
            if (to_main_array != null)
            {
                MainArrayLength++;
                Array.Resize<short>(ref mainArray, MainArrayLength);
                MainArray[MainArrayLength - 1] = (short)to_main_array;
            }
            if (to_filtration_array != null)
            {
                FiltrationArrayLength++;
                Array.Resize<short>(ref filtrationArray, FiltrationArrayLength);
                FiltrationArray[FiltrationArrayLength - 1] = (short)to_filtration_array;
            }
        }

        public void Filter()
        {
            for (short i = 0; i < MainArrayLength; i++)
            {
                for (short j = 0; j < FiltrationArrayLength; j++)
                {
                    if (MainArray[i] == FiltrationArray[j])
                    {
                        for (int k = i; k < MainArrayLength - 1; k++)
                            MainArray[k] = MainArray[k + 1];
                        MainArrayLength--;
                        Array.Resize<short>(ref mainArray, MainArrayLength);
                        break;
                    }
                }
            }
        }

        public string ShowMainArray()
        {
            return $"Main array: {string.Join(" ", MainArray)}";
        }

        public string ShowFiltrationArray()
        {
            return $"Filtration array: {string.Join(" ", FiltrationArray)}";
        }
    }
}

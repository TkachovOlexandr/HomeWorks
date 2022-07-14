using Medieval_Armies.Troops;

namespace Medieval_Armies.Champaign
{
    internal class Battlefield /* Поле боя */
    {
        public const short width = 100;
        public const short height = 20;
        private short[,] champaign = new short[height, width];

        public short Width// Ширина поля
        {
            get { return width; }
        }
        public short Height// Высота поля
        {
            get { return height; }
        }
        public short this[short i, short j]// Поле боя
        {
            get { return champaign[i, j]; }
            set { champaign[i, j] = value; }
        }
        public short[,] Champaign// Поле боя
        {
            get { return champaign; }
        }

        public Battlefield() { }

        delegate void ColorOfConsole();
        ColorOfConsole colorOfConsole;

        private void DarkGreenColor()// Зелёный цвет
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }
        private void BlueColor()// Синий цвет
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        private void DarkRedColor()// Красный цвет
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
        private void BlackColor()// Чёрный цвет
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Show(SoldierBase[] soldiers)// Полностью вывести поле боя на экран
        {
            for (short i = 0; i < Height; i++)
            {
                for (short j = 0; j < Width; j++)
                {
                    if (champaign[i, j] == 0)
                        colorOfConsole = DarkGreenColor;
                    else
                    {
                        bool IsAlive = true;
                        for (short k = 0; k < soldiers.Length; k++)
                        {
                            if (soldiers[k].LocationX == j && soldiers[k].LocationY == i)
                            {
                                IsAlive = soldiers[k].HitPoint == 0 ? false : true;
                                break;
                            }
                        }
                        if (IsAlive)
                        {
                            if (champaign[i, j] == 1)
                                colorOfConsole = BlueColor;
                            else
                                colorOfConsole = DarkRedColor;
                        }
                        else
                            colorOfConsole = BlackColor;
                    }
                    colorOfConsole?.Invoke();
                    Console.Write(" ");
                }
                colorOfConsole = BlackColor;
                colorOfConsole?.Invoke();
                Console.WriteLine();
            }
        }
        public bool IsTheBattleOver(SoldierBase[] soldiers)// Закончен ли уже бой?
        {
            for (short i = 0; i < soldiers.Length; i++)
            {
                if (soldiers[i].EnemyIsDefeated == true)
                    return true;
            }
            return false;
        }
    }
}
using Medieval_Armies.Weaponry;
using Medieval_Armies.Way_of_moving;

namespace Medieval_Armies.Troops
{
    abstract class SoldierBase /* Солдат (base) */
    {
        private string name;
        private short hitPoint;
        private float weaponProficiency;
        private WeaponBase weapon;
        private WayOfMovingBase wayOfMoving;
        private short locationX;
        private short locationY;
        private short groupNumber;
        private bool enemyIsDefeated;

        public string Name// Имя
        {
            get { return name; }
            set { name = value; }
        }
        public short HitPoint// Очки здоровья
        {
            get { return hitPoint; }
            set { hitPoint = value; }
        }
        public float WeaponProficiency// Коэфициент профессиональности в работе с оружием
        {
            get { return weaponProficiency; }
            set { weaponProficiency = value; }
        }
        public WeaponBase Weapon// Оружие
        {
            get { return weapon; }
            private set { weapon = value; }
        }
        public WayOfMovingBase WayOfMoving// Способ передвижения
        {
            get { return wayOfMoving; }
            set { wayOfMoving = value; }
        }
        public short LocationX// Координата по X
        {
            get { return locationX; }
            set { locationX = value; }
        }
        public short LocationY// Координата по Y
        {
            get { return locationY; }
            set { locationY = value; }
        }
        public short GroupNumber// Номер группы
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }
        public bool EnemyIsDefeated// Является ли враг поверженным?
        {
            get { return enemyIsDefeated; }
            set { enemyIsDefeated = value; }
        }

        private SoldierBase() { }
        protected SoldierBase(string name, short hitPoint, float weaponProficiency, WeaponBase weapon, WayOfMovingBase wayOfMoving, short locationX, short locationY, short groupNumber, bool enemyIsDefeated)
        {
            Name = name;
            HitPoint = hitPoint;
            WeaponProficiency = weaponProficiency;
            Weapon = weapon;
            WayOfMoving = wayOfMoving;
            LocationX = locationX;
            LocationY = locationY;
            GroupNumber = groupNumber;
            EnemyIsDefeated = enemyIsDefeated;
        }

        private void Move(short distance_to_rival, short rivalX, short rivalY, short[,] battlefield)// Передвигатся
        {
            float ratio = (float)(WayOfMoving.Speed / Math.Sqrt(distance_to_rival));
            short location_to_move_X = Convert.ToInt16((LocationX + ratio * rivalX) / (1 + ratio));
            short location_to_move_Y = Convert.ToInt16((LocationY + ratio * rivalY) / (1 + ratio));
            short value = battlefield[LocationY, LocationX];
            battlefield[LocationY, LocationX] = 0;
            Console.SetCursorPosition(LocationX, LocationY);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(" ");
            Console.SetCursorPosition(0, battlefield.GetLength(0));
            if (battlefield[location_to_move_Y, location_to_move_X] != 0)
            {
                short number = 3;
                while (number / 2 <= location_to_move_X || number / 2 < battlefield.GetLength(1) - location_to_move_X || number / 2 <= location_to_move_Y || number / 2 < battlefield.GetLength(0) - location_to_move_Y)
                {
                    bool If_found = false;
                    for (short i = 0; i < number; i++)
                    {
                        for (short j = 0; j < number; j++)
                        {
                            if (j == 1 && i != 0 && i != number - 1)
                            {
                                j = Convert.ToInt16(number - (short)2);
                                continue;
                            }
                            if (location_to_move_X + j >= number / 2 && location_to_move_X + j < battlefield.GetLength(1) + number / 2 && location_to_move_Y + i >= number / 2 && location_to_move_Y + i < battlefield.GetLength(0) + number / 2)
                            {
                                if (battlefield[location_to_move_Y + i - number / 2, location_to_move_X + j - number / 2] == 0)
                                {
                                    LocationX = Convert.ToInt16(location_to_move_X + j - number / 2);
                                    LocationY = Convert.ToInt16(location_to_move_Y + i - number / 2);
                                    If_found = true;
                                }
                            }
                            if (If_found)
                                break;
                        }
                        if (If_found)
                            break;
                    }
                    if (If_found)
                        break;
                    number += 2;
                }
            }
            else
            {
                LocationX = location_to_move_X;
                LocationY = location_to_move_Y;
            }
            battlefield[LocationY, LocationX] = value;
            Console.SetCursorPosition(LocationX, LocationY);
            if (GroupNumber == 1)
                Console.BackgroundColor = ConsoleColor.Blue;
            else
                Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(" ");
            Console.SetCursorPosition(0, battlefield.GetLength(0));
        }
        private void Wound(SoldierBase[] soldiers, short soldier_number, short battlefield_height)// Ранить противника
        {
            soldiers[soldier_number].HitPoint -= Convert.ToInt16(Weapon.Damage * WeaponProficiency);
            if (soldiers[soldier_number].HitPoint <= 0)
            {
                soldiers[soldier_number].HitPoint = 0;
                Console.SetCursorPosition(soldiers[soldier_number].LocationX, soldiers[soldier_number].LocationY);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.SetCursorPosition(0, battlefield_height);
            }
        }
        private void RivalSearch(short[,] battlefield, SoldierBase[] soldiers)// Поиск ближайшего противника
        {
            short? rivalX = null;
            short? rivalY = null;
            short? distance_to_rival = null;
            short number = 3;
            short soldier_number = 0;
            while (number / 2 <= LocationX || number / 2 < battlefield.GetLength(1) - LocationX || number / 2 <= LocationY || number / 2 < battlefield.GetLength(0) - LocationY)
            {
                for (short i = 0; i < number; i++)
                {
                    if (rivalX != null)
                        continue;
                    for (short j = 0; j < number; j++)
                    {
                        if (rivalX != null)
                            continue;
                        if (j == 1 && i != 0 && i != number - 1)
                        {
                            j = Convert.ToInt16(number - (short)2);
                            continue;
                        }    
                        if (LocationX + j >= number / 2 && LocationX + j < battlefield.GetLength(1) + number / 2 && LocationY + i >= number / 2 && LocationY + i < battlefield.GetLength(0) + number / 2)
                        {
                            if (battlefield[LocationY + i - number / 2, LocationX + j - number / 2] != 0 && battlefield[LocationY + i - number / 2, LocationX + j - number / 2] != GroupNumber)
                            {
                                for (short k = 0; k < soldiers.Length; k++)
                                {
                                    if (soldiers[k].LocationX == LocationX + j - number / 2 && soldiers[k].LocationY == LocationY + i - number / 2)
                                    {
                                        soldier_number = k;
                                        break;
                                    }
                                }
                                if (soldiers[soldier_number].HitPoint != 0)
                                {
                                    rivalX = Convert.ToInt16(LocationX + j - number / 2);
                                    rivalY = Convert.ToInt16(LocationY + i - number / 2);
                                    distance_to_rival = Convert.ToInt16(Math.Pow(j - number / 2, 2) + Math.Pow(i - number / 2, 2));
                                }
                            }
                        }
                    }
                }
                number += 2;
            }
            if (rivalX == null)
                EnemyIsDefeated = true;
            else if (distance_to_rival <= Math.Pow(Weapon.Range, 2))
                Wound(soldiers, soldier_number, (short)battlefield.GetLength(0));
            else
                Move((short)distance_to_rival, (short)rivalX, (short)rivalY, battlefield);
        }
        public virtual void Attack(short[,] battlefield, SoldierBase[] soldiers)// Атака
        {
            RivalSearch(battlefield, soldiers);
        }
    }
}
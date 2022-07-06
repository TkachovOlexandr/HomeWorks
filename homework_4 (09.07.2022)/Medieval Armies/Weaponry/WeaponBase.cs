namespace Medieval_Armies.Weaponry
{
    abstract class WeaponBase /* Оружие (base) */
    {
        private float range;
        private int damage;

        public float Range// Дальность действия (в "м")
        {
            get { return range; }
            set { range = value; }
        }
        public int Damage// Количество наносимого урона
        {
            get { return damage; }
            set { damage = value; }
        }

        private WeaponBase() { }
        protected WeaponBase(float range, int damage)
        {
            Range = range;
            Damage = damage;
        }
    }
}
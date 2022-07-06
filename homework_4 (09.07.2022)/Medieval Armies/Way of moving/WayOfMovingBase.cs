namespace Medieval_Armies.Way_of_moving
{
    abstract class WayOfMovingBase /* Способ передвижения (base) */
    {
        private float speed;

        public float Speed// Скорость передвижения (в "м/с")
        {
            get { return speed; }
            set { speed = value; }
        }

        private WayOfMovingBase() { }
        protected WayOfMovingBase(float speed)
        {
            Speed = speed;
        }
    }
}
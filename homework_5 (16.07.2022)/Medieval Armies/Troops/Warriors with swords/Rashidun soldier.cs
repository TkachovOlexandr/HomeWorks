using Medieval_Armies.Weaponry.One_handed_sword;
using Medieval_Armies.Way_of_moving;

namespace Medieval_Armies.Troops.Warriors_with_swords
{
    internal class Rashidun_soldier /* Солдат Рашидунского халифата */: SoldierBase
    {
        public Rashidun_soldier(string name, short locationX, short locationY, short groupNumber) : base(name, 100, (float)2.8, new Saif(), new ByCamel(), locationX, locationY, groupNumber, false) { }

        public override void Attack(short[,] battlefield, SoldierBase[] soldiers)
        {
            base.Attack(battlefield, soldiers);
        }
    }
}
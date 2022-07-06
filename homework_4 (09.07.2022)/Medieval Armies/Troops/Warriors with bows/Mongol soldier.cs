using Medieval_Armies.Weaponry.Bow;
using Medieval_Armies.Way_of_moving;

namespace Medieval_Armies.Troops.Warriors_with_bows
{
    internal class Mongol_soldier  /* Монголский солдат */: SoldierBase
    {
        public Mongol_soldier(string name, short locationX, short locationY, short groupNumber) : base(name, 100, (float)2.5, new Bow(), new ByHorse(), locationX, locationY, groupNumber, false) { }

        public override void Attack(short[,] battlefield, SoldierBase[] soldiers)
        {
            base.Attack(battlefield, soldiers);
        }
    }
}

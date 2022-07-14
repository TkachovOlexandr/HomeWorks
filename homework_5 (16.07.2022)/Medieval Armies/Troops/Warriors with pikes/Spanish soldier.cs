using Medieval_Armies.Weaponry.Pike;
using Medieval_Armies.Way_of_moving;

namespace Medieval_Armies.Troops.Warriors_with_pikes
{
    internal class Spanish_soldier  /* Испанский солдат */: SoldierBase
    {
        public Spanish_soldier(string name, short locationX, short locationY, short groupNumber) : base(name, 100, (float)2.2, new Pike(), new OnFoot(), locationX, locationY, groupNumber, false) { }

        public override void Attack(short[,] battlefield, SoldierBase[] soldiers)
        {
            base.Attack(battlefield, soldiers);
        }
    }
}

using Lists__n_Loops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Player : Creature
{
    public int gold;
    public int xp;
    public int level;
    public Player(string name, int health, int damage, int hit, int gold, int xp, int level)
    : base(name, health, damage, hit)
    {
        this.gold = gold;
        this.xp = xp;
        this.level = level;

    }
    public override void Attack(Creature target)
    {
        base.Attack(target);
    }
}

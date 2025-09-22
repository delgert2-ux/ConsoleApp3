using Lists__n_Loops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Creature
{
    public int health;
    public string name;
    public int damage;
    public int hit;
    public Item weapon;

    public Creature(string name, int health, int damage, int hit)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.hit = hit;
        weapon = Program.weapons[1];
    }

    public virtual void Attack(Creature target)
    {
        int num = Program.rand.Next(0, 101);
        int dam = damage + weapon.damage;
        if (num <= hit)
        {
            target.TakeDamage(dam);
            Console.WriteLine(name + " hits " + target.name + " with his " + weapon.name + " for " + dam + " damage");
        }
        else
        {
            Console.WriteLine(name + " misses " + target.name + "!");
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
    }
}
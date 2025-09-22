using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Item
{
    public string name;
    public int damage;
    public int value;
    public Item(string name, int damage, int value)
    {
        this.name = name;
        this.value = value;
        this.damage = damage;
    }
}

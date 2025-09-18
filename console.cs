using System;
using System.collections.Generic;

class plant
{
    private string name;
    private int growtime;
    private bool isHarvested;

    public plant(string name, int growtime)
    {
        this.name = name;
        this.growtime = growtime;
        this.isHarvested = false;
    }

    public string name => name;
    public int growtime => growtime;
    public bool isHarvested => isHarvested;

    public virtual void displayInfo()
    {
        Console.WriteLine($"{Name} - Waktu Tumbuh: {Growtime} hari - Status: {(isHarvested ? "Sudah Dipanen" : "Belum Dipanen")}");
    }

    public virtual void Harvest()
    {
        if (!isHarvested)
        {
            isHarvested = true;
            Console.WriteLine($"{Name} telah dipanen.");
        }
        else
        {
            Console.WriteLine($"{Name} sudah dipanen sebelumnya.");
        }
    }
}

class FruitPlant : Plant
{
    public FruitPlant(string name, int growtime) : base(name, growtime) { }

    public override void Harvest()
    {
        Console.Writeline($"Buah {name} telah dipanen.");
        base.Harvest();
    }
}

class vegetablePlant : Plant
{
    public vegetablePlant(string name, int growtime) : base(name, growtime) { }

    public override void Harvest()
    {
        Console.Writeline($"Sayur {name} telah dipanen.");
        base.Harvest();
    }
}


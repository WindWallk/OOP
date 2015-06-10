using System;

class LaptopShop
{
    static void Main(string[] args)
    {
        Laptop laptop = new Laptop("Lenovo Yoga 2 Pro", 2259.00m, new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5));
        laptop.Manufacturer = "Lenovo";
        laptop.Processor = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)";
        laptop.RAM = 8;
        laptop.GraphicsCard = "Intel HD Graphics 4400";
        laptop.HDD = 128;
        laptop.Screen = @"13.3"" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display";

        Console.WriteLine(laptop);
    }
}

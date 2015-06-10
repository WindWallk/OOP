using System;
using System.Collections.Generic;
using System.Linq;

class PCCatalog
{
    static void Main()
    {
        List<Computer> catalog = new List<Computer>();
        List<Component> components = new List<Component>();
        components.Add(new Component("HDD", 250.32m));
        components.Add(new Component("CPU", 560.45m));
        components.Add(new Component("RAM", 103.50m));
        Computer lenovo = new Computer("Lenovo", components);

        List<Component> components1 = new List<Component>();
        components1.Add(new Component("CPU", 231));
        components1.Add(new Component("Motheboard", 351));
        components1.Add(new Component("Graphics card", 351));
        Computer mac = new Computer("Mac", components1);

        List<Component> components2 = new List<Component>();
        components2.Add(new Component("CPU", 134));
        components2.Add(new Component("RAM", 123.65m, "4GB"));
        Computer sony = new Computer("Sony", components2);

        catalog.Add(lenovo);
        catalog.Add(mac);
        catalog.Add(sony);

        var sortCatalog = catalog.OrderBy(computer => computer.Price);

        foreach (var computer in sortCatalog)
        {
            Console.WriteLine(computer);
        }
    }
}
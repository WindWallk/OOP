using System;
using System.Text;

class Laptop
{
    private string model;
    private decimal price;
    private string manufacturer;
    private string processor;
    private int ram;
    private string graphicsCard;
    private int hdd;
    private string screen;

    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }
    public Laptop(string model, decimal price, Battery battery)
    {
        this.Model = model;
        this.Price = price;
        this.Batt = battery;
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The model cannot be empty!");
            }
            this.model = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The price cannot be negative number!");
            }
            this.price = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The manufactuer cannot be empty!");
            }
            this.manufacturer = value;
        }
    }

    public string Processor
    {
        get
        {
            return this.processor;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The processor cannot be empty!");
            }
            this.processor = value;
        }
    }

    public int RAM
    {
        get
        {
            return this.ram;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The RAM cannot be negative number!");
            }
            this.ram = value;
        }
    }

    public string GraphicsCard
    {
        get
        {
            return this.graphicsCard;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The Graphics Card cannot be empty!");
            }
            this.graphicsCard = value;
        }
    }

    public int HDD
    {
        get
        {
            return this.hdd;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The HDD cannot be negative number!");
            }
            this.hdd = value;
        }
    }

    public string Screen
    {
        get
        {
            return this.screen;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The Screen cannot be empty!");
            }
            this.screen = value;
        }
    }

    public Battery Batt { get; set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Laptop description:");
        result.AppendLine("Model: " + this.Model);

        if (manufacturer != null)
        {
            result.AppendLine("Manufacturer: " + this.Manufacturer);
        }
        if (processor != null)
        {
            result.AppendLine("Processor: " + this.Processor);
        }
        if (ram > 0)
        {
            result.AppendLine("RAM: " + this.RAM + " GB");
        }
        if (graphicsCard != null)
        {
            result.AppendLine("Graphics Card: " + this.GraphicsCard);
        }
        if (hdd > 0)
        {
            result.AppendLine("HDD: " + this.HDD + " GB");
        }
        if (screen != null)
        {
            result.AppendLine("Screen: " + this.Screen);
        }
        if (Batt.BatteryLife > 0)
        {
            result.AppendLine("Battery: " + this.Batt.BatteryModel);
        }
        if (Batt.BatteryModel != null)
        {
            result.AppendLine("Battery Life: " + this.Batt.BatteryLife + "hours");
        }
        result.AppendLine("Price: " + this.Price + " lv.");
        return result.ToString();

    }
}

using System;

class Employer
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value >= 0)
            {
                salary = value;
            }
            else
            {
                Console.WriteLine("Pensja nie może być ujemna.");
            }
        }
    }

    public virtual decimal CalculateBonus()
    {
        return 0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Imię: {FirstName}");
        Console.WriteLine($"Nazwisko: {LastName}");
        Console.WriteLine($"Pensja: {Salary:C}");
    }
}

class Director : Employer
{
    private decimal bonusPercentage;

    public decimal BonusPercentage
    {
        get { return bonusPercentage; }
        set
        {
            if (value >= 0)
            {
                bonusPercentage = value;
            }
            else
            {
                Console.WriteLine("Procent premii nie może być ujemny.");
            }
        }
    }

    public override decimal CalculateBonus()
    {
        return Salary * (bonusPercentage / 100);
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Procent premii: {BonusPercentage}%");
    }
}

class Accountant : Employer
{
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Stanowisko: Księgowy");
    }
}

class Technician : Employer
{
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Stanowisko: Technik");
    }
}

class Program
{
    static void Main()
    {

        Director director = new Director
        {
            FirstName = "Pracownik",
            LastName = "Jeden",
            Salary = 15000,
            BonusPercentage = 10
        };

        Accountant accountant = new Accountant
        {
            FirstName = "Pracownik",
            LastName = "Dwa",
            Salary = 8000
        };

        Technician technician = new Technician
        {
            FirstName = "Pracownik",
            LastName = "Trzy",
            Salary = 6000
        };

        Console.WriteLine("Informacje o dyrektorze:");
        director.PrintInfo();
        Console.WriteLine($"Premia: {director.CalculateBonus():C}");

        Console.WriteLine("\nInformacje o księgowym:");
        accountant.PrintInfo();

        Console.WriteLine("\nInformacje o techniku:");
        technician.PrintInfo();
    }
}

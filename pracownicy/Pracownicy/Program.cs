using System;

// Abstrakcyjna klasa Employer
abstract class Employer
{
    // Właściwość przechowująca imię pracownika
    public string FirstName { get; set; }

    // Właściwość przechowująca nazwisko pracownika
    public string LastName { get; set; }

    // Właściwość przechowująca pensję pracownika
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

    // Wirtualna metoda do obliczania premii (domyślnie brak premii)
    public virtual decimal CalculateBonus()
    {
        return 0;
    }

    // Wirtualna metoda do wydrukowania informacji o pracowniku
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Imię: {FirstName}");
        Console.WriteLine($"Nazwisko: {LastName}");
        Console.WriteLine($"Pensja: {Salary:C}");
    }
}

// Klasa dziedzicząca po Employer - Dyrektor
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

    // Przesłonięcie metody do obliczania premii dla dyrektora
    public override decimal CalculateBonus()
    {
        return Salary * (bonusPercentage / 100);
    }

    // Przesłonięcie metody do wydrukowania informacji o dyrektorze
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Procent premii: {BonusPercentage}%");
    }
}

// Klasa dziedzicząca po Employer - Księgowy
class Accountant : Employer
{
    // Przesłonięcie metody do wydrukowania informacji o księgowym
    public override void PrintInfo()
    {
        base.PrintInfo();
        // Dodatkowe informacje o księgowym
        Console.WriteLine("Stanowisko: Księgowy");
    }
}

// Klasa dziedzicząca po Employer - Technik
class Technician : Employer
{
    // Przesłonięcie metody do wydrukowania informacji o techniku
    public override void PrintInfo()
    {
        base.PrintInfo();
        // Dodatkowe informacje o techniku
        Console.WriteLine("Stanowisko: Technik");
    }
}

class Program
{
    static void Main()
    {
        // Przykładowe użycie

        Director director = new Director
        {
            FirstName = "Jan",
            LastName = "Kowalski",
            Salary = 10000,
            BonusPercentage = 15
        };

        Accountant accountant = new Accountant
        {
            FirstName = "Anna",
            LastName = "Nowak",
            Salary = 8000
        };

        Technician technician = new Technician
        {
            FirstName = "Piotr",
            LastName = "Zawadzki",
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

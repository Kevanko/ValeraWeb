// Models/Valera.cs
namespace ValeraApi.Models;

public class Valera
{
    public int Id { get; set; }

    public string Name { get; set; } = "Валера";

    public int Health { get; set; } = 100;
    public int Alcohol { get; set; } = 0;
    public int Joy { get; set; } = 0;
    public int Fatigue { get; set; } = 0;
    public decimal Money { get; set; } = 0;

    // Действия остаются без изменений
    public void GoToWork()
    {
        if (Alcohol < 50 && Fatigue < 10)
        {
            Joy = Math.Clamp(Joy - 5, -10, 10);
            Alcohol = Math.Max(0, Alcohol - 30);
            Money += 100;
            Fatigue = Math.Min(100, Fatigue + 70);
        }
    }

    public void ContemplateNature()
    {
        Joy = Math.Clamp(Joy + 1, -10, 10);
        Alcohol = Math.Max(0, Alcohol - 10);
        Fatigue = Math.Min(100, Fatigue + 10);
    }

    public void DrinkWineAndWatchSeries()
    {
        Joy = Math.Clamp(Joy - 1, -10, 10);
        Alcohol = Math.Min(100, Alcohol + 30);
        Fatigue = Math.Min(100, Fatigue + 10);
        Health = Math.Max(0, Health - 5);
        Money -= 20;
    }

    public void GoToBar()
    {
        Joy = Math.Clamp(Joy + 1, -10, 10);
        Alcohol = Math.Min(100, Alcohol + 60);
        Fatigue = Math.Min(100, Fatigue + 40);
        Health = Math.Max(0, Health - 10);
        Money -= 100;
    }

    public void DrinkWithMarginals()
    {
        Joy = Math.Clamp(Joy + 5, -10, 10);
        Health = Math.Max(0, Health - 80);
        Alcohol = Math.Min(100, Alcohol + 90);
        Fatigue = Math.Min(100, Fatigue + 80);
        Money -= 150;
    }

    public void SingInSubway()
    {
        Joy = Math.Clamp(Joy + 1, -10, 10);
        Alcohol = Math.Min(100, Alcohol + 10);
        Fatigue = Math.Min(100, Fatigue + 20);

        // Бонус $50, если изначально алкоголь был >40 и <70
        if (Alcohol - 10 > 40 && Alcohol - 10 < 70)
        {
            Money += 60; // $10 + $50 бонус
        }
        else
        {
            Money += 10;
        }
    }

    public void Sleep()
    {
        if (Alcohol < 30)
        {
            Health = Math.Min(100, Health + 90);
        }
        if (Alcohol > 70)
        {
            Joy = Math.Clamp(Joy - 3, -10, 10);
        }
        Alcohol = Math.Max(0, Alcohol - 50);
        Fatigue = Math.Max(0, Fatigue - 70);
    }
}
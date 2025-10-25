namespace ValeraApi.Models;

public class Valera
{
    public int Health { get; set; } = 100;
    public int Alcohol { get; set; } = 0;
    public int Joy { get; set; } = 0;
    public int Fatigue { get; set; } = 0;
    public int Money { get; set; } = 0;

    // Пойти на работу
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

    // Созерцать природу
    public void ContemplateNature()
    {
        Joy = Math.Clamp(Joy + 1, -10, 10);
        Alcohol = Math.Max(0, Alcohol - 10);
        Fatigue = Math.Min(100, Fatigue + 10);
    }

    // Пить вино и смотреть сериал
    public void DrinkWineAndWatchSeries()
    {
        Joy = Math.Clamp(Joy - 1, -10, 10);
        Alcohol = Math.Min(100, Alcohol + 30);
        Fatigue = Math.Min(100, Fatigue + 10);
        Health = Math.Max(0, Health - 5);
        Money -= 20;
    }

    // Сходить в бар
    public void GoToBar()
    {
        Joy = Math.Clamp(Joy + 1, -10, 10);
        Alcohol = Math.Min(100, Alcohol + 60);
        Fatigue = Math.Min(100, Fatigue + 40);
        Health = Math.Max(0, Health - 10);
        Money -= 100;
    }

    // Выпить с маргинальными личностями
    public void DrinkWithMarginals()
    {
        Joy = Math.Clamp(Joy + 5, -10, 10);
        Health = Math.Max(0, Health - 80);
        Alcohol = Math.Min(100, Alcohol + 90);
        Fatigue = Math.Min(100, Fatigue + 80);
        Money -= 150;
    }

    // Петь в метро
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

    // Спать
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
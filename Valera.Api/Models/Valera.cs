namespace Valera.Api.Models
{
    public class Valera
    {
        public int Health { get; private set; } = 100;
        public int Alcohol { get; private set; } = 0;
        public int Cheerfulness { get; private set; } = 0;
        public int Fatigue { get; private set; } = 0;
        public decimal Money { get; private set; } = 0m;

        private int Clamp(int v, int min, int max) => System.Math.Max(min, System.Math.Min(max, v));

        public bool CanGoToWork() => Alcohol < 50 && Fatigue < 10;

        public bool GoToWork()
        {
            if (!CanGoToWork()) return false;
            Cheerfulness = Clamp(Cheerfulness - 5, -10, 10);
            Alcohol = Clamp(Alcohol - 30, 0, 100);
            Money += 100m;
            Fatigue = Clamp(Fatigue + 70, 0, 100);
            return true;
        }

        public void ContemplateNature()
        {
            Cheerfulness = Clamp(Cheerfulness + 1, -10, 10);
            Alcohol = Clamp(Alcohol - 10, 0, 100);
            Fatigue = Clamp(Fatigue + 10, 0, 100);
        }

        public void DrinkWineAndWatchTV()
        {
            Cheerfulness = Clamp(Cheerfulness - 1, -10, 10);
            Alcohol = Clamp(Alcohol + 30, 0, 100);
            Fatigue = Clamp(Fatigue + 10, 0, 100);
            Health = Clamp(Health - 5, 0, 100);
            Money -= 20m;
        }

        public void GoToBar()
        {
            Cheerfulness = Clamp(Cheerfulness + 1, -10, 10);
            Alcohol = Clamp(Alcohol + 60, 0, 100);
            Fatigue = Clamp(Fatigue + 40, 0, 100);
            Health = Clamp(Health - 10, 0, 100);
            Money -= 100m;
        }

        public void DrinkWithMarginals()
        {
            Cheerfulness = Clamp(Cheerfulness + 5, -10, 10);
            Health = Clamp(Health - 80, 0, 100);
            Alcohol = Clamp(Alcohol + 90, 0, 100);
            Fatigue = Clamp(Fatigue + 80, 0, 100);
            Money -= 150m;
        }

        public void SingInMetro()
        {
            var before = Alcohol;
            Cheerfulness = Clamp(Cheerfulness + 1, -10, 10);
            Alcohol = Clamp(Alcohol + 10, 0, 100);
            Money += 10m;
            if (before > 40 && before < 70) Money += 50m;
            Fatigue = Clamp(Fatigue + 20, 0, 100);
        }

        public void Sleep()
        {
            if (Alcohol < 30) Health = Clamp(Health + 90, 0, 100);
            if (Alcohol > 70) Cheerfulness = Clamp(Cheerfulness - 3, -10, 10);
            Alcohol = Clamp(Alcohol - 50, 0, 100);
            Fatigue = Clamp(Fatigue - 70, 0, 100);
        }
    }
}
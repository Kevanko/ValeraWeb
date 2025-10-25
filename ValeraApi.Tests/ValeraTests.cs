using ValeraApi.Models;
using Xunit;

namespace ValeraApi.Tests;

public class ValeraTests
{
    [Fact] // Валера может пойти на работу, если трезвый и отдохнувший
    public void GoToWork_ShouldWork_WhenSoberAndRestful()
    {
        var valera = new Valera { Alcohol = 20, Fatigue = 5 };
        valera.GoToWork();
        Assert.Equal(100, valera.Money);
        Assert.Equal(-5, valera.Joy);
        Assert.Equal(0, valera.Alcohol); // 20 - 30 → 0
        Assert.Equal(75, valera.Fatigue); // 5 + 70
    }

    [Fact] // Валера НЕ пойдёт на работу, если слишком пьян
    public void GoToWork_ShouldDoNothing_IfTooDrunk()
    {
        var valera = new Valera { Alcohol = 60, Fatigue = 5, Money = 0 };
        valera.GoToWork();
        Assert.Equal(0, valera.Money);
        Assert.Equal(0, valera.Joy);
        Assert.Equal(60, valera.Alcohol);
        Assert.Equal(5, valera.Fatigue);
    }

    [Fact] // Валера НЕ пойдёт на работу, если слишком уставший
    public void GoToWork_ShouldDoNothing_IfTooTired()
    {
        var valera = new Valera { Alcohol = 20, Fatigue = 15, Money = 0 };
        valera.GoToWork();
        Assert.Equal(0, valera.Money);
    }


    [Fact] // Проверяет эффект от созерцания природы
    public void ContemplateNature_ShouldIncreaseJoyAndFatigue()
    {
        var valera = new Valera { Alcohol = 50, Fatigue = 80 };
        valera.ContemplateNature();
        Assert.Equal(1, valera.Joy);
        Assert.Equal(40, valera.Alcohol); // 50 - 10
        Assert.Equal(90, valera.Fatigue); // 80 + 10
    }

    [Fact] // Проверяет, что просмотр сериала снижает здоровье и деньги
    public void DrinkWineAndWatchSeries_ShouldDecreaseHealthAndMoney()
    {
        var valera = new Valera { Health = 100, Money = 100 };
        valera.DrinkWineAndWatchSeries();
        Assert.Equal(95, valera.Health);
        Assert.Equal(80, valera.Money);
        Assert.Equal(30, valera.Alcohol);
        Assert.Equal(10, valera.Fatigue);
        Assert.Equal(-1, valera.Joy);
    }

    [Fact] // Проверяет поход в бар
    public void GoToBar_ShouldIncreaseAlcoholAndFatigue()
    {
        var valera = new Valera();
        valera.GoToBar();
        Assert.Equal(1, valera.Joy);
        Assert.Equal(60, valera.Alcohol);
        Assert.Equal(40, valera.Fatigue);
        Assert.Equal(90, valera.Health);
        Assert.Equal(-100, valera.Money);
    }

    [Fact] // Выпить с маргинальными личностями
    public void DrinkWithMarginals_ShouldHurtHealthALot()
    {
        var valera = new Valera { Health = 100, Money = 200 };
        valera.DrinkWithMarginals();
        Assert.Equal(5, valera.Joy);
        Assert.Equal(20, valera.Health); // 100 - 80
        Assert.Equal(90, valera.Alcohol);
        Assert.Equal(80, valera.Fatigue);
        Assert.Equal(50, valera.Money); // 200 - 150
    }

    [Fact] // пение в метро с бонусом
    public void SingInSubway_ShouldGiveBonusIfAlcoholInRange()
    {
        var valera = new Valera { Alcohol = 50 }; // 50 ∈ (40, 70)
        valera.SingInSubway();
        Assert.Equal(1, valera.Joy);
        Assert.Equal(60, valera.Alcohol); // 50 + 10
        Assert.Equal(20, valera.Fatigue);
        Assert.Equal(60, valera.Money); // $10 + $50 бонус
    }

    [Fact] // пение в метро без бонуса < 40
    public void SingInSubway_ShouldNotGiveBonusIfAlcoholTooLow()
    {
        var valera = new Valera { Alcohol = 30 };
        valera.SingInSubway();
        Assert.Equal(10, valera.Money);
    }

    [Fact] // пение в метро без бонуса > 70
    public void SingInSubway_ShouldNotGiveBonusIfAlcoholTooHigh()
    {
        var valera = new Valera { Alcohol = 80 };
        valera.SingInSubway();
        Assert.Equal(10, valera.Money);
    }

    [Fact] // восстановление здоровья, если трезвый во сне
    public void Sleep_ShouldHealIfSober()
    {
        var valera = new Valera { Health = 20, Alcohol = 20, Fatigue = 90 };
        valera.Sleep();
        Assert.Equal(100, valera.Health); // 20 + 90 → capped at 100
        Assert.Equal(0, valera.Alcohol);  // 20 - 50 → 0
        Assert.Equal(20, valera.Fatigue); // 90 - 70
        Assert.Equal(0, valera.Joy);      // не меняется, т.к. alcohol ≤ 70
    }

    [Fact] // очень пьяный Валера теряет жизнерадостность во сне
    public void Sleep_ShouldDecreaseJoyIfVeryDrunk()
    {
        var valera = new Valera { Alcohol = 80, Joy = 5 };
        valera.Sleep();
        Assert.Equal(2, valera.Joy); // 5 - 3
        Assert.Equal(30, valera.Alcohol); // 80 - 50
    }

    [Fact] // пьяный Валера НЕ восстанавливает здоровье во сне
    public void Sleep_ShouldNotHealIfDrunk()
    {
        var valera = new Valera { Health = 30, Alcohol = 50 };
        valera.Sleep();
        Assert.Equal(30, valera.Health); // не изменилось, т.к. alcohol ≥ 30
    }
}
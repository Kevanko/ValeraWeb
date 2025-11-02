// Services/ValeraService.cs
using ValeraApi.Data;
using ValeraApi.Models;

namespace ValeraApi.Services;

public class ValeraService
{
    private readonly AppDbContext _context;

    public ValeraService(AppDbContext context)
    {
        _context = context;
    }

    public Valera GetValera()
    {
        return _context.Valeras.Find(1)!; // Всегда один Валера
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    // --- Действия ---

    public void GoToWork()
    {
        var v = GetValera();
        v.GoToWork();
        SaveChanges();
    }

    public void ContemplateNature()
    {
        var v = GetValera();
        v.ContemplateNature();
        SaveChanges();
    }

    public void DrinkWineAndWatchSeries()
    {
        var v = GetValera();
        v.DrinkWineAndWatchSeries();
        SaveChanges();
    }

    public void GoToBar()
    {
        var v = GetValera();
        v.GoToBar();
        SaveChanges();
    }

    public void DrinkWithMarginals()
    {
        var v = GetValera();
        v.DrinkWithMarginals();
        SaveChanges();
    }

    public void SingInSubway()
    {
        var v = GetValera();
        v.SingInSubway();
        SaveChanges();
    }

    public void Sleep()
    {
        var v = GetValera();
        v.Sleep();
        SaveChanges();
    }
}
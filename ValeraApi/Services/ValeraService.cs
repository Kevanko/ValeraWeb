// Services/ValeraService.cs
using ValeraApi.Data;
using ValeraApi.DTOs;
using ValeraApi.Models;

namespace ValeraApi.Services;

public class ValeraService
{
    private readonly AppDbContext _context;

    public ValeraService(AppDbContext context)
    {
        _context = context;
    }

    private Valera GetValera()
    {
        return _context.Valeras.Find(1)!;
    }

    private ValeraStateDto ToDto(Valera v)
    {
        return new ValeraStateDto
        {
            Health = v.Health,
            Alcohol = v.Alcohol,
            Joy = v.Joy,
            Fatigue = v.Fatigue,
            Money = v.Money
        };
    }

    public ValeraStateDto GetState()
    {
        var v = GetValera();
        return ToDto(v);
    }

    public ValeraStateDto GoToWork()
    {
        var v = GetValera();
        v.GoToWork();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto ContemplateNature()
    {
        var v = GetValera();
        v.ContemplateNature();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto DrinkWineAndWatchSeries()
    {
        var v = GetValera();
        v.DrinkWineAndWatchSeries();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto GoToBar()
    {
        var v = GetValera();
        v.GoToBar();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto DrinkWithMarginals()
    {
        var v = GetValera();
        v.DrinkWithMarginals();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto SingInSubway()
    {
        var v = GetValera();
        v.SingInSubway();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto Sleep()
    {
        var v = GetValera();
        v.Sleep();
        _context.SaveChanges();
        return ToDto(v);
    }
}
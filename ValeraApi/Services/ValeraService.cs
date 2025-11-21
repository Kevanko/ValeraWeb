// Services/ValeraService.cs
using Microsoft.EntityFrameworkCore;
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

    private ValeraStateDto ToDto(Valera v)
    {
        return new ValeraStateDto
        {
            Id = v.Id,
            Name = v.Name,
            Health = v.Health,
            Alcohol = v.Alcohol,
            Joy = v.Joy,
            Fatigue = v.Fatigue,
            Money = v.Money
        };
    }

    // Получить всех Валер
    public List<ValeraStateDto> GetAllValeras()
    {
        var valeras = _context.Valeras.ToList();
        return valeras.Select(ToDto).ToList();
    }

    // Получить по ID
    public ValeraStateDto? GetById(int id)
    {
        var v = _context.Valeras.Find(id);
        return v == null ? null : ToDto(v);
    }

    // Создать нового Валеру
    public ValeraStateDto CreateValera(CreateValeraDto dto)
    {
        var valera = new Valera
        {
            Name = dto.Name,
            Health = dto.Health,
            Alcohol = dto.Alcohol,
            Joy = dto.Joy,
            Fatigue = dto.Fatigue,
            Money = dto.Money
        };
        _context.Valeras.Add(valera);
        _context.SaveChanges();
        return ToDto(valera);
    }

    // Действия — теперь принимают ID
    public ValeraStateDto? GoToWork(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.GoToWork();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? ContemplateNature(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.ContemplateNature();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? DrinkWineAndWatchSeries(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.DrinkWineAndWatchSeries();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? GoToBar(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.GoToBar();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? DrinkWithMarginals(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.DrinkWithMarginals();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? SingInSubway(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.SingInSubway();
        _context.SaveChanges();
        return ToDto(v);
    }

    public ValeraStateDto? Sleep(int id)
    {
        var v = _context.Valeras.Find(id);
        if (v == null) return null;
        v.Sleep();
        _context.SaveChanges();
        return ToDto(v);
    }
}
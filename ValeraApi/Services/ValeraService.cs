using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ValeraApi.Data;
using ValeraApi.DTOs;
using ValeraApi.Models;

namespace ValeraApi.Services;

public class ValeraService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public ValeraService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    private int? GetCurrentUserId()
    {
        var idStr = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(idStr, out int id) ? id : null;
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

    public List<ValeraStateDto> GetAllValeras()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return new();

        var userRole = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

        var query = _context.Valeras.AsQueryable();
        if (userRole != "Admin")
            query = query.Where(v => v.UserId == userId);

        return query.ToList().Select(ToDto).ToList();
    }

    public ValeraStateDto? GetById(int id)
    {
        var v = _context.Valeras.Find(id);
        return v == null ? null : ToDto(v);
    }

    public ValeraStateDto CreateValera(CreateValeraDto dto)
    {
        var userId = GetCurrentUserId() ?? throw new UnauthorizedAccessException();

        var valera = new Valera
        {
            UserId = userId,
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

    // ... остальные методы (GoToWork, Sleep и т.д.) — без изменений
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
// DTOs/ValeraStateDto.cs
namespace ValeraApi.DTOs;

public class ValeraStateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "Валера";
    public int Health { get; set; }
    public int Alcohol { get; set; }
    public int Joy { get; set; }
    public int Fatigue { get; set; }
    public decimal Money { get; set; }
}
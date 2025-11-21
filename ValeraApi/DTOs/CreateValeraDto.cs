// DTOs/CreateValeraDto.cs
namespace ValeraApi.DTOs;

public class CreateValeraDto
{
    public string Name { get; set; } = "Новый Валера";
    public int Health { get; set; } = 100;
    public int Alcohol { get; set; } = 0;
    public int Joy { get; set; } = 0;
    public int Fatigue { get; set; } = 0;
    public decimal Money { get; set; } = 0;
}
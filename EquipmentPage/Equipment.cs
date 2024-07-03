using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentPage;

public class Equipment
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Picture { get; set; }
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? MuscleGroup { get; set; }
    public string? EquipmentType { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime? AquisitionDate { get; set; }
    public decimal AquisitionCost { get; set; }
    public string? WeightRange { get; set; }
    public DateTime? NextMaintenance { get; set; }
    public TimeSpan MaintenanceDuration { get; set; }
    public string? Location { get; set; }
    public string? Dimension { get; set; }


    public static List<Equipment> GetTestData()
    {
        var list = new List<Equipment>();
        var equipment = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Hantelbank",
            Brand = "Sinaaaaa",
            MuscleGroup = "Brust",
            Status = StatusEnum.Bereit, 
            AquisitionDate = DateTime.Now,
            EquipmentType = "Freigerät"
        };

        var equipment2 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Rudern",
            Brand = "Baingo GmbH",
            MuscleGroup = "Rücken",
            Status = StatusEnum.Defekt,
            AquisitionDate = DateTime.Now.AddDays(-14),
            EquipmentType = "Zug"
        };

        var equipment3 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Latzug",
            Brand = "KK KG",
            MuscleGroup = "Rücken",
            Status = StatusEnum.InWartung,
            AquisitionDate = DateTime.Now.AddDays(14),
            EquipmentType = "Zug"
        };
        var equipment4 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Latzug Breit",
            Brand = "KK KG",
            MuscleGroup = "Rücken",
            Status = StatusEnum.Defekt,
            AquisitionDate = DateTime.Now.AddDays(12),
            EquipmentType = "Zug"
        };

        var equipment5 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Laufband",
            Brand = "Tobi OHG",
            MuscleGroup = "Ausdauer",
            Status = StatusEnum.Bereit,
            AquisitionDate = DateTime.Now.AddDays(12),
            EquipmentType = "Ausdauer"
        };

        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment4);
        list.Add(equipment4);
        list.Add(equipment4);
        list.Add(equipment5);

        return list;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Marke: {Brand}, Muskelgruppe: {MuscleGroup}, Status: {Status}, Gerätetyp: {EquipmentType}";
    }
}



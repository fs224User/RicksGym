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
            Name = "Laufband2",
            Brand = "Tobi OHG",
            MuscleGroup = "Ausdauer",
            Status = StatusEnum.Bereit,
            AquisitionDate = DateTime.Now.AddDays(0),
            EquipmentType = "Ausdauer"
        };

        var equipment6 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Langhantel",
            Brand = "Siemens",
            MuscleGroup = "Brust",
            Status = StatusEnum.Bereit,
            AquisitionDate = DateTime.Now,
            EquipmentType = "Freigerät"
        };

        var equipment7 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Beinpresse",
            Brand = "BigBooty GmbH",
            MuscleGroup = "Beine",
            Status = StatusEnum.Defekt,
            AquisitionDate = DateTime.Now.AddDays(-14),
            EquipmentType = "Presse"
        };

        var equipment8 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Trizepsdrücken",
            Brand = "Markus Rühl KG",
            MuscleGroup = "Trizeps",
            Status = StatusEnum.Defekt,
            AquisitionDate = DateTime.Now.AddDays(-100),
            EquipmentType = "Kabelzug"
        };
        var equipment9 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Latzugstange",
            Brand = "Zander OHG",
            MuscleGroup = "Rücken",
            Status = StatusEnum.Defekt,
            AquisitionDate = DateTime.Now.AddDays(12),
            EquipmentType = "Hilfsmittel"
        };

        var equipment10 = new Equipment()
        {
            Id = Guid.NewGuid(),
            Name = "Kurzhantel",
            Brand = "Tobi OHG",
            MuscleGroup = "Bizeps",
            Status = StatusEnum.Bereit,
            AquisitionDate = DateTime.Now.AddDays(-200),
            EquipmentType = "Freigewicht"
        };

        list.Add(equipment);
        list.Add(equipment2);
        list.Add(equipment3);
        list.Add(equipment4);
        list.Add(equipment5);
        list.Add(equipment6);
        list.Add(equipment7);
        list.Add(equipment8);
        list.Add(equipment9);
        list.Add(equipment10);


        return list;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var lengthNameToAdd = 40 - Name.Length;
        var lengthBrandToAdd = 40 - Brand.Length;
        var lengthMuscleGroupToAdd = 40 - MuscleGroup.Length;
        var lengthEquipmentTypeToAdd = 40 - EquipmentType.Length;

        AddChars(sb, Name ,"Name: ", lengthNameToAdd);
        AddChars(sb,Brand, "Marke: ", lengthBrandToAdd);
        AddChars(sb,MuscleGroup, "Muskelgruppe: ", lengthMuscleGroupToAdd);
        AddChars(sb,EquipmentType, "Gerätetyp: ", lengthEquipmentTypeToAdd);
        sb.Append($"Status: {Status}");
        var test = sb.ToString().Length;
        return sb.ToString();
        //return $"Name: {Name}, Marke: {Brand}, Muskelgruppe: {MuscleGroup}, Status: {Status}, Gerätetyp: {EquipmentType}";
    }

    private void AddChars(StringBuilder stringBuilder, string name ,string toAdd ,int charsToAdd)
    {
        stringBuilder.Append(toAdd);
        stringBuilder.Append(name);
        for (int i = 0; i < charsToAdd; i++)
        {
            stringBuilder.Append(' ');
        }
    }
}



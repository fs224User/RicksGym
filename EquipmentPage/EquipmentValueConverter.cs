using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentPage;

public static class EquipmentValueConverter
{   
    public static StatusEnum GetEnum(string enumText)
    {
        if (enumText == "InWartung")
            return StatusEnum.InWartung;
        if (enumText == "Defekt")
            return StatusEnum.Defekt;
        return StatusEnum.Bereit;
    }

    public static decimal GetPrice(string priceText)
    {
        try 
        {
            return Convert.ToDecimal(priceText);
        }
        catch(Exception ex)
        {
            return 0m;
        }
    }

    public static TimeSpan GetTimeSpan(string timeSpanText)
    {
        try
        {
            var splits = timeSpanText.Split(':');
            var days = int.Parse(splits[0]);
            var hours = int.Parse(splits[1]);
            var minutes = int.Parse(splits[2]);
            var seconds = int.Parse(splits[3]);

            return new TimeSpan(days,hours,minutes,seconds);

        }
        catch (Exception)
        {
            return new TimeSpan(0);
        }
    }
}

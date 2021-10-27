using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANTS : Items
{

    private int wattage;
    private float earnings;
    private int heat;

    public void setWattage(int x)
    {
        wattage = x;
    }

    public void setEarnings(float x)
    {
        earnings = x;
    }

    public void setHeat(int x)
    {
        heat = x;
    }

    public int getWattage()
    {
        return wattage;
    }

    public float getEarnings()
    {
        return earnings;
    }

    public int getHeat()
    {
        return heat;
    }


    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Wattage", "Production", "Heat", getFormattedCost(), wattage.ToString(), string.Format("$", earnings.ToString("F2") + "\\day"), heat.ToString()};

        return j;
    }

    public int getBreakSize()
    {
        return 4;
    }
}
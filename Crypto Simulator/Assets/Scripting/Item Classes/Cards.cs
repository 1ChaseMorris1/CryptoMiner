using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : Items
{
    private int wattage;
    private int size;
    private float production;
    private int heat;

    public  void setWattage(int x)
    {
        wattage = x; 
    }

    public  void setSize(int x)
    {
        size = x; 
    }

    public void setProduction(float x)
    {
        production = x;
    }

    public  void setHeat(int x)
    {
        heat = x;
    }

    public  int getWattage()
    {
        return wattage; 
    }

    public  int getSize()
    {
        return size; 
    }

    public  float getProduction()
    {
        return production; 
    }

    public int getHeat()
    {
        return heat; 
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Wattage", "Size", "Production", "Heat", getFormattedCost(), wattage.ToString(), size.ToString(),
            string.Format("$" + production.ToString("F2") + "\\day"), heat.ToString() }; 

        return j;
    }

    public int getBreakSize()
    {
        return 5;
    }
}

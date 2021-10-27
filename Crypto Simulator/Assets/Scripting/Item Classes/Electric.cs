using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * contains PSUS and the electric things 
 */

public class Electric : Items
{

    private int wattage; 

    public void setWattage(int x)
    {
        wattage = x;
    }

    public  int getWattage()
    {
        return wattage; 
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Wattage", getFormattedCost(), wattage.ToString() };

        return j;
    }

    public int getBreakSize()
    {
        return 2;
    }
}

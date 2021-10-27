using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUS : Items
{
    private  int MHZ;

    public void setMHZ(int x)
    {
        MHZ = x;
    }

    public   int getMHZ()
    {
        return MHZ; 
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Wattage", getFormattedCost(), MHZ.ToString() };

        return j;
    }

    public int getBreakSize()
    {
        return 2;
    }

}

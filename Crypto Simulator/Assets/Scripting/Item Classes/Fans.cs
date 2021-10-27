using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fans : Items
{
    private int size;
    private string fanType; 
    private int cooling;
    private bool rigCompatible; 

    public void setFanType(string str)
    {
        fanType = str; 
    }

    public string getFanType()
    {
        return fanType; 
    }

    public   void setSize(int x)
    {
        size = x; 
    }

    public   void setCooling(int x)
    {
        cooling = x;
    }

    public   void setRig(string str)
    {
        switch (str)
        {
            case "NO":
                rigCompatible = false;
                break;
            case "YES":
                rigCompatible = true;
                break; 
        }
    }

    public   int getSize()
    {
        return size; 
    }

    public   int getCooling()
    {
        return cooling; 
    }

    public   bool getCompat()
    {
        return rigCompatible; 
    }

    private string getCompatible()
    {
        switch (rigCompatible)
        {
            case true: return "Yes";
            case false: return "No";
        }
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Size", "Fan Type", "Cooling", "Rig Suited", getFormattedCost(), size.ToString(), fanType.ToString(), cooling.ToString(), getCompatible() };

        return j;
    }

    public int getBreakSize()
    {
        return 5;
    }

}

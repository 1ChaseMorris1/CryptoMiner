using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigs : Items
{

    private int inch;
    private int capacity;
    private int ANTS;
    private int fans; 
    // tiles should be added in soon....

    public   void setInch(int x)
    {
        inch = x; 
    }

    public   void setCapacity(int x)
    {
        capacity = x; 
    }

    public   void setANTS(int x)
    {
        ANTS = x;
    }

    public   void setFans(int x)
    {
        fans = x;
    }

    public   int getInch()
    {
        return inch; 
    }

    public   int getCapacity()
    {
        return capacity; 
    }

    public   int getANTS()
    {
        return ANTS; 
    }

    public   int getFans()
    {
        return fans; 
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Card Inch", "Capacity", "ANT Capacity", "Fan Capacity", getFormattedCost(), inch.ToString(), capacity.ToString(), ANTS.ToString(), fans.ToString() };

        return j;
    }

    public int getBreakSize()
    {
        return 5;
    }

}

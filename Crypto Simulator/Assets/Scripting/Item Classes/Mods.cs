using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Mods : Items
{
    private  int amount;
    private  int size;
    private bool backplate;
    private  int boost;
    private Sprite backImg;

    public void setBackImg(Sprite img)
    {
        this.backImg = img; 
    }

    public Sprite getBackImg()
    {
        return backImg; 
    }
    

    public  void setAmount(int x)
    {
        amount = x;
    }

    public  void setSize(int x)
    {
        size = x; 
    }

    public   void setBackplate(string str)
    {
        switch (str)
        {
            case "NO":
                backplate = false;
                break;
            case "YES":
                backplate = true;
                break; 
        }
    }

    public   void setBoost(int x)
    {
        boost = x;
    }

    public   int getAmount()
    {
        return amount; 
    }

    public   int getSize()
    {
        return size; 
    }

    public   bool getBackplate()
    {
        return backplate; 
    }

    public   int getBoost()
    {
        return boost; 
    }

    private string getBackplateString()
    {
        switch (backplate)
        {
            case true: return "Yes";
            case false: return "No";
        }
    }

    // gets the card format, x is passed in for the sides if x is 0 then do string if x is 1 then return the variables. 
    public string[] getInfoCardFormat()
    {
        string[] j = { "Cost", "Amount","Size", "Backplate", "Cooling Boost", getFormattedCost(), amount.ToString(), size.ToString(), getBackplateString(), boost.ToString() };

        return j;
    }

    public int getBreakSize()
    {
        return 5;
    }
}

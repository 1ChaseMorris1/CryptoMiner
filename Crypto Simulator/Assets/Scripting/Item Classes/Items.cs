using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * contains variables that apply to all of the items in the game. 
 */

public class Items : MonoBehaviour
{
    private string Name; 
    private float cost;
    private Sprite picture; 

    public void setName(string name)
    {
        Name = name; 
    }

    public string getName()
    {
        return Name;
    }
    public void setCost(float cost)
    {
        this.cost = cost; 
    }

    public float getCost()
    {
        return cost; 
    }

    public void setSprite(Sprite sprite)
    {
        picture = sprite;
    }

    public Sprite getSprite()
    {
        return picture; 
    }
    
    public string getFormattedCost()
    {
        return string.Format("$" + cost.ToString("F2"));
    }

}

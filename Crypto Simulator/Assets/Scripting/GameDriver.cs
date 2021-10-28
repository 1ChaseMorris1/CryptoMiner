using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameDriver : MonoBehaviour
{

    public void changeScene() { SceneManager.LoadScene("Shop"); }

    public void mapScene() { SceneManager.LoadScene("Map"); }

    /*
     * this script is called first, this is the loading screen script, it will 
     * test if there is a save data file by reading in the data and if the data
     * is null then it will load all of the game assets for the first time
     */

    [SerializeField] private GameObject sideBar;                    

    public static List<Cards> cards = new List<Cards>();
    public static List<Fans> fans = new List<Fans>();
    public static List<Electric> psus = new List<Electric>();
    public static List<CPUS> cpus = new List<CPUS>();
    public static List<ANTS> ants = new List<ANTS>();
    public static List<Rigs> rigs = new List<Rigs>();
    public static List<Mods> mods = new List<Mods>();
    public static List<Electric> electric = new List<Electric>();

    public static List<string> names = new List<string>();
    public static List<float> costs = new List<float>();
    public static List<Sprite> images = new List<Sprite>();

    public static float playerMoney; 

    private void Start()
    {
        playerMoney = 0f;

        setAllItems();
    }

    public static int getItemAmount()
    {
        return 8; 
    }

    public static int getItemSize(int x)
    {
        switch (x)
        {
            case 0: return cards.Count;
            case 1: return fans.Count;
            case 2: return psus.Count;
            case 3: return cpus.Count;
            case 4: return ants.Count;
            case 5: return rigs.Count;
            case 6: return mods.Count;
            case 7: return electric.Count;
            default: return 0;
        }
    }

    public static int getTotalItemIterations()
    {
        return (cards.Count + fans.Count + psus.Count + cpus.Count + ants.Count + rigs.Count + mods.Count + electric.Count);
    }

    // can get any name in the classes, as they are a universal. 
    private static void setAllItems()
    {

        for (int i = 0; i < cards.Count; i++)
        {
            names.Add(cards[i].getName());
            costs.Add(cards[i].getCost());
            images.Add(cards[i].getSprite());
        }
        for (int i = 0; i < fans.Count; i++)
        {
            names.Add(fans[i].getName());
            costs.Add(fans[i].getCost());
            images.Add(fans[i].getSprite());
        }

        for (int i = 0; i < psus.Count; i++)
        {
            names.Add(psus[i].getName());
            costs.Add(psus[i].getCost());
            images.Add(psus[i].getSprite());
        }

        for (int i = 0; i < cpus.Count; i++)
        {
            names.Add(cpus[i].getName());
            costs.Add(cpus[i].getCost());
            images.Add(cpus[i].getSprite());
        }

        for (int i = 0; i < ants.Count; i++)
        {
            names.Add(ants[i].getName());
            costs.Add(ants[i].getCost());
            images.Add(ants[i].getSprite());
        }

        for (int i = 0; i < rigs.Count; i++)
        {
            names.Add(rigs[i].getName());
            costs.Add(rigs[i].getCost());
            images.Add(rigs[i].getSprite());
        }

        for (int i = 0; i < mods.Count; i++)
        {
            names.Add(mods[i].getName());
            costs.Add(mods[i].getCost());
            images.Add(mods[i].getSprite());
        }

        for (int i = 0; i < electric.Count; i++)
        {
            names.Add(electric[i].getName());
            costs.Add(electric[i].getCost());
            images.Add(electric[i].getSprite());
        }

    }

}

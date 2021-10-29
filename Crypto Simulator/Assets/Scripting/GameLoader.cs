using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * gameloader will load in the files and set the classes, if the user selects a saved items[x] scene from 
 * the menu class then it will load in the items[x] scene, otherwise it will load 
 * new assets from the save files
 */

public class GameLoader : MonoBehaviour
{

    public void changeScreen() { SceneManager.LoadScene("Columbus"); }

    private string[] items = System.IO.File.ReadAllLines("Assets/textAssets/items.txt");

    private static int x;                                                   // iterator for items[x]
    private static int arraySize;                                       // size of the arrays        

    private static int imageIterator;                                   // iterates through all images.
    [SerializeField] private Sprite[] image;                                // all images 
    [SerializeField] private Sprite[] backplate;                            // all backplates

    // loads all of the basic, non-saved assets in the game that are kept in a txt file. 

    private void Start()
    {
        setMapVariables(); 

        x = 0;
        arraySize = 0;
        imageIterator = 0;

        loadItems();

        SaveInfo.loadPlayer();
    }
    
    private void setMapVariables()
    {
   //     for (int i = 0; i < 5; i++)
    //        MapsDriver.mapUnlocks.Add(false);

        // TODO
        // load in the actual values with another loop.
    }

    private void loadItems()        // loads all of the items
    {
        readCards();
        readFans();
        readPsus();
        readCPU();
        readAnts();
        readRigs();
        readMods();
        readElectric(); 
    }

    private void readElectric()
    {

        while(items[x] != "#")
        {
            GameDriver.electric.Add(gameObject.AddComponent<Electric>());

            GameDriver.electric[arraySize].setName(items[x]); x++;
            GameDriver.electric[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.electric[arraySize].setWattage(int.Parse(items[x])); x++;
            GameDriver.electric[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;
    }

    private void readMods()
    {
        while(items[x] != "#")
        {

            GameDriver.mods.Add(gameObject.AddComponent<Mods>());
            
            GameDriver.mods[arraySize].setName(items[x]); x++;
            GameDriver.mods[arraySize].setAmount(int.Parse(items[x])); x++;
            GameDriver.mods[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.mods[arraySize].setSize(int.Parse(items[x])); x++;
            GameDriver.mods[arraySize].setBackplate(items[x]); x++;
            GameDriver.mods[arraySize].setBoost(int.Parse(items[x])); x++;
            GameDriver.mods[arraySize].setSprite(image[imageIterator]);
            GameDriver.mods[arraySize].setBackImg(backplate[Random.Range(0, 3)]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;
    }

    private void readRigs()
    {
        while(items[x] != "#")
        {

            GameDriver.rigs.Add(gameObject.AddComponent<Rigs>());
            
            GameDriver.rigs[arraySize].setName(items[x]); x++;
            GameDriver.rigs[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.rigs[arraySize].setInch(int.Parse(items[x])); x++;
            GameDriver.rigs[arraySize].setCapacity(int.Parse(items[x])); x++;
            GameDriver.rigs[arraySize].setANTS(int.Parse(items[x])); x++;
            GameDriver.rigs[arraySize].setFans(int.Parse(items[x])); x++;
            GameDriver.rigs[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;

    }

    private void readAnts()
    {
        while(items[x] != "#")
        {

            GameDriver.ants.Add(gameObject.AddComponent<ANTS>());

            GameDriver.ants[arraySize].setName(items[x]); x++;
            GameDriver.ants[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.ants[arraySize].setWattage(int.Parse(items[x])); x++;
            GameDriver.ants[arraySize].setEarnings(float.Parse(items[x])); x++;
            GameDriver.ants[arraySize].setHeat(int.Parse(items[x])); x++;
            GameDriver.ants[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;
    }

    private void readCPU()
    {
        while(items[x] != "#")
        {

            GameDriver.cpus.Add(gameObject.AddComponent<CPUS>());
            
            GameDriver.cpus[arraySize].setName(items[x]); x++;
            GameDriver.cpus[arraySize].setMHZ(int.Parse(items[x])); x++;
            GameDriver.cpus[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.cpus[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;

    }

    private void readPsus()
    {

        while(items[x] != "#")
        {

            GameDriver.psus.Add(gameObject.AddComponent<Electric>());

            GameDriver.psus[arraySize].setName(items[x]); x++;
            GameDriver.psus[arraySize].setWattage(int.Parse(items[x])); x++;
            GameDriver.psus[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.psus[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;
    }

    private void readFans()
    {
        while(items[x] != "#")
        {
            GameDriver.fans.Add(gameObject.AddComponent<Fans>());

            GameDriver.fans[arraySize].setName(items[x]); x++;
            GameDriver.fans[arraySize].setSize(int.Parse(items[x])); x++;
            GameDriver.fans[arraySize].setFanType(items[x]); x++;
            GameDriver.fans[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.fans[arraySize].setCooling(int.Parse(items[x])); x++;
            GameDriver.fans[arraySize].setRig(items[x]); x++;
            GameDriver.fans[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;
        }

        arraySize = 0;
        x++;

    }

    private void readCards()
    {

        while(items[x] != "#")
        {
            GameDriver.cards.Add(gameObject.AddComponent<Cards>()); 

            GameDriver.cards[arraySize].setName(items[x]); x++;
            GameDriver.cards[arraySize].setCost(float.Parse(items[x])); x++;
            GameDriver.cards[arraySize].setWattage(int.Parse(items[x])); x++;
            GameDriver.cards[arraySize].setSize(int.Parse(items[x])); x++;
            GameDriver.cards[arraySize].setProduction(float.Parse(items[x])); x++;
            GameDriver.cards[arraySize].setHeat(int.Parse(items[x])); x++;
            GameDriver.cards[arraySize].setSprite(image[imageIterator]);

            imageIterator++;

            arraySize++;

        }

        arraySize = 0;
        x++;
    }

}
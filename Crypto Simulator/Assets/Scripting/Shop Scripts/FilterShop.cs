using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* 
 * after searching once and then trying to search again, shop search quits working
 */

public class FilterShop : MonoBehaviour
{
    // fix this bullshit

    private GameObject searchButton;
    private GameObject searchText;
    private GameObject[] temp;
    private GameObject noResults; 

    public List<Toggle> toggles = new List<Toggle>();

    private static int y;

    public void populateGameobjects()
    {
        searchButton = GameObject.FindWithTag("searchButton");
        searchText = GameObject.FindWithTag("searchBar");
        temp = GameObject.FindGameObjectsWithTag("toggles");
        noResults = GameObject.FindWithTag("noresult");

        noResults.SetActive(false);

        for (int i = 0; i < temp.Length; i++)
            toggles.Add(temp[i].GetComponent<Toggle>());

    }

    public void filterToggles(List<GameObject> items)
    {
        y = 0;

        int x = 0; 

        x =+ filterTgl(GameDriver.cards.Count, items, 0);
        x =+ filterTgl(GameDriver.fans.Count, items, 1);
        x =+ filterTgl(GameDriver.psus.Count, items, 2);
        x =+ filterTgl(GameDriver.cpus.Count, items, 3);
        x =+ filterTgl(GameDriver.ants.Count, items, 4);
        x =+ filterTgl(GameDriver.rigs.Count, items, 5);
        x =+ filterTgl(GameDriver.mods.Count, items, 6);
        x =+ filterTgl(GameDriver.electric.Count, items, 7);

        if (x == 0) { noResults.SetActive(true); }
        else { noResults.SetActive(false); }

        // this checks the search after enabling the correct filters
        if(searchText.GetComponent<TextMeshProUGUI>().text != "\u200B")
        search(0);

    }

    // turn to bool if bool false turn on no result.
    private int filterTgl(int x, List<GameObject> items, int j)
    {

        for (int i = y; i < (x + y); i++)
        {
            if (toggles[j].isOn)
            {
                items[i].SetActive(true);
            } else
            {
                items[i].SetActive(false);
            }
        }
        y += x;

        if (toggles[j].isOn) return 1;
        else return 0;
    }


    public void setSearchButton()
    {
        searchButton.GetComponent<Button>().onClick.AddListener(() => search(1)); 
    }

    private void search(int shouldCall)
    {
        List<string> searchNames = new List<string>();
        List<int> instantiateNumber = new List<int>(); 

        string text = searchText.GetComponent<TextMeshProUGUI>().text;

        int iterator = 0;

        bool found = false;

        foreach (GameObject x in ShopDriver.itemCards)
        {
            if (x.activeSelf)
            {
                searchNames.Add(GameDriver.names[iterator]);
                instantiateNumber.Add(iterator); 
            }

            iterator++;
        }

        iterator = 0;
        
        if (text == "\u200B")
        {
            for (int i = 0; i < ShopDriver.itemCards.Count; i++)
                ShopDriver.itemCards[i].SetActive(true);

            if(shouldCall != 0)
            filterToggles(ShopDriver.itemCards);

            noResults.SetActive(false);

            return;
        }
        
        text = text.TrimEnd('\u200B');                 // weird ass dude go away 

        foreach(string x in searchNames)
        {
            if(text != x)
            {
                ShopDriver.itemCards[instantiateNumber[iterator]].SetActive(true);
            } else
            {
                ShopDriver.itemCards[instantiateNumber[iterator]].SetActive(false);
                found = true;
            }

            iterator++;
        }

        if (!found)
        {

            iterator = 0;

            string[] userText = text.Split(' ');

            for(int i = 0; i < userText.Length; i++)
                userText[i] = userText[i].ToUpper();


            bool local = false;

            foreach (string x in searchNames)
            {

                string[] names = x.Split(' ');

                foreach (string i in names)
                { 

                    foreach (string j in userText)
                        if (j.Equals(i)) local = true;


                    switch (local)
                    {
                        case true:
                            ShopDriver.itemCards[instantiateNumber[iterator]].SetActive(true);
                            found = true;
                            break;
                        case false:
                            ShopDriver.itemCards[instantiateNumber[iterator]].SetActive(false);
                            break;
                    }

                    if (local)
                    {
                        local = false;
                        break;
                    }
                }

                iterator++;
            }
        }

        if (!found)
            noResults.SetActive(true);
        else
            noResults.SetActive(false);

    }

}

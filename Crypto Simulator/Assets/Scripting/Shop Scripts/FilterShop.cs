using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        if(searchText.GetComponent<TextMeshProUGUI>().text != "\u200B")
        search();

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
        searchButton.GetComponent<Button>().onClick.AddListener(() => search()); 
    }

    // two different searches 
    // search null and search something 
    // this will allow the shop to update when a filter is pressed and not cause 
    // recursion when nothing is pressed as when the shop is reset, the text is null 
    // and it should only call the shop function if the next is not null.

    private void search()
    {
        List<string> searchNames = new List<string>();
        List<int> instantiateNumber = new List<int>(); 

        string text = searchText.GetComponent<TextMeshProUGUI>().text;

        int iter = 0;

        foreach(GameObject x in ShopDriver.itemCards)
        {
            if (x.activeSelf)
            {
                searchNames.Add(GameDriver.names[iter]);
                instantiateNumber.Add(iter); 
            }

            iter++;
        }

        /*
        if (text == "\u200B")
        {
            for (int i = 0; i < ShopDriver.itemCards.Count; i++)
                ShopDriver.itemCards[i].SetActive(true);

            filterToggles(ShopDriver.itemCards);

            noResults.SetActive(false);

            return;
        }
        */

        text = text.TrimEnd('\u200B');                 // weird ass dude

        int iterator = 0;

        bool found = false;

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
                print(x);

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
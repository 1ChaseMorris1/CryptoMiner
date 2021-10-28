using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// works amazing
public class FillShop : MonoBehaviour
{

    private GameObject itemCardPanel;                          // is the parent panel for the item card prefab.
    private GameObject infoCardPanel;                          // is the parent panel for the info card prefab. 
    private GameObject cartCardPanel;                          // is the parent panel for the cart card prefab. 

    private GameObject itemCardPrefab;                         // prefab for the item cards.  
    private GameObject infoCardPrefab;                         // prefab for the info cards.
    private GameObject cartCardPrefab;                         // prefab for the cart cards.

    private TextMeshProUGUI infoTextPrefab;                    // prefab for the info text. 

    private GameObject grey;

    private Animator background; 

    private GameObject info;

    // these lists are a tally of all items in all item classes,this helps 
    // runtime by being able to fill cards faster

    public void addShoppingCart(int x, List<GameObject> cartCards)
    {

        cartCards.Add(Instantiate(cartCardPrefab));

        int i = cartCards.Count - 1;

        cartCards[i].transform.SetParent(cartCardPanel.transform);

        cartCards[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameDriver.names[x];

        cartCards[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = string.Format("$" + GameDriver.costs[x].ToString("F2"));

        cartCards[i].transform.GetChild(2).GetComponent<Image>().sprite = GameDriver.images[x];

    }

    public void fillGameObjects()
    {
        itemCardPanel = GameObject.Find("ItemPanel");
        infoCardPanel = GameObject.Find("Info");
        cartCardPanel = GameObject.Find("CartPanel");

        itemCardPrefab = GameObject.FindWithTag("item");
        infoCardPrefab = GameObject.FindWithTag("moreinfo");
        cartCardPrefab = GameObject.FindWithTag("Cart");

        infoTextPrefab = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();

        grey = GameObject.Find("Grey");
        background = GameObject.Find("Background").GetComponent<Animator>();

        grey.SetActive(false);

    }

    public void fillItems(List<GameObject> itemCards)
    {

        for (int i = 0; i < GameDriver.getTotalItemIterations(); i++)
        {

            itemCards.Add(Instantiate(itemCardPrefab));

            itemCards[i].transform.SetParent(itemCardPanel.transform);

            itemCards[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameDriver.names[i];

            itemCards[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = string.Format("$" + GameDriver.costs[i].ToString("F2"));

            itemCards[i].transform.GetChild(2).GetComponent<Image>().sprite = GameDriver.images[i];

        }

    }

    // may move this function into game driver if I need something like it again.
    public void instantiateInfoCard(int x)
    {

        grey.SetActive(true);
        background.enabled = false;

        int iterator1 = 0;
        int currentIterator = 0;
        bool found = false;

        for (int i = 0; i < GameDriver.getItemAmount(); i++)
        {
            for (int j = 0; j < GameDriver.getItemSize(i); j++)
            {
                if (x == iterator1) {
                    makeInfoCard(x, i);
                    setInfoCardAssets(currentIterator, i);
                    found = true;
                    break;
                }

                currentIterator++;
                iterator1++;
            }
            if (found == true) { break; }
            currentIterator = 0;
        }

    }

    private void makeInfoCard(int x, int currentClass)
    {
        info = Instantiate(infoCardPrefab);

        info.transform.SetParent(infoCardPanel.transform);

        info.transform.localPosition = new Vector3(0, 0, 0);

        info.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameDriver.names[x];

        info.transform.GetChild(1).GetComponent<Image>().sprite = GameDriver.images[x];

        info.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => destroyInfoCard());

    }

    private void destroyInfoCard()
    {
        Destroy(info);
        grey.SetActive(false);
        background.enabled = true;
    }

    private void setInfoCardAssets(int itemNum, int currentClass)
    {

        List<TextMeshProUGUI> textUi = new List<TextMeshProUGUI>();

        switch (currentClass)
        {
            case 0:
                editText(GameDriver.cards[itemNum].getInfoCardFormat(), GameDriver.cards[itemNum].getInfoCardFormat().Length,
                    GameDriver.cards[itemNum].getBreakSize(), textUi);
                break;
            case 1:
                editText(GameDriver.fans[itemNum].getInfoCardFormat(), GameDriver.fans[itemNum].getInfoCardFormat().Length,
                    GameDriver.fans[itemNum].getBreakSize(), textUi);
                break;
            case 2:
                editText(GameDriver.psus[itemNum].getInfoCardFormat(), GameDriver.psus[itemNum].getInfoCardFormat().Length,
                    GameDriver.psus[itemNum].getBreakSize(), textUi);
                break;
            case 3:
                editText(GameDriver.cpus[itemNum].getInfoCardFormat(), GameDriver.cpus[itemNum].getInfoCardFormat().Length,
                    GameDriver.cpus[itemNum].getBreakSize(), textUi);
                break;
            case 4:
                editText(GameDriver.ants[itemNum].getInfoCardFormat(), GameDriver.ants[itemNum].getInfoCardFormat().Length,
                    GameDriver.ants[itemNum].getBreakSize(), textUi);
                break;
            case 5:
                editText(GameDriver.rigs[itemNum].getInfoCardFormat(), GameDriver.rigs[itemNum].getInfoCardFormat().Length,
                    GameDriver.rigs[itemNum].getBreakSize(), textUi);
                break;
            case 6:
                editText(GameDriver.mods[itemNum].getInfoCardFormat(), GameDriver.mods[itemNum].getInfoCardFormat().Length,
                    GameDriver.mods[itemNum].getBreakSize(), textUi);
                break;
            case 7:
                editText(GameDriver.electric[itemNum].getInfoCardFormat(), GameDriver.electric[itemNum].getInfoCardFormat().Length,
                    GameDriver.electric[itemNum].getBreakSize(), textUi);
                break;

        }
    }

    private void editText(string[] text, int iterator, int breakLine, List<TextMeshProUGUI> textUi)
    {
        int j = 0;

        for (int i = 0; i < iterator; i++)
        {
            textUi.Add(Instantiate(infoTextPrefab));

            textUi[j].text = text[i];

            if (j >= breakLine)
                textUi[j].transform.SetParent(info.transform.GetChild(3).transform);
            else
                textUi[j].transform.SetParent(info.transform.GetChild(2).transform);

            j++;
        }

        textUi.Clear();
    }

    public void turnOnCards()
    {
        for (int i = 0; i < ShopDriver.itemCards.Count; i++)
            ShopDriver.itemCards[i].SetActive(true);
    }

}

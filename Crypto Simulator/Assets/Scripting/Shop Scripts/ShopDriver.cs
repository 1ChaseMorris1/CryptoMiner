using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// works amazing
public class ShopDriver : MonoBehaviour
{
    // user money should be set independently and not in the isLoaded condition.

    private string shopErrorOne = "You do not have enough money to buy these items!";
    private string shopErrorTwo = "There is nothing in your cart!";

    private FillShop fillShop;                                             // is used to fill the shop up when needed.

    private FilterShop filterShop;                                          // is used to filter the shop. 

    private float cartMoney;                                               // money in cart 

    [SerializeField] private GameObject cartMoneyText;

    [SerializeField] private TextMeshProUGUI userMoneyText;

    public static List<GameObject> itemCards = new List<GameObject>();             // item card array. 
    public List<GameObject> cartCards = new List<GameObject>();             // cart card array. 

    private List<int> cardsBroughtIn = new List<int>();

    private int cartAmount;

    private void Start()
    {

        cartMoney = 0;

        cartAmount = 0;

        userMoneyText.text = string.Format( "$" + Player.money.ToString("F2"));

        fillShop = gameObject.AddComponent<FillShop>();

        fillShop.fillGameObjects();

        fillShop.fillItems(itemCards);

        filterShop = gameObject.AddComponent<FilterShop>();

        filterShop.populateGameobjects();

        intializeButtons();

        toggleChanged();

        filterShop.setSearchButton();

    }

    private void toggleChanged()
    {
        for (int i = 0; i < filterShop.toggles.Count; i++)
            filterShop.toggles[i].onValueChanged.AddListener(delegate { filterShop.filterToggles(itemCards); });

    }


    public void intializeButtons()
    {
        for (int i = 0; i < GameDriver.getTotalItemIterations(); i++)
        {
            int x = i;
            itemCards[x].transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => fillShop.instantiateInfoCard(x));
            itemCards[x].transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => addToCart(x));
        }
    }

    private void addToCart(int x)
    {

        bool found = false;
        int iter = 0;

        foreach (int i in cardsBroughtIn)
        {
            if (x == i)
            {
                found = true;
                iterateCart(iter, x);
                break;
            }
            iter++;
        }

        if (!found)
        {
            fillShop.addShoppingCart(x, cartCards);

            cardsBroughtIn.Add(x);

            int l = cartAmount;
            int y = x;

            cartCards[cartAmount].transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => DestroyCartCard(l, y));

            iterateCart(cartAmount, x);

            cartAmount++;

        }

    }

    private void iterateCart(int i, int x)
    {
        cartCards[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
            (int.Parse(cartCards[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text) + 1).ToString();

        cartMoney += GameDriver.costs[x];

        cartMoneyText.GetComponent<TextMeshProUGUI>().text = string.Format("$" + cartMoney.ToString("F2"));
    }

    private void DestroyCartCard(int x, int i)
    {
        int destroy = (int.Parse(cartCards[x].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text) - 1); 

        cartCards[x].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = destroy.ToString();

        cartMoney -= GameDriver.costs[i];

        cartMoneyText.GetComponent<TextMeshProUGUI>().text = string.Format("$" + cartMoney.ToString("F2"));

        if (destroy == 0)
        {
            Destroy(cartCards[x]);
            cardsBroughtIn[x] = -1;
        }

    }

    // exits the shop
    public void backOne()
    {

        if(getActiveMembers() > 0)
        {
            fillShop.exitError.SetActive(true);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            itemCards.Clear();

            cartCards.Clear();
        }

    }     // temporary

    public void forceClose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        itemCards.Clear();

        cartCards.Clear();
    }

    public void checkout()
    {
        if(cartMoney > Player.money)
        {
            fillShop.cartError.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopErrorOne;
            fillShop.cartError.SetActive(true);
        } else if (getActiveMembers() == 0)
        {
            fillShop.cartError.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopErrorTwo;
            fillShop.cartError.SetActive(true);
        } else
        {
            addInventory(); 
        }
    }

    private int getActiveMembers()
    {
        int items = 0;

        foreach (GameObject x in cartCards)
        {
            if (x != null) { items++; }
        }

        return items;
    }

    private int iter = 0; 

    private void addInventory()
    {
        List<string> names = new List<string>();
        List<int> amount = new List<int>();

        foreach (GameObject x in cartCards)
        {
            if (x != null)
            {
                names.Add(x.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                amount.Add(int.Parse(x.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text));
            }
        }

        int num;

        for(int i = 0; i < names.Count; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                num = testf(GameDriver.cards.Count, names[i]);
                if (num != -1) {

                    for(int l = 0; l < amount[num]; l++)
                    Player.inventory.cards.Add(GameDriver.cards[num]);
                    break;
                }

                num = testf(GameDriver.fans.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.fans.Add(GameDriver.fans[num]);
                    break;
                }

                num = testf(GameDriver.psus.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.psus.Add(GameDriver.psus[num]);
                    break;
                }

                num = testf(GameDriver.cpus.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.cpus.Add(GameDriver.cpus[num]);
                    break;
                }

                num = testf(GameDriver.ants.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.ants.Add(GameDriver.ants[num]);
                    break;
                }

                num = testf(GameDriver.rigs.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.rigs.Add(GameDriver.rigs[num]);
                    break;
                }

                num = testf(GameDriver.mods.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.mods.Add(GameDriver.mods[num]);
                    break;
                }

                num = testf(GameDriver.electric.Count, names[i]);
                if (num != -1)
                {
                    for (int l = 0; l < amount[num]; l++)
                        Player.inventory.electric.Add(GameDriver.electric[num]);
                }
            }
            iter = 0;
        }

        Player.money -= cartMoney;

        forceClose();
    }

    private int testf(int x, string name)
    {
        int y = iter;
        int loop = 0;

        for(int i = y; i < (x + y); i++)
        {
            if(GameDriver.names[i] == name)
                return loop;
            
            loop++;
            iter++;
        }
        return -1;
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// works amazing
public class ShopDriver : MonoBehaviour
{
    // user money should be set independently and not in the isLoaded condition.

    private FillShop fillShop;                                             // is used to fill the shop up when needed.

    private FilterShop filterShop;                                          // is used to filter the shop. 

    private float cartMoney;                                               // money in cart 

    [SerializeField] private GameObject cartMoneyText;

    public static List<GameObject> itemCards = new List<GameObject>();             // item card array. 
    public List<GameObject> cartCards = new List<GameObject>();             // cart card array. 

    private List<int> cardsBroughtIn = new List<int>();

    private int cartAmount;

    private void Start()
    {

        cartMoney = 0;

        cartAmount = 0;

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

    public void backOne()
    {
        if(cartCards.Count > 0)
        {
            // show warning
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        itemCards.Clear();

        cartCards.Clear(); 

    }     // temporary

}

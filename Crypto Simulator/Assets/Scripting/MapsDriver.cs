using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapsDriver : MonoBehaviour
{

    [SerializeField]
    private List<Button> areaButtons;

    [SerializeField]
    private GameObject infoArea;

    private string[] cities;

    private void Start()
    {

        setAreasColors();

        setButtonCalls();

        cities = System.IO.File.ReadAllLines("Assets/textAssets/Cities.txt");
    }

    private void setButtonCalls()
    {
        for (int i = 0; i < areaButtons.Count; i++)
        {
            int y = i;
                   areaButtons[i].onClick.AddListener(() => openInfo(y));
        }
    }


    // colors turn the boxes white and I dont know why, the codes are set correctly 
    // but is seems as though the color isnt updating. 
    
     private void setAreasColors()
     {
         ColorBlock color;

         for (int i = 0; i < areaButtons.Count; i++)
         {
             color = areaButtons[i].colors;

             if (!Player.unlockedMaps[i])
             {
                 color.normalColor = new Color32(115, 9, 9, 132);
                 color.highlightedColor = new Color32(169,9,9,132);
                 color.pressedColor = new Color32(169, 9, 9, 132);
                 color.selectedColor = new Color32(115, 9, 9, 132);
             } else
             {
                 color.normalColor = new Color32(25, 94, 23, 132);
                 color.highlightedColor = new Color32(25, 128, 23, 132);
                 color.pressedColor = new Color32(25, 128, 23, 132);
                 color.selectedColor = new Color32(25, 94, 23, 132);
             }

             areaButtons[i].colors = color;
         }
     }

    private void openInfo(int x)
    {
        if (!Player.unlockedMaps[x])
        {
            switch (x)                                  // columbus is not used because it is inately open.
            {
                case 1: instantiateInfoCard(x, "Dallas", 10000f); break;  // Dallas
                case 2: instantiateInfoCard(x, "Las Vegas", 50000f); break;  // Las Vegas 
                case 3: instantiateInfoCard(x, "Denver", 75000f); break;  // Denver
                case 4: instantiateInfoCard(x, "Seattle", 100000f); break;  // Seattle
            }
        } else
        {
            switch (x)
            {
                case 0: SceneManager.LoadScene("Columbus"); break;
                case 1:  break; // Dallas
                case 2:  break; // las Vegas
                case 3:  break; // Denver
                case 4:  break; // seattle
            }
        }
    }

    private void instantiateInfoCard(int x, string name, float cost)
    {

        infoArea.SetActive(true);

        infoArea.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(() => infoArea.SetActive(false));

        infoArea.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;

        infoArea.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = string.Format("$" + cost.ToString("#,##0"));

        infoArea.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cities[x - 1];

        // purchase

    }
    
}

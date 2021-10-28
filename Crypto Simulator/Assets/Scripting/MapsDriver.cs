using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapsDriver : MonoBehaviour
{

    [SerializeField]
    private List<Button> areaButtons;

    [SerializeField]
    private List<GameObject> infoAreas;

    public static List<bool> mapUnlocks = new List<bool>();

    private void Start()
    {

        setAreasColors();

        setButtonCalls(); 
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

            if (!mapUnlocks[i])
            {
                color.normalColor = new Color(115, 9, 9, 132);
                color.highlightedColor = new Color(169,9,9,132);
                color.pressedColor = new Color(169, 9, 9, 132);
                color.selectedColor = new Color(115, 9, 9, 132);
            } else
            {
                color.normalColor = new Color(25, 94, 23, 132);
                color.highlightedColor = new Color(25, 128, 23, 132);
                color.pressedColor = new Color(25, 128, 23, 132);
                color.selectedColor = new Color(25, 94, 23, 132);
            }

            areaButtons[i].colors = color;
        }
    }

    private void openInfo(int x)
    {
        if (mapUnlocks[x])
        {
            instantiateInfoCard(x);
        }
    }

    private void instantiateInfoCard(int x)
    {



    }

}

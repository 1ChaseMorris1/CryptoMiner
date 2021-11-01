using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortDriver : MonoBehaviour
{
    public TextMeshProUGUI money; 

    private void Start()
    {
        money.text = string.Format("$" + Player.money.ToString("F2"));
    }

    private void Update()
    {
        money.text = string.Format("$" + Player.money.ToString("F2"));
    }



}

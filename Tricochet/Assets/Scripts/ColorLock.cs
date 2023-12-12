using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLock : MonoBehaviour
{
    [SerializeField]
    Toggle p1Color;

    [SerializeField]
    Toggle p2Color;

    [SerializeField]
    Toggle p3Color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p1Color.isOn == true)
        {
            p2Color.isOn = false;
            p3Color.isOn = false;
            p2Color.interactable = false;
            p3Color.interactable = false;
        }
        else if (p2Color.isOn == true)
        {
            p1Color.isOn = false;
            p3Color.isOn = false;
            p1Color.interactable = false;
            p3Color.interactable = false;
        }
        else if (p3Color.isOn == true)
        {
            p1Color.isOn = false;
            p2Color.isOn = false;
            p1Color.interactable = false;
            p2Color.interactable = false;
        }
        else
        {
            p1Color.interactable = true;
            p2Color.interactable = true;
            p3Color.interactable = true;
        }
    }
}

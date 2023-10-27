using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCode : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //do what the sage advice gave you
        //the healthbar can even reference a health manager, and then update all by itself

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //make it so the object is taking damage not the prefab
    public void takeDamageV2(float fill)
    {
        gameObject.GetComponent<Image>().fillAmount = fill;
    }
}

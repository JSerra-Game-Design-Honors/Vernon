using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarScript : MonoBehaviour
{

    private float chargeAmount;
    private float chargeMultiplier = 1;

    private static int IDCharging = 0;
    private bool charged = false;

    private static int uID;
    private int ID;

    public void SetID(int i)
    {
        uID = i;
    }

    private void Awake()
    {
        ID = uID;
    }

    // Start is called before the first frame update
    void Start()
    {
        chargeAmount = 0;
        fill(0);
        
    }

    // Update is called once per frame

    //ok, so we got the whole ID thing working, now you have to figure out how to make each one fill up one at a time before filling the
    //next one... also, try and change the color from like grey to green when a bar is fully charged
    //find a way to output the amount of charge bars filled and send it back to the player so it can calculate bullet damage/speed etc
    void Update()
    {
        //why this no work??
        if(ID == IDCharging)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Debug.Log("Charging");
                chargeAmount += 0.001f * chargeMultiplier;

                //fill(chargeAmount);
                fill(chargeAmount);

                /*
                if (filled())
                {
                    IDCharging++;
                }
                */

            }
            else
            {
                chargeAmount = 0;
                fill(0);
            }
        }


        if(Input.GetKeyUp(KeyCode.W))
        {
            //Debug.Log("My ID is: " + ID);
            Debug.Log("IDCharging = " + IDCharging + "   ID = " + ID);
        }

    }

    private void fill(float fillA)
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

        foreach (GameObject child in bars)
        {
            if (child.CompareTag("ChargeBarFill"))
            {
                child.GetComponent<Image>().fillAmount = fillA;
            }
        }
    }

    private bool filled()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

        foreach (GameObject child in bars)
        {
            if (child.CompareTag("ChargeBarFill"))
            {
                if(child.GetComponent<Image>().fillAmount == 1)
                {
                    return true;
                }
                
            }
        }

        return false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChargeBarScript : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    private float chargeAmount;
    private float chargeMulti;

    private static int IDCharging = 0;
    public static int barsCharged = 0;

    private static int uID;
    private int ID;



    private List<GameObject> chargeBarObjs = new List<GameObject>();

    PhotonView view;

    public void SetID(int i)
    {
        uID = i;
    }

    private void Awake()
    {
        ID = uID;
        createList();
    }

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        chargeAmount = 0;
        clearFill();
        chargeMulti = Player.GetComponent<PlayerMovement>().returnChargeMulti();

    }

    public int returnNumCharged()
    {
        //Debug.Log("Function Called. BarsCharged = " + barsCharged);
        int sendBars = barsCharged;
        return sendBars;
    }

    // Update is called once per frame

    //ok, so we got the whole ID thing working, now you have to figure out how to make each one fill up one at a time before filling the
    //next one... also, try and change the color from like grey to green when a bar is fully charged
    //find a way to output the amount of charge bars filled and send it back to the player so it can calculate bullet damage/speed etc
    void Update()
    {
        //why this no work??
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Charging");
            chargeAmount += 0.001f * chargeMulti;


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
            clearFill();
            IDCharging = 0;
            barsCharged = 0;
        }


        if (Input.GetKeyUp(KeyCode.W))
        {
            //Debug.Log("My ID is: " + ID);
            //Debug.Log("IDCharging = " + IDCharging + "   ID = " + ID);
        }

    }

    void createList()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

        foreach (GameObject child in bars)
        {
            if (child.CompareTag("ChargeBarFill"))
            {
                chargeBarObjs.Add(child);
            }
        }
    }

    private void fill(float fillA)
    {

        if (ID == IDCharging)
        {
            chargeBarObjs[ID].GetComponent<Image>().fillAmount = fillA - ID;

            if (chargeBarObjs[ID].GetComponent<Image>().fillAmount == 1)
            {
                IDCharging++;
                //Debug.Log("Bars Charged = " + barsCharged);
                barsCharged++;
                //Debug.Log("Bars Charged = " + barsCharged);
            }
        }

    }

        private void clearFill()
        {
            chargeBarObjs[ID].GetComponent<Image>().fillAmount = 0;
        }




        private bool filled()
        {
            GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

            foreach (GameObject child in bars)
            {
                if (child.CompareTag("ChargeBarFill"))
                {
                    if (child.GetComponent<Image>().fillAmount == 1)
                    {
                        return true;
                    }

                }
            }

            return false;
        }

}

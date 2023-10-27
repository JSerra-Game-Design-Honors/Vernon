using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    //IN CODE CHANGE THE LAYERS AND TAGS OF EACH PLAYER AND BULLET TO MATCH THEIR PLAYERNUM, ALSO CHANGE COLOR OF HEALTH!!!
    //THE FILL AMOUNT IS CHANGING THE PREFAB NOT THE ACTUAL ONE!!!!!! WHY DOES THIS ALWAYS HAPPEN, FIX THIS!!!!

    [SerializeField]
    GameObject Shooter, Speedster, Sniper, Lightweight, Tank, Trapper, HealthManager1, HealthManager2, HealthManager3, Canvas, powerUp;

    //[SerializeField]
    //GameObject SniperGun, LightweightGun, TankGun, TrapperGun;

    [SerializeField]
    public GameObject HealthBar1, HealthBar2, HealthBar3;

    GameObject p1, p2, p3;
    Vector2 pos1, pos2, pos3;

    [SerializeField]
    float powerUpWaitTime;
    bool isPowerUpReady = true;

    GameObject CanvasObj;


    // Start is called before the first frame update
    void Start()
    {

        pos1 = new Vector2(-8, 0);
        pos2 = new Vector2(0, -3);
        pos3 = new Vector2(8, 0);

        //p1
        setp1Class(MainMenuController.p1Class, pos1);
        setp1Color(MainMenuController.p1Color);
        p1.GetComponent<PlayerController>().playerNum = 1;
        p1.layer = 6;
        p1.tag = "Player1";
        Instantiate(HealthManager1, new Vector2(0, 0), Quaternion.identity);

        //p2
        setp2Class(MainMenuController.p2Class, pos2);
        setp2Color(MainMenuController.p2Color);
        p2.GetComponent<PlayerController>().playerNum = 2;
        p2.layer = 7;
        p2.tag = "Player2";
        Instantiate(HealthManager2, new Vector2(0, 0), Quaternion.identity);

        //p3
        setp3Class(MainMenuController.p3Class, pos3);
        setp3Color(MainMenuController.p3Color);
        p3.GetComponent<PlayerController>().playerNum = 3;
        p3.layer = 8;
        p3.tag = "Player3";
        Instantiate(HealthManager3, new Vector2(0, 0), Quaternion.identity);


    }

    public Color32 bulletColor(int ID)
    {
        Color32 playerColor = new Color32(0, 0, 0, 255);

        if (ID == 1)
            playerColor = new Color32(255, 0, 0, 255);
        if (ID == 2)
            playerColor = new Color32(255, 150, 0, 255);
        if (ID == 3)
            playerColor = new Color32(255, 255, 0, 255);
        if (ID == 4)
            playerColor = new Color32(0, 255, 0, 255);
        if (ID == 5)
            playerColor = new Color32(0, 0, 255, 255);
        if (ID == 6)
            playerColor = new Color32(255, 0, 255, 255);

        return playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowerUpReady == false)
            return;

        Instantiate(powerUp, powerUp.GetComponent<PowerUpScript>().randomPos(), Quaternion.identity);
        StartCoroutine(placePowerUp());

    }

    public IEnumerator placePowerUp()
    {
        isPowerUpReady = false;
        yield return new WaitForSeconds(powerUpWaitTime);
        isPowerUpReady = true;
    }

    void setp1Class(int ID, Vector2 playerPos)
    {
        if(ID == 1)
            p1 = Instantiate(Shooter, playerPos, Quaternion.identity);
        if (ID == 2)
            p1 = Instantiate(Speedster, playerPos, Quaternion.identity);
        if (ID == 3)
            p1 = Instantiate(Sniper, playerPos, Quaternion.identity);
        if (ID == 4)
            p1 = Instantiate(Lightweight, playerPos, Quaternion.identity);
        if (ID == 5)
            p1 = Instantiate(Tank, playerPos, Quaternion.identity);
        if (ID == 6)
            p1 = Instantiate(Trapper, playerPos, Quaternion.identity);

    }

    void setp2Class(int ID, Vector2 playerPos)
    {
        if (ID == 1)
            p2 = Instantiate(Shooter, playerPos, Quaternion.identity);
        if (ID == 2)
            p2 = Instantiate(Speedster, playerPos, Quaternion.identity);
        if (ID == 3)
            p2 = Instantiate(Sniper, playerPos, Quaternion.identity);
        if (ID == 4)
            p2 = Instantiate(Lightweight, playerPos, Quaternion.identity);
        if (ID == 5)
            p2 = Instantiate(Tank, playerPos, Quaternion.identity);
        if (ID == 6)
            p2 = Instantiate(Trapper, playerPos, Quaternion.identity);

    }

    void setp3Class(int ID, Vector2 playerPos)
    {
        if (ID == 1)
            p3 = Instantiate(Shooter, playerPos, Quaternion.identity);
        if (ID == 2)
            p3 = Instantiate(Speedster, playerPos, Quaternion.identity);
        if (ID == 3)
            p3 = Instantiate(Sniper, playerPos, Quaternion.identity);
        if (ID == 4)
            p3 = Instantiate(Lightweight, playerPos, Quaternion.identity);
        if (ID == 5)
            p3 = Instantiate(Tank, playerPos, Quaternion.identity);
        if (ID == 6)
            p3 = Instantiate(Trapper, playerPos, Quaternion.identity);

    }

    void setp1Color(int ID)
    {
        Color32 playerColor = new Color32(0, 0, 0, 255);

        if (ID == 1)
            playerColor = new Color32(255, 0, 0, 255);
        if (ID == 2)
            playerColor = new Color32(255, 150, 0, 255);
        if (ID == 3)
            playerColor = new Color32(255, 255, 0, 255);
        if (ID == 4)
            playerColor = new Color32(0, 255, 0, 255);
        if (ID == 5)
            playerColor = new Color32(0, 0, 255, 255);
        if (ID == 6)
            playerColor = new Color32(255, 0, 255, 255);

        
        p1.GetComponent<SpriteRenderer>().color = playerColor;


        SpriteRenderer[] renderers;
        renderers = p1.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in renderers)
            sr.color = playerColor;
        HealthManager1.GetComponent<HealthManager>().HealthBar.GetComponent<Image>().color = playerColor;
    }

    void setp2Color(int ID)
    {
        Color32 playerColor = new Color32(0, 0, 0, 255);

        if (ID == 1)
            playerColor = new Color32(255, 0, 0, 255);
        if (ID == 2)
            playerColor = new Color32(255, 150, 0, 255);
        if (ID == 3)
            playerColor = new Color32(255, 255, 0, 255);
        if (ID == 4)
            playerColor = new Color32(0, 255, 0, 255);
        if (ID == 5)
            playerColor = new Color32(0, 0, 255, 255);
        if (ID == 6)
            playerColor = new Color32(255, 0, 255, 255);

        p2.GetComponent<SpriteRenderer>().color = playerColor;
        SpriteRenderer[] renderers;
        renderers = p2.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in renderers)
            sr.color = playerColor;
        HealthManager2.GetComponent<HealthManager>().HealthBar.GetComponent<Image>().color = playerColor;
    }

    void setp3Color(int ID)
    {
        Color32 playerColor = new Color32(0, 0, 0, 255);

        if (ID == 1)
            playerColor = new Color32(255, 0, 0, 255);
        if (ID == 2)
            playerColor = new Color32(255, 150, 0, 255);
        if (ID == 3)
            playerColor = new Color32(255, 255, 0, 255);
        if (ID == 4)
            playerColor = new Color32(0, 255, 0, 255);
        if (ID == 5)
            playerColor = new Color32(0, 0, 255, 255);
        if (ID == 6)
            playerColor = new Color32(255, 0, 255, 255);

        p3.GetComponent<SpriteRenderer>().color = playerColor;
        SpriteRenderer[] renderers;
        renderers = p3.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in renderers)
            sr.color = playerColor;
        HealthManager3.GetComponent<HealthManager>().HealthBar.GetComponent<Image>().color = playerColor;
    }
}

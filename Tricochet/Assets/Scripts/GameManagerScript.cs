using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    GameObject Shooter, Speedster, Sniper, Lightweight, Tank, Trapper, HealthManager1, HealthManager2, HealthManager3, Canvas, powerUp;

    //[SerializeField]
    //GameObject SniperGun, LightweightGun, TankGun, TrapperGun;

    [SerializeField]
    public GameObject HealthBar1, HealthBar2, HealthBar3;

    [SerializeField]
    TMP_Text score1, score2, score3;

    GameObject p1, p2, p3;
    Vector2 pos1, pos2, pos3;

    [SerializeField]
    float powerUpWaitTime;
    bool isPowerUpReady = true;

    GameObject CanvasObj;

    //[SerializeField]
    //GameObject MapPicker;

    public int countDownTime;
    public TMP_Text countDownDisplay;
    public Canvas countDownCanvas;

    //0 off, 1 on
    public static int gameState = 1;

    public static int playersLeft = 3;

    bool checkWin = true;

    public static int p1numWins = 0;
    public static int p2numWins = 0;
    public static int p3numWins = 0;

    public static int highest = 0;
    public static int middle = 0;
    public static int lowest = 0;

    public static int sceneNum = 1;


    // Start is called before the first frame update
    void Start()
    {
 
        //DontDestroyOnLoad(gameObject);
        gameState = 0;
        playersLeft = 3;
        checkWin = true;
        sceneNum++;

        pos1 = new Vector2(-8, 0);
        pos2 = new Vector2(0, -3.5f);

        //charlie/delta scene change
        if (sceneNum == 4 || sceneNum == 5)
        {
            pos2 = new Vector2(0, -4);
        }
        //echo scene change
        if (sceneNum == 6)
        {
            pos2 = new Vector2(0, -2);
        }


        pos3 = new Vector2(8, 0);

        //end scene change
        if (sceneNum == 11)
        {
            if(p1numWins > p2numWins && p1numWins > p3numWins)
            {
                pos1 = new Vector2(0, 3.5f);

                if (p2numWins > p3numWins)
                {
                    pos2 = new Vector2(6.5f, 0);
                    pos3 = new Vector2(-6.5f, 0);
                }
                else
                {
                    pos3 = new Vector2(6.5f, 0);
                    pos2 = new Vector2(-6.5f, 0);
                }

            }

            if (p2numWins > p1numWins && p2numWins > p3numWins)
            {
                pos2 = new Vector2(0, 3.5f);

                if (p1numWins > p3numWins)
                {
                    pos1 = new Vector2(6.5f, 0);
                    pos3 = new Vector2(-6.5f, 0);
                }
                else
                {
                    pos3 = new Vector2(6.5f, 0);
                    pos1 = new Vector2(-6.5f, 0);
                }
            }

            if (p3numWins > p1numWins && p3numWins > p2numWins)
            {
                pos3 = new Vector2(0, 3.5f);

                if (p1numWins > p2numWins)
                {
                    pos1 = new Vector2(6.5f, 0);
                    pos2 = new Vector2(-6.5f, 0);
                }
                else
                {
                    pos2 = new Vector2(6.5f, 0);
                    pos1 = new Vector2(-6.5f, 0);
                }
            }
            
        }

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

        //CountDownTimer
        if(sceneNum != 11)
        StartCoroutine(CountdownToStart());
        else
        {
            gameState = 1;
        }

    }

    void sortNums()
    {
        int num1 = p1numWins;
        int num2 = p2numWins;
        int num3 = p3numWins;

        if (num1 >= num2 && num1 >= num3)
        {
            highest = num1;
            if (num2 >= num3)
            {
                middle = num2;
                lowest = num3;
            }
            else
            {
                middle = num3;
                lowest = num2;
            }
        }
        else if (num2 >= num1 && num2 >= num3)
        {
            highest = num2;
            if (num1 >= num3)
            {
                middle = num1;
                lowest = num3;
            }
            else
            {
                middle = num3;
                lowest = num1;
            }
        }
        else
        {
            highest = num3;
            if (num1 >= num2)
            {
                middle = num1;
                lowest = num2;
            }
            else
            {
                middle = num2;
                lowest = num1;
            }
        }
    }

    IEnumerator CountdownToStart()
    {
        Canvas CountDownCanvas = Instantiate(countDownCanvas, new Vector2(0f, 0f), Quaternion.identity);
        TMP_Text newCountDownDisplay = Instantiate(countDownDisplay, new Vector2(0f, 0f), Quaternion.identity);
        newCountDownDisplay.transform.SetParent(CountDownCanvas.transform);
        newCountDownDisplay.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        newCountDownDisplay.gameObject.SetActive(true);
        //Debug.Log("Start CountDown");
        while (countDownTime > 0)
        {
            
            newCountDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            //Debug.Log("CountDown --");
            countDownTime--;
        }

        newCountDownDisplay.text = "GO!";
        gameState = 1;
        yield return new WaitForSeconds(1f);
        newCountDownDisplay.gameObject.SetActive(false);
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
        if (checkWin)
            playerWins();

        if (isPowerUpReady == false)
            return;

        if(sceneNum != 11)
        {
            Instantiate(powerUp, powerUp.GetComponent<PowerUpScript>().randomPos(), Quaternion.identity);
            StartCoroutine(placePowerUp());
        }
        

        

        //if (Input.GetKey(KeyCode.M))
        //Debug.Log("Num Wins = " + numWins);
    }

    public IEnumerator placePowerUp()
    {
        isPowerUpReady = false;
        yield return new WaitForSeconds(powerUpWaitTime);
        isPowerUpReady = true;
    }

    void playerWins()
    {
        if (playersLeft < 2)
        {
            if(GameObject.Find("Shooter(Clone)"))
            {Debug.Log("Player " + GameObject.Find("Shooter(Clone)").GetComponent<PlayerController>().playerNum + "wins!");}
            if (GameObject.Find("Sniper(Clone)"))
            { Debug.Log("Player " + GameObject.Find("Sniper(Clone)").GetComponent<PlayerController>().playerNum + "wins!"); }
            if (GameObject.Find("Lightweight(Clone)"))
            { Debug.Log("Player " + GameObject.Find("Lightweight(Clone)").GetComponent<PlayerController>().playerNum + "wins!"); }
            if (GameObject.Find("Speedster(Clone)"))
            { Debug.Log("Player " + GameObject.Find("Speedster(Clone)").GetComponent<PlayerController>().playerNum + "wins!"); }
            if (GameObject.Find("TankC(Clone)"))
            { Debug.Log("Player " + GameObject.Find("TankC(Clone)").GetComponent<PlayerController>().playerNum + "wins!"); }
            if (GameObject.Find("Trapper(Clone)"))
            { Debug.Log("Player " + GameObject.Find("Trapper(Clone)").GetComponent<PlayerController>().playerNum + "wins!"); }

            //p1 wins
            if (GameObject.Find("Shooter(Clone)"))
                if (GameObject.Find("Shooter(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }
            if (GameObject.Find("Sniper(Clone)"))
                if (GameObject.Find("Sniper(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }
            if (GameObject.Find("Lightweight(Clone)"))
                if (GameObject.Find("Lightweight(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }
            if (GameObject.Find("Speedster(Clone)"))
                if (GameObject.Find("Speedster(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }
            if (GameObject.Find("TankC(Clone)"))
                if (GameObject.Find("TankC(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }
            if (GameObject.Find("Trapper(Clone)"))
                if (GameObject.Find("Trapper(Clone)").GetComponent<PlayerController>().playerNum == 1)
            { p1numWins++; }

            //p2 wins
            if (GameObject.Find("Shooter(Clone)"))
                if (GameObject.Find("Shooter(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }
            if (GameObject.Find("Sniper(Clone)"))
                if (GameObject.Find("Sniper(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }
            if (GameObject.Find("Lightweight(Clone)"))
                if (GameObject.Find("Lightweight(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }
            if (GameObject.Find("Speedster(Clone)"))
                if (GameObject.Find("Speedster(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }
            if (GameObject.Find("TankC(Clone)"))
                if (GameObject.Find("TankC(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }
            if (GameObject.Find("Trapper(Clone)"))
                if (GameObject.Find("Trapper(Clone)").GetComponent<PlayerController>().playerNum == 2)
            { p2numWins++; }

            //p3 wins
            if (GameObject.Find("Shooter(Clone)"))
                if (GameObject.Find("Shooter(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }
            if (GameObject.Find("Sniper(Clone)"))
                if (GameObject.Find("Sniper(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }
            if (GameObject.Find("Lightweight(Clone)"))
                if (GameObject.Find("Lightweight(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }
            if (GameObject.Find("Speedster(Clone)"))
                if (GameObject.Find("Speedster(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }
            if (GameObject.Find("TankC(Clone)"))
                if (GameObject.Find("TankC(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }
            if (GameObject.Find("Trapper(Clone)"))
                if (GameObject.Find("Trapper(Clone)").GetComponent<PlayerController>().playerNum == 3)
            { p3numWins++; }

            checkWin = false;
            SceneManager.LoadScene(sceneNum);

        }

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

        //WHY THIS NO WORK!!!
        //p1.GetComponent<SpriteRenderer>().color = playerColor;
        //score1.color = playerColor;


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

        //p2.GetComponent<SpriteRenderer>().color = playerColor;
        //score2.color = playerColor;


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

        //p3.GetComponent<SpriteRenderer>().color = playerColor;
        //score3.color = playerColor;

        SpriteRenderer[] renderers;
        renderers = p3.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in renderers)
            sr.color = playerColor;
        
        HealthManager3.GetComponent<HealthManager>().HealthBar.GetComponent<Image>().color = playerColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPreview : MonoBehaviour
{
    //IN CODE CHANGE THE LAYERS AND TAGS OF EACH PLAYER AND BULLET TO MATCH THEIR PLAYERNUM, ALSO CHANGE COLOR OF HEALTH!!!

    [SerializeField]
    GameObject Shooter;
    [SerializeField]
    GameObject Speedster;
    [SerializeField]
    GameObject Sniper;
    [SerializeField]
    GameObject Lightweight;
    [SerializeField]
    GameObject Tank;
    [SerializeField]
    GameObject Trapper;
    [SerializeField]
    GameObject SniperGun;
    [SerializeField]
    GameObject LightweightGun;
    [SerializeField]
    GameObject TankGun;
    [SerializeField]
    GameObject TrapperGun;
    [SerializeField]
    GameObject MainMenuController;
    [SerializeField]
    TMP_Text playerName;

    public int currentClass;
    public  int currentColor;

    // Start is called before the first frame update
    void Start()
    {
        Shooter.GetComponent<SpriteRenderer>().enabled = false;
        Speedster.GetComponent<SpriteRenderer>().enabled = false;
        Sniper.GetComponent<SpriteRenderer>().enabled = false;
        Lightweight.GetComponent<SpriteRenderer>().enabled = false;
        Tank.GetComponent<SpriteRenderer>().enabled = false;
        Trapper.GetComponent<SpriteRenderer>().enabled = false;
        SniperGun.GetComponent<SpriteRenderer>().enabled = false;
        LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
        TankGun.GetComponent<SpriteRenderer>().enabled = false;
        TrapperGun.GetComponent<SpriteRenderer>().enabled = false;

    }

    private void FixedUpdate()
    {
        Shooter.GetComponent<Rigidbody2D>().rotation -= -1f;
        Speedster.GetComponent<Rigidbody2D>().rotation -= -1f;
        Sniper.GetComponent<Rigidbody2D>().rotation -= -1f;
        Lightweight.GetComponent<Rigidbody2D>().rotation -= -1f;
        Tank.GetComponent<Rigidbody2D>().rotation -= -1f;
        Trapper.GetComponent<Rigidbody2D>().rotation -= -1f;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeClass(int ID)
    {
        currentClass = ID;
        //shooter
        if (ID == 1)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = true;
            Speedster.GetComponent<SpriteRenderer>().enabled = false;
            Sniper.GetComponent<SpriteRenderer>().enabled = false;
            Lightweight.GetComponent<SpriteRenderer>().enabled = false;
            Tank.GetComponent<SpriteRenderer>().enabled = false;
            Trapper.GetComponent<SpriteRenderer>().enabled = false;
            SniperGun.GetComponent<SpriteRenderer>().enabled = false;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
            TankGun.GetComponent<SpriteRenderer>().enabled = false;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = false;
            playerName.text = "Shooter";
        }

        //speedster
        if (ID == 2)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = false;
            Speedster.GetComponent<SpriteRenderer>().enabled = true;
            Sniper.GetComponent<SpriteRenderer>().enabled = false;
            Lightweight.GetComponent<SpriteRenderer>().enabled = false;
            Tank.GetComponent<SpriteRenderer>().enabled = false;
            Trapper.GetComponent<SpriteRenderer>().enabled = false;
            SniperGun.GetComponent<SpriteRenderer>().enabled = false;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
            TankGun.GetComponent<SpriteRenderer>().enabled = false;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = false;
            playerName.text = "Speedster";
        }

        //sniper
        if (ID == 3)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = false;
            Speedster.GetComponent<SpriteRenderer>().enabled = false;
            Sniper.GetComponent<SpriteRenderer>().enabled = true;
            Lightweight.GetComponent<SpriteRenderer>().enabled = false;
            Tank.GetComponent<SpriteRenderer>().enabled = false;
            Trapper.GetComponent<SpriteRenderer>().enabled = false;
            SniperGun.GetComponent<SpriteRenderer>().enabled = true;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
            TankGun.GetComponent<SpriteRenderer>().enabled = false;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = false;
            playerName.text = "Sniper";
        }

        //lightweight
        if (ID == 4)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = false;
            Speedster.GetComponent<SpriteRenderer>().enabled = false;
            Sniper.GetComponent<SpriteRenderer>().enabled = false;
            Lightweight.GetComponent<SpriteRenderer>().enabled = true;
            Tank.GetComponent<SpriteRenderer>().enabled = false;
            Trapper.GetComponent<SpriteRenderer>().enabled = false;
            SniperGun.GetComponent<SpriteRenderer>().enabled = false;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = true;
            TankGun.GetComponent<SpriteRenderer>().enabled = false;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = false;
            playerName.text = "Lightweight";
        }

        //tank
        if (ID == 5)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = false;
            Speedster.GetComponent<SpriteRenderer>().enabled = false;
            Sniper.GetComponent<SpriteRenderer>().enabled = false;
            Lightweight.GetComponent<SpriteRenderer>().enabled = false;
            Tank.GetComponent<SpriteRenderer>().enabled = true;
            Trapper.GetComponent<SpriteRenderer>().enabled = false;
            SniperGun.GetComponent<SpriteRenderer>().enabled = false;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
            TankGun.GetComponent<SpriteRenderer>().enabled = true;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = false;
            playerName.text = "Tank";
        }

        //trapper
        if (ID == 6)
        {
            Shooter.GetComponent<SpriteRenderer>().enabled = false;
            Speedster.GetComponent<SpriteRenderer>().enabled = false;
            Sniper.GetComponent<SpriteRenderer>().enabled = false;
            Lightweight.GetComponent<SpriteRenderer>().enabled = false;
            Tank.GetComponent<SpriteRenderer>().enabled = false;
            Trapper.GetComponent<SpriteRenderer>().enabled = true;
            SniperGun.GetComponent<SpriteRenderer>().enabled = false;
            LightweightGun.GetComponent<SpriteRenderer>().enabled = false;
            TankGun.GetComponent<SpriteRenderer>().enabled = false;
            TrapperGun.GetComponent<SpriteRenderer>().enabled = true;
            playerName.text = "Trapper";
        }
    }

    public void changeColor(int ID)
    {
        currentColor = ID;
        Color32 playerColor = new Color32(0, 0, 0, 255);

        if(ID == 1)
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

        Shooter.GetComponent<SpriteRenderer>().color = playerColor;
        Speedster.GetComponent<SpriteRenderer>().color = playerColor;
        Sniper.GetComponent<SpriteRenderer>().color = playerColor;
        Lightweight.GetComponent<SpriteRenderer>().color = playerColor;
        Tank.GetComponent<SpriteRenderer>().color = playerColor;
        Trapper.GetComponent<SpriteRenderer>().color = playerColor;
        SniperGun.GetComponent<SpriteRenderer>().color = playerColor;
        LightweightGun.GetComponent<SpriteRenderer>().color = playerColor;
        TankGun.GetComponent<SpriteRenderer>().color = playerColor;
        TrapperGun.GetComponent<SpriteRenderer>().color = playerColor;
        playerName.color = playerColor;

    }
}

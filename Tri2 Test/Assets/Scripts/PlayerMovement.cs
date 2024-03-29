using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private bool _forwardMoving;
    private bool _backwardsMoving;
    private bool _leftMoving;
    private bool _rightMoving;
    private float _turnDirection;
    private bool hasShot;

    private Vector3 mousePos;

    public static float chargeThresholdLevel;
    private float chargeAmount;
    public int numChargeBars;

    [SerializeField]
    private float moveSpeed, speedMultiplier, chargeMultiplier;

    [SerializeField]
    GameObject ChargeBar;

    [SerializeField]
    public Bullet bullet;

    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    private Camera mainCam;


    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = Instantiate(this.canvas, new Vector3(0f, 0f, 0f), Quaternion.identity);
        _rigidbody = GetComponent<Rigidbody2D>();
        createChargeBars();
        //chargeFill.fillAmount = 0f;
        hasShot = true;
        canvas.worldCamera = mainCam;
    }

    void createChargeBars()
    {
        int yVal = 190;
        for(int i = 1; i < numChargeBars+1; i++)
        {
            yVal = 190 - ((i-1) * 55);
            GameObject chargeBar = Instantiate(ChargeBar, new Vector3(-140f, yVal, 0f), Quaternion.identity);
            chargeBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            chargeBar.GetComponent<ChargeBarScript>().SetID(i);
        }

        //resetChargeBars();
        
    }

    // Update is called once per frame
    void Update()
    {
        _forwardMoving = Input.GetKey(KeyCode.W);
        _backwardsMoving = Input.GetKey(KeyCode.S);
        _leftMoving = Input.GetKey(KeyCode.A);
        _rightMoving = Input.GetKey(KeyCode.D);
        

        //left click
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Charging");
            chargeAmount += 0.001f * chargeMultiplier;
            hasShot = false;
        }
        else if(!Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Not Charging/Shooting");
            if (hasShot == false)
            {
                hasShot = true;
                //chargeLevel = chargeFill.fillAmount;
                shoot();
                //chargeFill.fillAmount = 0f;
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //ability or something: right click
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ability or something
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //ability or something
        }



        if (_forwardMoving || _backwardsMoving || _leftMoving || _rightMoving)
        {
            //play audio and idle
        }
        
    }

    private void FixedUpdate()
    {
        if (_forwardMoving)
        {
            _rigidbody.AddForce(new Vector2(0,1) * this.moveSpeed * this.speedMultiplier);
        }
        if (_backwardsMoving)
        {
            _rigidbody.AddForce(new Vector2(0, -1) * this.moveSpeed * this.speedMultiplier);
        }
        if (_leftMoving)
        {
            _rigidbody.AddForce(new Vector2(-1, 0) * this.moveSpeed * this.speedMultiplier);
        }
        if (_rightMoving)
        {
            _rigidbody.AddForce(new Vector2(1, 0) * this.moveSpeed * this.speedMultiplier);
        }

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90);

    }

    private void shoot()
    {
        Bullet bullet = Instantiate(this.bullet, this.transform.position, this.transform.rotation);
        bullet.Project(transform.up);
    }


    //ok heres the thing: i want to access each bar individually to chain them charging one after the other. i can access them by their tag
    //but idk how to change their values since it wants to set them to a generic "gameObject" so... try to figure something out :D

    /*
    private void resetChargeBars()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

        foreach (GameObject bar in bars)
        {
            GameObject chargeBar = Instantiate(ChargeBar, new Vector3(-140f, 0f, 0f), Quaternion.identity);
            chargeBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            chargeBar.GetComponent<Image>().fillAmount = 0f;
        }
    }

    private void updateChargeBars()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("ChargeBarFill");

        foreach(GameObject bar in bars)
        {
            GameObject chargeBar = Instantiate(ChargeBar, new Vector3(-140f, 0f, 0f), Quaternion.identity);
            chargeBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }
    */


}
 
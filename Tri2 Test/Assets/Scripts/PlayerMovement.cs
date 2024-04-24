using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

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
    public static float barsChargedRN;

    [SerializeField]
    public float moveSpeed, speedMultiplier, chargeMultiplier;

    [SerializeField]
    GameObject ChargeBar;

    [SerializeField]
    public Bullet bullet;

    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private Camera miniCam;

    private Camera playerCam;
    private Camera miniMapCam;

    [SerializeField]
    GameObject HealthBar;

    private GameObject health;

    PhotonView view;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            Canvas canvas = Instantiate(this.canvas, new Vector3(0f, 0f, 0f), Quaternion.identity);
            canvas.sortingOrder = 1;
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            health = Instantiate(HealthBar, transform.position, Quaternion.identity);
            playerCam = Instantiate(mainCam, transform.position, Quaternion.identity);
            miniMapCam = Instantiate(miniCam, transform.position, Quaternion.identity);
            playerCam.orthographicSize = 7.5f;
            miniMapCam.orthographicSize = 25f;
            miniMapCam.transform.position = new Vector3(0f, 0f, -10f);
            miniMapCam.rect = new Rect(0.85f, 0.745f, 0.25f, 0.25f);
            canvas.worldCamera = playerCam;
            createChargeBars();
            //chargeFill.fillAmount = 0f;
            hasShot = true;
            
        }
    }

    public Vector3 returnPos()
    {
        return transform.position;
    }

    public float returnChargeMulti()
    {
        return chargeMultiplier;
    }

    void createChargeBars()
    {
        int botY = 190 - ((numChargeBars - 1) * 55);
        int yVal;
        for (int i = 1; i < numChargeBars + 1; i++)
        {
            yVal = botY + ((i - 1) * 55);
            GameObject chargeBar = Instantiate(ChargeBar, new Vector3(-140f, yVal, 0f), Quaternion.identity);
            chargeBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            chargeBar.GetComponent<ChargeBarScript>().SetID(i);
        }

        //resetChargeBars();

    }

    // Update is called once per frame
    private void Update()
    {
        if (view.IsMine)
        {
            _forwardMoving = Input.GetKey(KeyCode.W);
            _backwardsMoving = Input.GetKey(KeyCode.S);
            _leftMoving = Input.GetKey(KeyCode.A);
            _rightMoving = Input.GetKey(KeyCode.D);

            health.transform.position = transform.position + new Vector3(0, 0.75f, 0);
            playerCam.transform.position = transform.position + new Vector3(0, 0, -10);


            //left click
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Debug.Log("Charging");
                chargeAmount += 0.001f * chargeMultiplier;
                hasShot = false;
            }
            else if (!Input.GetKey(KeyCode.Mouse0))
            {
                if (hasShot == false)
                {
                    hasShot = true;
                    shoot();

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

    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            //Vector3 movement;
            //movement = UpdateMovementOverTime(movement, movementInput, Time.fixedDeltaTime);

            if (_forwardMoving)
            {
                _rigidbody.AddForce(new Vector2(0, 1) * moveSpeed * speedMultiplier);
            }
            if (_backwardsMoving)
            {
                _rigidbody.AddForce(new Vector2(0, -1) * moveSpeed * speedMultiplier);
            }
            if (_leftMoving)
            {
                _rigidbody.AddForce(new Vector2(-1, 0) * moveSpeed * speedMultiplier);
            }
            if (_rightMoving)
            {
                _rigidbody.AddForce(new Vector2(1, 0) * moveSpeed * speedMultiplier);
            }

            mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition);
            //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    private Vector3 UpdateMovementOverTime(Vector3 movement, object movementInput, float fixedDeltaTime)
    {
        throw new NotImplementedException();
    }

    private void shoot()
    {
        if (view.IsMine)
        {
            if (ChargeBar.GetComponent<ChargeBarScript>().returnNumCharged() != 0)
            {
                barsChargedRN = ChargeBar.GetComponent<ChargeBarScript>().returnNumCharged();

                //Bullet bullet;
                PhotonNetwork.Instantiate(bullet.name, transform.position, transform.rotation);
                

            }
        }

    }

    public float returnBarsChargedCalled()
    {
        return barsChargedRN;
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

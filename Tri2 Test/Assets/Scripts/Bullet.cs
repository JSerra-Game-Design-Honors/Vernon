using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    public float projSpeed = 500.0f;

    [SerializeField]
    GameObject player;

    private float projSpeedMult = 0;

    [SerializeField]
    public int lifeTime;
    int lifeTimeLessOne;

    [SerializeField]
    public float damage;

    [SerializeField]
    GameObject ChargeBar;


    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    public int lifeTimeMax;

    PhotonView view;


    // Start is called before the first frame update
    private void Awake()
    {
        view = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        lifeTimeMax = lifeTime;
        lifeTimeLessOne = lifeTimeMax - 1;
    }

    private void Start()
    {
        Project(transform.up);
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] trans;
        trans = GetComponentsInChildren<Transform>();
        foreach (Transform tr in trans)
        {
            tr.rotation = transform.rotation;
        }
    }

    public void Project(Vector2 direction)
    {
        //_rigidbody.AddForce(direction * this.projSpeed * ((PlayerMovement.chargeLevel * projSpeedMult) + 1f));

        //fix why its called project twice and why its the same speed everytime
        //if(ChargeBar.GetComponent<ChargeBarScript>().returnNumCharged() != 0)
        //{

        //its returning zero at this point... idk why?
            //projSpeedMult = ChargeBar.GetComponent<ChargeBarScript>().returnNumCharged();
        projSpeedMult = player.GetComponent<PlayerMovement>().returnBarsChargedCalled();
            //projSpeedMult = player.GetComponent<PlayerMovement>().barsChargedRN;
            //Debug.Log("Proj speed = " + projSpeedMult);
        //}
        _rigidbody.AddForce(direction * projSpeed * ((1f * projSpeedMult) + 1f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boarder")
        {
            lifeTime--;
            /*
            if (lifeTime == lifeTimeLessOne)
            {
                SpriteRenderer[] renderers;
                renderers = GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in renderers)
                {
                    Destroy(renderers[1]);
                }
            }
            */

            //color = gameObject.GetComponent<SpriteRenderer>().color;
            //try to change it so the backbullet dies but leaves the actual bullet visable
            if (lifeTime == 0)
                Destroy(gameObject);
        }
    }

    }

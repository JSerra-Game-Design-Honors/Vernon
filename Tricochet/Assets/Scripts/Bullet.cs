using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float projSpeed = 500.0f;

    [SerializeField]
    public int lifeTime;
    int lifeTimeLessOne;

    [SerializeField]
    public float damage;

    [SerializeField]
    public int ID;

    //[SerializeField]
    //public ParticleSystem ps;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    public int lifeTimeMax;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        lifeTimeMax = lifeTime;
        lifeTimeLessOne = lifeTimeMax - 1;
    }
    
    void Start()
    {


    }

    private void Update()
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
        _rigidbody.AddForce(direction * this.projSpeed);

        
    }

    public void layerTag(int layerNum, string tagName)
    {
        gameObject.layer = layerNum;
        gameObject.tag = tagName;
        Transform[] trans;
        trans = GetComponentsInChildren<Transform>();
        foreach (Transform tr in trans)
        {
            tr.gameObject.tag = tagName;
            tr.gameObject.layer = layerNum;
        }

        if (layerNum == 9)
        {

            //ParticleSystem.MainModule ma = ps.main;

            //ma.startColor = new Color(0, 200, 255, 255);

            _spriteRenderer.color = new Color32(0, 200, 255, 255);
        }
            
        if (layerNum == 10)
        {

        }
            _spriteRenderer.color = new Color32(255, 180, 0, 255);
        if (layerNum == 11)
        {

        }
            _spriteRenderer.color = new Color32(0, 255, 60, 255);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boarder")
        {
            lifeTime--;
            if(lifeTime == lifeTimeLessOne)
            {
                SpriteRenderer[] renderers;
                renderers = GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sr in renderers)
                {
                    Destroy(renderers[1]);
                }
            }

            //color = gameObject.GetComponent<SpriteRenderer>().color;
            //try to change it so the backbullet dies but leaves the actual bullet visable
            if (lifeTime == 0)
                Destroy(gameObject);

        }
    }

    public float getDamageVal()
    {
        return damage;
    }
}

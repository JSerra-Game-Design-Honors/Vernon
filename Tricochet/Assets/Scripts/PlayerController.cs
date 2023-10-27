using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //IN CODE CHANGE THE LAYERS AND TAGS OF EACH PLAYER AND BULLET TO MATCH THEIR PLAYERNUM, ALSO CHANGE COLOR OF HEALTH!!!
    //THE FILL AMOUNT IS CHANGING THE PREFAB NOT THE ACTUAL ONE!!!!!! WHY DOES THIS ALWAYS HAPPEN, FIX THIS!!!!

    private Rigidbody2D _rigidbody;

    [SerializeField]
    public int playerNum;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    public Bullet bulletPrefab;
    [SerializeField]
    public GameObject healthPrefab1;
    [SerializeField]
    public GameObject healthPrefab2;
    [SerializeField]
    public GameObject healthPrefab3;
    [SerializeField]
    public float health;
    [SerializeField]
    GameObject GameManager;
    [SerializeField]
    GameObject MainMenuManager;

    private bool _forwardMoving;
    private bool _backwardsMoving;
    private float _turnDirection;

    private float dashSpeed = 1f;
    public bool IsDashAvailable = true;
    public float DashTime = 0.1f;
    public float DashCooldownNum = 3f;

    public bool IsShootAvailable = true;
    [SerializeField]
    public float ShootCooldownNum = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {

        if (playerNum == 1)
            healthPrefab1.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health1 is: " + health);
        if (playerNum == 2)
            healthPrefab2.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health2 is: " + health);
        if (playerNum == 3)
            healthPrefab3.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health3 is: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNum == 1)
        {
            _forwardMoving = Input.GetKey(KeyCode.W);
            _backwardsMoving = Input.GetKey(KeyCode.S);
            if (Input.GetKey(KeyCode.A))
            { _turnDirection = 1f; }
            else if (Input.GetKey(KeyCode.D))
            { _turnDirection = -1f; }
            else
            { _turnDirection = 0f; }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (IsShootAvailable == false)
                    return;

                Shoot();
                StartCoroutine(ShootCooldown());
            }


            if(Input.GetKeyDown(KeyCode.E))
            {
                if (IsDashAvailable == false)
                    return;

                dashSpeed = 5;

                StartCoroutine(DashCooldown());
            }

            
        }

        if (playerNum == 2)
        {
            _forwardMoving = Input.GetKey(KeyCode.T);
            _backwardsMoving = Input.GetKey(KeyCode.G);
            if (Input.GetKey(KeyCode.F))
            { _turnDirection = 1f; }
            else if (Input.GetKey(KeyCode.H))
            { _turnDirection = -1f; }
            else
            { _turnDirection = 0f; }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (IsShootAvailable == false)
                    return;

                Shoot();
                StartCoroutine(ShootCooldown());
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (IsDashAvailable == false)
                    return;

                dashSpeed = 5;

                StartCoroutine(DashCooldown());
            }
        }

        if (playerNum == 3)
        {
            _forwardMoving = Input.GetKey(KeyCode.I);
            _backwardsMoving = Input.GetKey(KeyCode.K);
            if (Input.GetKey(KeyCode.J))
            { _turnDirection = 1f; }
            else if (Input.GetKey(KeyCode.L))
            { _turnDirection = -1f; }
            else
            { _turnDirection = 0f; }

            if (Input.GetKeyDown(KeyCode.U))
            {
                if (IsShootAvailable == false)
                    return;

                Shoot();
                StartCoroutine(ShootCooldown());
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                if (IsDashAvailable == false)
                    return;

                dashSpeed = 5;

                StartCoroutine(DashCooldown());
            }
        }
    }

    private void FixedUpdate()
    {
        if(_forwardMoving)
        {
            _rigidbody.AddForce(this.transform.up * this.moveSpeed * this.dashSpeed);
        }
        else if(_backwardsMoving)
        {
            _rigidbody.AddForce(this.transform.up * this.moveSpeed * -1 * this.dashSpeed);
        }

        if(_turnDirection != 0f)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
        if(playerNum == 1)
        {
            int layerNum = 9;
            string tagNum = "Bullet1";
            bullet.layerTag(layerNum, tagNum);
            //find a way to access the color and set it to the bullet
            //bullet.GetComponent<SpriteRenderer>().color = GameManager.GetComponent<GameManagerScript>().p3c;
            Color32 bc1 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p1Color);
            bullet.GetComponent<SpriteRenderer>().color = bc1;
        }
        if (playerNum == 2)
        {
            int layerNum = 10;
            string tagNum = "Bullet2";
            bullet.layerTag(layerNum,tagNum);
            Color32 bc2 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p2Color);
            bullet.GetComponent<SpriteRenderer>().color = bc2;
        }
        if (playerNum == 3)
        {
            int layerNum = 11;
            string tagNum = "Bullet3";
            bullet.layerTag(layerNum, tagNum);
            Color32 bc3 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p3Color);
            bullet.GetComponent<SpriteRenderer>().color = bc3;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerNum == 1)
        {         
            if (collision.gameObject.tag == "Bullet2" || collision.gameObject.tag == "Bullet3")
            {
                if (collision.gameObject.GetComponent<Bullet>().lifeTime < collision.gameObject.GetComponent<Bullet>().lifeTimeMax)
                {
                    float playerDamage = 0f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 2f)
                        playerDamage = 2f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 3f)
                        playerDamage = 3f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 4f)
                        playerDamage = 4f;

                    //Debug.Log("Player1 health down");
                    healthPrefab1.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab1.GetComponent<HealthManager>().isDead())
                        Destroy(gameObject);
                }
            }
        }

        if (playerNum == 2)
        {
            if (collision.gameObject.tag == "Bullet1" || collision.gameObject.tag == "Bullet3")
            {
                //Debug.Log("Was bullet");
                if (collision.gameObject.GetComponent<Bullet>().lifeTime < collision.gameObject.GetComponent<Bullet>().lifeTimeMax)
                {
                    //Debug.Log("got bullet component");
                    float playerDamage = 0f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 2f)
                        playerDamage = 2f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 3f)
                        playerDamage = 3f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 4f)
                        playerDamage = 4f;
                    //Debug.Log("Damage Done");

                    //Debug.Log("Player2 health down");
                    healthPrefab2.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab2.GetComponent<HealthManager>().isDead())
                        Destroy(gameObject);
                }
            }
        }

        if (playerNum == 3)
        {
            if (collision.gameObject.tag == "Bullet1" || collision.gameObject.tag == "Bullet2")
            {
                if (collision.gameObject.GetComponent<Bullet>().lifeTime < collision.gameObject.GetComponent<Bullet>().lifeTimeMax)
                {
                    float playerDamage = 0f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 2f)
                        playerDamage = 2f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 3f)
                        playerDamage = 3f;
                    if (collision.gameObject.GetComponent<Bullet>().damage == 4f)
                        playerDamage = 4f;

                    //Debug.Log("Player3 health down");
                    healthPrefab3.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab3.GetComponent<HealthManager>().isDead())
                        Destroy(gameObject);

                    //nah man it works
                }
            }
            
        }

    }

    public IEnumerator DashCooldown()
    {
        IsDashAvailable = false;

        yield return new WaitForSeconds(DashTime);

        dashSpeed = 1;

        yield return new WaitForSeconds(DashCooldownNum);

        IsDashAvailable = true;
    }

    public IEnumerator ShootCooldown()
    {
        IsShootAvailable = false;

        yield return new WaitForSeconds(ShootCooldownNum);

        IsShootAvailable = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField]
    public int playerNum;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    public Bullet bulletPrefab1, bulletPrefab2, bulletPrefab3;
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

    public AudioSource audioSourceShoot;
    public AudioSource audioSourceMove;
    public AudioClip shootAudio;
    public AudioClip warbleMove;
    private bool played = false;

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
    float maxHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        if (playerNum == 1)
            healthPrefab1.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health1 is: " + health);
        if (playerNum == 2)
            healthPrefab2.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health2 is: " + health);
        if (playerNum == 3)
            healthPrefab3.GetComponent<HealthManager>().setHealth(health); //Debug.Log("health3 is: " + health);
        resetBullets(bulletPrefab1.GetComponent<Bullet>().ID);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.gameState == 1)
        {
            if (health > maxHealth)
                health = maxHealth;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Player " + playerNum);
                //Debug.Log("Damage = " + bulletPrefab.GetComponent<Bullet>().damage);
                //Debug.Log("Bullet LifeTime = " + bulletPrefab.GetComponent<Bullet>().lifeTimeMax);
                //Debug.Log("Projectile Speed = " + bulletPrefab.GetComponent<Bullet>().projSpeed);
                Debug.Log("Health = " + healthPrefab1.GetComponent<HealthManager>().healthAmount);
                Debug.Log("Speed =" + moveSpeed);
                Debug.Log("Dash Cooldown = " + DashCooldownNum);
            }

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


                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (IsDashAvailable == false)
                        return;

                    dashSpeed = 5;

                    StartCoroutine(DashCooldown());
                }


                if (_forwardMoving || _backwardsMoving)
                {
                    if (!played) { audioSourceMove.Play(); played = true; }
                }
                else { audioSourceMove.Stop(); played = false; }


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

                if (_forwardMoving || _backwardsMoving)
                {
                    if (!played) { audioSourceMove.Play(); played = true; }
                }
                else { audioSourceMove.Stop(); played = false; }
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

                if (_forwardMoving || _backwardsMoving)
                {
                    if (!played) { audioSourceMove.Play(); played = true; }
                }
                else { audioSourceMove.Stop(); played = false; }
            }
        }
    }

    void resetBullets(int ID)
    {
        if(ID == 1)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab1.GetComponent<Bullet>().damage = 3f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab2.GetComponent<Bullet>().damage = 3f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab3.GetComponent<Bullet>().damage = 3f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 5;
        }

        if (ID == 2)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab1.GetComponent<Bullet>().damage = 3f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab2.GetComponent<Bullet>().damage = 3f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 400f;
            bulletPrefab3.GetComponent<Bullet>().damage = 3f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 5;
        }

        if (ID == 3)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab1.GetComponent<Bullet>().damage = 4f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab2.GetComponent<Bullet>().damage = 4f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 5;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab3.GetComponent<Bullet>().damage = 4f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 5;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 5;
        }

        if (ID == 4)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab1.GetComponent<Bullet>().damage = 2f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 6;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab2.GetComponent<Bullet>().damage = 2f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 6;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 450f;
            bulletPrefab3.GetComponent<Bullet>().damage = 2f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 6;
        }

        if (ID == 5)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 350f;
            bulletPrefab1.GetComponent<Bullet>().damage = 3f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 6;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 350f;
            bulletPrefab2.GetComponent<Bullet>().damage = 3f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 6;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 350f;
            bulletPrefab3.GetComponent<Bullet>().damage = 3f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 6;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 6;
        }

        if (ID == 6)
        {
            bulletPrefab1.GetComponent<Bullet>().projSpeed = 250f;
            bulletPrefab1.GetComponent<Bullet>().damage = 4f;
            bulletPrefab1.GetComponent<Bullet>().lifeTime = 7;
            bulletPrefab1.GetComponent<Bullet>().lifeTimeMax = 7;

            bulletPrefab2.GetComponent<Bullet>().projSpeed = 250f;
            bulletPrefab2.GetComponent<Bullet>().damage = 4f;
            bulletPrefab2.GetComponent<Bullet>().lifeTime = 7;
            bulletPrefab2.GetComponent<Bullet>().lifeTimeMax = 7;

            bulletPrefab3.GetComponent<Bullet>().projSpeed = 250f;
            bulletPrefab3.GetComponent<Bullet>().damage = 4f;
            bulletPrefab3.GetComponent<Bullet>().lifeTime = 7;
            bulletPrefab3.GetComponent<Bullet>().lifeTimeMax = 7;
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
        if(playerNum == 1)
        {
            audioSourceShoot.PlayOneShot(shootAudio);
            Bullet bullet = Instantiate(this.bulletPrefab1, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up);
            int layerNum = 9;
            string tagNum = "Bullet1";
            bullet.layerTag(layerNum, tagNum);
            Color32 bc1 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p1Color);
            bullet.GetComponent<SpriteRenderer>().color = bc1;
        }
        if (playerNum == 2)
        {
            audioSourceShoot.PlayOneShot(shootAudio);
            Bullet bullet = Instantiate(this.bulletPrefab2, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up);
            int layerNum = 10;
            string tagNum = "Bullet2";
            bullet.layerTag(layerNum,tagNum);
            Color32 bc2 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p2Color);
            bullet.GetComponent<SpriteRenderer>().color = bc2;
        }
        if (playerNum == 3)
        {
            audioSourceShoot.PlayOneShot(shootAudio);
            Bullet bullet = Instantiate(this.bulletPrefab3, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up);
            int layerNum = 11;
            string tagNum = "Bullet3";
            bullet.layerTag(layerNum, tagNum);
            Color32 bc3 = GameManager.GetComponent<GameManagerScript>().bulletColor(MainMenuController.p3Color);
            bullet.GetComponent<SpriteRenderer>().color = bc3;
        }

    }

    void 
        powerPlayerUp(int ID)
    {

        //They work
        //Debug.Log("PowerUp Script Ran");
        //Debug.Log("ID = " + ID);
        //Debug.Log("PlayerNum = " + playerNum);

        if(playerNum == 1)
        {
            if (ID == 1)
            {
                //damage up
                bulletPrefab1.GetComponent<Bullet>().damage++;
                
            }
            if (ID == 2)
            {
                //bounce up
                bulletPrefab1.GetComponent<Bullet>().lifeTimeMax++;
            }
            if (ID == 3)
            {
                //Bullet speed up
                bulletPrefab1.GetComponent<Bullet>().projSpeed = bulletPrefab1.GetComponent<Bullet>().projSpeed + 25;
            }
            if (ID == 4)
            {
                //health up
                healthPrefab1.GetComponent<HealthManager>().heal(3);
            }
            if (ID == 5)
            {
                //speed up
                moveSpeed++;
            }
            if (ID == 6)
            {
                //dash cooldown down
                DashCooldownNum = DashCooldownNum - 0.1f;

            }
        }

        if (playerNum == 2)
        {
            if (ID == 1)
            {
                //damage up
                //Debug.Log("Damage was = " + bulletPrefab2.GetComponent<Bullet>().damage);
                bulletPrefab2.GetComponent<Bullet>().damage++;
                //Debug.Log("Damage is = " + bulletPrefab2.GetComponent<Bullet>().damage);

            }
            if (ID == 2)
            {
                //bounce up
                //Debug.Log("Bullet LifeTime was = " + bulletPrefab2.GetComponent<Bullet>().lifeTimeMax);
                bulletPrefab2.GetComponent<Bullet>().lifeTimeMax++;            
                //Debug.Log("Bullet LifeTime is = " + bulletPrefab2.GetComponent<Bullet>().lifeTimeMax);
               
            }
            if (ID == 3)
            {
                //Bullet speed up
                //Debug.Log("Projectile Speed was = " + bulletPrefab2.GetComponent<Bullet>().projSpeed);
                bulletPrefab2.GetComponent<Bullet>().projSpeed = bulletPrefab2.GetComponent<Bullet>().projSpeed + 25;
               // Debug.Log("Projectile Speed is = " + bulletPrefab2.GetComponent<Bullet>().projSpeed);
               
            }
            if (ID == 4)
            {
                //health up
                //Debug.Log("Health was = " + healthPrefab1.GetComponent<HealthManager>().healthAmount);
                healthPrefab2.GetComponent<HealthManager>().heal(3);
                //Debug.Log("Health is = " + healthPrefab1.GetComponent<HealthManager>().healthAmount);

            }
            if (ID == 5)
            {
                //speed up
               // Debug.Log("Speed was =" + moveSpeed);
                moveSpeed++;
                //Debug.Log("Speed is =" + moveSpeed);
            }
            if (ID == 6)
            {
                //dash cooldown down
                //Debug.Log("Dash Cooldown was = " + DashCooldownNum);
                DashCooldownNum = DashCooldownNum - 0.1f;
                //Debug.Log("Dash Cooldown is = " + DashCooldownNum);

            }
        }

        if (playerNum == 3)
        {
            if (ID == 1)
            {
                //damage up
                bulletPrefab3.GetComponent<Bullet>().damage++;
            }
            if (ID == 2)
            {
                //bounce up
                bulletPrefab3.GetComponent<Bullet>().lifeTimeMax++;
            }
            if (ID == 3)
            {
                //Bullet speed up
                bulletPrefab3.GetComponent<Bullet>().projSpeed = bulletPrefab3.GetComponent<Bullet>().projSpeed + 25;
            }
            if (ID == 4)
            {
                //health up
                healthPrefab3.GetComponent<HealthManager>().heal(3);
            }
            if (ID == 5)
            {
                //speed up
                moveSpeed++;
            }
            if (ID == 6)
            {
                //dash cooldown down
                DashCooldownNum = DashCooldownNum - 0.1f;

            }
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
                    //if (collision.gameObject.GetComponent<Bullet>().damage == 2f)
                    //    playerDamage = 2f;
                    //if (collision.gameObject.GetComponent<Bullet>().damage == 3f)
                    //    playerDamage = 3f;
                    // if (collision.gameObject.GetComponent<Bullet>().damage == 4f)
                    //    playerDamage = 4f;
                    playerDamage = collision.gameObject.GetComponent<Bullet>().damage;

                    //Debug.Log("Player1 health down");
                    healthPrefab1.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab1.GetComponent<HealthManager>().isDead())
                    {
                        Destroy(gameObject);
                        GameManagerScript.playersLeft--;
                    }
                        
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
                    playerDamage = collision.gameObject.GetComponent<Bullet>().damage;
                    //Debug.Log("Damage Done");

                    //Debug.Log("Player2 health down");
                    healthPrefab2.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab2.GetComponent<HealthManager>().isDead())
                    {
                        Destroy(gameObject);
                        GameManagerScript.playersLeft--;
                    }
                        
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
                    playerDamage = collision.gameObject.GetComponent<Bullet>().damage;

                    //Debug.Log("Player3 health down");
                    healthPrefab3.GetComponent<HealthManager>().takeDamage(playerDamage);
                    if (healthPrefab3.GetComponent<HealthManager>().isDead())
                    {
                        Destroy(gameObject);
                        GameManagerScript.playersLeft--;
                    }
                        

                    //nah man it works
                }
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            powerPlayerUp(collision.gameObject.GetComponent<PowerUpScript>().randPowerID);
            Destroy(collision.gameObject);
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

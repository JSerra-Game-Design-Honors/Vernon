using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public GameObject HealthBar;

    [SerializeField]
    GameObject Canvas, GameManager, score;

    public int playerNum;

    public float healthAmount;
    private float maxHealth;

    // Start is called before the first frame update

    private void Awake()
    {
           
    }

    void Start()
    {
        
        if(playerNum == 1)
        {
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar1Obj = Instantiate(HealthBar, new Vector2(-650, 450), Quaternion.identity) as GameObject;
            HealthBar1Obj.transform.SetParent(CanvasObj.transform, false);
            GameObject Score1 = Instantiate(score, new Vector2(-650, 500), Quaternion.identity);
            Score1.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas1";
            
        }

        if(playerNum == 2)
        {
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar2Obj = Instantiate(HealthBar, new Vector2(0, 450), Quaternion.identity) as GameObject;
            HealthBar2Obj.transform.SetParent(CanvasObj.transform, false);
            GameObject Score2 = Instantiate(score, new Vector2(0, 500), Quaternion.identity);
            Score2.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas2";
        }

        if(playerNum == 3)
        {
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar3Obj = Instantiate(HealthBar, new Vector2(650, 450), Quaternion.identity) as GameObject;
            HealthBar3Obj.transform.SetParent(CanvasObj.transform, false);
            GameObject Score3 = Instantiate(score, new Vector2(650, 500), Quaternion.identity);
            Score3.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas3";
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newHealth()
    {
        if (playerNum == 1)
        {
            //Canvas.GetComponent<CanvasScript>().byebye();
            Destroy(GameObject.FindGameObjectWithTag("OldCanvas1"));
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar1Obj = Instantiate(HealthBar, new Vector2(-650, 450), Quaternion.identity) as GameObject;
            HealthBar1Obj.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas1";

        }

        if (playerNum == 2)
        {
            //Canvas.GetComponent<CanvasScript>().byebye();
            Destroy(GameObject.FindGameObjectWithTag("OldCanvas2"));
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar2Obj = Instantiate(HealthBar, new Vector2(0, 450), Quaternion.identity) as GameObject;
            HealthBar2Obj.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas2";
        }

        if (playerNum == 3)
        {
            //Canvas.GetComponent<CanvasScript>().byebye();
            Destroy(GameObject.FindGameObjectWithTag("OldCanvas3"));
            GameObject CanvasObj = Instantiate(Canvas, new Vector3(0, 0, -1), Quaternion.identity);
            GameObject HealthBar3Obj = Instantiate(HealthBar, new Vector2(650, 450), Quaternion.identity) as GameObject;
            HealthBar3Obj.transform.SetParent(CanvasObj.transform, false);
            CanvasObj.tag = "OldCanvas3";
        }

    }

        public void takeDamage(float damage)
    {
        //Debug.Log("Damage Taken: " + damage);
        //Debug.Log("Health before: " + healthAmount);
        //Debug.Log("Max Health before: " + maxHealth);
        healthAmount -= damage;
        float fillAmount = healthAmount / maxHealth;
        HealthBar.GetComponent<Image>().fillAmount = fillAmount;
        newHealth();
        //Debug.Log("Health after: " + healthAmount);
        //Debug.Log("Max Health after: " + maxHealth);
    }

    public void heal(float healingAmount)
    {
        healthAmount += healingAmount;
        float fillAmount = healthAmount / maxHealth;
        if (healthAmount >= maxHealth)
        {
            healthAmount = maxHealth;
            fillAmount = 1f;
        }
        HealthBar.GetComponent<Image>().fillAmount = fillAmount;
        newHealth();
    }

    public bool isDead()
    {
        if (healthAmount <= 0)
            return true;
        return false;
    }

    public void setHealth(float h)
    {
        healthAmount = h;
        maxHealth = h;
    }
}

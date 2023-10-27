using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    int pUpID;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pulseAnim();
    }

    public Vector2 randomPos()
    {
        float randX = Random.Range(-8.6f, 8.6f);
        float randY = Random.Range(-4.6f, 4f);
        return new Vector2(randX, randY);
    }

    public IEnumerator pulseAnim()
    {
            for (float i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.localScale += new Vector3(i * 0.1f, i * 0.1f, 0);
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.localScale -= new Vector3(i * 0.1f, i * 0.1f, 0);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Boarder")
        {
            gameObject.transform.position = randomPos();
        }

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3")
            Destroy(gameObject);
    }

}
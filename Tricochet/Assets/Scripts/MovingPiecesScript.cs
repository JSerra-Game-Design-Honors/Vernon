using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPiecesScript : MonoBehaviour
{
    [SerializeField]
    int ID;

    [SerializeField]
    float speed;

    //[SerializeField]
    //GameObject movingBox;

    bool stormMoving = true;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        if(ID == 2)
        StartCoroutine(stormMove());

        if (ID == 3)
        {
            Vector2 direction = new Vector2(1f, 0f);
            float randDir = Random.Range(1f, 5f);

            if(randDir > 1 && randDir < 2)
            {
                direction = new Vector2(1f, 1f);
            }
            if (randDir > 2 && randDir < 3)
            {
                direction = new Vector2(-1f, 1f);
            }
            if (randDir > 3 && randDir < 4)
            {
                direction = new Vector2(1f, -1f);
            }
            if (randDir > 4 && randDir < 5)
            {
                direction = new Vector2(-1f, -1f);
            }


            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 100f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(ID == 1)
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);

        if (ID == 2 && stormMoving)
        {
            transform.localScale -= new Vector3(0.0001F, 0.0001f, 0) * speed * Time.deltaTime * 100;
        }

        if(ID == 3)
        {
            
        }
    }

    public void Project(Vector2 direction)
    {
        //_rigidbody.AddForce(direction * 100);


    }

    IEnumerator stormMove()
    {
        
        yield return new WaitForSeconds(70/speed);
        stormMoving = false;
    }

    }

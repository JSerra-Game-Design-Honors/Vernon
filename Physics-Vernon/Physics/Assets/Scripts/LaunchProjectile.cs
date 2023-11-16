using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField]
    GameObject ball2;

    [SerializeField]
    GameObject ball3;

    public GameObject projectile;
    public float launchVelocity = 700f;

    Vector3 launcher;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            GameObject ball2 = Instantiate(projectile, transform.position-new Vector3(2, 0, 0), transform.rotation);
            GameObject ball3 = Instantiate(projectile, transform.position + new Vector3(2, 0, 0), transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, launchVelocity, 0));
            ball2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            ball3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }

        launcher = transform.localPosition;
        launcher.x += Input.GetAxis("Horizontal") * Time.deltaTime * 10;  
        launcher.y += Input.GetAxis("Vertical") * Time.deltaTime * 10;  
        transform.localPosition = launcher;
    }
}

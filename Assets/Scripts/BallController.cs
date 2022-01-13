using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float impulsForce = 5f;
    private bool ignoreNextCollision;
    private Vector3 startPos;
    public int perfectPass = 0;
    public bool isSuperSpeedActive;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
            return;

        if (isSuperSpeedActive)
        {
            if (!collision.transform.GetComponent<Goal>())
            {
                Destroy(collision.transform.parent.gameObject , 0.3f);
                Debug.Log("Destroying platform");
            }
        }
        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
                deathPart.HitDeathPart();
        }

        //Debug.Log("Ball touched");

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulsForce, ForceMode.Impulse);

        //timer =  Time.time;

        ignoreNextCollision = true;
        Invoke("AllowCollision", 0.2f);

        //Debug.Log(Time.time +" "+ timer);

        perfectPass = 0;
        isSuperSpeedActive = false;

    }

    private void Update()
    {
        if(perfectPass>=3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        }
    }
     
    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    // Update is called once per frame
    public void ResetBall()
    {
        transform.position = startPos;
    }
}

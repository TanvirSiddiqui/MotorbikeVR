using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f;
    public float acceleration = 0.5f;
    public float maximumspeed = 10f;

    public float distance = 5f;

    private float obsticlesSlowDown = 0.5f;
    public bool reachedFinishedLine = false;
    private bool startAccleration = false;
  
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayerAcceleration", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Acceleration Logic
        speed += acceleration * Time.deltaTime;

        if (speed > maximumspeed)
        {
            speed = maximumspeed;
        }

        //Player Movement logic
        if (startAccleration)
        {
            Vector3 direction = new Vector3(
                Camera.main.transform.forward.x,
                0,
                Camera.main.transform.forward.z);
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        if (transform.position.x < -5f) {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }else if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            speed*=obsticlesSlowDown;
            Debug.Log("Bari Khaise");
        }else if (collision.gameObject.tag == "FinishLine")
        {
            reachedFinishedLine = true;
            startAccleration = false;
        }
    }

    public void PlayerAcceleration()
    {
        startAccleration = true;
    }
}

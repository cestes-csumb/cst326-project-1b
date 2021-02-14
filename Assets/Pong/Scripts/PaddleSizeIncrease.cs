using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizeIncrease : MonoBehaviour
{
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    public Ball ball;
    public float countdownTimer;
    public float spawnTimer;
    private Vector3 leftSize;
    private Vector3 rightSize;

    // Start is called before the first frame update
    void Start()
    {
        //store original sizes
        leftSize = leftPaddle.transform.localScale;
        rightSize = rightPaddle.transform.localScale;
        //timer starts
        spawnTimer = 10.0f;
        //hide our object upon start
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;
        BoxCollider bc = this.GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
            //if our timer is 0, "spawn" the object
            /*we need random start position between:
            * x: -7.5 - 7.5
            * z: -5.7 - 5.7*/
            //adding an offset as it tends to place it rather low
            float xRand = Random.Range(-7.5f, 7.5f) + 0.8f;
            float zRand = Random.Range(-5.7f, 5.7f) + 0.8f;
            this.transform.position = new Vector3(xRand, 0.0f, zRand);
            MeshRenderer mr = this.GetComponent<MeshRenderer>();
            mr.enabled = true;
            BoxCollider bc = this.GetComponent<BoxCollider>();
            bc.enabled = true;
            spawnTimer = 10.0f;
        }
        //tick the countdown timer down
        if (countdownTimer > 0) {
            countdownTimer -= Time.deltaTime;
            //Debug.Log(countdownTimer.ToString());
            //once the countdown has reached 0, reset sizes
            if (countdownTimer <= 0) {
                //both sizes are passed in, but with spawn times/effect times set properly, only one should ever be larger than the other
                fixSize(leftSize, rightSize);
                countdownTimer = 0.0f;
            }
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        //left paddle hit 
        if (collision.relativeVelocity.x > 0.0)
        {
            Debug.Log("Increase Size of Left Paddle...");
        }
        //right paddle should make it negative
        else {
            Debug.Log("Increase Size of Right Paddle...");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //hide the object & disable collision
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;
        BoxCollider bc = this.GetComponent<BoxCollider>();
        bc.enabled = false;

        //check if left or right paddle hit the ball
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb.velocity.x > 0.0)
        {
            //Debug.Log("Increasing Size of Left Paddle...");
            Vector3 size = leftPaddle.transform.localScale;
            //scale the paddle by 1.5
            size.z *= 1.5f;
            leftPaddle.transform.localScale = size;
            //set time for 3 seconds
            countdownTimer = 3.0f;
        }
        else {
            //Debug.Log("Increase Size of Right Paddle...");
            Vector3 size = rightPaddle.transform.localScale;
            //scale the paddle by 1.5
            size.z *= 1.5f;
            rightPaddle.transform.localScale = size;
            //set time for 3 seconds
            countdownTimer = 3.0f;
        }

    }
    
    //method used to set the size of the paddles back to normal
    private void fixSize(Vector3 left, Vector3 right) {
        //check if left is larger than normal
        if (leftPaddle.transform.localScale != left)
        {
            //reset
            leftPaddle.transform.localScale = left;
        }
        //otherwise it's the right paddle
        else {
            rightPaddle.transform.localScale = right;
        }
    }
}

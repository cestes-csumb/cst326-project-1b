using UnityEngine;

public class BallDirectionChange : MonoBehaviour
{
    public Ball ball;
    public float spawnTimer;
    //-----------------------------------------------------------------------------

    private void Start()
    {
        //timer starts
        spawnTimer = 20.0f;
        //hide our object upon start
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;
        BoxCollider bc = this.GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    private void Update()
    {
        //decrease spawn timer every second
        spawnTimer -= Time.deltaTime;
        //once it reaches 0, "spawn" our object
        if (spawnTimer <= 0)
        {
            /*we need random start position between:
            * x: -7.5 - 7.5
            * z: -5.7 - 5.7*/
            //adding an offset as it tends to place it rather low
            float xRand = Random.Range(-7.5f, 7.5f) + 0.8f;
            float zRand = Random.Range(-5.7f, 5.7f) + 0.8f;
            this.transform.position = new Vector3(xRand, 0.0f, zRand);
            //make our object visible & have a collider
            MeshRenderer mr = this.GetComponent<MeshRenderer>();
            mr.enabled = true;
            BoxCollider bc = this.GetComponent<BoxCollider>();
            bc.enabled = true;
            spawnTimer = 20.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //do something interesting to the ball, paddle, or some other game element
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        //doubles velocity and reverses direction
        rb.velocity *= -2.0f;
        //hide the object & disable collision
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.enabled = false;
        BoxCollider bc = this.GetComponent<BoxCollider>();
        bc.enabled = false;
    }
}

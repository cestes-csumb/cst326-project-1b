using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {
    public float startSpeed;
    public float step;
    public bool useDebugVisualization;

    public float speed;
    private Rigidbody rb;

    //-----------------------------------------------------------------------------
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = startSpeed;
    }

    //-----------------------------------------------------------------------------
    // Update is called once per frame
    public void Update()
    {
        
    }
    public void Restart()
    {
        speed = startSpeed;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * speed; // change to send to losing side
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            speed += step;
            //get position of ball along z-axis and compare to position of paddle (paddle would be the collision object)
            //pivot is on the center of the paddle
            float heightAboveOrBelow = transform.position.z - collision.transform.position.z;
            //figure out max height of paddle (on the collider of the paddle), extents is the top and bottom
            float maxHeight = collision.collider.bounds.extents.z;
            //and we find out how far above or below we are from the center point
            float percentOfMax = heightAboveOrBelow / maxHeight;

            if (useDebugVisualization) {
                DebugDraw.DrawSphere(transform.position, 0.5f, Color.green);
                DebugDraw.DrawSphere(collision.transform.position, 0.5f, Color.red);
                Debug.Break();
                Debug.Log($"percent height = {percentOfMax}");
            }

            bool hitLeftPaddle = collision.gameObject.name == "PaddleLeft";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed: -speed;

            //so we're only modifying x and z, not y (y would be going towards the camera)
            Vector3 newVelocity = new Vector3(newHorizontalSpeed, 0f, percentOfMax * 4f).normalized * speed;
            rb.velocity = newVelocity;
        }
    }
}

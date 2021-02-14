using UnityEngine;

public class Paddle : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioSource speaker;
    public Ball ball;

    //-----------------------------------------------------------------------------
    public void MadeContact(Rigidbody ballRb)
    {
        //if the velocity is negative we need to account for that
        if (ballRb.velocity.x < 0.0f)
        {
            //start with a low pitch that will increase as the velocity goes up
            speaker.pitch = ballRb.velocity.x * -0.085f;
        }
        //velocity is positive so just start at the low pitch and increase as velocity goes up
        else {
            speaker.pitch = ballRb.velocity.x * 0.085f;
        }
        //play the sound
        speaker.PlayOneShot(hitSound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //when a collision with ball occurs, play the sound
        if (collision.gameObject.name.Equals("Ball")) {
            MadeContact(ball.GetComponent<Rigidbody>());
        }
    }
}

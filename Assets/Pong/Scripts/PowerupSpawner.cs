using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public PaddleSizeIncrease powerUpOne;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = 30;
            Debug.Log("Spawn powerup...");
        }

    }
    private void FixedUpdate()
    {
        
    }
}

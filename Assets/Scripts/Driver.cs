using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steeringSpeed = 0.1f;
    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostedSpeed = 30f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        float steerRate = Input.GetAxis("Horizontal")*steeringSpeed*Time.deltaTime;
        float forwardRate = Input.GetAxis("Vertical")*forwardSpeed*Time.deltaTime;
        transform.Rotate(0,0,-steerRate);
        transform.Translate(0,forwardRate,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        forwardSpeed = slowSpeed;
    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            
            forwardSpeed = boostedSpeed;
        }
    }
}

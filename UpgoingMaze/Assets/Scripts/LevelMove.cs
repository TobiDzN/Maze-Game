using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{ 

    [SerializeField] float speed = -3;
    

    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float getSpeed()
    {
        return speed;
    }

}

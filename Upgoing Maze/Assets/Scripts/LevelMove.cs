using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = -4;
    void Start()
    {
        
    }

    IEnumerator waiter ()
    {
        yield return new WaitForSeconds(1);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime; 
        if(Input.GetKeyUp(KeyCode.Space))
        {
            speed = speed * 2;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}

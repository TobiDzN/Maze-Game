using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection,new Vector3(0.383571625f, 14.5f, 0.142252937f), Quaternion.identity);
        }
    }
}

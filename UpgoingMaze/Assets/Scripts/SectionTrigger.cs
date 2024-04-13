using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject [] roadSections;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trigger"))
        {
            System.Random rnd = new System.Random();
            Instantiate(roadSections[rnd.Next(roadSections.Length)],new Vector3(0f, 16f, 0f), Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{

    [SerializeField] GameObject InsText, InsWasd, InsArrows;


    // Start is called before the first frame update
    void Start()
    {
        StartInstructionsTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator instructionTimer()
    {
        yield return new WaitForSeconds(5);
        InsText.SetActive(false);
        InsWasd.SetActive(false);
        InsArrows.SetActive(false);
    }

    public void StartInstructionsTimer()
    {
        InsText.SetActive(true);
        InsWasd.SetActive(true);
        InsArrows.SetActive(true);
        StartCoroutine(instructionTimer());
    }

}

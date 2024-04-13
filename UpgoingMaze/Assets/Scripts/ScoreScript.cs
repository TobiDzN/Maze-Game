using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    TMP_Text textbox;

    [SerializeField]
    BallScript ballScript;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: "+ballScript.getScore();
    }
}

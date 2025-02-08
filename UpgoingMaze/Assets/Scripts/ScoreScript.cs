using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    TMP_Text textbox;

    [SerializeField]
    BallScript ballScript;
    [SerializeField]
    PauseMenu pauseMenu;
    [SerializeField]
    TMP_Text diffTxt;
    [SerializeField]
    TMP_Text bestTxt;

    string diffText;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

        textbox.text = "Score: "+ballScript.getScore();
        bestTxt.text = "Best: "+ballScript.getBestScore();


        diffText = pauseMenu.getDiff();
        diffTxt.text = diffText;
        if(diffText.Equals("Easy"))
        {
            diffTxt.color = Color.green;
        }
        else if(diffText.Equals("Medium"))
        {
            diffTxt.color= Color.yellow;
        }
        else if(diffText.Equals("Hard"))
        {
            diffTxt.color = Color.red;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 7;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    [SerializeField]
    int Score = 0;
    GameObject levelmove;
    private BoxCollider2D boxCollider;
    float levelspeed;
    [SerializeField]
    private Vector2 velocity;
    [SerializeField]
    PauseMenu pauseui;
    [SerializeField]
    GameObject firstlevel;

    public GameObject[] walls;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    [SerializeField]private bool grounded;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        
    }

    public void Restart()
    {
        this.gameObject.transform.position = new Vector3(0f, 0f, 0f);
        Score = 0;
        velocity.x = 0f;
        this.gameObject.SetActive(true);
        walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        Instantiate(firstlevel, new Vector3(0f, -0.48f, 0f), Quaternion.identity);
        pauseui.Resume();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            this.gameObject.SetActive(false);
            pauseui.Pause();
        }

        if(collision.gameObject.CompareTag("Checkpoint"))
        {
            Score += 1;
            if (Score % 5 == 0)
            {
                levelmove = collision.gameObject;
                levelspeed = (float)levelmove.gameObject.GetComponentInParent<LevelMove>().getSpeed();
                levelmove.GetComponentInParent<LevelMove>().setSpeed(levelspeed * 1.1f);
                //speed only affects current level need to make it so when a level is created it gets the speed automatically
            }

        }
    }

    public int getScore()
    {
        return Score;
    }

}

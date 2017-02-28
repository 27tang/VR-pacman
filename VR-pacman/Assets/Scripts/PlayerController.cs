 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
   
    public Text scoreText;
    public Text winText;
    public Text loseText;

    public int health;
    public Slider healthSlider;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private int score;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        health = 100;
        loseText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

      //  Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Camera cam = GameObject.Find("/Player/[CameraRig]/Camera (eye)").GetComponent<Camera>();

       // Vector3 movement = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));



        //movement.y = 1;
        //rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pellet"))
        {
            other.gameObject.SetActive(false);
            score+=100;
            SetScoreText();
        }/* else if (other.gameObject.CompareTag("Ghost"))
        {
            health -= 5;
            healthSlider.value = health;
            if(health <= 0)
            {
                SetLoseText();
            }
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ghost"))
        {
            health -= 20;
            healthSlider.value = health;
            if (health <= 0)
            {
                SetLoseText();
                rb.transform.position = new Vector3(0, 6, 0);
                
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 100000)
        {
            winText.text = "You Win!";
        }
    }

    void SetLoseText()
    {
        loseText.text = "GAME OVER!!!";
    }

}

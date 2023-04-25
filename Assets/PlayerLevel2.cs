using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLevel2 : MonoBehaviour {

	public float movementSpeed = 10f;
    public Text scoreText;
    // private float topScore = 0.0f;
	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
        // if(rb.velocity.y > 0 && transform.position.y > topScore)
        // {
        //     topScore = transform.position.y;
        // }
        // scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}
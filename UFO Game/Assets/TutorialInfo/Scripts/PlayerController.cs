using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;  //Floating point variable to store the player's movement speed.
	private Rigidbody2D rb2d; //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private int count; //Integer to store the number of pickups collected so far.
	public Text countText; //Store a reference to the UI Text component which will display the number of pickups collected.
	public Text winText; //Store a reference to the UI Text component which will display the 'You win' message.

	void Start(){
	rb2d = GetComponent<Rigidbody2D> (); //Get and store a reference to the Rigidbody2D component so that we can access it.
		count = 0; // Sets count equal to zero  
		SetcountText(); //Call our SetCountText function which will update the text with the current value for count.
		winText.text = "";   //Initialze winText to a blank string since we haven't won yet at beginning.
	} 
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal"); // Uses that built in keyboard function to move the object horizontally 
		float moveVertical = Input.GetAxis ("Vertical"); // Uses that built in keyboard function to move the ojbect Vertically 
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical); //Use the two store floats to create a new Vector2 variable movement.
		rb2d.AddForce(movement * speed); //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.	    
	}
		void OnTriggerEnter2D(Collider2D other) 
		{
			//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
			if (other.gameObject.CompareTag("PickUp")){
				other.gameObject.SetActive(false);
			count++; //Add one to the current value of our count variable 
			SetcountText (); //Call our SetCountText function which will update the text with the current value for count.
		}

	}
	void SetcountText(){ //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
		countText.text = "Count" + count.ToString(); //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
		//Check if we've collected all 12 pickups. If we have...
		if (count >= 11)
			//... then set the text property of our winText object to "You win!"
			winText.text = "You win!";
	}
}

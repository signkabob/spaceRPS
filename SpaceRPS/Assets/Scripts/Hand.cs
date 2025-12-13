using UnityEngine;

public class Hand : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Set player's movement speed.
    public float rotationSpeed = 90.0f; // Set layer's rotation speed.
    
    // Private variables
    private Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private float horizontalInput; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));     
        
        rb.linearVelocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        GameObject opponent = other.gameObject;
        
        if (opponent.gameObject.name == "Left_Wall" || opponent.gameObject.name == "Right_Wall" || opponent.gameObject.name == "Bottom_Wall" || opponent.gameObject.name == "Top_Wall"){
            transform.Rotate(0,0,180);
        }else if (this.gameObject.name == "Paper"){
            if (opponent.gameObject.name == "Scissor"){
                Debug.Log("SCISSOR BEATS PAPER");
            }
            else if (opponent.gameObject.name == "Rock")
            {
                Debug.Log("PAPER BEATS ROCK");
            }
        }else if (this.gameObject.name == "Rock"){
            if(opponent.gameObject.name == "Scissor")
            {
                Debug.Log("ROCK BEATS SCISSOR");
            }
            if(opponent.gameObject.name == "Paper")
            {
                Debug.Log("PAPER BEATS ROCK");
            }
        }    


    }

    private void OnCollisionEnter2D(Collision2D other){
        //Debug.Log("CRASH");
        
        Transform parent = other.gameObject.transform.parent;
        
        if (parent != null){
            if (parent.gameObject.name == "Walls"){
                transform.Rotate(0,0,180);
            }
        }        

    }
}

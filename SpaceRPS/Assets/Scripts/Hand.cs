using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Set player's movement speed.
    public float rotationSpeed = 90.0f; // Set layer's rotation speed.
    //public Sprite scissorSprite; //Resources.Load <Sprite> ("Sprites/scissor2_0");
    //public Sprite rockSprite;
    //public Sprite paperSprite;
    
    // Private variables
    private Rigidbody2D rb; 
    private float horizontalInput; 
    private SpriteRenderer spriteRenderer; 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PauseForSeconds(3f));
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
                spriteRenderer.sprite = other.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.name = "Scissor";
            }
            else if (opponent.gameObject.name == "Rock")
            {
                //Debug.Log("PAPER BEATS ROCK");
            }
        }else if (this.gameObject.name == "Rock"){
            if(opponent.gameObject.name == "Scissor")
            {
                //Debug.Log("ROCK BEATS SCISSOR");
            }
            if(opponent.gameObject.name == "Paper")
            {
                spriteRenderer.sprite = other.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.name = "Paper";
            }
        }else if (this.gameObject.name == "Scissor"){
            if(opponent.gameObject.name == "Rock")
            {
                spriteRenderer.sprite = other.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.name = "Rock";
            }
            if(opponent.gameObject.name == "Paper")
            {
                //Debug.Log("SCISSOR BEATS PAPER");
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
    
    IEnumerator PauseForSeconds(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}

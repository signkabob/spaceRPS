using UnityEngine;

public class Player : MonoBehaviour
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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        // transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);
        // transform.Rotate(Vector3.back * horizontalInput * rotationSpeed * Time.fixedDeltaTime);
    }

    void FixedUpdate(){
        // Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));     
        
        rb.linearVelocity = transform.up * moveSpeed;

        if (rb != null){
            float rotationAmount = -horizontalInput * rotationSpeed * Time.fixedDeltaTime;
            float newRotationZ = rb.rotation + rotationAmount;
            rb.MoveRotation(newRotationZ);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("TRIGGER");

        Transform parent = other.gameObject.transform.parent;
        
        if (parent != null){
            if (parent.gameObject.name == "Walls"){
                transform.Rotate(0,0,180);
            }
        }    


    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("CRASH");
        
        Transform parent = other.gameObject.transform.parent;
        
        if (parent != null){
            if (parent.gameObject.name == "Walls"){
                transform.Rotate(0,0,180);
            }
        }        

    }
}

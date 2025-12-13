using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Set player's movement speed.
    public float rotationSpeed = 90.0f; // Set layer's rotation speed.

    public string nextScene; 
    public string gameOverScene;
    
    // Private variables
    private Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private float horizontalInput; 
    private Transform parent;
    //private int parentSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        parent = this.gameObject.transform.parent;
        //parentSize = parent.childCount;
        StartCoroutine(PauseForSeconds(5f));
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        foreach (Transform child in parent)
        {
            if (child.name == "Paper")
            {
                return;
            }
        }
        Debug.Log("WIN");
        SceneManager.LoadScene(nextScene);


        

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
        
        GameObject opponent = other.gameObject;

        if (opponent.gameObject.name == "Left_Wall" || opponent.gameObject.name == "Right_Wall" || opponent.gameObject.name == "Bottom_Wall" || opponent.gameObject.name == "Top_Wall"){
            transform.Rotate(0,0,180);
        }else if (opponent.gameObject.name == "Rock")
        {
            SceneManager.LoadScene(gameOverScene);
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

    IEnumerator PauseForSeconds(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}

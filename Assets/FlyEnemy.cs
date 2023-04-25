using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField] string triggeringTag;
    public GameManagerScript gameManager;

    private float rotationSpeed;
    private GameObject player;
    bool right;
    bool left=true;
    // void Update()   
    // {
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     float verticalInput = Input.GetAxis("Vertical");

    //     Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
    //     float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
    //     movementDirection.Normalize();

    //     transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

    //     if (movementDirection != Vector2.zero)
    //     {
    //         Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
    //         transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    //     }
    // }
    
     void Start () {
     
        // player = GameObject.FindGameObjectWithTag("Player");
     }
     void Update () {
     
    //  if(player == null)
    //     return;
         if(!right)
         {
            this.StartCoroutine(MoveToRight());
         }
         
         else if(!left)
         {
             this.StartCoroutine(MoveToLeft());
         }
     }
     IEnumerator MoveToLeft (){
        transform.position = Vector2.MoveTowards(transform.position,  new Vector3 (transform.position.x - 23.0f, transform.position.y, transform.position.z) , speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        right = false;
        left =true;
     }
     IEnumerator MoveToRight (){
        transform.position = Vector2.MoveTowards(transform.position,  new Vector3 (transform.position.x+23.0f, transform.position.y, transform.position.z) , speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
         right = true;
         left =false;
     }
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            gameManager.restart();
        }
    }
}

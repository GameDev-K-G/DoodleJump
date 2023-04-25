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
    
     void Update () {
 
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

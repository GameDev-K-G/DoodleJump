using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public GameObject player;
    private int countPlatform=1;
    public int numberOfPlatforms=20;
    [SerializeField] string sceneName;
    public GameManagerScript gameManager;
    float StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos=transform.position.y;
    }
     // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < StartPos){
            Destroy(player.gameObject);
            gameManager.restart();
        }

        
    }
    private void OnTriggerEnter2D (Collider2D other){
        countPlatform++;
        if(countPlatform == numberOfPlatforms+2){
            SceneManager.LoadScene(sceneName);
        }
        Destroy(other.gameObject);

    }
   
}

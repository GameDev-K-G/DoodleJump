using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    // private GameObject myPlat;
    private int countPlatform=0;
    public GameManagerScript gameManager;
    public int numberOfPlatforms=20;
    [SerializeField] string sceneName;
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
    private void OnTriggerEnter2D (Collider2D collision){
        countPlatform++;
        if(countPlatform == numberOfPlatforms+2){
            SceneManager.LoadScene(sceneName);
        }
        Destroy(collision.gameObject);
        

    }
   
}

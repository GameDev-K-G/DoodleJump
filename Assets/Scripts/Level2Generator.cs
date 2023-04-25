using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Generator : MonoBehaviour {

	public GameObject platformPrefab;
	public int numberOfPlatforms = 10;
	public float levelWidth = 10f;
	public float minY = .2f;
	public float maxY = 1.5f;

	// Use this for initialization
	void Start () {
       float [] arr = new float[numberOfPlatforms+1];

		Vector3 spawnPosition = new Vector3();
       
        float temp;
        arr[0]=11.41f;
		for (int i = 1; i <= numberOfPlatforms; i++)
		{
            temp = Random.Range(-levelWidth, levelWidth);
            while (Mathf.Abs((temp - arr[i-1])) > 13.0 || Mathf.Abs((temp - arr[i-1])) < 10.0)
            {
                temp = Random.Range(-levelWidth, levelWidth);
            }
			spawnPosition.x = temp;
            arr[i]=spawnPosition.x;
			spawnPosition.y += Random.Range(minY, maxY);
			
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
        
	}

}
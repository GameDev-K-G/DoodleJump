using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Generator : MonoBehaviour {

	public GameObject platformPrefab;
	public GameObject EnemyPrefab;

	public int numberOfPlatforms = 10;
	public float levelWidth = 10f;
	public float minY = .2f;
	public float maxY = 1.5f;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		Vector3 spawnPosition = new Vector3();
		Vector3 enemySpawnPosition = new Vector3();
        float [] arrX = new float[numberOfPlatforms+1];
         float [] arrY = new float[numberOfPlatforms+1];
        arrX[0]=3.4f;
        arrY[0]=3.4f;
		for (int i = 1; i <= numberOfPlatforms; i++)
		{
            x = Random.Range(-levelWidth, levelWidth);
            y = Random.Range(minY, maxY);
            while (Mathf.Abs((x - arrX[i-1])) > 13.0 || Mathf.Abs((x - arrX[i-1])) < 10.0)
            {
                x = Random.Range(-levelWidth, levelWidth);
            }
			if(i % 2 == 0 && i != 0)
			{
                enemySpawnPosition.y += Random.Range(arrY[i-1]+3.0f, arrY[i-1]+9.0f);
                enemySpawnPosition.x =  Random.Range(arrX[i-1], x);
                Instantiate(EnemyPrefab, enemySpawnPosition, Quaternion.identity);
			}
			spawnPosition.y += y;
			spawnPosition.x = x;
            arrY[i]=spawnPosition.y;
            arrX[i]=spawnPosition.x;
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
        
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    private GameObject[] columns;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public int columnPoolSize = 5;
    public float columnMin=-1.8f;
    public float columnMax = 2.7f;
    private Vector2 objectPoolPosition = new Vector2(-15f, -35f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start () {

        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);

        }
	}
	
	// Update is called once per frame
	void Update () {

        timeSinceLastSpawned += Time.deltaTime;
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >=spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spwanYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn++].transform.position = new Vector2(spawnXPosition, spwanYPosition);
            
            if( currentColumn>=columnPoolSize)
            {
                currentColumn = 0;  
            }
        }
	}
}

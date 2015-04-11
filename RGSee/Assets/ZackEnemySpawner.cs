using UnityEngine;
using System.Collections;

public class ZackEnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    private GameObject player;
    private float timer = 0f;
    float spawnRate = 3f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            timer = 0f;
            float r = 3f;
            float x = Random.Range(-r, r), y = Random.Range(-r, r);
            Instantiate(enemyPrefab, player.transform.position + new Vector3(x,y,0), Quaternion.identity);
        }

	}
}

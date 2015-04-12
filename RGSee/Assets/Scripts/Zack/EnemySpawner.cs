using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    private float timer = 0f;
    float spawnRate = 1f;
    public bool spawnEnabled = true;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnabled)
        {
            timer += Time.deltaTime;
            if (timer > spawnRate)
            {
                timer = 0f;
                float r = 3f;
                float x = Random.Range(-r, r), y = Random.Range(-r, r);
                //Instantiate(enemyPrefab, player.transform.position + new Vector3(x, y, 0), Quaternion.identity);
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }
        }

    }
}

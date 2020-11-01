using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    public float min_Y = -4.3f;
    public float max_Y = 4.3f;

    public GameObject[] asteroid_Prefabs;
    public GameObject enemyPrefab;

    public float timer = 2f;

    private float reference_timer = 0f;
    private float reference_speed = 1f;
    private float timer_fase1 = 30f;
    private float timer_fase2 = 50f;
    private float timer_fase3 = 100f;
    private float timer_fase4 = 150f;


    // Start is called before the first frame update
    void Start(){
        Invoke("SpawnEnemies", timer);
    }

    // Update is called once per frame
    void Update(){
        reference_timer += reference_speed * Time.deltaTime;
    }

    void SpawnEnemies(){
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if (Random.Range(0, 2) > 0){
            Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)], temp, Quaternion.identity);
        }else {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
        }

        if (reference_timer > timer_fase1) timer = 1.5f;
        if (reference_timer > timer_fase2) timer = 1.0f;
        if (reference_timer > timer_fase3) timer = 0.5f;
        if (reference_timer > timer_fase4) timer = 0.3f;
        Invoke("SpawnEnemies", timer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour{

    public float speed = 5f;
    public float deactivate_Timer = 3f;

    public float bound_X = 10f;


    [HideInInspector]
    public bool is_EnemyBullet = false;

    // Start is called before the first frame update
    void Start(){
        if (is_EnemyBullet) {
            speed *= -1f;
            //Only for EnemyBullet
            Invoke("DeactivateGameObject", deactivate_Timer);
        }
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        

        if (temp.x > bound_X) {
            //Only for PlayerBullet
            DeactivateGameObject();
        }
        else {
            transform.position = temp;
        }
    }
    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D target){
        //if (target.tag == "Bullet" || target.tag == "Enemy") {
        if (target.tag == "Enemy") {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}

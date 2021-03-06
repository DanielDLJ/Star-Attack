﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    public float speed = 5f;
    public float rotate_Speed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_X = -11f;

    public Transform attack_Point;
    public GameObject bulletPrefab;


    private Animator animation;
    private AudioSource exposionSound;

    // Start is called before the first frame update
    void Start(){
        animation = GetComponent<Animator>();
        exposionSound = GetComponent<AudioSource>();
        if (canRotate){
            if (Random.Range(0, 2) > 0) {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }
        }
        if (canShoot) 
            Invoke("StartShooting", Random.Range(1f, 3f));

    }

    // Update is called once per frame
    void Update(){
        Move();
        RotateEnemy();
    }

    void Move(){
        if (canMove){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_X)
                gameObject.SetActive(false);
        }
    }

    void RotateEnemy(){
        if (canRotate){
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting() {
        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.Euler(0f, 0f, 90f));
        bullet.GetComponent<BulletScript>().is_EnemyBullet = true;
        if (canShoot) {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void TurnOffGameObject() {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    void TurnOffBoxCollider() {
        //already disabled canShoot // canShoot == false (already disabled) && canRotate == false (not asteroid)
        if ((canShoot == false && canRotate == false || canShoot == true) && GetComponent<BoxCollider2D>() != null) GetComponent<BoxCollider2D>().enabled = false;
        //asteroid
        if (canRotate) GetComponent<CircleCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D target){
        if (target.tag == "Bullet"){
            canMove = false;
            if (canShoot) {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject", 2.5f);
            Invoke("TurnOffBoxCollider", 0f);
            exposionSound.Play();
            animation.Play("Destroy");
        }
    }
}

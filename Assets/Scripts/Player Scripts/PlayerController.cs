using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float speed = 5f;
    public float min_Y, max_Y = 5f;
    public float min_X, max_X = 8.5f;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_Point;

    private float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    private AudioSource laserAudio;

    // Start is called before the first frame update
    void Start(){
        current_Attack_Timer = attack_Timer;
        laserAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        MovePlayer();
        Attack();
    }

    void MovePlayer(){

        //Y
        if(Input.GetAxisRaw("Vertical") > 0f){
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y) temp.y = max_Y;
            transform.position = temp;
        } else if (Input.GetAxisRaw("Vertical") < 0f){
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y) temp.y = min_Y;
            transform.position = temp;
        }

        //X
        if (Input.GetAxisRaw("Horizontal") > 0f) {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_X) temp.x = max_X;
            transform.position = temp;
        } else if (Input.GetAxisRaw("Horizontal") < 0f) {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_X) temp.x = min_X;
            transform.position = temp;
        }

    }

    void Attack(){
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer){
            canAttack = true;
        }


        if (Input.GetKeyDown(KeyCode.K)){
            if (canAttack){
                canAttack = false;
                attack_Timer = 0f;
                //Transform baseAmmoTransform = player_Bullet.GetComponentsInChildren<Transform>(true)[0];
                //Quaternion baseAmmoRotation = baseAmmoTransform.rotation;

                Instantiate(player_Bullet, attack_Point.position, Quaternion.Euler(0f, 0f, 90f));
                //Instantiate(player_Bullet, attack_Point.position, baseAmmoRotation);
                //Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);

                //Play Audio
                laserAudio.Play();
                
            }
        }
    }

}

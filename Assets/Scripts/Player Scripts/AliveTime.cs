using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AliveTime : MonoBehaviour
{

    private float timeAlive = 0f;
    private int minuteCount;
    private int hourCount;
    private Text textTimer;

    private bool count = true;
    // Start is called before the first frame update
    void Start() {
        textTimer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        //timeAlive += Time.deltaTime;
        //textTimer.text = "" + timeAlive;
        if(count) UpdateTimerUI();

    }

    public void UpdateTimerUI(){
        //set timer UI
        timeAlive += Time.deltaTime;
        textTimer.text = hourCount + "h:" + minuteCount + "m:" + (int)timeAlive + "s";
        if (timeAlive >= 60)
        {
            minuteCount++;
            timeAlive %= 60;
            if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount %= 60;
            }
        }
    }


    public void stropTimer(){
        count = false;
    }
}

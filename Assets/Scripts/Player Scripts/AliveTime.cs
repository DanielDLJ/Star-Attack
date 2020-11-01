using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AliveTime : MonoBehaviour
{

    private static float timeAlive = 0f;
    private static int minuteCount;
    private static int hourCount;
    //private Text textTimer;
    private TextMeshProUGUI textTimer;

    private static bool count = false;
    // Start is called before the first frame update
    void Start() {
        textTimer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() {
        //timeAlive += Time.deltaTime;
        //textTimer.text = "" + timeAlive;
        //Debug.Log(count);
        if (count) UpdateTimerUI();
        if (count == false) textTimer.text = hourCount + "h:" + minuteCount + "m:" + (int)timeAlive + "s";

    }

    public void UpdateTimerUI(){
        //set timer UI
        timeAlive += Time.deltaTime;
        textTimer.text = "" + hourCount + "h:" + minuteCount + "m:" + (int)timeAlive + "s";
        if (timeAlive >= 60) {
            minuteCount++;
            timeAlive %= 60;
            if (minuteCount >= 60) {
                hourCount++;
                minuteCount %= 60;
            }
        }
    }


    public void stropTimer(){
        count = false;
    }

    public void startTimer(){
        timeAlive = 0f;
        minuteCount = 0;
        hourCount = 0;
        count = true;
        Debug.Log("startTimer");
    }
}

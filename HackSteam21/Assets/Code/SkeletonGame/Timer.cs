using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 30f;
    public Text timerText;
    void Start()
    {
        
    }

    
    void Update()
    {
        totalTime -= Time.deltaTime;
        timerText.text = Mathf.Round(totalTime).ToString();

        if (totalTime<=0)
        {
            Time.timeScale = 0;
        }
    }
}

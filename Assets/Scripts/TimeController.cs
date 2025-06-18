using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float totalTimeSeconds = 600f;
    [SerializeField] private Text textTime;
    private float remainingTimeSeconds;
    [SerializeField]private bool timeIsOver = false;

    void Start()
    {
        remainingTimeSeconds = totalTimeSeconds;
        UpdateTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeIsOver)
        {
            remainingTimeSeconds -= Time.deltaTime;
            UpdateTime();
            if (remainingTimeSeconds <= 0)
            {
                remainingTimeSeconds = 0;
                timeIsOver = true;

            }


        }
        if (timeIsOver)
        {
            SceneManager.LoadScene(3);
        }
    }

    void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(remainingTimeSeconds / 60);
        int seconds = Mathf.FloorToInt(remainingTimeSeconds % 60);
        textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    void LoadGameOverScene()
    {
        //SceneManager.LoadScene(3);   
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_FinishPanel : MonoBehaviour
{
    public GameObject finishPanel; 
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        LevelController.Instance.Finish += FinishLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FinishLevel()
    {
        finishPanel.SetActive(true);
        timeText.text = LevelController.Instance.time;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    public Text levelInfo;

    // Start is called before the first frame update
    void Start()
    {
        levelInfo.text = "Level " + CheckLevel.levelId + " is loaded.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

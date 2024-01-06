using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelGenerator.Scripts;
using LevelGenerator.Scripts.Structure;
using System;

public class CheckLevel : MonoBehaviour
{
    public GameObject level;
    private GameObject obj;

    public LocalNavMeshBuilder localNavMeshBuilder;

    public static int corridors = 4;
    public static int rooms = 1;
    public static int treasures = 1;
    public static int levelId = 1;

    //private bool load = false;

    public int seed;
    public int level_id;

    // Start is called before the first frame update
    void Start()
    {
        obj = Instantiate(level, new Vector3(0.0f, 0.0f, 0.0f),
            Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
        LevelGenerator.Scripts.LevelGenerator levelGenerator = obj.GetComponent<LevelGenerator.Scripts.LevelGenerator>();
        System.Random random = new System.Random();
        levelGenerator.Seed = random.Next(int.MinValue, int.MaxValue);
        TagRule[] tagRules = levelGenerator.SpecialRules;
        foreach (TagRule rule in tagRules)
        {
            if (rule.Tag == "corridor")
            {
                rule.MinAmount = corridors - levelId;
                rule.MaxAmount = corridors;

            }
            else
            if (rule.Tag == "room")
            {
                rule.MinAmount = levelId;
                rule.MaxAmount = rooms;
            }
            else
            if (rule.Tag == "treasure")
            {
                rule.MinAmount = treasures;
                rule.MaxAmount = treasures;
            }
        }

        levelGenerator.MaxLevelSize = corridors + rooms + treasures + 1;
        levelGenerator.MaxAllowedOrder = levelGenerator.MaxLevelSize;
        //Debug.Log(levelGenerator.MaxLevelSize * 100.0f);
        //localNavMeshBuilder.m_Size = new Vector3(levelGenerator.MaxLevelSize * 100.0f, 40.0f, levelGenerator.MaxLevelSize * 100.0f);
        Debug.Log(levelId * 100.0f);
        localNavMeshBuilder.m_Size = new Vector3(levelId * 100.0f, 40.0f, levelId * 100.0f);
        Debug.Log("Level: " + levelId + "Seed: " + levelGenerator.Seed);
        level_id = levelId;
    }

    // Update is called once per frame
    void Update()
    {
        LevelGenerator.Scripts.LevelGenerator levelGenerator = obj.GetComponent<LevelGenerator.Scripts.LevelGenerator>();
        if (GameObject.Find("gracz") == null)
        {
            Debug.Log("Wrong seed: " + levelGenerator.Seed);
            Destroy(obj);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*if (!load)
        {
            
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLevel.levelId > 1 && level1_light.activeSelf == true)
        {
            level1_light.SetActive(false);
        }
    }

    public GameObject level1_light;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "gracz")
        {
            CheckLevel.corridors += 2;
            CheckLevel.rooms += 1;
            CheckLevel.treasures = CheckLevel.levelId / 7 + 1;
            CheckLevel.levelId++;
            CheckLevel.stairs = CheckLevel.levelId / 10 + 1;
            //NavMeshBake.surfaces.Clear();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

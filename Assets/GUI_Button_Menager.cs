using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Button_Menager : MonoBehaviour
{
    //For Menu scene
    public GameObject mainMenu;
    public GameObject control;
    public GameObject levelLoaded;
    
    // Start is called before the first frame update
    void Start()
    {
        control.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void EndGameClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NewGameClick()
    {
        CheckLevel.corridors = 4;
        CheckLevel.rooms = 1;
        CheckLevel.treasures = 1;
        CheckLevel.levelId = 1;
        SceneManager.LoadScene("Random_Level");
    }

    public void ControlClick()
    {
        control.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackToMenuClick()
    {
        control.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ConfirmClck()
    {
        Cursor.lockState = CursorLockMode.Locked;
        levelLoaded.SetActive(false);
    }
}

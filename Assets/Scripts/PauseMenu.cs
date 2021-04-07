using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool paused;

    public float sensitivity;

    public GameObject panel;

    public Slider sens;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
                panel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = false;
                panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }

        sensitivity = sens.value;
    }

    public void Retry()
    {
        CloseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {  
        paused = false;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void OpenMenu()
    {
        
    }

    void CloseMenu()
    {
        
    }
}

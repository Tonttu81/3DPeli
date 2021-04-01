using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance { get; private set; }

    bool fading = false;
    float alpha;

    public Image fade;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (alpha < 1f)
            {
                alpha += 1f * Time.deltaTime;
            }
        }
        else
        {
            if (alpha > 0)
            {
                alpha -= 1f * Time.deltaTime;
            }
        }

        fade.color = new Color(0, 0, 0, alpha);
    }

    public void LoadScene(int index) // GlobalScript.Instance.LoadScene("scenen buildindex");
    {
        fading = true;
        if (alpha > 1f)
        {
            SceneManager.LoadScene(index);
            alpha = 1f;
            fading = false;
        }   
    }
}

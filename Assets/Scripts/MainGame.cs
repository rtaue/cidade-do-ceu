using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {
    public GameObject MenuPanel;

    public bool forge, door, train, wire, lever, rock, wheel, load;
    private float actualTimeScale;

	// Use this for initialization
	void Start () {
        actualTimeScale = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () {
		if ((forge && wire && lever))
        {
            door = true;
        }
        else if (load && rock && wheel)
        {
            train = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0.1f)
            {
                Time.timeScale = 0;
                MenuPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = actualTimeScale;
                MenuPanel.SetActive(false);
            }
        }

    }

    public void Pause()
    {

        if (Time.timeScale > 0.1f)
        {

            Time.timeScale = 0;

        }
        
    }

    public void Play()
    {

        if (Time.timeScale == 0)
        {

            Time.timeScale = actualTimeScale;

        }

    }

    public void Reset()
    {
        Time.timeScale = actualTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Options()
    {

        if (Time.timeScale > 0.1f)
        {
            Time.timeScale = 0;
            MenuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = actualTimeScale;
            MenuPanel.SetActive(false);
        }

    }

    public void MainMenu()
    {
        Time.timeScale = actualTimeScale;
        SceneManager.LoadScene("Menu");

    }

    public void Settings()
    {

        

    }

    public void Quit()
    {

        Application.Quit();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void buttonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void store()
    {
        SceneManager.LoadScene(2);

    }

    public void quit()
    {
        Application.Quit();
    }
}

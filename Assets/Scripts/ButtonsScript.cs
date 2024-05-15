using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    public LoadingScreen loadingScreenObj;

    // FOR THE START BUTTON

    public void StartGame()
    {
        loadingScreenObj.GoToScene(1);
    }

    public void GoToTitle()
    {
        loadingScreenObj.GoToScene(0);
    }

    // FOR THE QUIT BUTTON

    public void Quit()
    {
        Application.Quit();
    }

}

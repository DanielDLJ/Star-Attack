using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static Stack<string> scenes = new Stack<string>();

    public void PlayGame() {
        //SceneManager.LoadScene(2);index
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadControlsMenu() {
        //SceneManager.LoadScene(1);index
        SceneManager.LoadScene("ControlsMenu");
    }

    public void LoadMenu() {
        Debug.Log("Menu");
        //SceneManager.LoadScene(0);index
        SceneManager.LoadScene("Menu");
    }
}

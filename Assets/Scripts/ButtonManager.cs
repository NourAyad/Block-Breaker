using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	void Start ()
    {
        Screen.SetResolution(730, 900, false);
	}
	
	public void NewGameBtn (string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void ExitGameBtn ()
    {
        Application.Quit();
    }
}

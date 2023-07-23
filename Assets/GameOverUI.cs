using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void Home()
    {
		SceneManager.LoadScene("MenuScene");
	}
	public void Quit()
	{
		Application.Quit();
	}
}

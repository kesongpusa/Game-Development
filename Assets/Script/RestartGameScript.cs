using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGameScript : MonoBehaviour
{
    public GameObject restartButton;
    public void RestartGame()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void ShowRestartButton()
    { restartButton.SetActive(true); }
}

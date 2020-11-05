using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    public GameObject inGame;
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        inGame.SetActive(true);
        gameObject.SetActive(false);
    }
}

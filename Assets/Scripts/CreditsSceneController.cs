using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSceneController : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    private bool screenLocked = true;
    void Start()
    {
        StartCoroutine(UnlockScreen());
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    IEnumerator UnlockScreen()
    {
        yield return new WaitForSeconds(5);
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
        screenLocked = false;
    }

    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return) && screenLocked == false)
        {
            SceneManager.LoadScene(0);
        }
    }
}

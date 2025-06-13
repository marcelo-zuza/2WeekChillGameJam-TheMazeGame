using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseInstructionsButton : MonoBehaviour
{
    [SerializeField] GameObject clickToStart;
    void Start()
    {
        StartCoroutine(ShowCloseInstructionsButton());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
        public void CloseInstructions()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator ShowCloseInstructionsButton()
    {
        yield return new WaitForSeconds(5);
        clickToStart.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainScreenController : MonoBehaviour
{
    [SerializeField] GameObject logoScreen;
    [SerializeField] float fadeSpeed = 5f;
    [SerializeField] float logoExibitionTime = 3f;


    private UnityEngine.UI.Button startButton;
    [SerializeField] float blocktime = 1f;
    public bool screenLocked = true;
    private bool isFading = false;

    void Start()
    {
        StartCoroutine(LockScreen());
        StartCoroutine(FaseStart());
    }

    void Update()
    {

    }

    IEnumerator LockScreen()
    {
        yield return new WaitForSeconds(blocktime);
        screenLocked = false;
    }

    IEnumerator FaseStart()
    {
        yield return new WaitForSeconds(logoExibitionTime);
        CanvasGroup canvasGroup = logoScreen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        isFading = true;
        while (isFading)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            if (canvasGroup.alpha <= 0)
            {
                isFading = false;
            }
            yield return null;
        }
        logoScreen.gameObject.SetActive(false);
    }


}

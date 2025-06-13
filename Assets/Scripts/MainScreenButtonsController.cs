using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenButtonsController : MonoBehaviour
{
    private MainScreenController mainScreenController;
    [SerializeField] GameObject mainScreenTitle;
    [SerializeField] GameObject instructions;
    void Start()
    {
        mainScreenController = GameObject.FindObjectOfType<MainScreenController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (mainScreenController.screenLocked == false)
        {
            mainScreenTitle.gameObject.SetActive(false);
            instructions.gameObject.SetActive(true);
        }
    }


}

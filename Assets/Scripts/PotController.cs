using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotController : MonoBehaviour
{
    private bool playerInRange;
    private PlayerController playerController;
    [SerializeField] private Button dontHaveItems;
    [SerializeField] private Button dontHaveBook;
    [SerializeField] private Button dontHavePotion;
    [SerializeField] private Button haveAllItems;
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.hasBook == true && playerController.hasPotion == true && playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            print("ALL DONE");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        if (other.tag == "Player")
        {
            if (playerController.hasBook == false && playerController.hasPotion == false)
            {
                dontHaveItems.gameObject.SetActive(true);
            }
            else if (playerController.hasBook == true && playerController.hasPotion == false)
            {
                dontHavePotion.gameObject.SetActive(true);
            }
            else if (playerController.hasBook == false && playerController.hasPotion == true)
            {
                dontHaveBook.gameObject.SetActive(true);
            }
            else if (playerController.hasBook == true && playerController.hasPotion == true)
            {
                haveAllItems.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        dontHaveItems.gameObject.SetActive(false);
        dontHavePotion.gameObject.SetActive(false);
        dontHaveBook.gameObject.SetActive(false);
        haveAllItems.gameObject.SetActive(false);
    }
}

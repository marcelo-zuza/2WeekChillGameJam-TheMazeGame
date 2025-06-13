using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionController : MonoBehaviour
{
    [SerializeField] private Button getPotionButton;
    private PlayerController playerController;
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            getPotionButton.gameObject.SetActive(false);
            if (gameObject.tag == "Potion")
            {
                playerController.hasPotion = true;
            }
            else if (gameObject.tag == "Book")
            {
                playerController.hasBook = true;
            }
                
                
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            getPotionButton.gameObject.SetActive(true);
            playerInRange = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            getPotionButton.gameObject.SetActive(false);
            playerInRange = false;
        }    
    }
}

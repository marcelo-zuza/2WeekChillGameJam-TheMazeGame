using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] public Transform playerCamera;
    [SerializeField] private float rotatinSpeed = 5f;
    [SerializeField] private RawImage potionIcon;
    [SerializeField] private RawImage bookIcon;


    private CharacterController playerController;
    private Vector3 velocity;
    private float xRotation = 0f;

    // Itens
    public bool hasPotion = false;
    public bool hasBook = false;

    // Steps
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> footstepsSounds;


    void Start()
    {
        playerController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
        ShowIcons();
        SoundOfSteps();

    }

    void FixedUpdate()
    {
        //MovePlayer();
    }

    void MovePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // player movement
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;
        playerController.Move(move * speed * Time.deltaTime);

        // gravity
        if (playerController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(RotatePlayer(rotatinSpeed));
        }
    }

    IEnumerator RotatePlayer(float rotationSpeed) // O nome da variável 'duration' no seu código original não é muito clara para a ideia de 'speed'. Mudei o parâmetro para 'rotationSpeed'
    {
        float startAngle = transform.eulerAngles.y; // Armazena o ângulo inicial
        float targetAngle = startAngle + 180f;
        float elapsedTime = 0f;

        while (elapsedTime < 1f) // O 'elapsedTime' deve ir de 0 a 1 para o Lerp funcionar corretamente
        {
            // Interpola entre o ângulo inicial e o ângulo alvo
            transform.rotation = Quaternion.Euler(0f, Mathf.Lerp(startAngle, targetAngle, elapsedTime), 0f);
            elapsedTime += Time.deltaTime * rotationSpeed; // Multiplica por 'rotationSpeed' para controlar a velocidade da rotação
            yield return null;
        }

        // Garante que o jogador termine exatamente no ângulo alvo
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    void ShowIcons()
    {
        if (hasPotion)
        {
            potionIcon.gameObject.SetActive(true);
        }

        if (hasBook)
        {
            bookIcon.gameObject.SetActive(true);
        }
    }

    void SoundOfSteps()
    {
        Vector3 horizontalVelocity = new Vector3(playerController.velocity.x, 0, playerController.velocity.z);
        if (horizontalVelocity.magnitude < 0.1f)
        {
            return;
        }
        int randomIndex = UnityEngine.Random.Range(0, footstepsSounds.Count);
        audioSource.PlayOneShot(footstepsSounds[randomIndex]);
    }


}

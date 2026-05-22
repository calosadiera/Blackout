using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GeneratorSystem : MonoBehaviour
{
    [Header("Pengaturan")]
    public float activationTime = 2f;
    public float interactRadius = 2f;

    [Header("Scene Selanjutnya")]
    public string nextSceneName;

    [Header("Referensi")]
    public Transform player;
    public GameObject progressBarUI;
    public Image progressBarFill;
    public DoorController door;
    public TextMeshProUGUI interactPromptText; // ganti dari GameObject

    private float holdTimer = 0f;
    private bool isActivated = false;

    void Update()
    {
        if (isActivated) return;

        float distance = Vector2.Distance(transform.position, player.position);
        bool isInRange = distance <= interactRadius;

        // Tampilkan/sembunyikan prompt
        interactPromptText.gameObject.SetActive(isInRange);

        if (isInRange && Input.GetKey(KeyCode.E))
        {
            // Tahan E → naikkan timer
            holdTimer += Time.deltaTime;
            progressBarUI.SetActive(true);
            progressBarFill.fillAmount = holdTimer / activationTime;

            if (holdTimer >= activationTime)
                ActivateGenerator();
        }
        else
        {
            // Lepas E → reset timer
            holdTimer = 0f;
            progressBarUI.SetActive(false);
        }
    }

    void ActivateGenerator()
    {
        isActivated = true;
        holdTimer = 0f;
        progressBarUI.SetActive(false);
        interactPromptText.gameObject.SetActive(false);

        // Buka pintu
        door.OpenDoor();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
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
    public TextMeshProUGUI interactPromptText;

    private float holdTimer = 0f;
    private bool isActivated = false;

    void Update()
    {
        if (isActivated) return;

        float distance = Vector2.Distance(transform.position, player.position);
        bool isInRange = distance <= interactRadius;

        interactPromptText.gameObject.SetActive(isInRange);

        if (isInRange && Input.GetKey(KeyCode.E))
        {
            holdTimer += Time.deltaTime;
            progressBarUI.SetActive(true);
            progressBarFill.fillAmount = holdTimer / activationTime;

            if (holdTimer >= activationTime)
                ActivateGenerator();
        }
        else
        {
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

        door.OpenDoor();

        LevelManager.Instance.generatorActivated = true;
    }

    public void SetActivated(bool activated)
    {
        isActivated = activated;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
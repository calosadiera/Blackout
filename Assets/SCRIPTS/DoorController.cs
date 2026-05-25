using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [Header("Pengaturan")]
    public string nextSceneName;
    public GameObject doorSprite;

    private bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = true;
        if (doorSprite != null)
            doorSprite.SetActive(true);
    }

    // Tambah fungsi ini untuk dipanggil saat Load
    public void SetDoorState(bool open)
    {
        isOpen = open;
        if (doorSprite != null)
            doorSprite.SetActive(open);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
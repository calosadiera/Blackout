using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [Header("Pengaturan")]
    public string nextSceneName;
    public GameObject doorSprite; // sprite pintu yang akan disembunyikan

    private bool isOpen = false;

    // Dipanggil dari GeneratorSystem saat generator aktif
    public void OpenDoor()
    {
        isOpen = true;
        if (doorSprite != null)
            doorSprite.SetActive(true); // sembunyikan sprite pintunya
    }

    // Saat player masuk trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
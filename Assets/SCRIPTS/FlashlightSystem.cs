using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashlightSystem : MonoBehaviour
{
    [Header("Referensi Light 2D")]
    public Light2D spotLight;

    [Header("Pengaturan Senter")]
    public float spotIntensity = 1.2f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        spotLight.intensity = spotIntensity;
    }

    void Update()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorld - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spotLight.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
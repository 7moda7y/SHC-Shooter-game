using UnityEngine;

public class looking : MonoBehaviour
{
    public float mousespeed = 100f;
    public Transform player;
    float xrotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);

        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);

    }
}

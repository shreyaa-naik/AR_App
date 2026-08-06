using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotationSpeed = 15f;
    private bool isAutoRotating = false;

    void Update()
    {
        if (isAutoRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void ToggleAutoRotate()
    {
        isAutoRotating = !isAutoRotating;
        Debug.Log(isAutoRotating ? "🌀 Auto-rotation ON" : "🌀 Auto-rotation OFF");
    }
}
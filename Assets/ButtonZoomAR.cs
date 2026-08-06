using UnityEngine;

public class ButtonZoomAR : MonoBehaviour
{
    [Header("Assign your Temple model container here")]
    public Transform target;

    [Header("Zoom Settings")]
    public float zoomStep = 0.2f;
    public float minScale = 0.1f;
    public float maxScale = 3f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 30f; // Your custom rotation speed (degrees per click)

    [Header("Vertical Rotation Settings")]
    public float verticalRotationStep = 15f; // degrees per click up/down
    private float currentVerticalRotation = 0f;
    private float maxVerticalRotation = 80f; // limit to prevent flipping

    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Vector3 initialPosition;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("❌ Target not assigned in ButtonZoomAR!");
            return;
        }

        // Save the starting transform values
        initialScale = target.localScale;
        initialRotation = target.localRotation;
        initialPosition = target.localPosition;

        Debug.Log("✅ ButtonZoomAR initialized");
    }

    // ------------------ ZOOM ------------------

    public void ZoomIn()
    {
        Debug.Log("🔍 Zoom In clicked");
        if (target == null) return;

        Vector3 newScale = target.localScale + Vector3.one * zoomStep;
        target.localScale = ClampScale(newScale);
    }

    public void ZoomOut()
    {
        Debug.Log("🔍 Zoom Out clicked");
        if (target == null) return;

        Vector3 newScale = target.localScale - Vector3.one * zoomStep;
        target.localScale = ClampScale(newScale);
    }

    private Vector3 ClampScale(Vector3 scale)
    {
        scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
        scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
        scale.z = Mathf.Clamp(scale.z, minScale, maxScale);
        return scale;
    }

    // ------------------ ROTATION (Your version integrated) ------------------

    public void RotateLeft()
    {
        Debug.Log("⟲ Rotate Left clicked");
        if (target == null) return;

        target.Rotate(Vector3.up, -rotationSpeed );
    }

    public void RotateRight()
    {
        Debug.Log("⟳ Rotate Right clicked");
        if (target == null) return;

        target.Rotate(Vector3.up, rotationSpeed );
    }

    // ------------------ VERTICAL VIEW CHANGE ------------------

    public void MoveUp()  // tilt camera up → see front / back
    {
        Debug.Log("⬆ Move Up clicked");
        if (target == null) return;

        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation - verticalRotationStep, -maxVerticalRotation, maxVerticalRotation);
        target.rotation = Quaternion.Euler(currentVerticalRotation, target.rotation.eulerAngles.y, 0);
    }

    public void MoveDown()  // tilt camera down → see top view again
    {
        Debug.Log("⬇ Move Down clicked");
        if (target == null) return;

        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation + verticalRotationStep, -maxVerticalRotation, maxVerticalRotation);
        target.rotation = Quaternion.Euler(currentVerticalRotation, target.rotation.eulerAngles.y, 0);
    }

    // ------------------ RESET ------------------

    public void ResetTransform()
    {
        Debug.Log("🔄 Reset clicked");
        if (target == null) return;

        target.localScale = initialScale;
        target.localRotation = initialRotation;
        target.localPosition = initialPosition;
        currentVerticalRotation = 0f;
    }
}
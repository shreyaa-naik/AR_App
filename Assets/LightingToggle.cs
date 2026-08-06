using UnityEngine;

public class LightingToggle : MonoBehaviour
{
    [Header("Assign the light you want to toggle")]
    public Light targetLight;

    private bool isLightOn = true;

    public void ToggleLight()
    {
        if (targetLight == null)
        {
            Debug.LogError("❌ No light assigned in LightingToggle script!");
            return;
        }

        isLightOn = !isLightOn;
        targetLight.enabled = isLightOn;

        Debug.Log(isLightOn ? "💡 Light turned ON" : "🌙 Light turned OFF");
    }
}
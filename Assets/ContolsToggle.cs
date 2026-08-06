using UnityEngine;

public class ControlsToggle : MonoBehaviour
{
    public GameObject controlsPanel;
    private bool isVisible = false;

    public void ToggleControls()
    {
        isVisible = !isVisible;
        controlsPanel.SetActive(isVisible);
    }
}
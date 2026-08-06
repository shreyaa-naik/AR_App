using UnityEngine;

public class OpenInMaps : MonoBehaviour
{
    [Header("Temple Location (Latitude, Longitude)")]
    public string latitude = "13.467649";  // example Barkur location
    public string longitude = "74.750995";

    public void OpenTempleLocation()
    {
        string url = $"https://www.google.com/maps?q={latitude},{longitude}";
        Application.OpenURL(url);
        Debug.Log("📍 Opening Temple in Google Maps");
    }
}
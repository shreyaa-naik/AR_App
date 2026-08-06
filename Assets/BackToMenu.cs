using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // MUST be public
    public void GoBack()
    {
        SceneManager.LoadScene("HomeMenu"); // exact scene name
    }
}
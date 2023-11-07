using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PlayAgain : MonoBehaviour
{
    public void OnPlayAgainClick()
    {
        Debug.Log("Play Again button clicked");
        SceneManager.LoadScene("SampleScene"); // Load the main game scene to restart
    }
}

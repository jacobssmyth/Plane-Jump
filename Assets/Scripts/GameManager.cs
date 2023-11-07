using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class GameManager : MonoBehaviour
{
    
    private static float finalDistanceTraveled = 0.0f;
    public void GameOver(float distanceTraveled)
    {
        if (distanceTraveled > PlayerPrefs.GetFloat("HighScore", 0))
        {
            // Save the new high score
            PlayerPrefs.SetFloat("HighScore", distanceTraveled);
        }

        finalDistanceTraveled = distanceTraveled;
        SceneManager.LoadScene("GameOver");
    }
    public float GetFinalDistanceTraveled()
    {
        Debug.Log("return " + finalDistanceTraveled);
        return finalDistanceTraveled;
    }
}

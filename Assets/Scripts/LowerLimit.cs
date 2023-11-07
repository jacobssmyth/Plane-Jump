using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class LowerLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plane"))
        {
            Debug.Log("Limit Hit");
            PlaneMovement planeMovement = other.GetComponent<PlaneMovement>();
            
            planeMovement.PlayerDied();
           // SceneManager.LoadScene("GameOver"); // Load the game over scene
        }
    }
}
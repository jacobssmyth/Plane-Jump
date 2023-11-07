using UnityEngine;
using TMPro;

public class DistanceTraveledOver : MonoBehaviour
{
    public TextMeshProUGUI distanceText;

    private void Start()
    {
        
        GameManager gameManager = FindObjectOfType<GameManager>();
      
        float finalDistanceTraveled = gameManager.GetFinalDistanceTraveled();
        distanceText.text = "Distance Traveled: " + finalDistanceTraveled.ToString("F0") + " m";
    
    }
}

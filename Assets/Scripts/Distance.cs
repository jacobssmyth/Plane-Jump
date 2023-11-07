using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public PlaneMovement planeMovement;

    private void Start()
    {
        planeMovement = FindObjectOfType<PlaneMovement>();
    }

    private void Update()
    {
        distanceText.text = "Distance: " + planeMovement.GetDistanceTraveled().ToString("F0") + " m";
    }
}
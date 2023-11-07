using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float flapForce = 5.0f;
    public float maxTiltAngle = 45.0f;
    public float fallTiltAngle = 30.0f; // Angle when the plane is falling
    public float tiltSpeed = 5.0f;
    public float gravity = 9.8f;
    public float flapCooldown = 0.5f; // Cooldown period between flaps

    private Rigidbody2D rb;
    private bool canFlap = true;
    private float planeSpeed = 5.0f;
    private float distanceTraveled = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        distanceTraveled += planeSpeed * Time.deltaTime;
        
        if (canFlap && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FlapCooldown());
            rb.velocity = new Vector2(rb.velocity.x, flapForce);
        }

        if (!canFlap)
        {
            rb.velocity += Vector2.down * gravity * Time.deltaTime;
        }

        // Calculate the target tilt angle based on velocity
        float targetTiltAngle = Mathf.Lerp(
            -fallTiltAngle,
            maxTiltAngle,
            Mathf.InverseLerp(-flapForce, flapForce, rb.velocity.y)
        );

        Quaternion targetTiltRotation = Quaternion.Euler(0, 0, targetTiltAngle);

        // Apply smooth rotation to the plane
        transform.rotation = Quaternion.Slerp(transform.rotation, targetTiltRotation, tiltSpeed * Time.deltaTime);
    }

    private IEnumerator FlapCooldown()
    {
        canFlap = false;
        yield return new WaitForSeconds(flapCooldown);
        canFlap = true;
    }
    public void PlayerDied()
    {
        Debug.Log("Player died");
        GameManager gameManager = FindObjectOfType<GameManager>();
        Debug.Log("died + " + distanceTraveled);
        gameManager.GameOver(distanceTraveled);

        // Any other game over logic...
    }
    public float GetDistanceTraveled()
    {
        
        return distanceTraveled;
    }
}

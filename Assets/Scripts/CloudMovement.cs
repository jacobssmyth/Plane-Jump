using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

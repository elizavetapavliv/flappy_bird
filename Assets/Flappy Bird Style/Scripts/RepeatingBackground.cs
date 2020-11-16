using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            transform.position += new Vector3(groundHorizontalLength * 2f, 0, 0);
        }
    }
}
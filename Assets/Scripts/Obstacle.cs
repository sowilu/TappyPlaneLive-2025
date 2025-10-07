using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float speed = 3;

    public float xOffset = 2;
    public float yOffset = 2;
    
    
    void Start()
    {
        Vector3 offset = new();
        offset.x += Random.Range(-xOffset, xOffset);
        offset.y += Random.Range(-yOffset, yOffset);
        
        transform.position += offset;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}

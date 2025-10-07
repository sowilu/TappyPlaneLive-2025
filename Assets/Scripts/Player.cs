using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float jumpForce = 10;
    
    private int score = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        //get component from the same game object script is on
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Point"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}

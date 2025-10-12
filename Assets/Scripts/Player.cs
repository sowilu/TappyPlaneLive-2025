using System;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public ScoreBoard scoreBoard;
    public GameObject spawner;
    public TextMeshProUGUI scoreText;
    public float jumpForce = 10;
    
    [Header("Sound effects")]
    public AudioClip jumpSound;
    public AudioClip deathSound;
    
    private int score = 0;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private void Start()
    {
        //get component from the same game object script is on
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        scoreBoard.ShowScore(score);
        audioSource.PlayOneShot(deathSound);
        spawner.SetActive(false); //disable
        Destroy(this); //remove player script
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The force applied to move the player.
    /// </summary>
    public float moveForce;

    /// <summary>
    /// The force applied to make the player jump.
    /// </summary>
    public float jumpForce;

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float playerMovement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(playerMovement * moveForce, rb.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Origen: transform.position (posición del jugador)
        // Dirección: Vector2.down (hacia abajo)
        // Distancia: 1.0f (distancia del raycast)
        // Capa: groundLayer (capa del suelo)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer);
        
        return hit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Debug.Log("Tas morio.");
            //Time.timeScale = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
}

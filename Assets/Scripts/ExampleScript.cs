using UnityEngine;

/// <summary>
/// Example script for Academia 42 Unity Workshop
/// This script demonstrates basic Unity scripting concepts
/// </summary>
public class ExampleScript : MonoBehaviour
{
    // Public variables that can be modified in the Unity Inspector
    public float moveSpeed = 5f;
    public string playerName = "Player";
    
    // Private variables
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bienvenido al Taller de Unity - Academia 42!");
        Debug.Log($"Nombre del jugador: {playerName}");
    }
    
    // Update is called once per frame
    void Update()
    {
        // Update timer
        timer += Time.deltaTime;
        
        // Example: Basic movement using arrow keys or WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
        
        // Example: Simple action on space bar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"¡Espacio presionado! Tiempo transcurrido: {timer:F2} segundos");
        }
    }
}

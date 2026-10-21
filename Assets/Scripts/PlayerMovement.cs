using UnityEngine; // Importa las funcionalidades principales de Unity

// Clase que controla el movimiento del jugador
public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento de la nave (ajustable desde el Inspector)
    public float speed = 5f;

    // Referencia al componente Rigidbody2D del jugador
    private Rigidbody2D rb;

    // Variable que almacena la dirección de movimiento en cada frame
    private Vector2 movement;

    // Prefab de la explosión
    public GameObject explosionPrefab;

    // Sonido de daño
    public AudioSource audioSource;

    // Método Start: se ejecuta una vez al iniciar el objeto
    void Start()
    {
        // Obtiene el componente Rigidbody2D que está adjunto al mismo GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Método Update: se ejecuta en cada frame (ideal para leer inputs)
    void Update()
    {
        // Obtiene el valor del eje horizontal (A/D o flechas izquierda/derecha)
        float moveX = Input.GetAxis("Horizontal");

        // Obtiene el valor del eje vertical (W/S o flechas arriba/abajo)
        float moveY = Input.GetAxis("Vertical");

        // Crea un vector con la dirección del movimiento basado en el input
        movement = new Vector2(moveX, moveY);
    }

    // Método FixedUpdate: se ejecuta a intervalos fijos (ideal para física)
    void FixedUpdate()
    {
        // Mueve el Rigidbody2D usando su posición actual + dirección * velocidad * tiempo fijo
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    // Pierde una vida al tocar el muro de los lados o inferior
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si toca un muro
        if (other.CompareTag("Muro"))
        {
            // Perder vida
            GameManager.instance.LoseLife();

            // Crear explosión en la posición del jugador
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Reproducir sonido
            audioSource.Play();
        }
    }
}


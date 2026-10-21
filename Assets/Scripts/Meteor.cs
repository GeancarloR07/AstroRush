using UnityEngine; // Importa las funcionalidades principales de Unity

// Clase que controla el comportamiento del meteorito
public class Meteor : MonoBehaviour
{
    // Velocidad de desplazamiento del meteorito
    public float speed = 3f;

    // Referencia al componente AudioSource para reproducir sonido
    AudioSource audioSource;

    // Prefab de la explosión que se generará al colisionar
    public GameObject explosionPrefab;

    // Método Update: se ejecuta en cada frame
    void Update()
    {
        // Mueve el meteorito hacia abajo en el eje Y
        // Vector2.down equivale a (0, -1)
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Obtiene el componente AudioSource del objeto
        // (Nota: esto se está llamando cada frame, lo cual no es óptimo pero se mantiene igual)
        audioSource = GetComponent<AudioSource>();

        // Verifica si el meteorito ha salido de la pantalla (por debajo del límite Y)
        if (transform.position.y < -6)
        {
            // Destruye el meteorito para liberar memoria
            Destroy(gameObject);
        }
    }

    // Método que detecta colisiones con otros colliders configurados como trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Notifica al GameManager que el jugador pierde una vida
            GameManager.instance.LoseLife();

            // Instancia (crea) una explosión en la posición actual del meteorito
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Reproduce el sonido del meteorito
            audioSource.Play();

            // Destruye el meteorito después de 0.2 segundos (permite reproducir el sonido)
            Destroy(gameObject, 0.2f);
        }
    }
}
using UnityEngine; // Importa el espacio de nombres principal de Unity

// Clase pública llamada Battery que hereda de MonoBehaviour (necesario para scripts en Unity)
public class Battery : MonoBehaviour
{
    // Referencia al componente AudioSource para reproducir sonido
    AudioSource audioSource;

    // Variable pública que define los puntos que otorga la batería al jugador
    public int points = 10;

    // Variable pública que define el tiempo máximo (en segundos) antes de que la batería desaparezca automáticamente
    public float lifeTime = 6f;

    // Método Start: se ejecuta automáticamente una vez cuando el objeto se instancia en la escena
    void Start()
    {
        // Destruye el objeto (la batería) después de "lifeTime" segundos
        Destroy(gameObject, lifeTime);

        // Obtiene el componente AudioSource que está adjunto al mismo objeto
        audioSource = GetComponent<AudioSource>();
    }

    // Método que se ejecuta cuando otro collider entra en el trigger de este objeto (requiere que el collider sea "Is Trigger")
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Llama al GameManager para añadir puntos al jugador
            GameManager.instance.AddPoints(points);

            // Reproduce el sonido asociado a la batería
            audioSource.Play();

            // Destruye el objeto después de 0.2 segundos (da tiempo a que el sonido se reproduzca)
            Destroy(gameObject, 0.2f);
        }
    }
}
using UnityEngine; // Importa funcionalidades principales de Unity
using TMPro; // Importa TextMeshPro para manejar textos en UI
using UnityEngine.SceneManagement; // Permite gestionar escenas (reiniciar, cargar, etc.)

// Clase principal que gestiona el estado del juego
public class GameManager : MonoBehaviour
{
    // Instancia estática para acceder al GameManager desde otros scripts (patrón Singleton)
    public static GameManager instance;

    // Variable que almacena el puntaje actual del jugador
    public int score = 0;

    // Variable que almacena las vidas actuales del jugador
    public int lives = 3;

    // Referencia al texto UI que muestra el puntaje
    public TextMeshProUGUI scoreText;

    // Referencia al texto UI que muestra las vidas
    public TextMeshProUGUI livesText;

    // Contador de baterías recolectadas
    public int batteriesCollected = 0;

    // Referencia al panel de Game Over en la UI
    public GameObject gameOverPanel;

    // Método Awake: se ejecuta antes de Start, ideal para inicializaciones críticas
    private void Awake()
    {
        // Asigna esta instancia al singleton para acceso global
        instance = this;
    }

    // Método Start: se ejecuta al iniciar el juego
    void Start()
    {
        // Actualiza la interfaz con los valores iniciales
        UpdateScoreUI();
        UpdateLivesUI();
    }

    // Método público para añadir puntos al jugador
    public void AddPoints(int amount)
    {
        // Suma los puntos recibidos al score total
        score += amount;

        // Cada batería recogida incrementa este contador
        batteriesCollected++;

        // Cada 15 baterías recolectadas se otorga una vida extra
        if (batteriesCollected % 15 == 0)
        {
            AddLife();
        }

        // Actualiza la UI del puntaje
        UpdateScoreUI();
    }

    // Método privado para añadir una vida al jugador
    void AddLife()
    {
        // Se limita el máximo de vidas a 3
        if (lives < 3)
        {
            lives++; // Incrementa las vidas
            UpdateLivesUI(); // Actualiza la UI
        }
    }

    // Método público que se llama cuando el jugador pierde una vida
    public void LoseLife()
    {
        lives--; // Reduce una vida

        UpdateLivesUI(); // Actualiza la UI

        // Si las vidas llegan a 0 o menos, se termina el juego
        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Método que actualiza el texto del puntaje en pantalla
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Método que actualiza el texto de vidas en pantalla
    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }

    // Método que se ejecuta cuando el jugador pierde todas las vidas
    void GameOver()
    {
        // Activa el panel de Game Over
        gameOverPanel.SetActive(true);

        // Detiene el tiempo del juego (pausa total)
        Time.timeScale = 0f;
    }

    // Método público para reiniciar el juego
    public void RestartGame()
    {
        // Restaura el tiempo a normal
        Time.timeScale = 1f;

        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
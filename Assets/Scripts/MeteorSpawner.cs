using UnityEngine; // Importa las funcionalidades principales de Unity

// Clase encargada de generar meteoritos y aumentar la dificultad progresivamente
public class MeteorSpawner : MonoBehaviour
{
    // Prefab del meteorito que se va a instanciar
    public GameObject meteorPrefab;

    // Tiempo inicial entre cada aparición de meteoritos
    public float spawnRate = 2f;

    // Rango horizontal donde pueden aparecer los meteoritos
    public float xRange = 8f;

    // Posición fija en el eje Y donde se generan (parte superior de la pantalla)
    public float spawnY = 6f;

    // Factor por el cual se reduce el tiempo de aparición (aumenta dificultad)
    public float difficultyIncrease = 0.95f;

    // Método Start: se ejecuta una vez al iniciar el objeto
    void Start()
    {
        // Llama repetidamente al método "SpawnMeteor"
        // Empieza después de 2 segundos y luego se repite cada "spawnRate" segundos
        InvokeRepeating("SpawnMeteor", 2f, spawnRate);

        // Llama repetidamente al método "IncreaseDifficulty"
        // Empieza después de 10 segundos y se repite cada 10 segundos
        InvokeRepeating("IncreaseDifficulty", 10f, 10f);
    }

    // Método que aumenta la dificultad del juego
    void IncreaseDifficulty()
    {
        // Reduce el tiempo entre spawns (los meteoritos aparecerán más rápido)
        spawnRate *= difficultyIncrease;

        // Cancela la invocación actual de SpawnMeteor
        CancelInvoke("SpawnMeteor");

        // Reinicia la invocación con el nuevo spawnRate
        // 0f significa que empieza inmediatamente
        InvokeRepeating("SpawnMeteor", 0f, spawnRate);
    }

    // Método encargado de generar un meteorito
    void SpawnMeteor()
    {
        // Genera una posición aleatoria en el eje X dentro del rango definido
        float randomX = Random.Range(-xRange, xRange);

        // Crea la posición final donde aparecerá el meteorito
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        // Instancia (crea) el meteorito en la posición definida sin rotación
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}
using UnityEngine; // Importa las funcionalidades principales de Unity

// Clase encargada de generar (spawnear) baterías en el juego
public class BatterySpawner : MonoBehaviour
{
    // Prefab de la batería que se va a instanciar en la escena
    public GameObject batteryPrefab;

    // Tiempo en segundos entre cada aparición de una batería
    public float spawnTime = 3f;

    // Rango máximo en el eje X donde pueden aparecer las baterías
    public float xRange = 8f;

    // Rango máximo en el eje Y donde pueden aparecer las baterías
    public float yRange = 4f;

    // Método Start: se ejecuta una vez al iniciar el objeto
    void Start()
    {
        // Llama repetidamente al método "SpawnBattery"
        // Primer parámetro: nombre del método como string
        // Segundo parámetro: tiempo de espera antes de la primera ejecución (1 segundo)
        // Tercer parámetro: intervalo de repetición (cada "spawnTime" segundos)
        InvokeRepeating("SpawnBattery", 1f, spawnTime);
    }

    // Método que se encarga de generar una batería en una posición aleatoria
    void SpawnBattery()
    {
        // Genera una posición aleatoria en el eje X dentro del rango definido
        float randomX = Random.Range(-xRange, xRange);

        // Genera una posición aleatoria en el eje Y dentro del rango definido
        float randomY = Random.Range(-yRange, yRange);

        // Crea un vector con la posición aleatoria generada
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Instancia (crea) una nueva batería en la posición generada
        // Quaternion.identity significa que no tendrá rotación
        Instantiate(batteryPrefab, spawnPosition, Quaternion.identity);
    }
}
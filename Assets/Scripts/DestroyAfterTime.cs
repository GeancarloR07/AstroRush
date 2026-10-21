using UnityEngine; // Importa las funcionalidades principales de Unity

// Clase encargada de destruir automáticamente un objeto después de un tiempo
public class DestroyAfterTime : MonoBehaviour
{
    // Tiempo en segundos antes de destruir el objeto (configurable desde el Inspector)
    public float destroyTime = 1f;

    // Método Start: se ejecuta una vez al iniciar el objeto
    void Start()
    {
        // Destruye el GameObject al que está adjunto este script después de "destroyTime" segundos
        Destroy(gameObject, destroyTime);
    }
}
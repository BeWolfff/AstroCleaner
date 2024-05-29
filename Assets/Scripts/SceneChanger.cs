using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject Music;
    public float delay = 80f; // Délai en secondes
    public string sceneName = "SampleScene"; // Nom de la scène à charger

    private float elapsedTime = 0f; // Temps écoulé depuis le début

    void Update()
    {
        // Incrémente le temps écoulé
        elapsedTime += Time.deltaTime;

        // Vérifie si le délai est écoulé ou si la touche Échap est enfoncée
        if (elapsedTime >= delay || Input.GetKeyDown(KeyCode.Escape))
        {
            // Change de scène
            SceneManager.LoadScene(sceneName);
            Destroy(Music);
        }
    }
}
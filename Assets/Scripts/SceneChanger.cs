using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject Music;
    public float delay = 80f; // D�lai en secondes
    public string sceneName = "SampleScene"; // Nom de la sc�ne � charger

    private float elapsedTime = 0f; // Temps �coul� depuis le d�but

    void Update()
    {
        // Incr�mente le temps �coul�
        elapsedTime += Time.deltaTime;

        // V�rifie si le d�lai est �coul� ou si la touche �chap est enfonc�e
        if (elapsedTime >= delay || Input.GetKeyDown(KeyCode.Escape))
        {
            // Change de sc�ne
            SceneManager.LoadScene(sceneName);
            Destroy(Music);
        }
    }
}
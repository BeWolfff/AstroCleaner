using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed = 20f;
    public GameObject Music;
    private Rigidbody rb;
    private bool isMoving = false;
  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Rotation de la fusée vers la droite avec la touche droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Tourne la fusée autour de son axe horizontal (Z) vers la droite
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Rotation de la fusée vers la gauche avec la touche gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Tourne la fusée autour de son axe horizontal (Z) vers la gauche
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        // Rotation de la fusée vers le haut avec la touche haut
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Tourne la fusée autour de son axe horizontal (X) vers la droite
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }

        // Rotation de la fusée vers le bas avec la touche Bas
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Tourne la fusée autour de son axe horizontal (X) vers la gauche
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }

        // Vérifie si la barre d'espace est enfoncée et que le mouvement n'a pas encore commencé
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if (!isMoving)
            {
                isMoving = true;
            }
           else
            {
                isMoving = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.A)){
            Destroy(Music);
        }


        // Si le mouvement a commencé, déplace l'objet vers le haut à la vitesse spécifiée
        if (isMoving)
        {
            // Déplace l'objet dans la direction "vers le haut" (axe Y positif)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

         
        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Niveau 1"))
        {
            SceneManager.LoadScene("lvl1");
        }
        if (collision.gameObject.CompareTag("Niveau 2"))
        {
            SceneManager.LoadScene("lvl2");
        }
        if (collision.gameObject.CompareTag("Niveau 3"))
        {
            SceneManager.LoadScene("lvl3");
        }
    }
}
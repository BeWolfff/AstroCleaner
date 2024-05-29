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
        // Rotation de la fus�e vers la droite avec la touche droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Tourne la fus�e autour de son axe horizontal (Z) vers la droite
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Rotation de la fus�e vers la gauche avec la touche gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Tourne la fus�e autour de son axe horizontal (Z) vers la gauche
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        // Rotation de la fus�e vers le haut avec la touche haut
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Tourne la fus�e autour de son axe horizontal (X) vers la droite
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }

        // Rotation de la fus�e vers le bas avec la touche Bas
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Tourne la fus�e autour de son axe horizontal (X) vers la gauche
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }

        // V�rifie si la barre d'espace est enfonc�e et que le mouvement n'a pas encore commenc�
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


        // Si le mouvement a commenc�, d�place l'objet vers le haut � la vitesse sp�cifi�e
        if (isMoving)
        {
            // D�place l'objet dans la direction "vers le haut" (axe Y positif)
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
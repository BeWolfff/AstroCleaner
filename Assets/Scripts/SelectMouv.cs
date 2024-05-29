using UnityEngine;

public class SelectMouv : MonoBehaviour
{
    public float moveSpeed = 20f;

    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Vérifie si la barre d'espace est enfoncée et que le mouvement n'a pas encore commencé
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
        }

        // Si le mouvement a commencé, déplace l'objet vers le haut à la vitesse spécifiée
        if (isMoving)
        {
            // Déplace l'objet dans la direction "vers le haut" (axe Y positif)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}

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
        // V�rifie si la barre d'espace est enfonc�e et que le mouvement n'a pas encore commenc�
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
        }

        // Si le mouvement a commenc�, d�place l'objet vers le haut � la vitesse sp�cifi�e
        if (isMoving)
        {
            // D�place l'objet dans la direction "vers le haut" (axe Y positif)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}

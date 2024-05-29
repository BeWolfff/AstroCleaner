
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    void Start()
    {
        
    }


    void Update()
    {
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + speed * Time.deltaTime * direction,
                                                            GetComponent<Transform>().position.y,
                                                            GetComponent<Transform>().position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "void" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

}

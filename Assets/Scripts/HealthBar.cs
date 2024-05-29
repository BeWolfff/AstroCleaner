
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float vie;
    public Image health_bar;
    public float max_vie;
    public GameObject deadMenu;
    public GameObject player;
    void Start()
    {
        max_vie = vie;
        deadMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.fillAmount = vie / max_vie;
        if (vie < 100 && vie >= 70)
        {
            health_bar.GetComponent<Image>().color = Color.green;
        }
        if (vie < 70 && vie >= 40)
        {
            health_bar.GetComponent<Image>().color = Color.yellow;
        }
        if (vie < 40 && vie > 0)
        {
            health_bar.GetComponent<Image>().color = Color.red;
        }
        if (vie <= 0)
        {
            deadMenu.SetActive(true);
            Destroy(player);
        }
    }
}

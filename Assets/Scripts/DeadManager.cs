
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseMission()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Reload()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Leave()
    {
        SceneManager.LoadScene("lvl1");
    }
}

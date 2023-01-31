using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_scenes : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu_V2");
    }
}

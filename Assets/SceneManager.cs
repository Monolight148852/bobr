using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
     public void SwitchScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}

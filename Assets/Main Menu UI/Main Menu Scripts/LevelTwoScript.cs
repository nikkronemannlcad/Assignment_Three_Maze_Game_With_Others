using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTwoScript : MonoBehaviour
{
    public void LoadMaxsLevel()
    {

        Debug.Log("Button click");
        SceneManager.LoadScene("Max's Scene");
    }
}

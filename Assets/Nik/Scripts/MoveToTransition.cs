using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToTransition : MonoBehaviour
{
    public void LoadNiksLevel()
    {

        Debug.Log("Button click");
        SceneManager.LoadScene("Nik's Scene");
    }
}
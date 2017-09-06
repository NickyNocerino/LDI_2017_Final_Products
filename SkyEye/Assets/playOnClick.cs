using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class playOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] string SceneName;
   public void ChangeScene()
    {
        StartCoroutine(WaitBeforeLoad());
    }
    IEnumerator WaitBeforeLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
    }
}

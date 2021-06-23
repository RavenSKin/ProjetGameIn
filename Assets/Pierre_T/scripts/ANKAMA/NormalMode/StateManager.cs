using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public string SceneName;
    public List<GameObject> BattleScene = new List<GameObject>();
    public List<GameObject> NormalScene = new List<GameObject>();
    public bool BattleStart;
    
  

    // Update is called once per frame
    void Update()
    {
       
    }
   /* public void BattleMode()
    {
        StartCoroutine(LaunchBattleMod());
       
    }*/
    /*public void AdventureMode()
    {

        SceneManager.LoadScene(SceneName);
    }*/

    public void World_1()
    {
        SceneManager.LoadScene(SceneName);
    }
    /*IEnumerator LaunchBattleMod()
    {

        yield return new WaitForSeconds(2f);
        foreach (GameObject _battle in BattleScene)
            {
                _battle.SetActive(true);
            }
            foreach(GameObject _normal in NormalScene)
            {
                _normal.SetActive(false);
            }
    }*/
}

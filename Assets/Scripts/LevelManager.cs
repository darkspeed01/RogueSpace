using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
 
    public void loadLevel(string lvlName)
    {
        Debug.Log("Loading " + lvlName);
        SceneManager.LoadScene(lvlName);
    }

}

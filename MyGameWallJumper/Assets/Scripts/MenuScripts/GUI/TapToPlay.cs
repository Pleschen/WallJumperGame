using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TapToPlay : MonoBehaviour {    
    private void Start() {        
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void TaskOnClick() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}

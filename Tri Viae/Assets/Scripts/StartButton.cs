using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    public Button button;
    public string NewScene;
    private void Start() {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClicked);
    }
    void onClicked(){
        Invoke("MoveScene", 2f);
    }
    void MoveScene(){
        SceneManager.LoadScene(NewScene);
    }
}

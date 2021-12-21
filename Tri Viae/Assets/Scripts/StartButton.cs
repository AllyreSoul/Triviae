using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StartButton : MonoBehaviour, IPointerEnterHandler
{
    public Button button;
    public string NewScene;
    private void Start() {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClicked);
    }
    void onClicked(){
        SoundHandler.SoundHandlerPlay("Selected");
        Time.timeScale = 1;
        MoveScene();
    }
    void MoveScene(){
        SceneManager.LoadScene(NewScene);
    }
    public void OnPointerEnter(PointerEventData data){
        SoundHandler.SoundHandlerPlay("Select", true);
    }
}

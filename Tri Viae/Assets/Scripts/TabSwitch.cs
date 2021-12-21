using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabSwitch : MonoBehaviour, IPointerEnterHandler
{
    public GameObject Target, Prev;
    public Button button;
    public bool freezeTime = false;
    private void Start() {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClicked);
    }
    private void onClicked(){
        SoundHandler.SoundHandlerPlay("Selected");
        Prev.SetActive(false);
        Target.SetActive(true);
        if(freezeTime){
            Time.timeScale = 0;
        } else Time.timeScale = 1;
    }
    public void OnPointerEnter(PointerEventData data){
        SoundHandler.SoundHandlerPlay("Select", true);
    }
}

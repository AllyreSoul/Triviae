using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    public Button button;
    private void Start() {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClicked);
    }
    private void onClicked(){
        Application.Quit();
    }
}

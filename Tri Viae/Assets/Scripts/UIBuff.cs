using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBuff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

   public PlayerCombat player;
    public Sel sel;
    public Transform BuffUI, UIObject, Anchor;
    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerCombat>();
    }
    public void OnPointerEnter(PointerEventData data)
        {
            SoundHandler.SoundHandlerPlay("Select", true);
            UIObject = Instantiate(BuffUI, Anchor);
            UIBuffLocal UIInternal = UIObject.GetComponent<UIBuffLocal>();
            UIInternal.sel = sel;
            switch(sel){
                case Sel.Atk:
                UIInternal.stringText = "+ " + (player.Atk - 5).ToString();
                break;
                case Sel.Def:
                UIInternal.stringText = "+ " + (player.Def - 1).ToString();
                break;
                case Sel.HP:
                UIInternal.stringText = "+ " + (player.MaxHP - 100).ToString();
                break;
            }
        }
 
    public void OnPointerExit(PointerEventData data)
        {
            GameObject.Destroy(UIObject.gameObject);
        }
}



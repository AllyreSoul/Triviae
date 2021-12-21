using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffObject : MonoBehaviour
{
    public SpriteRenderer selfRenderer;
    public Buff buff;
    public Sprite Atk, HP, Def;
    public GameObject LocalNotif, Anchor;
    private void Start() {
        Anchor = GameObject.Find("ObtainAnchor");
        switch(buff.type){
            case Sel.Atk:
                selfRenderer.sprite = Atk;
                break;
            case Sel.Def:
                selfRenderer.sprite = Def;
                break;
            case Sel.HP:
                selfRenderer.sprite = HP;
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
            SoundHandler.SoundHandlerPlay("Buff");
            PlayerCombat player = other.gameObject.GetComponent<PlayerCombat>();
            Debug.Log("buff amount =" + buff.amount);
            Debug.Log(player.Atk);
            switch(buff.type){
                case Sel.Atk:
                    player.Atk += buff.amount;
                    break;
                case Sel.Def:
                    player.Def += buff.amount;
                    break;
                case Sel.HP:
                    player.MaxHP += buff.amount;
                    player.Hp += buff.amount;
                    break;
            }
            player.UpdateUI();
            player.SyncData();
            GameObject n = Instantiate(LocalNotif, Anchor.transform);
            UIBuffLocal nInternal = n.GetComponent<UIBuffLocal>();
            nInternal.sel = buff.type;
            nInternal.stringText = "+ " + buff.amount.ToString();
            GameObject.Destroy(this.gameObject, 1f);
            GameObject.Destroy(n, 1f);
            this.gameObject.SetActive(false);
    }
}

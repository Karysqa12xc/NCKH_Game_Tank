using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bombParameter, bulletParameter;
    [SerializeField] private int minBomb = 0;
    [SerializeField]private Quest questGetKey;
    [SerializeField] private HealCharater healingPlayer;
    private void Start() {
        healingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealCharater>();
        questGetKey = GameObject.Find("QuestUI").GetComponent<Quest>();
    }
    public int GetBomb()
    {
        return minBomb;
    }
    public int SubBomb() => minBomb--;

    public void pickItem(GameObject item)
    {
        if (item.tag == "Bomb")
        {
            minBomb = minBomb + 1;
            string stringtookBombParameter = string.Format("Bombs: {0}", minBomb);
            bombParameter.text = stringtookBombParameter;
            Destroy(item);
        }
        if(item.tag == "Key"){
            questGetKey.key++;
            Destroy(item);
        }
        if(item.tag == "Heal" && healingPlayer.GetcurHealth() < healingPlayer.GetMaxHealth()){
            healingPlayer.GetcurHealthHealing();
            Destroy(item);
        }
    }
}

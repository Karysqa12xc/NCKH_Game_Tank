using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeItems : MonoBehaviour
{
    private int minBomb = 0;
    [SerializeField]private TextMeshProUGUI bombParameter, bulletParameter;
    public void pickItem(GameObject item){
        minBomb = minBomb + 1;
        string stringtookBombParameter = string.Format("Bombs: {0}", minBomb);
        bombParameter.text = stringtookBombParameter;
        Destroy(item);
    }
}

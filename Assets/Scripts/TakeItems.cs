using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeItems : MonoBehaviour
{
    private const int MAX_BOMB = 3;
    private int minBomb = 0;
    [SerializeField]private TextMeshProUGUI bombParameter, bulletParameter;
    public void pickItem(GameObject item){
        minBomb = minBomb + 1;
        string stringtookBombParameter = string.Format("Bombs: {0}/{1}", minBomb, MAX_BOMB);
        bombParameter.text = stringtookBombParameter;
        Destroy(item);
    }
}

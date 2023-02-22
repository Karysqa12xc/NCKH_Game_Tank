using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bombParameter, bulletParameter;
    [SerializeField] private int minBomb = 0;
    [SerializeField] private PlantingBomb callParameter;
    public int GetBomb()
    {
        return minBomb;
    }
    public void SubBomb() => minBomb--;
    public void pickItem(GameObject item)
    {
        minBomb++;
        string stringtookBombParameter = string.Format("Bombs: {0}", minBomb);
        bombParameter.text = stringtookBombParameter;
        Destroy(item);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlantingBomb : MonoBehaviour
{
    [SerializeField] private Tank_Inputs posittionOfCrosshair;
    Vector3 positionCrossHair;
    [SerializeField] private GameObject bombPreabs;
    [SerializeField] private AklbuAlapba ActiveBomb;
    [SerializeField] private TextMeshProUGUI changeBombParemeter;
    [SerializeField] private TakeItems quantityBomb;
    private void Start()
    {
        posittionOfCrosshair = GetComponent<Tank_Inputs>();
        ActiveBomb = bombPreabs.GetComponent<AklbuAlapba>();
    }
    public void Planting()
    {
        if (Input.GetKeyDown(KeyCode.X) && quantityBomb.GetBomb() > 0)
        {   
            quantityBomb.SubBomb();
            string stringBombParameter = string.Format("Bombs: {0}", quantityBomb.GetBomb());
            changeBombParemeter.text = stringBombParameter;
            positionCrossHair = posittionOfCrosshair.CrosshairPosition;
            Instantiate(bombPreabs, positionCrossHair, bombPreabs.transform.rotation);
        }
    }
    private void Update()
    {
        Planting();
    }

}

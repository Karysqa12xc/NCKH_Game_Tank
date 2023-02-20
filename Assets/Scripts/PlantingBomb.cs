using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingBomb : MonoBehaviour
{
    [SerializeField] private Tank_Inputs posittionOfCrosshair;
    Vector3 positionCrossHair;
    [SerializeField] private GameObject bombPreabs;
    [SerializeField] private AklbuAlapba ActiveBomb;
    private void Start()
    {
        posittionOfCrosshair = GetComponent<Tank_Inputs>();
        ActiveBomb = bombPreabs.GetComponent<AklbuAlapba>();
    }
    public void Planting()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            positionCrossHair = posittionOfCrosshair.CrosshairPosition;
            Instantiate(bombPreabs, positionCrossHair, bombPreabs.transform.rotation);
        }
    }
    private void Update()
    {
        Planting();
    }

}

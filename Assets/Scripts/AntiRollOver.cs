using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollOver : MonoBehaviour
{
    [SerializeField] private Transform _playerRotation;
    [SerializeField] private GameObject instuctAntiRollOver;

    private void Start()
    {
        _playerRotation = GetComponent<Transform>();
    }
    void Update()
    {
        handleRollOver();
        // Debug.Log(_playerRotation.rotation.eulerAngles);
    }
    private void handleRollOver()
    {
        if (
            _playerRotation.rotation.eulerAngles.x == 90 ||
            _playerRotation.rotation.eulerAngles.z == 90 ||
            _playerRotation.rotation.eulerAngles.x == -90 ||
            _playerRotation.rotation.eulerAngles.z == -90 ||
            _playerRotation.rotation.eulerAngles.x == 180 ||
            _playerRotation.rotation.eulerAngles.z == 180 ||
            _playerRotation.rotation.eulerAngles.x == -180 ||
            _playerRotation.rotation.eulerAngles.z == -180 || 
            _playerRotation.rotation.eulerAngles.x == 270 ||
            _playerRotation.rotation.eulerAngles.z == 270 ||
            _playerRotation.rotation.eulerAngles.x == -270 ||
            _playerRotation.rotation.eulerAngles.z == -270

        )
        {
            instuctAntiRollOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                instuctAntiRollOver.SetActive(false);
                _playerRotation.rotation = Quaternion.identity;
            }
        }
    }
}

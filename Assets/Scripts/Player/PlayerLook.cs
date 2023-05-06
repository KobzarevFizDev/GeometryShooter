using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Прокинуть PlayerInput через Zenject
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 1000f;
    [SerializeField] private Transform _playerOrientation;

    private float _xAxisClamp;

    private void Awake()
    {
        LockCursor();
    }

    private void Update()
    {
        Rotate();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Rotate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -1f, 1f);
        mouseY = Mathf.Clamp(mouseY, -1f, 1f);

        _xAxisClamp += mouseY;

        if(_xAxisClamp > 40f)
        {
            _xAxisClamp = 40f;
            mouseY = 0;
        }
        else if(_xAxisClamp < -40f)
        {
            _xAxisClamp = -40f;
            mouseY = 0;
        }

        transform.Rotate(Vector3.left, mouseY);
        _playerOrientation.Rotate(Vector3.up, mouseX);
    }
}

using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Netologia.Necro.Manager
{
    public class InputManager : MonoBehaviour
    {
        private SceneController _sceneController;    //injected
        private Controls.GameActions _controls;      //injected

        private Coroutine _restartCoroutine;

        [SerializeField] private GameObject _restartUI;
        [SerializeField] private Image _restartFill;
        [SerializeField, Range(0.1f, 1f)] private float _restartPushInSec = 0.25f;

        private void OnRestartPerformed(InputAction.CallbackContext obj)
        {
            _restartUI.SetActive(true);
            _restartCoroutine = StartCoroutine(Restarter());
        }

        private void OnRestartCanceled(InputAction.CallbackContext obj)
        {
            StopCoroutine(_restartCoroutine);
            _restartFill.fillAmount = 0f;
            _restartUI.SetActive(false);
        }

        private IEnumerator Restarter()
        {
            while(true)
            {
                var value = _restartFill.fillAmount + _restartPushInSec * Time.deltaTime;
                _restartFill.fillAmount = value;
                if (value >= 1f)
                {
                    _sceneController.OpenGameScene();
                }
                yield return null;
            }
        }

        private void Start()
        {
            _controls.Restart.performed += OnRestartPerformed;
            _controls.Restart.canceled += OnRestartCanceled;
            _restartFill.fillAmount = 0f;
            _restartUI.SetActive(false);
        }

        private void OnDestroy()
        {
            _controls.Restart.performed -= OnRestartPerformed;
            _controls.Restart.canceled -= OnRestartCanceled;
        }

        [Inject]
        private void Configure(SceneController sceneController, Controls.GameActions controls)
        {
            _sceneController = sceneController;
            _controls = controls;
        }
    }
}


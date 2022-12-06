using System;
using System.Collections;
using Code.Common.RuntimeSet;
using Code.Common.RuntimeSet.Instances;
using Code.PlayerControl;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countDown;
        [SerializeField] private AudioSource _tickSound;
        [SerializeField] private TransformRuntimeSet _playerCars;

        private void Start()
        {
            ActivatePlayers(false);
            StartCoroutine(StartCounting());
        }

        private IEnumerator StartCounting()
        {
            yield return StartCoroutine(Tick("3"));
            yield return StartCoroutine(Tick("2"));
            yield return StartCoroutine(Tick("1"));
            ActivatePlayers(true);
            yield return StartCoroutine(Tick("GO!"));
            _countDown.gameObject.SetActive(false);
        }

        private IEnumerator Tick(string tickValue)
        {
            _countDown.text = tickValue;
            yield return new WaitForSeconds(1f);
        }

        private void ActivatePlayers(bool state)
        {
            foreach (var car in _playerCars.Items)
            {
                if (car.TryGetComponent(out CarController carController))
                {
                    carController.enabled = state;
                }
            }
        }
    }
}
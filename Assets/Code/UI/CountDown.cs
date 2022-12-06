using System;
using System.Collections;
using Code.Common.RuntimeSet;
using Code.Common.RuntimeSet.Instances;
using Code.Level;
using Code.PlayerControl;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.UI
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countDown;
        [SerializeField] private AudioSource _tickSound;
        [SerializeField] private TransformRuntimeSet _playerCars;
        [SerializeField] private ObstacleSpawner _obstacleSpawner;

        private void Start()
        {
            ActivatePlayers(false);
            ActivateObstaclesGeneration(false);
            StartCoroutine(StartCounting());
        }

        private IEnumerator StartCounting()
        {
            yield return StartCoroutine(Tick("3"));
            yield return StartCoroutine(Tick("2"));
            yield return StartCoroutine(Tick("1"));
            ActivatePlayers(true);
            ActivateObstaclesGeneration(true);
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

        private void ActivateObstaclesGeneration(bool state)
        {
            _obstacleSpawner.enabled = state;
        }
    }
}
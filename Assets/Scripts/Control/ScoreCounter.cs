﻿using System;
using DefaultNamespace;
using UnityEngine;

namespace Control
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private UIScore _uiScore;

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Obstacle")) return;
            _uiScore.IncrementScore();
            _uiScore.UpdateScore();
        }
    }
}
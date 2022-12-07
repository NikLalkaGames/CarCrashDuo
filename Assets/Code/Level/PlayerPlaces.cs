using System.Collections.Generic;
using System.Linq;
using Code.Common;
using Code.UI;
using UnityEngine;

namespace Code.Level
{
    
    public class PlayerPlaces : MonoBehaviour
    {
        public List<Transform> PlayerCars;
        public List<Transform> PlayerCarsOrdered => PlayerCars.OrderByDescending(pc => pc.position.z).ToList();

        [SerializeField] private List<PlayerInfo> _playerInfos;

        private void Update()
        {
            _playerInfos[0].Place = PlayerCars.First().position.z > PlayerCars.Last().position.z ? 1 : 2;
            _playerInfos[1].Place = PlayerCars.Last().position.z > PlayerCars.First().position.z ? 1 : 2;
        }

    }
}
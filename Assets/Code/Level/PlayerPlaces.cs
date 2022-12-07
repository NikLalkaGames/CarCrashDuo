using System.Collections.Generic;
using System.Linq;
using Code.Common.RuntimeSet.Instances;
using Code.UI;
using UnityEngine;

namespace Code.Level
{
    
    public class PlayerPlaces : MonoBehaviour
    {
        [SerializeField] private UIPlayerPos _uiPlayerPos;

        public List<Transform> PlayerCars;
        public List<Transform> PlayerCarsOrdered => PlayerCars.OrderByDescending(pc => pc.position.z).ToList();
        
        private void Update()
        {
            _uiPlayerPos.UpdatePositions(PlayerCars.First().position.z > PlayerCars.Last().position.z ? 1 : 2,
                PlayerCars.Last().position.z > PlayerCars.First().position.z ? 1 : 2);
        }

    }
}
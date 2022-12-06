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

        public TransformRuntimeSet PlayerCars;
        public List<Transform> PlayerCarsOrdered => PlayerCars.Items.OrderByDescending(pc => pc.position.z).ToList();
        
        private void Update()
        {
            _uiPlayerPos.UpdatePositions(PlayerCars.Items.Last().position.z > PlayerCars.Items.First().position.z ? 1 : 2, 
                PlayerCars.Items.First().position.z > PlayerCars.Items.Last().position.z ? 1 : 2);
        }

    }
}
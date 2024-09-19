using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Frog : MonoBehaviour
    {
        [SerializeField] private FrogType type;
        public static event Action<Frog> clicked;

        public FrogType Type => type;

        private void OnMouseDown()
        {
            clicked(this);
        }
    }
}
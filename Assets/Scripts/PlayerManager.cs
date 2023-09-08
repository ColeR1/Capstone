using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LP.FDG.InputManager;

namespace LD.FDG.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}

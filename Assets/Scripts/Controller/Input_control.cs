using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace zhb
{
    [RequireComponent(typeof(PlayerInput))]
    public class Input_control : MonoBehaviour
    {
        public Vector2 move;
        public static PlayerInputactions inputactions;
        private playerController player;

        public Vector2 Move { get => move; }

        public void Awake()
        {
            inputactions = new PlayerInputactions();
            player=GetComponent<playerController>();
        }

        public void OnEnable()
        {
            inputactions.Enable();
            
        }
        public void Disable()
        {
            inputactions.Disable();
        }
        private void FixedUpdate()
        {
            
            move = inputactions.Gameplay.Move.ReadValue<Vector2>();
            if(player!=null){
                player.move(move);
            }
        }
        private void OnShoot(InputValue input){
            // Debug.Log("shoot");
            Vector3 mPosition=Input.mousePosition;
            player.shoot(mPosition);
        }
        private void OnPickup()
        {
            player.PickupWeapon();
        }
    };
}

﻿using UnityEngine;
using System.Collections;

namespace GameProgramming2D
{


    public class InputManager : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                //Pause Game
                GameManager.Instance.Pauser.TogglePause();
            }

            if (GameManager.Instance.Player != null)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    GameManager.Instance.Player.Jump = true;
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    GameManager.Instance.Player.Gun.Fire();
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    GameManager.Instance.Player.LayBomb();
                }
                var horizontal = Input.GetAxis("Horizontal");
                GameManager.Instance.Player.SetHorizontal(horizontal);

            }


        }
    }
}

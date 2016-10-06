using UnityEngine;
using System.Collections;

namespace GameProgramming2D
{
    public class GameOverGUI : MonoBehaviour
    {

        public void OnRestartPressed()
        {
            GameManager.Instance.Restart();
        }

        public void OnMainMenuPressed()
        {
            GameManager.Instance.MainMenu();
        }

    }
}
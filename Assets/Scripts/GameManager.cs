﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using GameProgramming2D.State;

namespace GameProgramming2D
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }

        private Pauser _pauser;
        private InputManager _inputManager;
        private PlayerControl _playerControl;

        public Pauser Pauser
        {
            get
            {
                return _pauser;
            }
        }

        public PlayerControl Player
        {
            get {

                if(_playerControl == null)
                {
                    _playerControl = FindObjectOfType<PlayerControl>();
                }

                return _playerControl; }
        }

        public GameStateManager StateManager
        {
            get; set;
        }

        private void Awake()
        {
            if(_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
                Init();
            }
            else if(_instance != this)
            {
                Destroy(this);
            }
            
        }

        private void Init()
        {
            _pauser = gameObject.GetOrAddComponent<Pauser>();
            _inputManager = gameObject.GetOrAddComponent<InputManager>();
            _playerControl = FindObjectOfType<PlayerControl>();
            InitGameStateManager();
        }

        private void InitGameStateManager()
        {
            StateManager = new GameStateManager(new MenuState());
            StateManager.AddState(new GameState());
            StateManager.AddState(new GameOverState());
        }

        public void GameOver()
        {
            StateManager.PerformTransition(TransitionType.GameToGameOver);
        }

        public void Restart()
        {
            StateManager.PerformTransition(TransitionType.GameOverToGame);
        }

        public void MainMenu()
        {
            StateManager.PerformTransition(TransitionType.GameOverToMainMenu);
        }
    }
}

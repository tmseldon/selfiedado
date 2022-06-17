using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Control
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] Canvas _menuScreen;
        [SerializeField] AudioClip _pauseFX;
        [SerializeField][Range(0f, 1f)] float _volume = 0.5f;


        private bool _isPause = false;
        public bool IsPause { get { return _isPause; } }

        void Start()
        {
            _menuScreen.enabled = false;
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_isPause)
                {
                    GetPauseMenu();
                }
                else
                {
                    ResumeGame();
                }
            }
        }

        private void GetPauseMenu()
        {
            _isPause = true;
            AudioSource.PlayClipAtPoint(_pauseFX, Camera.main.transform.position, _volume);
            _menuScreen.enabled = true;
            ToogleSystems(false);
        }

        public void ResumeGame()
        {
            _menuScreen.enabled = false;
            ToogleSystems(true);
            _isPause = false;
        }

        private void OnApplicationPause(bool pause)
        {
            GetPauseMenu();
        }

        public void BackToMainMenu()
        {
            ToogleSystems(true);
        }


        private void ToogleSystems(bool status)
        {
            if (status)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}

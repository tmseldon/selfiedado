using Game.SceneControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [Header("Botones")]
        [SerializeField] Button _mainMenu;
        [SerializeField] Button _quitGame;

        private SceneManagerMain _sceneControl;

        void Start()
        {
            _sceneControl = FindObjectOfType<SceneManagerMain>();

            _mainMenu.onClick.AddListener(_sceneControl.GoToMain);
            _quitGame.onClick.AddListener(_sceneControl.QuitGame);
        }
    }

}
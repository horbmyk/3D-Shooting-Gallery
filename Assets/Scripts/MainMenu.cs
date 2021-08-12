using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingGallery
{
    public class MainMenu : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;//Unlocke mouse
            Cursor.visible = true;
        }

        public void LoadSceneGame()//Load Scene Game
        {
            SceneManager.LoadScene("Game");
        }

        public void Quit()//Quit Game
        {
            Application.Quit();
        }
    }
}

using UnityEngine;

namespace ShootingGallery
{
    public class LockedMouse : MonoBehaviour
    {
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;//locked mouse for scene Game
            Cursor.visible = false;//unvisible mouse for scene Game
        }
    }
}

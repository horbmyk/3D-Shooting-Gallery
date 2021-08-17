using UnityEngine;

namespace ShootingGallery
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Player Player;
        [SerializeField] private Shooting Shooting;
        [SerializeField] private WeaponsControler WeaponsControler;

        private void FixedUpdate()
        {
            Player.Rotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));//Rotate player

            if (Input.GetMouseButtonDown(0))//Shot
                Shooting.Shot();

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                WeaponsControler.SetWeapon(1);//Change Weapon

            if (Input.GetAxis("Mouse ScrollWheel") < 0)//Change Weapon
                WeaponsControler.SetWeapon(-1);
        }
    }
}

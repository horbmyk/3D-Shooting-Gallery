using UnityEngine;

namespace ShootingGallery
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Camera PlayerCamera;
        [SerializeField] private TargetsController TargetsController;
        [SerializeField] private WeaponsControler WeaponsControler;
        private RaycastHit Hit;
        private Ray Ray;
        const float MaxDistanceRay = 20f;

        public void Shot()//Shot 
        {
            Ray = PlayerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            WeaponsControler.PlayShotSound();

            if (Physics.Raycast(Ray, out Hit, MaxDistanceRay) && Hit.collider.CompareTag("Target"))
                Hit.collider.GetComponent<Target>().TakeShot();
            else
                TargetsController.MissedToTarget();
        }
    }
}

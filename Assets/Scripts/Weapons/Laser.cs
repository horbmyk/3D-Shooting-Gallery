using UnityEngine;

namespace ShootingGallery
{
    public class Laser : MonoBehaviour, IWeapon
    {
        [SerializeField] private AudioSource AudioSource;
        [SerializeField] private AudioClip ShotSound;

        public void PlayShotSound()
        {
            AudioSource.PlayOneShot(ShotSound);
        }
    }
}

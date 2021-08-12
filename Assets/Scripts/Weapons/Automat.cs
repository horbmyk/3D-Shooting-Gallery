using UnityEngine;

namespace ShootingGallery
{
    public class Automat : MonoBehaviour, IWeapon
    {
        [SerializeField] private AudioSource AudioSource;
        [SerializeField] private AudioClip ShotSound;

        public void PlayShotSound()
        {
            AudioSource.PlayOneShot(ShotSound);
        }
    }
}

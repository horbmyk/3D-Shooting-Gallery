using UnityEngine;

namespace ShootingGallery
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera PlayerCamera;
        [SerializeField] private float Sensitivity;
        [SerializeField] private float Smoothness;
        private float XRotation;
        private float YRotation;
        private float XCurentRotation;
        private float YCurentRotation;
        private float XCurentVelocity;
        private float YCurentVelocity;

        public void Rotation(float xRotation, float yRotation)//Rotation Player and Camera
        {
            XRotation += xRotation * Sensitivity;
            YRotation += yRotation * Sensitivity;
            YRotation = Mathf.Clamp(YRotation, -67, 67);
            XCurentRotation = Mathf.SmoothDamp(XCurentRotation, XRotation, ref XCurentVelocity, Smoothness);
            YCurentRotation = Mathf.SmoothDamp(YCurentRotation, YRotation, ref YCurentVelocity, Smoothness);
            transform.rotation = Quaternion.Euler(0f, XCurentRotation, 0f);
            PlayerCamera.transform.rotation = Quaternion.Euler(-YCurentRotation, XCurentRotation, 0f);
        }

        public Vector3 GetPosition => transform.position;//Get position Player 
    }
}

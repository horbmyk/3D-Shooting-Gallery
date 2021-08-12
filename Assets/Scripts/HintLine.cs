using UnityEngine;

namespace ShootingGallery
{
    public class HintLine : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Player Player;
        [SerializeField] private TargetsController TargetsController;
        private Vector3[] positions;

        void Start()
        {
            UpdateHintLine();
        }

        private void SetPositions()//Set position for line
        {
            positions = new Vector3[2] { Player.GetPosition, TargetsController.GetPositionCurentTarget() };
        }

        private void DrawLine(Vector3[] vertexPositions) //Draw curent line
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(vertexPositions);
        }

        public void UpdateHintLine() //update line
        {
            SetPositions();
            DrawLine(positions);
        }
    }
}

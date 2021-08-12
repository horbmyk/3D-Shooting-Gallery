using System.Collections.Generic;
using UnityEngine;

namespace ShootingGallery
{
    public class TargetsController : MonoBehaviour
    {
        [SerializeField] private LevelController levelController;
        [SerializeField] private GameObject TargetBody;
        [SerializeField] private GameObject TargetLight;
        [SerializeField] private GameObject TargetCentr;
        [SerializeField] private Player Player;
        [SerializeField] private HintLine HintLine;
        private List<Target> PoolTargets;
        const float Radius = 6f;
        const float PositionsY = 3.6f;
        private int RandNum;

        void Start()
        {
            InstantiateTargets();
        }

        void InstantiateTargets()//Instantiate Targets
        {
            PoolTargets = new List<Target>();

            for (float x = -Radius; x <= Radius; x += 1.5f)
            {
                float z = Mathf.Sqrt((Radius * Radius) - (x * x));
                GameObject targetBody = Instantiate(TargetBody);
                GameObject targetLight = Instantiate(TargetLight);
                GameObject targetCentr = Instantiate(TargetCentr);
                targetBody.GetComponent<Target>().SetTarget(targetBody, new Vector3(x, PositionsY, z), 
                    targetLight, targetCentr, ChoiceNextTarget,HittingTarget);
                PoolTargets.Add(targetBody.GetComponent<Target>());
            }

            SetRotateToPlayer();
            ChoiceNextTarget();
        }

        public void HittingTarget()
        {
            levelController.HittingTarget();
        }

        public void ChoiceNextTarget() //Choice NextTarget
        {
            
            foreach (var item in PoolTargets)
            {
                item.LightOff();
                item.UnActive();
            }

            int tmpRandNum = RandNum;

            do
            {
                RandNum = Random.Range(0, PoolTargets.Count);

                if (Mathf.Abs(RandNum - tmpRandNum) > 1)
                {
                    PoolTargets[RandNum].LightOn();
                    PoolTargets[RandNum].Activate();
                    break;
                }
            }
            while (Mathf.Abs(RandNum - tmpRandNum) <= 1);

            HintLine.UpdateHintLine();
        }

        public void MissedToTarget()//Missed to current target
        {
            PoolTargets[RandNum].MissedToTarget();
        }

        private void SetRotateToPlayer() // Set Rotate to player
        {
            foreach (var item in PoolTargets)
            {
                item.SetRotateTo(Player.GetPosition);
            }
        }

        public Vector3 GetPositionCurentTarget() => PoolTargets[RandNum].GetCentrTargetPosition();// Get position curent target
    }
}

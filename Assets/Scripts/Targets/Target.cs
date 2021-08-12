using System.Collections;
using UnityEngine;

namespace ShootingGallery
{
    public class Target : MonoBehaviour
    {
        public delegate void ChoiceNextTarget();
        public delegate void HittingTarget();
        private ChoiceNextTarget ChoiceTarget;
        private HittingTarget HitTarget;
        private GameObject Body;
        private GameObject LightObj;
        private GameObject Centr;
        private Light Light;
        private Animator Animator;
        private bool Active;
        // Set obj Target
        public void SetTarget(GameObject targetObj, Vector3 targetPos, GameObject light, GameObject centrTarget,
            ChoiceNextTarget choiceNextTarget, HittingTarget hitTarget)
        {
            this.Body = targetObj;
            this.LightObj = light;
            this.LightObj.transform.SetParent(this.Body.transform);
            this.Centr = centrTarget;
            this.Centr.transform.SetParent(this.Body.transform);
            this.Body.transform.position = targetPos;
            this.ChoiceTarget = choiceNextTarget;
            this.HitTarget = hitTarget;
            this.Light = LightObj.GetComponentInChildren<Light>();
            this.Animator = LightObj.GetComponent<Animator>();
        }
        // Activate this target(for correct shooting)
        public void Activate()
        {
            Active = true;
        }
        // Unctivate this target(for correct shooting)
        public void UnActive()
        {
            Active = false;
        }

        public void LightOff()
        {
            Light.enabled = false;
        }

        public void LightOn()
        {
            Light.enabled = true;
        }
        //Take damage
        public void TakeShot()
        {
            StartCoroutine(HittingToTarget());

            if (Active)
            {
                HitTarget();
                ChoiceTarget();
            }
        }

        public void MissedToTarget()//MissedToCurrentTarget
        {
            Animator.SetTrigger("MissedToTarget");
        }

        public Vector3 GetCentrTargetPosition()
        {
            return Centr.transform.position;
        }
        //for correct rotate to player in start
        public void SetRotateTo(Vector3 value)
        {
            transform.LookAt(value);
            transform.Rotate(270, 0, 0);
        }

        public IEnumerator HittingToTarget()//When target hiting
        {
            for (int i = 0; i < 9; i++)
            {
                yield return new WaitForSeconds(0.01f);
                Quaternion RotationX = Quaternion.AngleAxis(5, Vector3.right);
                Body.transform.localRotation *= RotationX;
            }

            for (int i = 0; i < 45; i++)
            {
                yield return new WaitForSeconds(0.01f);
                Quaternion RotationX = Quaternion.AngleAxis(1, -Vector3.right);
                Body.transform.localRotation *= RotationX;
            }
        }
    }
}

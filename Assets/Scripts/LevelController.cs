using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ShootingGallery
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private TargetsController TargetsController;
        [SerializeField] Text TimeTotalLevel_txt;
        [SerializeField] Text TimeCurrentTarget_txt;
        [SerializeField] Text ScoreTarget_txt;
        private float TimeCurrentTarget;
        private float TimeTotalLevel;
        private float TimeTotalLevelResult;
        private int Score_Target = 0;

        private void Awake()
        {
            ResultsData.LevelController = this;
        }

        private void Start()
        {
            TimeCurrentTarget = 10;
            TimeTotalLevel = 60;
            Score_Target = 0;
            TimeTotalLevelResult = 0;
            ScoreTarget_txt.text = "Score " + Score_Target.ToString();
        }

        void Update()
        {
            TimeCurrentTarget -= Time.deltaTime;
            TimeCurrentTarget_txt.text = "Curent left " + Math.Round(TimeCurrentTarget).ToString() + " Seconds";
            TimeTotalLevel -= Time.deltaTime;
            TimeTotalLevel_txt.text = "Total left " + Math.Round(TimeTotalLevel).ToString() + " Seconds";
            TimeTotalLevelResult += Time.deltaTime;

            if (TimeCurrentTarget <= 0)
            {
                TimeCurrentTarget = 10;
                TargetsController.ChoiceNextTarget();
            }

            if (TimeTotalLevel <= 0)
                EndGame(false);
        }

        public void HittingTarget()// Hitting target
        {
            TimeCurrentTarget = 10;
            Score_Target++;
            ScoreTarget_txt.text = "Score " + Score_Target.ToString();

            if (Score_Target == 10)
                EndGame(true);
        }

        public void EndGame(bool win)//End curent game
        {
            if (win)
            {
                ResultsData.LevelResult = true;
                ResultsData.CurentTimeResult = (int)Math.Round(TimeTotalLevelResult);
                ResultsData.PoolResults.Add((int)Math.Round(TimeTotalLevelResult));
            }
            else
                ResultsData.LevelResult = false;

            SceneManager.LoadScene("Results");
        }
    }
}

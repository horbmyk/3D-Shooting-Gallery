using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootingGallery
{
    public class ResultController : MonoBehaviour
    {
        [SerializeField] private GameObject LogoWin;
        [SerializeField] private GameObject LogoLose;
        [SerializeField] private GameObject ResultTimeWin;
        [SerializeField] private GameObject ResultsBoard;
        [SerializeField] private Text ResultPrefab_txt;
        [SerializeField] private Text CurentResul_txt;
        private const int MaxQuantityBestResults = 10;
        private int CurentQuantityBestResults;

        private void Awake()
        {
            ResultsData.ResultController = this;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;//Setting Mouse
            Cursor.visible = true;//Setting Mouse

            if (ResultsData.LevelResult == true)
            {
                ResultTimeWin.SetActive(true);
                CurentResul_txt.text = ResultsData.CurentTimeResult + " Seconds";//CurentResult
                LogoWin.SetActive(true);
                LogoLose.SetActive(false);
            }
            else
            {
                LogoWin.SetActive(false);
                ResultTimeWin.SetActive(false);
                LogoLose.SetActive(true);
            }

            ResultsData.PoolResults.Sort();//Update sorting best results
            CurentQuantityBestResults = ResultsData.PoolResults.Count;

            if (CurentQuantityBestResults >= MaxQuantityBestResults)
                CurentQuantityBestResults = MaxQuantityBestResults;

            foreach (Transform child in ResultsBoard.transform) Destroy(child.gameObject);//Delete old results

            StartCoroutine(ViewingResults());//Add new results
        }

        IEnumerator ViewingResults()
        {
            for (int i = 0; i < CurentQuantityBestResults; i++)
            {
                yield return new WaitForSeconds(0.5f);
                Text result = Instantiate(ResultPrefab_txt, ResultsBoard.transform);
                result.text = (i + 1).ToString() + "st " + ResultsData.PoolResults[i] + " Seconds";
            }
        }

        public void LoadSceneGame()//LoadSceneGame
        {
            SceneManager.LoadScene("Game");
        }

        public void Quit()//QuitGame
        {
            Application.Quit();
        }
    }
}

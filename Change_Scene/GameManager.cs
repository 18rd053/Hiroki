using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームマネージャーが各シーンに一つになるように
namespace Select_tank
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _GameManager;

        [SerializeField]
        private GameManagerData _GameManagerDate = null;


        private void Awake()
        {
            if(_GameManager == null)
            {
                _GameManager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    public GameManagerData Get_GameManageraData()
        {
            return _GameManagerDate;
        }
    }
}

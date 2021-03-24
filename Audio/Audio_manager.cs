using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//各シーンに一つになるようシーン内のオブジェクトに取り付ける（GameManager）
namespace Audio_keeper
{
    public class Audio_manager : MonoBehaviour
    {
        private static Audio_manager _Audio_manager;

        [SerializeField]
        private Audio_managerData _Audio_managerData = null;

        private void Awake()
        {
            if (_Audio_manager == null)
            {
                _Audio_manager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public Audio_managerData Get_AudioManagerData()
        {
            return _Audio_managerData;
        }
    }
}

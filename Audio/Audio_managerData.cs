using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//各オーディオのステータスを保持し全てのシーンで共有
namespace Audio_keeper
{
    [CreateAssetMenu(fileName = "Audio_keeper_Data", menuName = "Audio_keeper_Data")]
    public class Audio_managerData : ScriptableObject
    {

        [SerializeField]
        private float BGM_volume;
        [SerializeField]
        private float SE_volume;
        [SerializeField]
        private float CV_volume;

        
            

        public void Set_volume(float _BGM_volume, float _SE_volume, float _CV_volume)
        {

            BGM_volume = _BGM_volume;
            SE_volume = _SE_volume;
            CV_volume = _CV_volume;
        }

        public float Get_BGMVolume()
        {
            return BGM_volume;
        }

        public float Get_SEVolume()
        {
            return SE_volume;
        }

        public float Get_CVVolume()
        {
            return CV_volume;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

namespace Audio_keeper
{
    public class Audio_controller : MonoBehaviour
    {
        //BGM,SE,Voiceそれぞれの音量調整用

        /// <summary>
        /// シーン開始時
        /// Audio_managerData - Slider - AudioSource
        ///
        /// 音量変更時
        /// Slider - Audio_managerData
        /// |_ AudioSource
        /// </summary>

        [SerializeField]
        private Slider BGM_slider;

        [SerializeField]
        private Slider SE_slider;

        [SerializeField]
        private Slider Voice_slider;


        //初期値は0.2
        [SerializeField]
        private AudioSource BGM;
        //初期値は0.4
        [SerializeField]
        private AudioSource SE;
        //初期値は0.5
        [SerializeField]
        private AudioSource Voice;


        [SerializeField]
        private AudioClip SE_check;

        [SerializeField]
        private AudioClip Voice_check;

        [SerializeField]
        private Audio_managerData _Audio_managerData;


        //初めの変更を行うため
        private bool Change_flg = true;

        private void Awake()
        {
            _Audio_managerData = FindObjectOfType<Audio_manager>().Get_AudioManagerData();

            
        }

        //SEとVoiceは戦車本体が持っているためFWTで取得
        void Start()
        {
            SE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
            Voice = GameObject.FindWithTag("Voice").GetComponent<AudioSource>();

            Change_flg = false;
            //オーディオマネージャーから前回のシーンと同じ音量を取得しスライダーに反映
            BGM_slider.value = _Audio_managerData.Get_BGMVolume();
            SE_slider.value = _Audio_managerData.Get_SEVolume();
            Voice_slider.value = _Audio_managerData.Get_CVVolume();

            Change_flg = true;

            //スライダーの値からオーディオソースのボリュームを設定
            Control_audio();
        }

        //各パラメータが操作された時に呼び出される
        private void Control_audio()
        {
            //_Audio_managerData.Set_volume(BGM.volume, SE.volume, Voice.volume);
            _Audio_managerData.Set_volume(BGM_slider.value, SE_slider.value, Voice_slider.value);

            BGM.volume = BGM_slider.value;
            SE.volume = SE_slider.value;
            Voice.volume = Voice_slider.value;// * 7;
            
        }

        //各パラメータが操作されたらスライダーから呼び出される
        public void Check_BGM()
        {
            if (Change_flg)
            {
                Control_audio();
            }
        }

        public void Check_SE()
        {
            if (Change_flg)
            {
                Control_audio();
                SE.PlayOneShot(SE_check);
            }
        }

        public void Check_Voice()
        {
            if (Change_flg)
            {
                Control_audio();
                Voice.PlayOneShot(Voice_check);
            }
        }
    }
}
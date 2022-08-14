using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LoadScreen.Scripts
{
    public class LevelIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("Lock")]
        [SerializeField] private int levelNumber;
        [SerializeField] private GameObject levelLock;

        [Header("Audio")]
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip clickAudioClip;
        [SerializeField] private AudioClip lockedClickAudioClip;
        [SerializeField] private AudioClip enterAudioClip;
        [SerializeField] private AudioClip exitAudioClip;

        [Header("Scene")] 
        [SerializeField] private string scene;
        
        private RectTransform _rectTransform;
        private bool _isAccessable = false;
        
        private void Awake(){
            _rectTransform = GetComponent<RectTransform>();
            if(!PlayerPrefs.HasKey("Last Level")) PlayerPrefs.SetInt("Last Level", 1);

            var currentLevel = PlayerPrefs.GetInt("Last Level");
            
            if (currentLevel >= levelNumber)
            {
                levelLock.SetActive(false);
                _isAccessable = true;
            }
            else
            {
                levelLock.SetActive(true);
                _isAccessable = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            source.clip = enterAudioClip;
            source.Play();
            var newSize = Vector3.one * 1.1f;
            LeanTween.scale(_rectTransform, newSize, 0.05f);
        }   

        public void OnPointerExit(PointerEventData eventData)
        {
            source.clip = exitAudioClip;
            source.Play();
            var newSize = Vector3.one;
            LeanTween.scale(_rectTransform, newSize, 0.05f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isAccessable)
            {
                source.clip = clickAudioClip;
                source.Play();
                SceneManager.LoadScene(scene);
                
                PlayerPrefs.SetInt("Current Level", levelNumber);
                return;
            }
            
            source.clip = lockedClickAudioClip;
            source.Play();
        }
        
        
    }
}

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance

    {
        get { return _instance; }
    }

    [SerializeField] Button exitButton;
    [SerializeField] Button stopButton;

    [SerializeField] public Text restTimeText;

    [SerializeField] RectTransform mainScreenRT;
    [SerializeField] RectTransform dialScreenRT;
    [SerializeField] RectTransform runningTimerScreenRT;

    [SerializeField] RectTransform confirmButtonRT;
    [SerializeField] RectTransform denyButtonRT;
    [SerializeField] RectTransform exitButtonRT;

    Image buttonImage;
    Shadow buttonShadow;
    Shadow stopButtonShadow;
    int screenWidth;
    int screenHeight;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        buttonImage = exitButton.GetComponent<Image>();
        buttonShadow = exitButton.GetComponent<Shadow>();
        stopButtonShadow = stopButton.GetComponent<Shadow>();
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    public void MainScreenOn()
    {
        TimerManager.Instance.StopTimer();
    }

    public void AddTimerScreenOn()
    {

    }

    public void RunningTimerScreenOn()
    {
        TimerManager.Instance.StopTimer();
    }

    public void OnTimerStarted()
    {
        mainScreenRT.DOAnchorPosX(-screenWidth, 0.5f);
        runningTimerScreenRT.DOAnchorPosX(0, 0.5f);
    }

    public void OnTimerFinished()
    {
        mainScreenRT.DOAnchorPosX(0, 0.5f);
        runningTimerScreenRT.DOAnchorPosX(screenWidth, 0.5f);
    }

    public void OnAddTimer()
    {
        mainScreenRT.DOAnchorPosY(-screenHeight, 0.5f);
        dialScreenRT.DOAnchorPosY(0, 0.5f);
    }

    public void OnTimerAdded()
    {
        dialScreenRT.DOAnchorPosY(screenHeight, 0.5f);
        mainScreenRT.transform.DOMoveY(0, 0.5f);
    }

    public void OnAddRestTime()
    {
        mainScreenRT.DOAnchorPosY(-screenHeight, 0.5f);
        dialScreenRT.DOAnchorPosY(0, 0.5f);
    }

    public void OnRestTimeAdded()
    {
        dialScreenRT.DOAnchorPosY(screenHeight, 0.5f);
        mainScreenRT.transform.DOMoveY(0, 0.5f);
    }

    public void OnExitButtonShow()
    {
        confirmButtonRT.DOAnchorPosX(-225, 0.5f);
        denyButtonRT.DOAnchorPosX(-375, 0.5f);
        buttonImage.DOFade(0.1f, 0.7f);
        
        DOTween.To(() => buttonShadow.effectDistance, x => buttonShadow.effectDistance = x, new Vector2(0,0), 0.5f);
        exitButton.interactable = false;
    }

    public void OnExitButtonHide()
    {
        confirmButtonRT.DOAnchorPosX(-75, 0.5f);
        denyButtonRT.DOAnchorPosX(-75, 0.5f);
        buttonImage.DOFade(1, 1f);
        DOTween.To(() => buttonShadow.effectDistance, x => buttonShadow.effectDistance = x, new Vector2(12, -12), 0.5f);
        exitButton.interactable = true;
    }
}
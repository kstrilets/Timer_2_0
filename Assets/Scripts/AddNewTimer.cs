using UnityEngine;
using UnityEngine.UI;


public class AddNewTimer : MonoBehaviour
{
    [SerializeField] GameObject HMSCanvas;
    [SerializeField] GameObject timersHolder;
    [SerializeField] GameObject timerButtonPrefab;
    [SerializeField] GameObject addTimerButtonPrefab;

    GameObject goAddTimer;

    private void Start()
    {
        TimerManager.Instance.AddStartTimers();

        foreach (var item in TimerManager.Instance.userTimers)
        {
            InitTimerButtons(item);
        }
        goAddTimer = Instantiate(addTimerButtonPrefab, transform.position, Quaternion.identity);
        goAddTimer.transform.SetParent(timersHolder.transform);
        goAddTimer.transform.localScale = Vector3.one;
    }

    void InitTimerButtons(int _item)
    {
        GameObject go = Instantiate(timerButtonPrefab, transform.position, Quaternion.identity);
        string strTime = Utils.HelperParseToString(_item);
        go.transform.GetChild(0).GetComponent<Text>().text = strTime;
        go.transform.SetParent(timersHolder.transform);
        go.transform.localScale = Vector3.one;
    }
    
    public void AddTimerButton(int _item)
    {
        GameObject go = Instantiate(timerButtonPrefab, transform.position, Quaternion.identity);
        string strTime = Utils.HelperParseToString(_item);
        go.transform.GetChild(0).GetComponent<Text>().text = strTime;
        go.transform.SetParent(timersHolder.transform);
        go.transform.SetSiblingIndex(go.transform.parent.childCount - 2);
        go.transform.localScale = Vector3.one;
    }

}
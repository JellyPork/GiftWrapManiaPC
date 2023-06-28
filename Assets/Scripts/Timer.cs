using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Timer : MonoBehaviour
{
    [Header("Timer UI references :")] [SerializeField]
    private Image uiFillImage;

    [SerializeField] private Text uiText;
    private int Duration { get; set; }
    private bool IsPaused { get; set; }
    private int _remainingDuration;

    // Events --
    private UnityAction _onTimerBeginAction;
    private UnityAction<int> _onTimerChangeAction;
    private UnityAction _onTimerEndAction;
    private UnityAction<bool> _onTimerPauseAction;

    private void Start()
    {
        UpdateUI(_remainingDuration);
        ResetTimer();
    }

    private void Update()
    {
        // init timer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDuration(10).OnBegin(() => Debug.Log("Timer begin"))
                .OnChange(seconds => Debug.Log($"Timer changed : {seconds}"))
                .OnEnd(() => Debug.Log("Timer end"))
                .OnPause(isPaused => Debug.Log($"Timer paused : {isPaused}"))
                .Begin();
        }
        UpdateUI(_remainingDuration);
    }

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;

        Duration = _remainingDuration = 0;

        _onTimerBeginAction = null;
        _onTimerChangeAction = null;
        _onTimerEndAction = null;
        _onTimerPauseAction = null;

        IsPaused = false;
    }

    public void SetPaused(bool paused)
    {
        IsPaused = paused;

        if (_onTimerPauseAction != null)
            _onTimerPauseAction.Invoke(IsPaused);
    }


    public Timer SetDuration(int seconds)
    {
        Duration = _remainingDuration = seconds;
        return this;
    }

    //-- Events ----------------------------------
    public Timer OnBegin(UnityAction action)
    {
        _onTimerBeginAction = action;
        return this;
    }

    public Timer OnChange(UnityAction<int> action)
    {
        _onTimerChangeAction = action;
        return this;
    }

    public Timer OnEnd(UnityAction action)
    {
        _onTimerEndAction = action;
        return this;
    }

    public Timer OnPause(UnityAction<bool> action)
    {
        _onTimerPauseAction = action;
        return this;
    }

    public void Begin()
    {
        _onTimerBeginAction?.Invoke();

        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (_remainingDuration > 0)
        {
            if (!IsPaused)
            {
                _onTimerChangeAction?.Invoke(_remainingDuration);
                _remainingDuration--;
            }

            yield return new WaitForSeconds(1f);
        }

        End();
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = $"{seconds / 60:D2}:{seconds % 60:D2}";
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    private void End()
    {
        _onTimerEndAction?.Invoke();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
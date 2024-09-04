using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private int startSecond = 3;
    private TextMeshProUGUI textMP;

    public static Action onTimerEnded;

    private void Start()
    {
        textMP = GetComponent<TextMeshProUGUI>();
        if (SceneManager.GetActiveScene().name != "Hub") return;
        onTimerEnded?.Invoke();
        gameObject.SetActive(false);
    }

    private IEnumerator TimerCoroutine()
    {
        for (int i = startSecond; i > 0; i--)
        {
            textMP.text = $"{i}";
            yield return new WaitForSeconds(1);
        }
        onTimerEnded?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EnemyGenerator.onGenerationEnded += () => StartCoroutine(TimerCoroutine());
    }
    private void OnDisable()
    {
        EnemyGenerator.onGenerationEnded -= () => StartCoroutine(TimerCoroutine());
    }
}

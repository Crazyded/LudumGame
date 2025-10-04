using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public Image fadeImage; // UI Image ��� ����������
    public float fadeDuration = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ����� ��� �������� � ������ ������� (����� ��� GameObject)
    public void ChangeRoom(GameObject roomToActivate)
    {
        StartCoroutine(TransitionCoroutine(roomToActivate));
    }

    private IEnumerator TransitionCoroutine(GameObject roomToActivate)
    {
        // ����������
        yield return StartCoroutine(FadeCoroutine(1f)); // Fade to black

        // ������������ ��� ������� (���� ��� ��� �������� �������)
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        // ���������� ������ �������
        roomToActivate.SetActive(true);

        // ���������� �����������
        yield return StartCoroutine(FadeCoroutine(0f)); // Fade to clear
    }

    private IEnumerator FadeCoroutine(float targetAlpha)
    {
        if (fadeImage == null) yield break;

        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }
    }
}
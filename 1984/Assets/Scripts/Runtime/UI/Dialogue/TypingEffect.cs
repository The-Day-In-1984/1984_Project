using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;

public class TypingEffect : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private string _currentText;
    private Coroutine _typingCoroutine;


    public bool IsTypingNull()
    {
        return _typingCoroutine == null;
    }
    public void Init(TextMeshProUGUI textMeshPro)
    {
        _textMeshPro = textMeshPro;
        textMeshPro.text = string.Empty;
    }

    public void StartTyping(string text)
    {
        if (!IsTypingNull())
        {
            SkipTyping();
        }
        else
        {
            _typingCoroutine = StartCoroutine(TypeText(text));
        }
    }

    public void SkipTyping()
    {
        // 타이핑 중인 텍스트를 바로 모두 출력합니다.
        StopCoroutine(_typingCoroutine);
        _textMeshPro.text = _currentText;
        _typingCoroutine = null;
    }

    private IEnumerator TypeText(string text)
    {
        // 타이핑 효과를 위해 한 글자씩 출력합니다.
        _currentText = text;
        _textMeshPro.text = string.Empty;

        for (int i = 0; i < text.Length; i++)
        {
            _textMeshPro.text += text[i];
            yield return new WaitForSeconds(0.02f / GameManager.UI.TextSpeed);
        }

        // 타이핑 완료 후, 코루틴을 null로 설정합니다.
        _typingCoroutine = null;
    }
}
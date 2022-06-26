using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _levelSlider;
    [SerializeField] private TMPro.TMP_Text _valueText;
    
    [SerializeField] private Color Positive; //5ABDF4
    [SerializeField] private Color Negative;

    [SerializeField] private ScoreSystem _score;

    private int _combo = 0;

    public void HideProgressBar()
    {
        gameObject.SetActive(false);
        _combo = 0;
    }
    
    public void UpdateLevel()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().SetTrigger("Hide");
        
        
        float share = _score.MaxLevel / 3;
        float curLevel = (float)_score.CharacterLevel % share;
        float ratio = curLevel / share;
        _levelSlider.fillAmount = Mathf.Abs(ratio);

        _combo += _score.CharacterLevel - _score.cache;
        _valueText.text = Mathf.Abs(_combo).ToString();

        _levelSlider.color = _score.CharacterLevel > 0 ? Positive : Negative;
        //if (_score.CharacterLevel > 0)
        //    _levelSlider.color = Positive;
        //else
        //    _levelSlider.color = Negative;
    }
}
using UnityEngine;

public class UIController : MonoBehaviour
{
    private static UIController Instanse;
    [SerializeField] private GameObject _startUI;
    
    private void Awake()
    {
        Instanse = this;
    }

    public void HideStartInterface()
    {
        _startUI.SetActive(false);
    }

    
}
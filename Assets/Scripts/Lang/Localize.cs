using UnityEngine;
using TMPro;
public class Localize : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public string source
    {
        get { return _source; }
        set { _source = value; }
    }

    [SerializeField] private string _source = "";
    [SerializeField] private bool isAwake = false;

    private void Start()
    {
        if (!isAwake)
            UpdateLabel();
    }



    public void UpdateLabel()
    {
        if (tmp == null)
        {
            tmp = GetComponent<TextMeshProUGUI>();
        }
        if(_source == "")
        {
            _source = tmp.text;
        }

        tmp.text = LangContainer.Instance.GetData(_source);
    }

}

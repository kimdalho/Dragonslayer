using UnityEngine;
using UnityEngine.UI;
using MasterySystem;
public class UiMasteryNodeBtn : UI_Base
{

    [SerializeField] 
    private int id;

    [SerializeField]
    private Image enableSprite;
    public Image icon;
    public Image slot;

    //다시 한번 검토
    //TableData가 존재하는데 이 데이터가 중복적으로 있어야하는가? 

    //문제 해결방법
    //1. NodeData의 다음 Next노드를 가리키는 구조를 분리 시킨다.
    //2. 분리된 데이터 구조만 맴버 클래스로 가지고있고 나머지 데이터는 TableContainer에서 불러온다.

    private MasteryNodeData data;


    
    Button showButton;
  
    public override void Init()
    {
        showButton = GetComponent<Button>();
        showButton.onClick.AddListener(OnClickShowButton);
        //data = TableContainer.Instance.masteryDataList[id];
        //#################################################
        //유저정보 불러와야함
    }
    private void OnClickShowButton()
    {
        if (data.use)
        {
            if (data.next == null)
            {
                Action(false);
                return;
            }

            if (data.next.use)
                return;

            Action(false);
        }
        else
        {
            if (data.canactivate)
            {
                Action(true);
            }
                
        }
    }

    private void Action(bool enable)
    {
        if (data.next == null)
        {
            Debug.Log("Last StatSkill Clicked");
            return;
        }
        else
        {
            data.next.canactivate = enable;
        }

        enableSprite.gameObject.SetActive(enable);
        data.use = enable;   
    }

    public MasteryNodeData GetData()
    {
        return data;
    }
}


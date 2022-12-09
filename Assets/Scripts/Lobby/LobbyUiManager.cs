using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
///  추후 각 UiManager단을 알수있는 상위 UiManager를 추가로 상속받는 구조로 변경해야한다.
/// </summary>
public class LobbyUiManager : Singleton<LobbyUiManager>
{
    [SerializeField] GameObject uiRoot;

    public delegate void OnEsapceEvent();

    [Header("Image")]
    public UiBackGround background_Image;

    [Header("Button")]
    public UiSettingButton setting_btn;
    public UiGamePlayButton gameplay_btn;

    [Header("Status")]
    public Status_Energy status_energy;
    public Status_Gem status_gem;
    public Status_Gold status_gold;
    public Stack<OnEsapceEvent> panel_stack;
    [Header("Mid")]
    public BowViewer bowView;

    [Header("Bottom")]
    [SerializeField]
    InvenButton invenButton;
    [SerializeField]
    UpgradeButton upgradeButton;
    [SerializeField]
    ShopButton shopButton;


    public List<Equip> EquopList;
    public Transform instantUi;
    public Queue<Str_ItemInfo> equipBuffer;



    public Transform root;


    public void Awake()
    {
        equipBuffer= new Queue<Str_ItemInfo>();
        panel_stack = new Stack<OnEsapceEvent>();
        setting_btn.Init();
        gameplay_btn.Init();
        background_Image.Init();
        status_energy.Init();
        status_gem.Init();
        status_gold.Init();
        bowView.Init();
        upgradeButton.Init();
        shopButton.Init();
        Global.Chainevent(eEventType.Language, OnEvent);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panel_stack.Count > 0)
        {
            panel_stack.Pop().Invoke();
        }
        curPanel.transform.localPosition = Vector3.Lerp(curPanel.transform.localPosition, Panel_pos[select], 0.1f);

        Debug.Log("curPanel.transform.position" + curPanel.transform.position);
        Debug.Log("Panel_pos[select]" + Panel_pos[select]);
        
        while(equipBuffer.Count > 0)
        {
            for(int i = 0; i < EquopList.Count; i++)
            {
                if (EquopList[i].isUse == false)
                {
                    Str_ItemInfo item = equipBuffer.Dequeue();
                    EquopList[i].Set(item);
                    break;
                }
                    
            }
            
        }

    }

    public Transform curPanel;
    public List<Vector3> Panel_pos;
    public int select = 1;
    public void OnClickInvenButton()
    {
        select = 0;
     
    }

    public void OnClickBowType()
    {
        select = 1;
    }


    public void OnClickUpgradeButton()
    {
        select = 2;
    }


    public void OnClickSetting()
    {
        select = 4;
    }


    public void OnEvent()
    {
        UpdateAllLabel();
    }


    public void UpdateAllLabel()
    {
        Localize[] langContainers = uiRoot.GetComponentsInChildren<Localize>(true);
        for (int i = 0; i < langContainers.Length; i++)
        {
            langContainers[i].UpdateLabel();
        }
    }
}
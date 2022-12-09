using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class BowViewer : UI_Base
{
    enum eBindImages
    {
        IconFrameImg = 0,
        lockIcon = 1,
    }

    enum eBindButtons
    {
        BowViewBtn = 0,
        LeftBtn = 1,
        RightBtn = 2,
    }

    enum eStatus
    {
        StatusAtk = 0,
        StatusSpeed = 1,
        StatusRange = 2,
    }

    enum eTmp
    {
        TitleTmp = 0,
    }

    public void Test()
    {
        t2est skill = new t2est();
    }
    public class t2est
    {
        public t2est()
        {
            //연출
            //연출2
            //연출3
        }

        ~t2est()
        {
         //디버그(해재되;었요~)  ;
        }

   }


    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(eTmp));
        Bind<BindImage>(typeof(eBindImages));
        Bind<BindButton>(typeof(eBindButtons));

        Bind<BindingStatus>(typeof(eStatus));
        Get<BindButton>("BowViewBtn").Init();
        Get<BindButton>("LeftBtn").Init(OnClickedLeftButton);
        Get<BindButton>("RightBtn").Init(OnClickedRightButton);

        Get<BindImage>("IconFrameImg").Init();
        Get<BindImage>("lockIcon").Init();

        
        Get<BindingStatus>("StatusAtk").Init();
        Get<BindingStatus>("StatusSpeed").Init();
        Get<BindingStatus>("StatusRange").Init();
        

        BowInfoData info = LoadInfo();
        RefreshUi(info);

    }

    private BowInfoData LoadInfo()
    {
        var loadData = PlayerPrefs.GetInt(ePPType.User_Bow.ToString(), -1);

        if(loadData == -1)
            loadData = 0;

        PlayerPrefs.SetInt(ePPType.User_Bow.ToString(), loadData);

        BowInfoData viewInfo = TableContainer.bowInfoDataMgr.GetBowInfoData((int)loadData);
        return viewInfo;
    }

    private void RefreshUi(BowInfoData viewInfo)
    {
        if (viewInfo.id != 0)
        {
            Get<BindingStatus>("StatusAtk").SetTmp("???");
            Get<BindingStatus>("StatusSpeed").SetTmp("???");
            Get<BindingStatus>("StatusRange").SetTmp("???");
            Get<TextMeshProUGUI>("TitleTmp").text = viewInfo.testName;
            Get<BindImage>("lockIcon").Show();
        }
        else
        {
            Get<BindingStatus>("StatusAtk").SetTmp(viewInfo.atk);
            Get<BindingStatus>("StatusSpeed").SetTmp(viewInfo.speed);
            Get<BindingStatus>("StatusRange").SetTmp(viewInfo.range);
            Get<TextMeshProUGUI>("TitleTmp").text = viewInfo.testName;
            Get<BindImage>("lockIcon").Hide();
        }


    }

    private void OnClickedLeftButton()
    {
        var loadData = PlayerPrefs.GetInt(ePPType.User_Bow.ToString(),1);
        loadData--;

        if (TableContainer.bowInfoDataMgr.BowInfoListExistData((int)loadData) == false)
            loadData = TableContainer.bowInfoDataMgr.BowInfoListCount() - 1;

        PlayerPrefs.SetInt(ePPType.User_Bow.ToString(), loadData);
        BowInfoData viewInfo = TableContainer.bowInfoDataMgr.GetBowInfoData((int)loadData);
        RefreshUi(viewInfo);
    }

    private void OnClickedRightButton()
    {
        var loadData = PlayerPrefs.GetInt(ePPType.User_Bow.ToString(), -1);
        loadData++;

        if (TableContainer.bowInfoDataMgr.BowInfoListExistData((int)loadData) == false)
            loadData = 0;

        PlayerPrefs.SetInt(ePPType.User_Bow.ToString(), loadData);
        BowInfoData viewInfo = TableContainer.bowInfoDataMgr.GetBowInfoData((int)loadData);
        RefreshUi(viewInfo);
    }
}

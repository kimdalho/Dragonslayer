# 방어와 공격을 함께한다! PvP 디펜스 게임 드레곤 슬레이어
## 혼자하는 디펜스 게임 멈춰!!✋ 내가 디펜스게임 고수다!

# 🗂 프로젝트 소개
- 개발 기간 : 2022.11.28 ~ 2022.12.10
- 개발 툴 : Unity
- 이외 툴 : Git / Notion / Figma / Slack / Trello
  <br />
<br />

<img width="400" src="https://user-images.githubusercontent.com/49323810/206891612-58054672-d562-48af-b9a5-a8a1ab002137.png">

<b>기술서 블로그</b> : https://helloworld0513.tistory.com/1 <br/>

# ✔ 핵심 기능

> ### 💬 타워 디펜싱과 공격을 함께는 1대1 실시간 멀티 플레이 시스템

- 지금 소환해야할 유닛을 신중히 선택하세요!
- 유닛의 소환도 중요하지만 당신의 타워를 지키는것도 잊지마세요!

  <br/>
> ### 🎰 복잡하지 않은 전략적 요소
> 
- 유닛은 각 고유한 속성을 가져요!
- 상대가 취하는 속성이 무엇일까요?
  
> ### 🗳 로그라이크 게임식 스킬 획득 시스템
  <br/>
- 한정적인 스킬 선택에서 최적이 무엇인지 고민하세요!
- 상대의 전략은 무엇일지 파악하세요!


  <br/>


# 🎥 데모


</details>
https://blog.kakaocdn.net/dn/eq2B1S/btrTqDb9heQ/wDfHunR7DXCc3a3Uf3YZA1/1.mp4?attach=1&knm=tfile.mp4
<br />
</details>
## 로비 씬
https://user-images.githubusercontent.com/49323810/207049525-160b3cf7-57c4-48d6-ac87-af387f0e3bc2.gif
<br />
# 🧩 아키텍쳐
</div>
<img width="400" src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2Fbtmvpr%2FbtrThOT344F%2FDCksbR6arzw1AVZ3jnZIvk%2Fimg.png">
<br />

# ⛔️ 트러블 슈팅

## 1. 포톤 CreateRoom 미동작 에러
포톤에서 지원해주는 함수의 존재여부를 알지못해 발생한 오류였습니다
OnConnectedToServer를 이용하여 Connect를 체크하였지만 해당 함수를 콜하지 못해 방을 생성하지않는 이슈였습니다.
다양한 트러블 슈팅과 도큐먼트를 찾아 override void OnConnectedToMaster() 함수를 포톤에서 지원해준다는것을 뒤 늦게 알게되었습니다.

 
```
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
        Debug.Log("연결");
    }

    private void OnConnectedToServer()
    {
        
    }
```


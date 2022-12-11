# 방어와 공격을 함께한다! PvP 디펜스 게임 드레곤 슬레이어
## 혼자하는 디펜스 게임 멈춰!!✋ 내가 디펜스게임 고수다!

# 🗂 프로젝트 소개
- 개발 기간 : 2022.11.28 ~ 2022.12.10
- 개발 툴 : Unity
- 이외 툴 : Git / Notion / Figma / Slack / Trello
  <br />
<br />

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

# 🧩 아키텍쳐


</div>
<br />

# ⛔️ 트러블 슈팅

## 1. 채팅방 입력 메세지 미출력 에러
<details>
 

<br/>

## 2. 모바일 토론방 이용중 홈버튼 및 화면전환시 에러 발생
<details>
  <summary>펼치기</summary>
    
서비스를 배포하고 실제 유저들이 사용중에 발견한 에러입니다😰<br/>
기존에는 컴포넌트가 언마운트 될 때, beforeunload 이벤트를 이용해 브라우저가 새로고침 될 때, 닫힐 때
disconnect신호를 서버에 전달하였으나, 모바일 환경에서 다시 문제가 발생하였습니다.

<br/>

> ### 1. 에러 현상

* 모바일 환경에서 탭 이동, 홈버튼, 화면 전환 버튼 클릭 시, 해당 채팅방이 종료될 때까지 유저가 다시 채팅방에 입장할 수 없는 심각한 오류를 발견하였습니다.

  ```javascript
  React.useEffect(() => {
    window.addEventListener("beforeunload", (e) => {
      client.disconnect(() => client.unsubscribe("sub-0"), headers);
    }); // 브라우저를 새로고침 하거나 종료하면 disconnect신호 보냄

    return () => {
      client.disconnect(() => client.unsubscribe("sub-0"), headers);
    };
  }, []);
  ```

  기존에 사용하던 disconnect코드<br/><br/>

> ### 2. 원인

* 서버에서 동일한 유저의 채팅방 다중 입장을 차단하고 있기 때문에, 탭 이동, 홈버튼, 화면 전환 버튼 클릭 시 서버
disconnect 미작동으로 인해 해당 유저가 채팅방에 남아있는걸로 인식되었습니다.<br/><br/>

> ### 3. 해결코드
* visibilitychange 이벤트를 연결해 현재 화면이 보이고 있는지 visibleHendler함수를 만들어 판단 후 disconnect신호를 서버에 보내줌

  ```javascript
  useEffect(() => {
    if (!messageLoaded) return;

    connectSocket(roomId, headers, client);
    // 메세지 로딩이 끝나면 소켓 서버에 연결

    window.addEventListener("beforeunload", (e) => {
      client.disconnect(() => client.unsubscribe("sub-0"), headers);
    }); // 브라우저를 새로고침 하거나 종료하면 disconnect신호 보냄

    const mobile = mobileCheck();
    mobile && window.addEventListener("visibilitychange", visibleHendler);
    // 모바일 환경에서 탭 전환이나 화면 전환시 disconnect신호를 보내지 못해 발생하는 오류 해결을 위해 사용

    return () => {
      client.disconnect(() => client.unsubscribe("sub-0"), headers);
      mobile && window.removeEventListener("visibilitychange", visibleHendler);
    };
  }, [messageLoaded]);

  const visibleHendler = (e) => {
    const state = document.visibilityState === "hidden"; // 화면에 안보이면

    if (state) {
      client.disconnect(() => client.unsubscribe("sub-0"), headers);
      history.replace("/");
      dispatch(
        alertAction.open({
          type: "confirm",
          message: "채팅방에 다시 입장하시겠습니까?",
          action: () => history.push("/chatroom/" + roomId),
        })
      );
    }
  };
  ```
  <br/>
</details>

<br/>

## 3. 채팅방 타이머 시간이 어긋나는 문제
<details>
  <summary>펼치기</summary>
최초 채팅방 타이머는 서버로 부터 남은 시간을 받아 setInterval을 사용해 1초씩 빼주었습니다.
하지만 이런 방식은 여러가지 문제가 발생하였습니다.

<br/>

  > ### 원인
  * setInterval이 1초마다 실행된다는 보장성이 없다.
  * alert, confirm등 브라우저가 멈추면 타이머도 멈춰 시간이 어긋난다

  <br/>

  > ### 해결
  * 일단 alert이나 confirm이 브라우저를 멈춘다면 사용하지 않으면 된다고 생각하여,<br/>직접 redux와 portal을 이용해 만들어 사용하였습니다.<br/><br/>
  그리고 서버로부터 채팅방의 종료예정시간을 받아 현재 시간과 비교하며 얼마나 남았는지 계산, useInterval커스텀 훅을 사용하여 1초마다 정보를 갱신해주었습니다.

    ```javascript
    const CountDownTimer = (props) => {
      const dispatch = useDispatch();

      const end = new Date(props.endAt.replaceAll("-", "/")); // 해당 채팅방 종료 시간
      const now = new Date(); // 현재 시간

      const [time, setTime] = useState((end - now) / 1000 + 1);

      useInterval(() => setTime((end - now) / 1000), time);

      useEffect(() => {
        if (time <= 0) {
          history.push("/");
          dispatch(
            alertAction.open({
              message: "토론이 종료되었습니다.",
            })
          );
          return;
        }
      }, [time]);

      // 분이랑 초로 변경
      const minutes = Math.floor(time / 60);
      const seconds = Math.floor(time % 60);

      return (
        <Timer restTime={time < 60 && true}>
          <Minutes>{minutes.toString().padStart(2, "0")}</Minutes> :
          <Seconds>{seconds.toString().padStart(2, "0")}</Seconds>
        </Timer>
      );
    };
    ```
    https://haekang.notion.site/setInterval-useInterval-d62a416e2db147c48ef5304de44a23f3

<br />
</details>

<br/>

# 👨‍👨‍👦‍👦 유저 피드백

>  ### 피드백 수집일자 : 2022년 3월 28일 ~ 2022년 4월 4일 <br />
>  ### 피드백 수 : 총 22개

<br />

<details>
  <summary>피드백 내용 확인</summary>

- 긍정적인 피드백
  - 채팅에서 논리로 이겨버리고 받은 포인트로 랩업해서 랭킹 1등했어요!
  - 행운뽑기 기능이 신박하고 도박요소가 있어서 재밌었습니다 ㅎㅎ 그리고 아이템 구매하는 창에서 하나씩 어떤 기능인지 설명해줘서 좋았어요 1조 분들 너무너무 고생하셨습니다.
  - DALK를 프로젝트를 준비하며, A가 좋을까 B가 더 나은 것은 아닐까. 가장 많이 고민하고 또 토론한 분들이 운영진 분들이시겠다는 생각이 들었습니다. 정말 수고 많으셨고, 앞으로 나아가실 길도 진심으로 응원하겠습니다. 모두 건강 잘 챙겨가면서 하시길 바라며.. 좋은 서비스 만들어주셔서 감사합니다🙆‍♀️
  - 아이디어 좋은거 같아요 사용자가 많아지면 더재밌게 채팅할 수있을 거같아요! 번창하시길 바랄게요!
    
    <br />

- 개선에 대한 피드백
    > 다양한 기능을 써보고 싶어도 어디에 어떤 기능이 있는지 모르겠어요. 
    
    - 사용자의 이용률과 경험만족도를 끌어올리기 위해 투표창 인식을 위한 UI 개선을 진행, <br />
    처음 방문한 사용자들을 위해 메인배너에 사용방법창으로 갈 수 있는 캐러셀을 추가

        |배너 캐러셀|투표창 초기 펼침|
        |:-:|:-:|
        |<img src ="https://user-images.githubusercontent.com/96935557/161725645-2e16ebae-b03d-4bf4-aeed-06603f7097be.png">|<img src ="https://user-images.githubusercontent.com/96935557/161725952-1705eddd-21d9-4d5b-a32d-960f4ee81f6d.png">|


        <br />
        <br />
    > 아이폰 모바일 화면은 뷰가 깨져 보여요.
    
    -  리사이즈 Event를 통해 화면크기를 실시간 계산 후 적용하는 과정을 통해서 모든 모바일 뷰 화면을 깨짐없이 개선 <br />

        ```Javascript
        const MobileFrame = ({ children }) => {
          const handleResize = () => {
            const vh = window.innerHeight * 0.01;
            document.documentElement.style.setProperty("--vh", `${vh}px`);
          };

          useEffect(() => {
            handleResize();
            window.addEventListener("resize", handleResize);

            return () => window.removeEventListener("resize", handleResize);
          }, []);

          return (
            <MobileContainer>
            <MobileWrap id="globalPortal">
                <MobileContent>{children}</MobileContent>
            </MobileWrap>
            </MobileContainer>
          );
        };
        ```

        <br />
    > 채팅방이 너무 좁아서 한눈에 토론내용을 보기 어려워요.
    - 헤더를 통합하여 채팅창을 넓게 만들어 사용자들의 불편사항 개선

        |개선 전|개선 후|
        |:-:|:-:|
        |<img src="https://user-images.githubusercontent.com/96935557/161725088-df287b72-2cd5-4724-842d-22b6ed015591.png">|<img src="https://user-images.githubusercontent.com/96935557/161725389-8c3cc822-1549-4bc2-b8bd-dfd474b7e2cf.png">|
</details>

<br />

# 🤝 후기 및 회고

<code>전해강</code> <br />
끝나지 않을 것 같았던 항해 마지막 프로젝트를 좋은 팀원분들 만나 함께 할 수 있어서 재밌었습니다..! <br />
여러분들 앞으로 하시는 일 다 잘되시고 꽃길만 걸으시길 바랍니다🌸

<code>차민재</code> <br />
실전 프로젝트를 진행하고 클린 코드의 중요성과 자바스크립트의 이해도를 높여야겠다는 생각을 했습니다. <br />
이제부터 나의 목표는 JS엔진 심장에 박기.. <br />
열심히 해준 모든 팀원들 덕분에 좋은 결과물이 나온 것 같고, 특히 저에게 도움을 많이 주셨던 해강님에게 무한의 감사를🙏

---

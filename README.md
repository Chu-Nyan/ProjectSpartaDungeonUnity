![](https://velog.velcdn.com/images/jwn7003/post/2b4f8b40-d66f-4ee2-8b65-849989a06f7b/image.PNG)

### 🔨 선택 과제 : 스파르타 던전 - Unity 버전! 
#### 이름 : 노재우(A09)



### **🔨 필수 요구 사항**

📌 **메인 화면 구성**

+ 아이디, 레벨, 골드 ⭕
+ Status 보기 ⭕
+ Inventory 보기 ⭕



### **🔨 선택 요구 사항** 

- 아이템 장착 팝업 업그레이드 ❌
- 상점 기능 ❌

---

![](https://velog.velcdn.com/images/jwn7003/post/0ba07f7c-dbca-44b8-9bb6-306c4a8a9f89/image.png)

먼저, 다이어그램은 많이 미숙하니 비거나 틀린 부분이 있을 수도 있습니다.<br>
기본적인 게임 흐름은 예제와 거의 동일하고 플레이시 왼쪽 상단에 디버그 할 수 있게
경험치와 골드 추가, 아이템 추가 기능이 있습니다.<br>
중간중간 지금 기능에서 사용되지 않는 기능들도 있는데 시간이 부족하네요 하하..<br>


그리고 질문할 사항들은 맨 밑에 정리해서 적어두고 **_#0_** 이렇게 본문에도 살짝 표시해두겠습니다 😄<br>

필수 요구 사항을 `MVC 패턴`에 집중해서 만들어 보았습니다.<br>
 HUD부분은 옛날 MVC 모델, 다른 UI는 Cocoa MVC모델입니다.<br>



📌 1. Status보기, HUD, 옛날 MVC 모델
![](https://velog.velcdn.com/images/jwn7003/post/71277ac2-c81e-499b-9f90-74eb82b29994/image.png)![](https://velog.velcdn.com/images/jwn7003/post/6cc2aec3-43d9-4e0e-b5de-02e8f769e54b/image.png)

**_#1_** 이 구조가 요즘 사용하는 MVC 패턴인 줄 알았는데 아닌 거 같더라고요..<br>
일단은 만들었으니 따로 수정은 안하였습니다.<br>
플레이어 컨트롤러는 현재 게임 구조상 없기에 UIController에 맨밑에 함수 경험치, 골드추가 함수가 있습니다.<br>
위에서 말한 디버그용 기능입니다.<br>

플레이어 컨트롤러에서 모델의 프로퍼티를 호출하여 인자값을 전달합니다.<br>
**_#2_**그럼 모델에서 그 값을 처리하고 HUD로 전달하여 HUD는 모델을 참조하여 화면을 갱신합니다.<br>

📌 2. Inventory 보기, HUD빼고 모든 UI와 UIcontroller사용 , Cocoa MVC모델
![](https://velog.velcdn.com/images/jwn7003/post/cab0277a-7fee-46f9-b6ba-8c9dc6e8eec7/image.png)

아이템을 착용하는 방법을 나타내었습니다

이벤트 트리거는 어디다 두어야할지 몰라서 UI에 넣고 작성하였습니다.<br>
**_#2_** 1번과 다르게 호출할 때 필요한 인자들도 같이 보냈습니다.<br>
평소에는 리스트로 착용한 장비를 만들었는데 이번에는 딕셔너리도 한 번 사용 해보고싶어서 큰 의미없이 사용하였습니다.<br>
착용 부위는 현재 7개가 있는데 종류가 3개라서 3개만 사용할 수 있습니다. <br>
코드로 생각해봐서는 추가 아이템 만들어도 잘 작동할 것 같습니다.<br>
활은 양손이기에 착용시 좌우에 있는 무기가 다 없어지도록 만들었습니다.<br>
아이템 파괴후 화면을 갱신할 때 두 번째 인자값으로 `true`를 주는데 컨트롤러를 통해 슬롯 데이터 교체까지 진행하게 했습니다.

---
마지막으로 코드를 작성할 때 의문이 들었던 점들입니다.<br>
과제 제출 문서에는 마감 1분전이라 작성을 하지 못했습니다.. 😔<br>

#1 cocoa MVC는 정확한 자료가 있는데 1번 MVC도 MVC가 맞나요?<br>
웹에서는 두 가지 모델의 개념이 막 섞여서 돌아다니네요..<br>

#2 1번과 2번의 차이점 중 하나는 데이터를 어떻게 불러오냐인데
1번은 호출 함수에서 매니저를 통해 직접 참조할 데이터에 접근합니다.<br>
2번은 호출 함수의 인자값을 통해서 전달합니다.<br>
2번으로 하는게 객체지향? 프로그래밍에 가깝나요? 혹은 올바른 방법인가요?<br>

마지막으로 가장 중요한 부분인데 제가 작성한 코드들이 MVC패턴이 맞긴한가요?<br>

---
긴 글과 더욱 긴 코드를 읽어주셔서 감사합니다.<br>
제가 설명을 잘못하는데 유사 한국어인 부분이 있어 이해하기 힘드시다면 불러주세요.<br>
버선발로 뛰어가겠습니다.<br>
좋은 하루 보내세요 튜터님👍

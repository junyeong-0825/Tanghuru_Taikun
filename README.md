탕후루 타이쿤
=============
본 문서는 탕후루 타이쿤에 대한 기능을 설명하기 위한 문서 입니다.
문서는 기능을 만든 사람들이 함께 작성하고 있으며, 본인이 개발한 기능에 대한 설명이 포함됩니다.

* * *
맡은 기능 (만든사람)
---
설명




### 플레이어 이동 및 상호작용 관련 기능 구현 [유준영]
---

##### 1. 캐릭터 이동기능 구현

- InputSystem을 이용하여 wasd키를 입력받고 방향에 따라 캐릭터가 이동하도록 구현
  
	-> 플레이어 이동속도는 고정
- 키보드 입력에 따라 (움직이는 방향) 플레이어 스프라이트가 상,하,좌,우로 향하도록 변경
- 타이쿤이라는 게임 특성상 점프 기능은 불필요하다고 느껴 팀원과 소통 후 구현하지 않음

#### 2. 플레이어의 오브젝트 상호작용 기능 구현

- Tab 키 입력으로 인벤토리 UI On/Off 하도록 함
- 플레이어 스프라이트가 바라보는 방향에 따라 Ray가 향하는 방향이 변경되도록 구현
- 특정 LayerMask를 가진 오브젝트만 Raycast가 적용되도록 구현
- 상호작용 가능한 오브젝트가 Ray의 최대거리 이내로 들어와 인식되면 해당 오브젝트 위치에 PromptText가 출력되도록 구현하였고 떨어지면 Text가 사라지도록 함
- Text출력 후 Space키 입력시 오브젝트에 붙어있는 Tag에 따라 기능수행하도록 구현
  
	-> 추가로 Space키 입력시 오브젝트 위치에 이펙트가 생성되고 효과음 들리도록 

#### 3. 상호작용으로 인한 플레이어 Data 변경 로직 구현 

- 플레이어를 싱글톤화 하여 관련 Data와 Method를 쉽게 접근하도록 
- 플레이어가 소지할 수 있는 재료와 아이템 종류를 Enum과 Public 변수로 선언
- 상호작용키 입력시 전달받는 매개변수를 통해 플레이어가 재료, 아이템을 획득하거나 소비하도는 과정 로직을 구현함
  
	-> Cooking(Resources.RESOURCE1, 30) 은 재료 1번을 30개 소비하고 아이템 1번을 30개 얻음 
#### 0. 기타 구현사항

- 게임 플레이에 필요한 기본적인 UI 요소들 임시로 구성
	-> 옵션버튼, 사운드토글버튼, 플레이어 재화 UI, Quest 버튼, 플레이어 LV UI
	-> 옵션 내부의 소리조절 슬라이더, 게임재생 및 홈키 버튼 등
-  배경음악 및 효과음, 이펙트 등의 요소 사용기능 구현 (EffectManager)
-  
<br>
<br>

---
<br>

### 아이템과 인벤토리 상호작용 [안석환]
---
<br>

##### 1. 아이템 생성
<br>

- 아이템 SO: 구성(이름, 설명, 아이템 타입(재료, 완성품), 아이콘, 아이템이 스태킹
- 아이템과 인벤토리 상호작용 기능 구현: 상호작용시 인벤토리에 인스턴스 추가 및 원 객체 파괴
<br>

#### 2. 인벤토리 기능구현
<br>

- 인벤토리에 아이템 유아이 기능 구현(아이템 담기, 빼기)
- 인벤토리 토글 기능
- 인벤토리와 아이템이 상호작용 했을 때 기능구현(인벤토리UI 객체 정보담기 등)

<br>
#### 3. 플레이어와 인벤토리의 상호작용 기능 구현
<br>

- 아이템과 플레이어의 상호작용 내용 구성(임시로 부딧혔을 때로 구현)
<br>

#### 0. 기타 구현사항
<br>

- 인벤토리, 아이템, 맵등 임시 UI

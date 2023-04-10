
# **1984**

> 브릿지 11기 정규 프로젝트 레포지토리입니다.

## **프로젝트 소개**

게임 이름:  
게임 장르:  
플랫폼:  
개발 엔진:  
게임 소개:  

## 프로젝트 구조

1. 프로젝트 폴더 구조
2. 프로젝트 시스템 구조
3. 프로젝트 진행 방식
4. ETC

<details><summary>프로젝트 구조</summary>
<p>

### 유니티 폴더 구조

- https://github.com/The-Day-In-1984/1984_Project/issues/13

해당 이슈를 참고

### 프로젝트 시스템 구조

파트 회의를 통해 각자 필요하다고 생각하는 시스템 담당

- https://github.com/The-Day-In-1984/1984_Project/discussions/26

해당 내용을 기반으로 아래와 같이 분배

- https://github.com/The-Day-In-1984/1984_Project/issues/27

### 프로젝트 진행 방식

Root기준으로 [Proceedings](https://github.com/The-Day-In-1984/1984_Project/tree/main/Proceedings)폴더에 프로그래밍 회의록이 작성됩니다.

Root기준으로 [1984](https://github.com/The-Day-In-1984/1984_Project/tree/main/1984)폴더는 Unity폴더입니다

#### Issue

![image](https://user-images.githubusercontent.com/84510455/226410817-0c80a98d-c4e8-4ee1-aa77-909a1c2631a1.png)

이슈는 작업을 트래킹하기 위해 사용합니다.

**최대한 자세하게 작성하기!**

이슈에 들어가는 내용은 개발 예정 기능, 개발 중인 기능, 발생한 버그 등이 작성됩니다.

현재 제작된 템플릿 두개(기능, 버그)를 사용하여 작성해주시면 됩니다.

이미지와 같이 가장 큰 분류부터 트리형식으로 작성해주시면 됩니다.

*읽고 바로 작업이 가능한 분류까지 세분화하는게 좋습니다.*

작업을 이슈로 두는 이유는 작업 자체를 **세분화**하고 해당 작업을 **추적** 및 **바인딩**하기 위함입니다.

*현재 레포에서 해당 이슈로 브랜치를 만들어서 기능을 완수하는 목적성을 지님*

만약 해당 이슈대로 작업이 되지 않고 변동 사항이 있을 때는 이슈도 같이 수정해주시면 됩니다.

#### Pull Request

![image](https://user-images.githubusercontent.com/84510455/226414237-41c6e5bd-4c27-462e-9cbb-6c6c09ddeb73.png)

1. Reviewers: 자신을 제외한 팀원(리뷰 인원)
2. Assigness: 확인자, 해당 풀리퀘 작성자
3. Labels: 해당 기능에 맞게.. 추가 기능인지, 버그인지
4. Development: 해당 기능 이슈를 바인딩하여 자동으로 연동

풀리퀘는 이슈에 작성된 내용 즉, 기능 브랜치를 main으로 병합할 때 사용

1. 각 시스템은 독립적이기 때문에 해당 기능에 맞는 브랜치를 사용
2. 종속적인 기능 ex)Manager는 해당 브랜치로 전환하여 작성 후 병합
3. 풀리퀘가 생성되면 리뷰를 남은 사람을 등록하고 가능하다면 코드 리뷰형식으로 진행

풀리퀘도 이슈와 같은 작성방식을 가져감  

해당 이슈와 바인딩하여 작성, 내용은 상세하게 바로 병합하지 않고 리뷰를 받고 확인되면 병합

**코드리뷰**

풀리퀘가 생성되면 아마 이메일, 깃헙 notification을 통해 알림이 옵니다.(리뷰로 걸면)

해당 풀리퀘에 들어가면 오른쪽 위에 Review가 있습니다.

리뷰가 필요한 코드가 있다면 해당 코드를 드래그하여 리뷰를 남기거나 없다면 Review changes를 클릭하여 리뷰를 남깁니다.

Comment: 리뷰를 남기고 병합을 허용
Approve: 리뷰를 통과하고 병합을 허용
Request changes: 리뷰를 통과하지 못하고 병합을 거부

리뷰를 남기고 병합을 허용하면 해당 풀리퀘는 병합이 가능합니다.

가능하다면 리뷰를 남기는 것이 좋습니다..!

*Git Flow를 참고*

#### 종속적인 기능을 작업할 때

거의 발생하지 않겠지만 Manager의 경우 API를 추가하여 연결하는 작업의 경우..  

앞서 말한 해당 브랜치로 전환 후 Manager작업 후 현재 브랜치에 병합할 것.

나머지도 같은 형식으로 진행

#### Discussion

![image](https://user-images.githubusercontent.com/84510455/226415257-b54e4672-bb78-4351-89ec-4ec193aa327b.png)

이슈에 적지 못하는 토론 내용을 작성

이야기가 필요한 내용 현재 프로젝트에 도움이 되는 자료, 해결해야 하지만 이야기가 필요한 내용 등등을 작성해주시면 됩니다.

작성방법은 직관적이라 idea, QnA등 해당 내용에 맞게 작성 부탁드립니다.



### ETC

#### 회의록

*예시*

![image](https://user-images.githubusercontent.com/84510455/226413835-62ac4004-60ae-4cdc-9122-d7e4097ea694.png)

특별한 일이 없다면 대부분 전체 회의가 끝나고 **플밍회의**를 진행합니다. 테이블은 동일

한 주 동안 진행한 사항에 대하여 이야기, 회고를 진행합니다.

*어느정도 틀이 잡히면 2주로 전환*

</p>
</details> 

## 과거 작성 내용

<details><summary>legacy Issue</summary>
<p>

프로젝트 사용 방법

- https://github.com/The-Day-In-1984/1984_Project/issues/17
- https://github.com/The-Day-In-1984/1984_Project/discussions/39

</p>
</details> 
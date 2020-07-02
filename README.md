# 2020GameEngine

2012180007 김동순     E-Mail - eutteumiyo@naver.com





에셋스토어에서 다운 받은 에셋들
1. 호수 맵 : https://assetstore.unity.com/packages/3d/environments/roadways/lake-race-track-55908
2. 유니티 제공 차 스텐다드 에셋 : https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2017-3-32351
3. 기름통 아이템 : https://assetstore.unity.com/packages/3d/props/oil-cans-841
4. 계기판 png : https://m.bobaedream.co.kr/board/bbs_view/national/1658665

게임소개
Road Racer는 시간의 흐름에 따라 연료량이 줄어들고
연료량이 0이 되면 게임 오버되는 게임입니다.
연료는 트랙에 랜덤한 위치에서 생성되고 연료를 먹게 되면
플레이어의 연료의 양이 늘어나고 UI로 표시됩니다.
연료 아이템은 시간에 따라 총 30개가 생겨나며 30개를 모두 먹으면
게임에서 승리합니다.

조작방법
w -> 가속페달 (엑셀)
s  -> 브레이크 및 후진
a  -> 왼쪽으로 방향 틀기
d  -> 오른쪽으로 방향 틀기

적용된 기술 
코루틴 함수 (연료 아이템 생성 시)
카메라 2대 사용 (카메라를 2대 배치하고 Depth와 위치 조절)
스크립트를 통한 UI 변화 (시간에 따라 연료 UI가 사라져가고 아이템을 먹을 시 채워짐)
플레이어 차와 아이템이 닿으면 아이템이 사라짐
스크립트를 참조해 값을 화면 상 표시


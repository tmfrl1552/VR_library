using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Search //처음 query시 나온 결과
{
	public string version;
	public string title;
	public string link;
	public string pubDate;
	public string imageUrl;
	public string totalResults;
	public string startIndex;
	public string itemsPerPage;
	public string query;
	public string searchCategoryId;
	public string searchCategoryName;
	public Book[] item;
}

[System.Serializable]
public class Book // Search class -> item 배열에 있는 결과(도서에 대한 데이터)
{
	public string title; 
	public string link;
	public string author;
	public string pubDate;
	public string description;
	public string creator;
	public string isbn;
	public string isbn13;
	public string itemId;
	public string priceSales;
	public string priceStandard;
	public string stockStatus;
	public string mileage;
	public string cover;
	public string categoryId; 
	public string categoryName; 
	public string publisher; 
	public string customerReviewRank;
	public void coverReplace(){this.cover = this.cover.Replace("sum", "500");}
}




public class categoryAPI : MonoBehaviour
{
	private const string apiurl= "http://www.aladin.co.kr/ttb/api/ItemSearch.aspx?ttbkey=ttbanny5051756001&QueryType=Title&MaxResults=1&start=1&SearchTarget=Book&output=js";
	public string[] Titles = new string[54];
    //public static categoryAPI abcd;
	public static string[] college = 
	{ "&Query=스마트 경영학", "&Query=마케팅 조사론", "&Query=거시금융경제학",
		"&Query=생산운영관리", "&Query=지배권력과 경제번영", "&Query=Financial Management", 
		"&Query=통계학 : 기본개념과 원리","&Query=문화 마케팅 입문","&Query=경영정보시스템 4차"
		,"&Query=마이크로전자회로", "&Query=쉽게 배우는 기계공학 개론", "&Query=컴퓨터 구조 및 설계", 
		"&Query=최신 표면처리공학", "&Query=대학생을 위한 공학윤리", "&Query=기초부터 배우는 건축시공", 
		"&Query=명품 C++ Programming","&Query=소프트웨어와 컴퓨팅 사고","&Query=핵심 화학반응공학",
		"&Query=연필로 쓰는 광고기획론", "&Query=여론의 법정에서", "&Query=장애인 복지정책과 실천", 
		"&Query=인공지능 시대의 사회학적 상상력", "&Query=사회과학 연구방법론", "&Query=커뮤니케이션을 공부하는 당신을 위하여", 
		"&Query=현대사회와 미디어","&Query=국제협상의 이론과 실제","&Query=사무관리론"
		,"&Query=최신 광학개론", "&Query=캠벨 생명과학", "&Query=유전학의 이해", 
		"&Query=생생한 사례로 배우는 확률과 통계", "&Query=아시모프의 천문학 입문", "&Query=대기과학 에센스", 
		"&Query=우리 주변의 화학물질","&Query=생명환경과학","&Query=기초 정수론",
		"&Query=표준국어문법론", "&Query=대학 기초 영문법", "&Query=풀어쓴 대학한문 : 초급편 ", 
		"&Query=라틴어 첫걸음", "&Query=글로벌 스페인어", "&Query=아랍어 통번역 입문편", 
		"&Query=초급 프랑스어","&Query=기초 포르투갈어","&Query=외국어와 통역.번역",
		"&Query=현대 심리치료와 상담 이론", "&Query=식품포장학", "&Query=새로 쓰는 소비자의사결정", 
		"&Query=근골격 해부학", "&Query=고급 영양학", "&Query=현대인과 패션", 
		"&Query=한 눈에 알 수 있는 약리학","&Query=범죄수사법 실무","&Query=민사소송법 (김홍엽)"
	};
	public static string[] fam = 
	{ "&Query=2020 짠테크 가계부", "&Query=카카오프렌즈 머니북", "&Query=가정을 변화시키는", 
		"&Query=욜로 패밀리", "&Query=엄마와 딸 사이", "&Query=나는 왜 가족이", 
		"&Query=남편 수업","&Query=가족을 변화시키는","&Query=아는만큼 행복이 커지는",
		"&Query=고양이가 좋아하는 청소", "&Query=정성스럽게 혼자 삽니다", "&Query=미니멀 라이프 물건 관리와", 
		"&Query=1일 1분 정리법", "&Query=초절약 살림법", "&Query=알뜰 살림 상식사전", 
		"&Query=심플하게 정성껏","&Query=천연 세제 생활","&Query=살림 뭐든지 혼자 잘함",
		"&Query=하우스 인테리어", "&Query=홈 인테리어 위빙", "&Query=라이프 인테리어가 있는 집", 
		"&Query=유럽의 리빙 플레이스", "&Query=젊은 전원 주택", "&Query=더 베스트 리빙 가이드", 
		"&Query=원룸 생활자를 위한 첫","&Query=고양이를 위한 집 만들기","&Query=안 부르고 혼자 고침",
		"&Query=700만이 뽑은 대한민국", "&Query=희동이네 쌀베이킹", "&Query=인스타그램 빅히트 레시피", 
		"&Query=오늘, 양식 하다", "&Query=매직 파스타", "&Query=고기굽기의 기술", 
		"&Query=백종원이 추천하는 집밥","&Query=맛있는 계란 요리","&Query=에어프라이어 요리 마스터북",
		"&Query=한입에 주간 도시락", "&Query=우리 가족 캐릭터 데코", "&Query=무적의 샌드위치", 
		"&Query=식빵을 맛있게 먹는", "&Query=밀프렙 샐러드", "&Query=유민주 파티시에의", 
		"&Query=스콘 수업","&Query=하루하루, 홈카페","&Query=칵테일 도감",
		"&Query=옷으로 마음을 만지다", "&Query=구두 손질의 노하우", "&Query=빈티지 맨즈 웨어",
		"&Query=약사 버블워니의 DIY", "&Query=아름답고 특별한 비누 레시피", "&Query=여드름 셀프케어", 
		"&Query=스킨케어 바이블","&Query=머리 묶기 헤어스타일링","&Query=쇼트 네일 아트"
	};
	public static string[] health = 
	{ "&Query=생활습관만 바꿨을", "&Query=병리학 이야기", "&Query=내 몸에 이로운 식사를", 
		"&Query=4대 만성병 자연치유", "&Query=어지럼증 바로알기", "&Query=환자 주도 치유 전략", 
		"&Query=시크릿! 건강 핸드북","&Query=35세부터 치아 관리","&Query=비우고 낮추면 반드시",
		"&Query=아무튼, 요가", "&Query=게으른 요가", "&Query=죽기 전까지 병원 갈 일", 
		"&Query=관절은 늙지 않는", "&Query=올어바웃바디", "&Query=밤의 요가", 
		"&Query=1일 2분 스트레칭","&Query=중요한 건 제대로 걷기다","&Query=새우등과 거북목은",
		"&Query=바다낚시 첫걸음", "&Query=내 인생의 첫 골프 수업", "&Query=클라이밍 교과서", 
		"&Query=등산 마운티니어링", "&Query=바다의 파도에 몸을 실어", "&Query=시바리나의 발레", 
		"&Query=자전거의 모든 것 81가지","&Query=당구 300 교과서","&Query=초보자도 쉽게 배우는 스키비법",
		"&Query=딴짓거리 EASY", "&Query=이 문제 풀 수", "&Query=두뇌가 좋아하는 스도쿠 2", 
		"&Query=가로세로 낱말 상식까지", "&Query=멘사 추리 퍼즐 1", "&Query=판타스틱 미로 여행 30선", 
		"&Query=미술 용어 퍼즐","&Query=미니 바둑 퍼즐","&Query=왕초보 장기 첫걸음",
		"&Query=반려견 홈케어", "&Query=고양이처럼 생각하기", "&Query=스티커 컬러링 반고흐", 
		"&Query=스티커 아트북 트래블", "&Query=애뽈의 숲소녀 컬러링북", "&Query=작고 예쁜 그림 한 장", 
		"&Query=타로카드 올바른 안내서","&Query=카메라, 시작해보려","&Query=갤럭시로 찍다",
		"&Query=여름 손뜨개", "&Query=가방 패턴 만들기", "&Query=리본코사지와 리본소품",
		"&Query=로버트 랭의 종이접기", "&Query=테이프 공예", "&Query=봄여름가을겨울 꽃자수", 
		"&Query=시얀의 플라워 레슨","&Query=텃밭 농사 무작정","&Query=베란다 텃밭 가꾸기"
	};
	public static string[] ss = 
	{ "&Query=다른 게 아니라 틀린", "&Query=다가오는 말들", "&Query=당신들의 아랫사람이", 
		"&Query=고기로 태어나서", "&Query=사람의 자리", "&Query=청년팔이 사회", 
		"&Query=인권도 차별이 되나요","&Query=이 선생의 학교폭력","&Query=감정은 어떻게 전염되는가",
		"&Query=불평등의 세대", "&Query=열심히 일하지 않아도", "&Query=낙인찍힌 몸", 
		"&Query=알지 못하는 아이의 죽음", "&Query=트라이앵글의 심리", "&Query=누가 진짜 범인인가", 
		"&Query=악의 해부","&Query=퇴적 공간","&Query=선량한 차별주의자",
		"&Query=정의란 무엇인가 37개국", "&Query=생각을 빼앗긴 세계", "&Query=좀비 사회학", 
		"&Query=이상한 정상가족", "&Query=우리는 미래에 조금 먼저", "&Query=시대의 어둠을 밝힌다", 
		"&Query=최저임금 1만원","&Query=돈보다 생명을","&Query=내가 낸 세금, 다",
		"&Query=나는 아기 캐리어가", "&Query=반사회적 가족", "&Query=우리 시대 혐오를 읽다", 
		"&Query=미투의 정치학", "&Query=아파도 미안하지 않습니다", "&Query=우리는 살아남는 중이다", 
		"&Query=페미니즘 교실","&Query=여성 혐오를 혐오한다","&Query=늑대와 함께 달리는 여인들",
		"&Query=프로파간다 선전 전략", "&Query=포스트 트루스", "&Query=출판하는 마음", 
		"&Query=자유론 현대지성 클래식", "&Query=포퓰리즘 첫단추", "&Query=자본주의 리얼리즘 대안은", 
		"&Query=정신의 삶 사유와 의지","&Query=마르크스 주의란","&Query=한나 아렌트 탈출",
		"&Query=꿰뚫는 세계지도 상식도감", "&Query=수직 사회", "&Query=중공업 가족의 유토피아",
		"&Query=공기파는 사회에 반대", "&Query=플라스틱 없는 삶", "&Query=사랑할까, 먹을까", 
		"&Query=미래는 오지 않는다","&Query=빅데이터 소사이어티","&Query=공존과 지속"
	};
	public static string[] travel = 
	{ "&Query=인조이 중국", "&Query=저스트 고 홍콩", "&Query=내일은 타이베이", 
		"&Query=베트남 셀프 트래블", "&Query=인조이 말레이시아", "&Query=지금 우리, 싱가포르", 
		"&Query=무작정 따라하기 방콕","&Query=앙코르와트 내비게이션","&Query=소곤소곤 라오스",
		"&Query=리얼 블라디보스톡", "&Query=스위스 셀프 트래블", "&Query=트래블로그 폴란드", 
		"&Query=아이슬란드 너는 나에게", "&Query=파리는 언제나 옳다", "&Query=너를 만나러 노르웨이", 
		"&Query=두 번째 스페인, 발렌시아","&Query=언젠가는, 터키","&Query=설렘 두배 독일",
		"&Query=시칠리아에서 본 그리스", "&Query=베네치아로 답하다", "&Query=행복이 번지는 곳 크로아티아", 
		"&Query=진짜 네덜란드 이야기", "&Query=매혹의 땅, 코카서스", "&Query=오스트리아 부다페스트", 
		"&Query=디어 슬로베니아","&Query=이지 시베리아 횡단열차","&Query=동유럽 슬로바키아",
		"&Query=애리조나 답사기", "&Query=저스트 고 시애틀", "&Query=베스트 캘리포니아", 
		"&Query=뉴질랜드, 달려라 청춘", "&Query=자신만만 세계여행 캐나다", "&Query=80일간의 호주", 
		"&Query=오 마이 하와이","&Query=지금, 괌","&Query=사이판 100배 즐기기",
		"&Query=저스트 고 모로코", "&Query=남아공에 꼭 가야만", "&Query=부에노스아이레스의 잡화점", 
		"&Query=괜찮아, 쿠바니까", "&Query=난생 처음 페루", "&Query=선샤인 멕시코", 
		"&Query=론리플래닛 인도","&Query=세계를 간다 네팔","&Query=프렌즈 두바이",
		"&Query=나 홀로 제주", "&Query=쉼표, 경주", "&Query=대전여지도",
		"&Query=조선의 유토피아 십승지를 걷다", "&Query=남해여행자", "&Query=대구를 데꾸가", 
		"&Query=나의 지리산","&Query=도도한 여행 우이도","&Query=전주, 느리게 걷기"
	};
	public static string[] school = 
	{ "&Query=1일 1독해 한국사 통일 신라", "&Query=교육부 지정 필수 영단어 1-2", "&Query=즐깨감 과학탐구 동물", 
		"&Query=쎈연산 02권 초등 1-2 (2019", "&Query=한끝 초등사회 3-2 (2019년", "&Query=해법 총정리 1-1 (8절)", 
		"&Query=오투 초등과학 3-2 2015 개정","&Query=글자 바로 쓰기 초등 국어 2-2","&Query=우등생 평가 3학년 9월호 2019",
		"&Query=디딤돌 독해력 2 수능까지", "&Query=탐깨비 초등 사회 4-2 2019", "&Query=초등 영어 파닉스가 스타트다", 
		"&Query=쎈연산 10권 초등 5-2", "&Query=안쌤의 STEAM 과학 5~6", "&Query=EBS 헬로 소프트웨어 엔트리", 
		"&Query=EBS 방학생활 6학년 2019","&Query=유형맞짱 4-2 2019","&Query=백점 초등 바슬즐 2-1",
		"&Query=올리드 중등 과학 1-1", "&Query=메가스터디 비문학 독해연습 1", "&Query=1등만들기 중학 도덕 1-1", 
		"&Query=응가역사 2-1", "&Query=중등 키 수학 총정리 28일", "&Query=중학 문법이 내신이다", 
		"&Query=올쏘 중학 사회 2","&Query=본 중등 과학 2-1","&Query=창비 중학교 국어 내신",
		"&Query=아빠마음 중학 수학", "&Query=Middle School 자습서 양현권", "&Query=하이라이트 교과서 뛰어넘기 역사", 
		"&Query=중학 비문학 독해 연습 실력", "&Query=해법 45년간 고입총정리 도덕", "&Query=싸플 중학교 과학 3", 
		"&Query=기적의 중학 도형 2권 중2","&Query=창의력과학 아이앤아이 물리","&Query=연상달인 세계사 암기법",
		"&Query=ㄹㅇㅍㅌ 독서", "&Query=뜯어먹는 수능 1등급 1800", "&Query=수능 100일 공부법", 
		"&Query=자이스토리 확률과 통계 940제", "&Query=완성 모의고사 생명과학 2", "&Query=사파이어 사회문화 N제", 
		"&Query=드림하이 모의고사 한국사","&Query=고잉 국어영역 언어와 매체","&Query=다빈출코드 고1 독해",
		"&Query=우쥬 N프로젝트 화학 1", "&Query=기출의 파급효과 기하와 벡터", "&Query=이동글 수능국어 문학편",
		"&Query=지금필수 영어 듣기 35회", "&Query=현자의 돌 생활과 윤리", "&Query=매스튜터 파이널 수학영역 가형", 
		"&Query=수능특강 사용설명서 지구과학","&Query=2020 대학으로 가는 구술면접","&Query=대입수시전형, 수리논술로"
	};
	public static string[] novel = 
	{ 
		"&Query=지구에서 한아뿐", "&Query=그믐 또는 당신이", "&Query=작은마음동호회", 
		"&Query=웬만해선 아무렇지 않다", "&Query=가짜 팔로 하는 포옹", "&Query=다른 모든 눈송이와", 
		"&Query=경애의 마음","&Query=이마를 비추는,","&Query=거기 있나요 김유정",
		"&Query=아몬드(양장)", "&Query=비행운", "&Query=현남오빠에게", 
		"&Query=대도시의 사랑법", "&Query=밤의 여행자들", "&Query=오직 한사람의 차지", 
		"&Query=너의 빛나는 그 눈이","&Query=옥상에서 만나요","&Query=사서함 110호의",
		"&Query=새벽 별이 이마에", "&Query=지극히 내성적인", "&Query=레몬 권여선", 
		"&Query=위저드 베이커리 창비", "&Query=다행히 졸업", "&Query=알려지지 않은 예술가의 눈물과", 
		"&Query=달을 먹다","&Query=한정희와 나","&Query=그 남자네 집",
		"&Query=달과 6펜스", "&Query=랩 걸", "&Query=섬에 있는 서점", 
		"&Query=마티네의 끝에서", "&Query=나의 눈부신 친구", "&Query=A가 X에게", 
		"&Query=명탐정의 규칙","&Query=그해, 여름 손님","&Query=빛과 물질에 관한",
		"&Query=무의미의 축제", "&Query=나를 보내지 마", "&Query=베로니카, 죽기로", 
		"&Query=낭만적 연애와 그 후의", "&Query=1984", "&Query=13.67", 
		"&Query=할머니가 미안하다고","&Query=폭풍의 언덕","&Query=예감은 틀리지 않는다",
		"&Query=잘못은 우리별에", "&Query=연을 쫓는 아이", "&Query=존재의 세 가지 거짓말",
		"&Query=참을 수 없는 존재의", "&Query=엘리너 올리펀트는", "&Query=밤의 피크닉", 
		"&Query=팔월의 일요일들","&Query=비와 별이 내리는 밤","&Query=우리와 당신들"
	};
	public static string[] poetry = 
	{
		"&Query=유에서 유", "&Query=빈 배처럼 텅 비어", "&Query=서랍에 저녁을 넣어", 
		"&Query=오래 속삭여도 좋을 이야기", "&Query=우리의 대화는 이런 것입니다", "&Query=은는이가", 
		"&Query=타인의 의미","&Query=일요일과 나쁜 날씨","&Query=세상의 모든 최대화",
		"&Query=다시 오지 않는 것들", "&Query=꽃을 보듯 너를 본다", "&Query=아마도 아프리카", 
		"&Query=유리구슬은 썩지 않는다", "&Query=한 사람의 닫힌 문", "&Query=동주와 빈센트", 
		"&Query=너는 내가 버리지 못한 유일한 문장이다","&Query=우물에서 하늘 보기","&Query=아버지도 나를 슬퍼했다",
		"&Query=여행의 이유", "&Query=잊기 좋은 이름", "&Query=쉬운 일은 아니지만", 
		"&Query=죽고싶지만 떡볶이는", "&Query=사랑과 가장 먼 단어", "&Query=무례한 사람에게 웃으며 대처하는 법", 
		"&Query=어른은 어떻게 돼?","&Query=약간의 거리를 둔다","&Query=떠나고 싶을때 나는 읽는다",
		"&Query=느낌의 공동체", "&Query=우리, 독립출판", "&Query=우리는 사랑아니면 여행", 
		"&Query=우리가 녹는 온도", "&Query=걷는 듯 천천히", "&Query=내가 모르는 것이 참 많다", 
		"&Query=그쪽의 풍경은 환한가","&Query=여자 둘이 살고 있습니다","&Query=언젠가 설명이 필요한",
		"&Query=정확한 사랑의 실험", "&Query=피아니스트는 아니지만 매일", "&Query=잘 있지 말아요", 
		"&Query=나는 왜 쓰는가", "&Query=문학은 어떻게 내 삶을", "&Query=지지 않는다는 말", 
		"&Query=너도 떠나보면 나를 알게","&Query=빗방울처럼 나는","&Query=혼자서 완전하게",
		"&Query=나는 토끼처럼 귀를", "&Query=별일 아닌 것들로 별일이", "&Query=순간의 나와 영원의",
		"&Query=우리가 사랑한 1초들", "&Query=나를 보는 당신을", "&Query=시간은 이야기가 된다", 
		"&Query=당신에게 하고 싶은 말이","&Query=천천히, 스미는","&Query=어른이 되면 발달장애인"
	};
	public static string[] self = 
	{ 
		"&Query=딱 1년만 미치도록", "&Query=아주 작은 습관의 힘", "&Query=공부의 미래", 
		"&Query=오래 하는 힘", "&Query=진짜 공부 인생을 극적으로", "&Query=아침의 재발견", 
		"&Query=부의 원천 꿈을","&Query=참된 인생의 성공","&Query=판단과 선택 왜",
		"&Query=말센스", "&Query=이제껏 너를 친구라고", "&Query=회사생활예절 무개념", 
		"&Query=거절 잘해도 좋은 사람", "&Query=귀를 열면 대화가 달라진다", "&Query=왜 말을 그렇게 해", 
		"&Query=감사하면 달라지는 것들","&Query=신경써달라고 한 적","&Query=나는 내 편이라고 생각",
		"&Query=백 살까지 유쾌하게", "&Query=행복한 이기주의자", "&Query=리부팅 재충전의 기술", 
		"&Query=어떻게 나답게 살 것인가", "&Query=퍼즈 일시정지", "&Query=1년 전과 똑같은 고민을", 
		"&Query=걱정이 많아서 걱정인","&Query=치유 있는 그대로의","&Query=12가지 행복의 법칙",
		"&Query=리더는 하루에 백 번", "&Query=실리콘밸리의 팀장들", "&Query=무기가 되는 스토리", 
		"&Query=끌리는 사람은 매출이", "&Query=갑을 이기는 을의 협상법", "&Query=설득의 심리학 1 ", 
		"&Query=1분 전달력","&Query=말투 때문에 말투 덕분에","&Query=펭귄이 말해도 당신보다",
		"&Query=메이크 타임 구글벤처스", "&Query=메모 독서법", "&Query=기억력의 신 챔피언", 
		"&Query=이과식 독서법", "&Query=매일 아침 써봤니", "&Query=1만시간의 재발견", 
		"&Query=결국 공부는 지식을 정리하는","&Query=이기적 1시간","&Query=기획자의 노트",
		"&Query=욕망과 수납", "&Query=이대로는 순간 정리를", "&Query=작은 삶을 권하다",
		"&Query=버리고 비웠더니 행복이", "&Query=크리에이티브는 단련된다", "&Query=알고리즘, 인생을 계산하다", 
		"&Query=생각이 돈이 되는 순간","&Query=진작 이렇게 생각할 걸","&Query=서른의 휴직"
	};


	string URL;
	//	public Text responseText;
	public Search[] search = new Search[54];
	public string image;
	public MeshRenderer[] cubeRenderer;
  //  public TextMesh[] bookinfo;
    //public MeshRenderer cubeRenderer2;
    public GameObject[] info;
    public GameObject loading;

    public int i;
	public int j;
	WWW request;
	WWW www;
	public Text[] Text1;
    string text1;
    string text2;
	string json;
	public string[] sample = new string[54];

	void Start()
	{
        loading.SetActive(false);
		for(j=0;j<54;j++){
			if (SceneManager.GetActiveScene().name == "college"){
				Titles[j] = college[j];
			}
			if (SceneManager.GetActiveScene().name == "travel"){
				Titles[j] = travel[j];
			}
			if (SceneManager.GetActiveScene().name == "school"){
				Titles[j] = school[j];
			}
			if (SceneManager.GetActiveScene().name == "ss"){
				Titles[j] = ss[j];
			}
			if (SceneManager.GetActiveScene().name == "health"){
				Titles[j] = health[j];
			}
			if (SceneManager.GetActiveScene().name == "family"){
				Titles[j] = fam[j];
			}
			if (SceneManager.GetActiveScene().name == "novel"){
				Titles[j] = novel[j];
			}
			if (SceneManager.GetActiveScene().name == "poetry"){
				Titles[j] = poetry[j];
			}
			if (SceneManager.GetActiveScene().name == "self"){
				Titles[j] = self[j];
			}
		}
		StartCoroutine("OnResponse");

	}


	public IEnumerator OnResponse()
	{
        loading.SetActive(true);
        for (i=0;i<54;i++){
			URL = apiurl + Titles[i];
			request = new WWW(URL);
			yield return request;
			json = request.text;
			//string text1 = "", text2 = "";
			json = json.Replace(";", ""); //마지막 ; 없애기
			json = json.Replace("\\'", "*");
			json = json.Replace("&lt", "*"); 
			json = json.Replace("&gt", "*"); 

			search[i]= JsonUtility.FromJson<Search>(json); //이제 여기서 item(책) 추출해야 함
            text1 = "";
            for(int z = 0; z < search[i].item[0].description.Length; z++)
            {
                text1 += search[i].item[0].description[z];
                if (z % 27 == 26) text1 += "\n";
            }
			text2 = "책 제목 : " + search[i].item[0].title + "\n\n"+ "저자 : "
				+search[i].item[0].author+"\n\n"+"출판사 : " +search[i].item[0].publisher+"\n\n"+
				"정가 : " +search[i].item[0].priceStandard+"원"+"\n\n"+"출간일 : " +
				search[i].item[0].pubDate+"\n\n"+text1;
            //Text1[i].text = String.Copy(text2);
            info[i].GetComponent<TextMesh>().text = text2;
            info[i].SetActive(false);
            //bookinfo[i].text = String.Copy(text2);
        //    Debug.Log(i+"info : "+bookinfo[i].text);

            search[i].item[0].coverReplace();
			image = search[i].item[0].cover;
		//	sample[i] = "http://www.aladin.co.kr/shop/book/wletslookViewer.aspx?ISBN="+search[i].item[0].isbn+"&mode=image";
		//	Application.OpenURL(sample[i]);

			www = new WWW(image);
			yield return www;
			cubeRenderer[i].material.mainTexture = www.texture;
            
		}
        loading.SetActive(false);

    }
	public void SampleView(int i){
		//Application.OpenURL(sample[i]);
	}

    public void TextmeshUpdate()
    {
      // info[0].SetActive(true);
    }
}

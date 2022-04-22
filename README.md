# 저장소 소개
AngelSix님의 유튜브 동영상을 보면서 WPF를 공부하고 있습니다.       
영상를 따라 갈수록 기초가 잡히지 않고, 많은 UI로 소스가 꼬이고... 이해가 가질 않는 부분이 많습니다.   
이번 기회에 MVVM과 사용한 UI에 대해 정리하려고 합니다.

어떻게 정리할지가 고민입니다.

처음 시작하시는 분들이 각 소스를 접하고 난 뒤 이해가능할 정도로 코맨트들 달고 싶습니다.
저는 소스의 흐름정도를 파악한 수준이라, 세세하개 말할려다보면
"뭘 이런거까지 말해야하나?, 이건 어떻게 말하지?" 이렇게 생각이 많아지네요.
일단 가능한대로 적어보고 차차 수정해나가는 식으로 방향을 잡겠습니다.

# 프로젝트 구성
* MVVM
* NewStartTreeViews
* Chating App
<br />  

# MVVM
**현재 정리 중**             
         
느낀점 노트 (후에 정리 할것)
MVVM은 구체적으로 확립된 개념이 아니다.  
근거는 많은 사람들이 MVVM 패턴이 가장 중요하다고 하지만   
사실 MVVM은 "이것이다"라고 하는 명확하고 정확한 설명이 없다. 즉 MVVM에 대한 설명을 듣고 곧 바로 이해 할 수가 없다(처음 접하는 경우),   
MVVM은 말로 설명하기가 어렵고 경험함으로 써 익힐 수 있다고 한다.   
그래서 받은 느낌은 "MVVM에서 지켜할 기준은 있지만 정해진 형식은 없다"입니다.   
여러 타입의 View, ViewModel, Model이 있는 것 같습니다.   
다만 지켜할 MVVM의 기준이 있습니다.   
1.ViewModel은 View와 특별한 의존성을 가지지 않는다. (ViewModel은 그 자체로 존재 할 수 있다.)    
2.ViewModel은 View를 추상화한 것    
(1,2를 조합했을 때 받은 느낌은 그릇(View)에 물(ViewModel)을 담으면 물그릇이 되고 밥(ViewModel)을 담으면 밥그릇이 된다.)   
3. ViewModel에는 UI 관련된 요소를 넣으면 안 된다. (System.Windows 나 System.Windows.Controls 따위 것들 혹은 DependencyObject 관련된 것들 등등..)            
4. ??       

   
<br />    
ViewModel은 그 View가 가진 속성(Property)이나 행위(Behavior), 동작(Command) 따위만을 뽑아내서   
정리하고 유지하는 클래스 정도라고 할 수 있다.     
     
<br />     
    
start     
MVVM을 보고 느낀점은 굳이 귀찮게 이렇게 구분하는 이유가 궁금했다.   
MVVM의 의도와 장점을 보자면  
View와 ViewModel, Model 이렇게 세분화 시킴으로써   
디자인, 동작, 데이터 이런 식으로 분리를 할 수있다.   
개발자가 혼자 모두 처리하는 방식이 있다면,   
MVVM형식은 : View부분은 디자니어, ViewModel은 개발자, Model은 서버와 연동함으로 써 데이터를 가져 올 수있게 된다.     
이렇게 세분화되어 만들어진 UI는 잘 다듬어서 다른 곳에서 재사용이 가능해진다.(크로스 플랫폼)    
또는 같은 플랫폼에서 UI를 재사용해 개발 시간을 단축 시킬 수 있다.   end
     
<br />        

start   
View 영역의 UI 요소는 Binding을 위한 DP 를 구성하고 있고     
Binding은 기본적으로 DP 간 property 연결을 구현하고 있지만    
DataContext를 통해 ViewModel을 할당한 뒤 Binding으로 연결된 property 를 동기화하여    
View와 ViewModel, 또한 View와 Model 간의 관계를 느슨한 결합으로 처리하는 방식을    
WPF에서 기본적으로 제공해 준다  end  
    
<br />    
"xaml.cs 에 생성자 구문을 제외하고 아무것도 넣지마"    
View에 로직을 넣지 말라는 것을 의미한다.   
View 로직이 들어가면 어떠한 형태로든지 간에 Model이나 ViewModel에 의존성을 갖게 된다.   
(View는 디자이너 영역이다, 디자이너가 로직을 짜는 것은 이상하다.)
(이견이 많음)
예외사항 =>  
Converter, Trigger, Behavior 이렇게 3가지 상황에서는 예외 + 바로 상위 View에 대한 설정     
      
      
UI 와 관련이 있을만한 요소나 속성 따위 등을 ViewModel에서 완전히 제거하고       
딱 Model을 이용한 데이터 핸들링만 집중하는 것이 중요하다고 할 수 있다.        
그리고 View에 영향을 주어야 하는 것들이라면 Binding을 통해서만 조작     


<br />   
<br />   
MVVMd의 대한 개념을 익히고 있는데 굉장히 이해하기 어렵다,      
알지 못하는 개념과 단어들. ;;       
어떠한부분을 설명하고 그 것을 우회하기위해, MVVM를 지키기 위해 Converter, Trigger, Behavior,AttachedProperty 등등을 사용하면 된다,    
이렇게하면 된다라고하는데 이해 할 수가 없다. 그 개념을 모르니까...      
경험 후 => 개념정독(MVVM) => 경험 .... 무한순환으로 돌아가야 이해할 수 있을 것 같다.    
    
# NewStartTreeViews   
Nuget Package등 호환 문제로 .Net Framework 4.8로 시작했습니다.    
NewStartTreeViews 프로젝트에 사용한 UI와 MVVM에 대한 이야기입니다.
<br />  

## 개발정보
* .NET 4.8 (.Net Framework)
* C# 7.3
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/ko/vs/preview/)
<br />  

## 프로젝트구조
* 📁 Directory    
  * 📃 DirectoryStructure.cs 
* 📁 Data   
   * 📃 DirectoryItem.cs
   * 📃 DirectoryItemType.cs     
* 📁 ViewModels
   * 📁 Base      
       * 📃 BaseViewModel.cs
       * 📃 RelayCommand.cs
   * 📃 DirectoryItemViewModel.cs
   * 📃 DirectoryStructureViewModel.cs
* 📃 HeaderToImageConverter.cs
<br />   

## UI 설명 목차
- [BaseViewModel](#BaseViewModel)
- [RelayCommand](#RelayCommand)
- [DirectoryItem](#DirectoryItem)
<br />  

### BaseViewModel
```
// A base view model that fires Property Changed events as needed
[AddINotifyPropertyChangedInterface] // 말 그대로 "INotifyPropertyChanged" 클래스를 구현한다.
public class BaseViewModel : INotifyPropertyChanged // 구현한 클래스로부터 상속 받는다.
{
    // The event that is fired when any child property changes its value
    public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {}; // 자산(property)이 바뀌면 바로 알 수있다.
    
    // Call this to fire a<see cref="PropertyChanged"/> event
    public void OnPropertyChanged(string name)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}
```
BaseViewModel 클래스를 상속받아 자산(Property)이 변경되면 언제든지 알람을 받거나 이벤트 처리 할 수 있다.  
<br />
Ex) 예제 코드  
```
public class Person : BaseViewModel
{
    public string GivenNames { get; set; }
}
```
새로운 value가 들어오면 GivenName의 값이 새 value로 변경되며 OnPropertyChanged를 통해 알림을 받는다.     
출처 : Github fody => https://github.com/Fody/PropertyChanged

<br /> 

### RelayCommand
```
class RelayCommand : ICommand
{
   // Private Members
   private Action mAction;

   // Public Events
   public event EventHandler CanExecuteChanged = (sender, e) => {};
   
   // Default Constuctor
   public RelayCommand(Action action)  // 대리자 Action을 이용해 요청을 받는다
   {
       mAction = action;
   }

   // Command Methods
   // A relay command can always execute
   public bool CanExecute(object parameter) // 실행가능 여부 확인
   {
       return true;
       // return fasle 실행 불가능 
   }
   
   /// Executes the commands Action
   public void Execute(object parameter)
   {
       mAction();
   }
}
```
저는 주로 클릭이 가능 한곳에서 사용했습니다.   
예를들면 버튼과 폴더 클릭시 이어질 행동에 사용 했습니다.   
Ex) 창의 최소화, 종료 버튼, 폴더 클릭시 하위 파일 보기   
CanExecute(object parameter)를 활용해서 이어질 행동을 실행할 수도, 막을 수도 있습니다.
(버튼 클릭이 안된다던가, 특정상황시 비활성화 등등)  
<br />   

### DirectoryItem
```
// Information about a directory item as a drive, a file or a folder
public class DirectoryItem
{
    // The type of this item
    public DirectoryItemType Type { get; set; }

    // The absolute path to this item
    public string FullPath { get; set; }

    // The name of this directory item  //탐색한 파일의 타입을 읽어옴 => 파일이 드라이브 or 폴더인지 구분하는 문
    public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
}
```
Model부분으로 폴더의 타입, 경로, 이름을 설정해두었다

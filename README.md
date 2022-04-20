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
* NewStartTreeViews
 * Chating App

# NewStartTreeViews 
Nuget Package등 호환 문제로 .Net Framework 4.8로 시작했습니다.    
NewStartTreeViews 프로젝트에 사용한 UI와 MVVM에 대한 이야기입니다.

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

### BaseViewModel
```
// A base view model that fires Property Changed events as needed
[AddINotifyPropertyChangedInterface] // 말 그대로 "INotifyPropertyChanged" 클래스를 구현한다.
public class BaseViewModel : INotifyPropertyChanged // 구현한 클래스로부터 상속 받는다.
{
    // The event that is fired when any child property changes its value
    public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {}; // 자산(property)이 바뀌면 언제든지 알 수있다.
    
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
Ex) 창의 최소화 종료 버튼, 폴더 클릭스 하위 파일 보기  


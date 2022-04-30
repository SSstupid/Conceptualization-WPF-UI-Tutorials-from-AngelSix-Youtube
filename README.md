# 저장소 소개
AngelSix님의 유튜브 동영상을 보면서 WPF를 공부하고 있습니다.       
영상를 따라 갈수록 기초가 잡히지 않고, 많은 UI로 소스가 꼬이고... 이해가 가질 않는 부분이 많습니다.   
이번 기회에 MVVM과 사용한 UI에 대해 정리하려고 합니다.

어떻게 정리할지가 고민입니다.

처음 시작하시는 분들이 각 소스를 접하고 난 뒤 어느정도 이해가가도록 코맨트를 달고 싶습니다.
저는 소스의 흐름정도를 파악한 수준이라, 세세하게 말할려다보면
"뭘 이런거까지 말해야하나?, 이건 어떻게 말하지?" 이렇게 생각이 많아지네요.
일단 가능한대로 적어보고 차차 수정해나가는 식으로 방향을 잡겠습니다.

# 프로젝트 구성
* MVVM
* NewStartTreeViews => - [UI 로직 목차](#UI 로직 목차)
* Chating App
* 오류해결 노트
<br />  

# MVVM
**현재 정리 중**       
![MVVM](https://user-images.githubusercontent.com/90036120/165052637-8c495f75-0cef-4925-ad6b-4180e7177909.png)

(MVVM에 대한 각 개념은 땡겨와서 정리할 것 그 후 개인적인 의견 코멘트 달기)      
View는 디자이너 영역으로 눈에 보여지는 그래픽입니다.                   
                  
ViewModel은 View와 Model사이에서 연결 해주는 역활입니다.(전달자)                  
ViewModel은 로직이 포함되어 있습니다.           
                  
Model은 Data부분 입니다. DB와 연동하여 Data를 가져 올 수도 있습니다.                

Command는 캡슐화된 것을 요청하는 부분입니다.                                
예를들면 => View에서 'ABC'라는 것을 요청하고 ViewModel은 ABC를 요청받아 처리하고 (Model에서 value받고) Binding으로 값을 제공합니다.              
여기서 View는 ABC라는 것을 요청만 할뿐 ABC가 무엇인지는 알 필요가 없습니다.               
즉 View와 ViewModel간의 의존성이 없는 부분이라고 할 수 있습니다.           
만약 View가 ABC를 요청할떄 'ABC는 무엇무엇이다' ViewModel아 너 이거 있니?라고 한다면 ViewModel은 ABC에 대한 고정적인 부분이 필요하고 의존성이 생깁니다. (재고할것)         
(무엇인지 안다면 굳이 ViewModel에 요청 할 필요가 없다고 생각이 듭니다. View에서 바로 처리해버리면 되니까, 그러나 MVVM에서 View는 이러한 처리를 하지 않습니다.)    

Ex) 나이를 설정하고 출력하는 예제입니다.(HowOldAreYouTest)       
![image](https://user-images.githubusercontent.com/90036120/165894987-8599f0bc-6d61-464f-b643-b8ee9d026947.png)
```
<!-- View(MainWindow.xaml) -->
<TextBlock Text="나이를 설정하세요"/>
<TextBox Text="{Binding GetSetAge}" />

<TextBlock Text="나이 : "/>    
<TextBox  Text="{Binding GetSetAge}" />    
 ```
 1. View에서 'GetSetAge'를 호출합니다.
 ```
// ViewModel(WindowViewModel)
AgeData whatAge = new AgeData();

public int GetSetAge 
{ 
    get => whatAge.Age;
    set => whatAge.Age = value;
}
   ```
   ```
// Model(AgeData)
private int age= 24;

public int Age
{
    get => age;
    set => age = value;
} 
```
2. ViewModel에서 Model(AgeData)을 'whatAge'로 인스턴스화합니다.    
3. whatAge에서 받아 GetSetAge의 값을 셋팅합니다.   
4. GetSetAge를 View에게 반환합니다.    
    

              
느낀점 노트 (후에 정리 할것)       
MVVM은 구체적으로 확립된 개념이 아니다.  (Model, View, ViewModel로 나눈다는 개념이지만 그 나누는 방법과 View와 ViewModel을 구분하는 구체적인 것이 없다.)
근거는 많은 사람들이 MVVM 패턴이 가장 중요하다고 하지만   
사실 MVVM은 "이것이다"라고 하는 명확하고 정확한 설명이 없다. 즉 MVVM에 대한 설명을 듣고 곧 바로 이해 할 수가 없다(처음 접하는 경우),   
MVVM은 말로 설명하기가 어렵고 경험함으로 써 익힐 수 있다고 한다.   
그래서 받은 느낌은 "MVVM에서 지켜할 기준은 있지만 정해진 형식은 없다"입니다.   
(여러 타입의 ViewModel, Model이 있는 것 같습니다.)                    
                  
다만 지켜할 MVVM의 기준이 있습니다.   
1.ViewModel은 View와 특별한 의존성을 가지지 않는다. (ViewModel은 그 자체로 존재 할 수 있다.)    
2.ViewModel은 View를 추상화한 것    
3. ViewModel에는 UI 관련된 요소를 넣으면 안 된다. (System.Windows 나 System.Windows.Controls 관련됫 것 Or DependencyObject 관련된 것들 등등..)            
4. 디자인과 로직을 최대한 분리하는 것(Xaml에 Code behind를 가능한 넣지 말 것)          
5. 데이터는 뷰에서 노출되어야 한다.               
6. 뷰에서 사용 가능한 커맨드들을 제공한다. 이 커맨드는 ICommand를 통해 만든다.                          
   
<br />    
ViewModel은 그 View가 가진 속성(Property)이나 행위(Behavior), 동작(Command)을 뽑아내서   
정리하고 유지하는 클래스 정도라고 할 수 있다.     
     
<br />     
     
MVVM을 보고 느낀점은 굳이 귀찮게 이렇게 구분하는 이유가 궁금했다.   
MVVM의 의도와 장점을 보자면  
View와 ViewModel, Model 이렇게 세분화 시킴으로써   
디자인, 동작, 데이터 이런 식으로 분리를 할 수있다.   
개발자가 혼자 모두 처리하는 방식이 있다고 하면,   
MVVM형식은 : View부분은 디자니어, ViewModel은 개발자, Model은 서버와 연동함으로 써 데이터를 가져 올 수있게 된다.     
이렇게 세분화되어 만들어진 UI 로직은 잘 다듬어서 다른 곳에서 재사용이 가능해진다.(크로스 플랫폼)    
또는 같은 플랫폼에서 UI 로직을 재사용해 개발 시간을 단축 시킬 수 있다.               
     
<br />        

View 영역의 UI 요소는 Binding을 위한 DP 를 구성하고 있고     
Binding은 기본적으로 DP 간 property 연결을 구현하고 있지만    
DataContext를 통해 ViewModel을 할당한 뒤 Binding으로 연결된 property 를 동기화하여    
View와 ViewModel 간의 관계를 느슨한 결합으로 처리하는 방식을 (WPF에서)기본적으로 제공해 준다.           
    
<br />    
     
View 로직이 들어가면 어떠한 형태로든지 간에 Model이나 ViewModel에 의존성을 갖게 된다.   
(View는 디자이너 영역이다, 디자이너가 로직을 짜는 것은 이상하다.)
(이견이 많음)
예외사항 =>  
Converter, Trigger, Behavior 이렇게 3가지 상황에서는 예외 + 바로 상위 View에 대한 설정     
      
      
UI 와 관련이 있을만한 요소나 속성 등을 ViewModel에서 완전히 제거하고       
딱 Model을 이용한 데이터 핸들링만 집중하는 것이 중요하다고 할 수 있다.        
그리고 View에 영향을 주어야 하는 것들이라면 Binding을 통해서 조작한다.     


<br />   
<br />   
MVVM의 대한 개념을 익히고 있는데 굉장히 이해하기 어렵다,      
알지 못하는 개념과 단어들;;       
어떠한부분을 설명하고 그 것을 우회하기위해, MVVM를 지키기 위해 Converter, Trigger, Behavior,AttachedProperty 등등을 사용하면 된다,    
이렇게하면 된다라고하는데 이해 할 수가 없다. 그 개념을 모르니까...      
경험 후 => 개념정독(MVVM) => 경험 .... 무한순환으로 돌아가야 이해할 수 있을 것 같다.     <br/> <br/>              
                   
 
**Trigger, Behavior이 정확히 뭘 뜻하는 걸까??**      
        
*Trigger는 어떤 조건, 이벤트 등 주어졌을 때 묵시적으로 컨트롤의 상태 또는 이벤트 핸들러 등을 호출하는 기능을 의미한다.
*즉, Trigger는 사용하면 엘리먼트의 프로퍼티나 데이터 바인딩, 이벤트에서 발생하는 변화에 엘리먼트와 컨트롤이 어떻게 반응할지를 정할 수 있다.
```
<TextBlock Name="tblk1" Text="Hello, WPF world" FontSize="30" HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Setter Property="Foreground" Value="Green"></Setter>
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Foreground" Value="Red"/>
                            <Setter Property="TextDecorations" Value="Underline"/>
                        </Trigger>
                    </Style.Triggers>
                </Style>
```

<br />   

*Behavior란?
말그대로 행동을 가지고 있는 객체입니다. 예를들면 드래그앤드랍이라는 행동이 있다면 그 행동 하나를 가지고 있는 객체입니다.    
드래그앤드랍 기능을 가지는 Behavior를 원하는 실버라이트 컨트롤에 부여하면 그 컨트롤은  드래그앤드랍기능을 사용 할 수 있도록 되는 것이죠.   
                  
<br />   
<br />   

+++
MVVM의 패턴을 강력하게 고집하는데 솔직하게 말하자면 굳이 이렇게까지 해야하는지는 잘 모르겠습니다.                
디자인과 개발의 영역이 구분되는 건 좋습니다만, 너무 강력하게 영역을 분할할려고하니(서양방식 인듯?)
오히려 개발할 때 불편을 느낄 수 있을 것 같습니다.
    
# NewStartTreeViews   
Nuget Package등 호환 문제로 .Net Framework 4.8로 시작했습니다.    
NewStartTreeViews 프로젝트에 사용한 UI에 대한 이야기입니다.
파일탐색 프로그램입니다.

<br />  

## 개발정보
* .NET 4.8 (.Net Framework)
* C# 7.3
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/ko/vs/preview/)
<br />  

## 프로젝트구조
* 📁 Directory    
  * 📃 DirectoryStructure.cs 
   * 📃 DirectoryItem.cs
   * 📃 DirectoryItemType.cs     
* 📁 ViewModels    
   * 📃 BaseViewModel.cs
   * 📃 RelayCommand.cs
   * 📃 DirectoryItemViewModel.cs
   * 📃 DirectoryStructureViewModel.cs                
* 📃 HeaderToImageConverter.cs
<br />   

## UI 로직 목차
- [BaseViewModel](#BaseViewModel)
- [RelayCommand](#RelayCommand)
- [DirectoryItem](#DirectoryItem)
- [DirectoryStructure](#DirectoryStructure)
- [DirectoryItemViewModel](#DirectoryItemViewModel)
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
Model부분으로 파일(item)의 타입, 경로, 이름을 설정해두었다

### DirectoryStructure
```
public class DirectoryStructure
{
	public static List<DirectoryItem> GetlogicalDrives()
	{
		// 드라이브를 가져옵니다.(요약)
		// DirectoryItem을 인스턴스화 후 FullPath에 드라이브(DriveInfo = Directory.GetLogicalDrives())를 세트 후 리스트화(List<DirectoryItem>) 시킵니다.
		return Directory.GetLogicalDrives().Select(DriveInfo => new DirectoryItem { FullPath = DriveInfo, Type = DirectoryItemType.Drive }).ToList();
	}

	// 드라이브 하위 파일을 가져옵니다.
	public static List<DirectoryItem> GetDirectoryContents(string fullPath)
	{
		// 리스트 생성
		var items = new List<DirectoryItem>();
		
		#region Get folders 

		// 드라이브의 하위 폴더를 가져옵니다.
		try
		{
			var dirs = Directory.GetDirectories(fullPath);

			// Null 값이 아닌 경우 Type이 Folder면 리스트에 추가합니다.
			if (dirs.Length > 0)
				items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
		}
		catch { }
		#endregion

		#region Get Files

		// 하위 파일을 가져 옵니다. (Not null and If type is File) , Get folders와 같습니다.
		try
		{
			var fs = Directory.GetFiles(fullPath);

			if (fs.Length > 0)
				items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
		}
		catch { }
		#endregion

		return items;
	}


	/// 경로에서 파일 or 폴더의 이름을 가져옵니다.
	public static string GetFileFolderName(string path)
	{
		// path가 null값일 경우 empty반환
		if (string.IsNullOrEmpty(path))
			return string.Empty;

		// 이스케프 문자 '\' 처리 => '\\'
		var normalizedPath = path.Replace('/', '\\');

		// 마지막 '\\'의 위치를 찾습니다. ()
		var lastIndex = normalizedPath.LastIndexOf('\\');

		// '\'이 없을시 그대로 반환
		if (lastIndex <= 0)
			return path;

		// 마지막 '//'뒤의 문자열을 반환합니다.
		//Ex) C:\Program Files => Program Files
		//Ex) C:\Program Files\dotnet\LICENSE.txt => License.txt
		return path.Substring(lastIndex + 1);

	}
}
```

### DirectoryItemViewModel
```
public class DirectoryItemViewModel : BaseViewModel
{
	#region Public Properties

	/// The type of this item
	public DirectoryItemType Type { get; set; }

	public string ImageName => Type == DirectoryItemType.Drive ? "drive.png" : (Type == DirectoryItemType.File ? "file.png" : (IsExpanded ? "folder-open.png" :              "folder-closed.png"));

	/// The full path to the item
	public string FullPath { get; set; }


	/// The name of this directory item
	public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); }}


	/// A list of all children contained inside this item
	public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

	/// Indicates if this item can be expanded
	public bool CanExpand { get { return this.Type != DirectoryItemType.File; }  }

	public bool IsExpanded
	{
		get => this.Children?.Count(f => f != null) > 0;

		set
		{
			// If th UI tells us to expand...
			if (value == true)
				// Find all children
				Expand();
			// If the UI tells us to close
			else
				this.ClearChildren();
		}
	}

	#endregion

	#region Public Commands

	/// THe command to expand this item
	public ICommand ExpandCommand { get; set; }

	#endregion

	#region Constructor

	/// Default constructor
	public DirectoryItemViewModel(string fullPath, DirectoryItemType type )
	{
		// Create commands
		this.ExpandCommand = new RelayCommand(Expand);

		// Set path and type
		this.FullPath = fullPath;
		this.Type = type;

		// Setup the children as needed
		this.ClearChildren();
	}

	#endregion

	#region Helper Methods


	/// Removes all children from the list, adding a dummy item to show the expand icon if required
	private void ClearChildren()
	{
		// Clear items
		this.Children = new ObservableCollection<DirectoryItemViewModel>();

		// Show the expand arrow if we are not a file
		if (this.Type != DirectoryItemType.File)
			this.Children.Add(null);
	}

	#endregion

	#region find children

	/// Expands this directory and find all children
	private void Expand()
	{
		if (this.Type == DirectoryItemType.File)
			return;

		//Find all children
		var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
		this.Children = new ObservableCollection<DirectoryItemViewModel>(
			children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
	}

	#endregion
}
```

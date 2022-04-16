# 저장소 소개
AngelSix님의 유튜브 동영상을 보면서 WPF를 공부하고 있습니다.       
강의를 따라 갈수록 기초가 잡히지 않고, 많은 UI로 소스가 꼬이고.. 이해가 가질 않는 부분이 많습니다.   
이번 기회에 MVVM과 사용한 UI에 대해 정리하려고 합니다.

# NewStartTreeViews 
Nuget Package등 호환 문제로 .Net Framework 4.8로 시작했습니다.
NewStartTreeViews 프로젝트에 사용한 UI와 MVVM에 대한 이야기입니다.

## 개발정보
* .NET 4.8 (.Net Framework)
* C# 7.3
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/ko/vs/preview/)
<br />

## 프로젝트 구조
* 📁 Directory    
  * 📁 Data   
     * 📃 DirectoryItem.cs
     * 📃 DirectoryItemType.cs     
  * 📁 ViewModels
     * 📁 Base      
         * 📃 BaseViewModel.cs
         * 📃 RelayCommand.cs
     * 📃 DirectoryItemViewModel.cs
     * 📃 DirectoryStructureViewModel.cs
  * 📃 DirectoryStructure.cs
* 📃 HeaderToImageConverter.cs
<br />

# RF.QuickQuitAndRestart
 A BepInEx Plugin for Taiko no Tatsujin: Rhythm Festival to Quickly Quit and Restart Songs in Enso Mode  
 Quickly restart the current song being played or quickly exit back to Song Select.  
 
# Requirements
 Visual Studio 2022 or newer  
 Taiko no Tatsujin: Rhythm Festival  
 [BepInEx be 697](https://builds.bepinex.dev/projects/bepinex_be) or [BepInEx 6.0.0-pre.2](https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2)  

# How to use

- [Install BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html)  
- Download `RF.QuickQuitAndRestart.dll` from the [releases page](https://github.com/Renzo904/TekaTeka/releases) and extract its contents on `(GameFolder)\BepInEx\plugins\`  
- Or, install by copying the Repo URL and using [Taiko Mod Manager](https://github.com/cainan-c/TaikoModManager)  


# Build
 Install  into your Rhythm Festival directory and launch the game.\
 This will generate all the dummy dlls in the interop folder that will be used as references.\
 Make sure you install the Unity.IL2CPP-win-x64 version.\
 Newer versions of BepInEx could have breaking API changes until the first stable v6 release, so those are not recommended at this time.
 
 Attempt to build the project, or copy the .csproj.user file from the Resources file to the same directory as the .csproj file.\
 Edit the .csproj.user file and place your Rhythm Festival file location in the "GameDir" variable.

# Mouse Macro
a mouse and keyboard action automation desktop app which simulates mouse clicks. It can release your hand and finger from endlessly clicking. Some useful occasions e.g.

* RPG game character attacks.

* FPS quick firing. also it can simulate to compensate recoil

* panic buying train ticket/biding on websites

Configurable and modular architecture can be reprogram to any requirement and occasion.

## Screenshot

![fig 1](screenshoot.PNG)

## Requirement

* Window 10
* .Net Framework 4.7.2

## Download 

you can download from release.



## Usage
* download the zip file
* unzip
* run ***n43e120.MouseMacro.exe***

## Squad Mod 

> Press **[F5]** to switch to AK-74 Auto mode for FPS video game Squad.
> this is out-of-box example of demonstration
> now click left mouse button, it should be move down automatically as you hold down LMB.
> **[F6]** for M4 burst mode for FPS video game Squad.
> **[F7]** for pistol mode for FPS video game Squad.
> **[F8]** to stop it, press F8 again to return previous mode.

> click **Setting button** on the **app window**.
> and then click **MacroControllers** item in the list on the **Setting Window**
> and then click **Squad** item on the **IMacroController Collection Editor Window**
> and then click the **Left Mouse Button** item to open a dropdown menu.
> in the dropdown menu you can choose one of many other gun fire modes you want, there are many of them.

## DIY Mod Guide 
* write a new macro can not be more easy. just write a static C# class and static method and attach [MarcoAction] attribute to your method.
* If you create your own put your dll or exe file into **/mod** folder and there you go.
* it is designed to open-source, so that users can make variant of system of their own to fit to other FPS game, other purposes, etc.

## Update History
> 2020/10/30 update fixed a random crash bug which is caused by GC collecting a HOOKPROC callback delegate for receiving mouse/keyboard input event defined in local function scope. Also it fixed a mistype bug in function LEFTUP() which should be MOUSEEVENTF_LEFTUP not DOWN.

> 2018/12/27 first submit version. download from my [baidu Cloud Disk](https://pan.baidu.com/s/1tUXBKcouEG7hbYGleozDmA)
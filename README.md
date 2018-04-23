# MouseMacro
a general purpose Mouse Macro e.g. FPS game created by [me](https://github.com/n43e120/blog)

## Download 
you can download compiled executable from my [baidu Cloud Disk](https://pan.baidu.com/s/1tUXBKcouEG7hbYGleozDmA)

## usage
* download **MouseMarco_20180423build.zip**
* unzip
* open **WinFormMouseMarcoFPSRecoilCompensator.exe**

> Press **[F5]** to switch to AK-74 Auto mode for FPS video game Squad.
> this is out-of-box example of demostration
> now click left mouse button, it should be move down automatically as you hold down LMB.
> **[F6]** for M4 burst mode for FPS video game Squad.
> **[F7]** for pistol mode for FPS video game Squad.
> **[F8]** to stop it, press F8 again to return previous mode.

> click **Setting button** on the **app window**.
> and then click **MacroControllers** item in the list on the **Setting Window**
> and then click **Squad** item on the **IMacroController Collection Editor Window**
> and then click the **Left Mouse Button** item to open a dropdown menu.
> in the dropdown menu you can choose one of many other gun fire modes you want, there are many of them.

## Mod Guide 
* Demo code is just rough tuned for almost all guns in game Squad version 10.2.
* you can change the code in **class RecoilCompensatorMouseRunner** in **file SquadRecoilCompensator.cs** to tweak the recoil strength and/or add new gun mode by adding a new **static method** in the class for future version of the game. 
* you also can create new class, even build variant of entire system to fit to other FPS game or other purposes.


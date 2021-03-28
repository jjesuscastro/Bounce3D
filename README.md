# Bounce3D

A 3D recreation of the old mobile game, Bounce. A working build, BuildNoAudio is present in the repository; best played on 1920x1080 resolution.

## Controls
WASD/Arrow Keys = Move  
Mouse = Camera  
Z = Zoom Minimap  
M = Open/Close Minimap

## Known Bugs
1. Ball/Player does not move with the platform.
    * This is "intentional", a previous bug was present wherein ball/player cannot move when a moving platform is set as the parent.
1. Cannot jump while climbing a slope.
    * Fix is already known. Need to use a RayCast and check the slope as a ground. There is currently only one RayCast pointing down hence the bug.

## Screenshots
**Main Menu**  
<img src="https://github.com/jjesuscastro/Bounce3D/blob/main/GitHubAssets/mainMenu.png?raw=true" width="400px" />

**Level Select**  
<img src="https://github.com/jjesuscastro/Bounce3D/blob/main/GitHubAssets/levelSelect.png?raw=true" width="400px" />

**Playthrough**  
<img src="https://github.com/jjesuscastro/Bounce3D/blob/main/GitHubAssets/playThrough.png?raw=true" width="400px" />

**Level Complete**  
<img src="https://github.com/jjesuscastro/Bounce3D/blob/main/GitHubAssets/levelComplete.png?raw=true" width="400px" />

## References
1. [THIRD PERSON MOVEMENT in Unity](https://www.youtube.com/watch?v=4HpC--2iowE) by [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA)
1. [Mini Unity Tutorial - How To Create Fire - Beginner](https://www.youtube.com/watch?v=qShjsxopbfQ) by [Jimmy Vegas](https://www.youtube.com/channel/UCRMXHQ2rJ9_0CHS7mhL7erg)
1. [Yughues Free Metal Materials](https://assetstore.unity.com/packages/2d/textures-materials/metals/yughues-free-metal-materials-12949) by [Nobiax / Yughues](https://assetstore.unity.com/publishers/4986)
1. [Tileable Bricks Wall](https://assetstore.unity.com/packages/2d/textures-materials/brick/tileable-bricks-wall-24530) by [Game-Ready Studios](https://assetstore.unity.com/publishers/9338)
1. [Geometric Free 3D print model](https://www.cgtrader.com/free-3d-print-models/jewelry/rings/geometric-4c95daad-ff37-4a30-b6f5-091e3a236d4d) by [3d-jewellery](https://www.cgtrader.com/3d-jewellery)
1. [Modern Arrow straight 120 degree apex Free 3D model](https://www.cgtrader.com/free-3d-models/various/various-models/modern-arrow) by [jstudio](https://www.cgtrader.com/jstudio)

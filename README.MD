# Read Me

## My Boids Flocking Algorithm POC

This is my own variant of this popular game algo, based on this article:
https://www.oreilly.com/library/view/ai-for-game/0596005555/ch04.html
and with a lot of help from tutorials on *bored to bits* youtube channel:
https://www.youtube.com/c/BoardToBitsGames

## Goals
1. Implement flocking algo using only 3 (instead of 4) core behaviors: Alignment, Cohesion and Avoidance (avoidance also takes care of some of the "seperation" logic)
2. Implement a weights system to balance behaviors, to avoid direct script public var manipulation
3. Implement flocking logic as infrastructure, not just a single scene / project effort. Create a solution easily transfarrable to any unity project (script dump or as untiyPackage)
4. Use editor scripting and scriptable Objects (so i can get updated on all the recent EditorGUI/GUILayout changes)

## Current Status
All main goals delivered...

## Next / Nice to have
Multiple Flocks
add a scene for a flock based game
add a scene for a flock used as "visual background" (e.g. birds in sky, piegons running in village square)
add a scene with boids implemented on unity character rigs

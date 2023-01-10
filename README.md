# Catch’em All:
Help Chloe on the first day of her new job at Old Mapple Way; her boss has given her some tasks to get her up to pace with the rest of her coworkers. She has to collect the required jelly color from the massive storm of jellies coming her way. But things are more challenging than it seems; with each level increasing the difficulty.

Can you keep up with the pace and help Chloe secure this job?

## Overview:
### Genre:
Arcade / 2D
### Target Audience: 
-	Age: 10–15
-	Gender: Male/Female 
## Game elements:
### Story: 
On this mysterious farm, far away from the city, objects are falling from the sky. Chloe’s task is to collect the required color of the jelly from the different objects falling. But things are not this simple.

The following rules must be followed:
-	If she collects any other colored jelly than the required one, she loses a lifeline; she has a total of 3 lifelines. 
-	If she collects a black jelly, not only is a lifeline lost, but total points also get reduced by 10.
-	If points fall below 0, the game is over.
-	If she is hit by the bomb, the level restarts.
-	With each correct color jelly collected, she gains 10 points.
-	The only way to qualify for the next round is if she manages to collect the required number of jelly.
-	With each level, the speed at which the objects are falling increases.

As the level proceeds, obstacles also increase, and collision with obstacles (cactus, monsters) results in health loss.
If after level completing level 4, her current score is greater than the highest score (coming from the database) then the high score is updated.

Successful completion of all the levels will get her the new job. 

### Location: 
The game takes place at Old Mapple Way; a farm far away from the city.
### Character: 
A single player game. Chloe is the main character.

<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Character/Idle/Idle%20(1).png" width="100" height="100">


### Jellies: 
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(1).png" width="100" height="100"> <img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(2).png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(3).png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(4).png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(5).png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Jellies/Jelly%20(6).png" width="100" height="100">


### Bomb:
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Others/Bomb.png" width="100" height="100">

### Obstacles:
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Obstacles/Cactus%20(2).png" width="100" height="100"> <img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Obstacles/Crate.png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Obstacles/StoneBlock.png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/2D%20Pixel%20Item%20Pack/No%20Outline/S_ItemNoOutline_ChestGold_00.png" width="100" height="100">
<img src="https://github.com/Haadia19/2DGame-Catch-emAll/blob/main/Assets/Others/SignArrow.png" width="100" height="100">

### Level Design: 
- Level 1:
Chloe has to collect 10 points to clear level 1. This level is fairly easy with only a few obstacles in her way. Collision with a cactus results in health loss.

- Level 2:
Chloe has to collect 30 points to clear level 2. This level has a monster patrolling the scene, collision with monster results in health loss. Contact should be avoided by jumping over the monster. This level has a secret bonus. If Chloe jumps on the chess box, she collects 100 points. Jumping on the chess box results in confetti being instantiated.

- Level 3:
Chloe has to collect 50 points to clear level 1. Things start to get difficult here, not only the sun goes down but the jellies are being spawned at a faster rate and their gravity is also less. She must hurry and collect the correct jellies.
 
-	Level 4:
Chloe has to collect 70 points to clear level 1. The last level of the game. Completing this level would win the game. But things are not that easy, although its day time but there is smoke in the path and in between the smoke there are dangerous cactus. 

## Mechanics:

### Sound Effects:
Each level has a different sound effects:
-	Background music
- Score Increase
-	Score Reduce
-	Health Reduce
-	Lifeline lost
-	Bonus points
-	Game Won
-	Game Over
-	Level Complete

### Canvas:
It includes the following:
-	Health bar
-	Lifeline
-	Points
-	High score from database
-	Image of color of jelly to be caught
- On screen game commands

### Menus:
-	Start Menu
-	Rules Menu
-	Game Over Menu
-	Level Complete Menu
-	Game Complete Menu

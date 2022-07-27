# Breakout 2.5D

## Introduction

This game is similar to the classic breakout game but with a twist from soul-like games. There are three difficulty levels (easy, medium, and hard). Each difficulty adjusts the max velocity of the ball.

You win by completing 50 levels, and you a level by clearing all blocks. You score by hitting the blocks and lose all progress if you lose the ball.

The game has the three most important factors of a game:

* A player (the paddle).
* A non-playing character (the blocks).
* Randomness (launch direction and spawn rate of powerups)

## The Project

The game has three scenes:

* The menu scene.
* The game scene
* The end scene.

### The Game Manager

It is a singleton that persists among the scenes. It is responsible for level progression, recording the score, changing the state, and quitting the game.

### The Spawn Manager

It exists in the play scene. It spawns blocks and powerups by instantiating prefabs.

### The Player Controller

It is responsible for moving the paddle. It has three parts (left, middle, and right). Each segment changes the trajectory of the ball.

### The Projectile

The ball can bounce or destroy objects on collision. It has a coroutine that starts when a player consumes a powerup. Moreover, The ball has different sounds based on interaction with its environment.

### The Block

It has life, its starts with one life and max at 5. The life of each block is adjusted on each level using a logarithmic function `f(level) = log2(level) + 1)`. Moreover, the block emits particles and plays a sound during a collision.

### The Powerup

It spawns at random intervals using invoke repeat function. When the player consumes the powerup, the ball grows in size for a limited time, making it easy to hit.

## The Design

### The environments

The game is 3D with an isotopic view, hence 2.5D. Objects have a bouncy material with no friction, and the ball velocity is capped based on difficulty level. The walls are tilted so that the ball never parallel bounces infinitely. Moreover, A sensor trigger destroys out-of-bound objects.

### The user-interface

It utilized buttons to adjust for difficulty and to return to the menu screen.
The text display info such as:

* Input
* Score
* Level

### The User Experience

The sound effects and particle effects enhance the user experience. A block's color changes when it has more than one. Moreover, an animator handles the transition between scenes, where it fades in and out.

### Additional Notes

Some key binds for testing purposes:

* _B_ Destroys all blocks in the scene (test the level progression).
* _T_ Launches the ball at 90 degrees (tests the tilted walls).

## Conclusion

Final thoughts, this game utilizes many concepts to make the game coherent. The Game Manager controls the flow of scenes and preserves data such as score and level. It is also a singleton, which means there will only be one it persists among states as a way of management and data passing. Moreover, A coroutine handles the time out of powerups.

Lastly, the level progression follows a mathematical model where a block requires more hits to get destroyed. There are also visual cues to show when a block has more than one life. In Addition, particle effects and audio clips enhance the user experience.

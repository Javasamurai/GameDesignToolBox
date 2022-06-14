### Read Me
Game designer toolbox
##About Project
With this toolbox, designer can design and play around different types of levels with verities of game elements
### Game configs: Scriptable object
Actor Brain
- Player Brain: Controls player speed, can be extended
- Wanderer Brain: Moves to and fro in a range, Range and speed can be tweaked
- Chaser Brain: Chases player in a range, Range of follow and speed can be tweaked
- Turret brain: Shoot projectiles

###Spawner Config: Sciptable object
UI elements of each element can tweaked
- Name shown in UI
- Sprite: Icon shown
- MaxSpawn: Max number of items can be spawned, ex: 1 for player
- Prefab: Prefab to spawn during dropping game entity

### Collectibles
- Coins: Updates game coins when collected
- Flag: Triggers game over state when collected

### Health Component: Independent component for health tracking
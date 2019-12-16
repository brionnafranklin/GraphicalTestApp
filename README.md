| Brionna Franklin|
| :---          	|
| s198017      	|
| Assessment 2 |
| Assessment 2 Documentation |

## Program Usage

  Open GraphicalTestApp.exe

  Player 1 controls (blue tank)
    -w: moves tank up
    -s: moves tank down
    -d: moves tank right
    -a: moves tank left
    -e: turns barrel right
    -q: turns barrel left
    -space bar: shoots bullet

 Player 2 controls (red tank)[key pad input only]
  -8: moves tank up
  -5: moves tank down
  -6: moves tank right
  -4: moves tank left
  -9: turns barrel right
  -7: turns barrel left
  -0: shoots bullet

After 1 minute (or holding down 6 and 9 on the keyboard) a power up will spawn in the center.
If a player collides with the power up their tank's barrel will be replaced with a better one that turns faster and fires more rapidly.

<Know bugs>
After one player dies their hitbox stays where they died and can still kill the other player. 
	(side note: for some reason the dead player's hitbox is not shown when hitboxes are toggled on)

## I. Requirements

1. **Description of Problem**: For this assessment you are to make a Visual Studio C# project that utilises your Vector and Matrix maths classes.

    - **Name**: GraphicalTestApp

    - **Problem Statement**: For this assessment you are to make a Visual Studio C# project that utilises your Vector and Matrix maths classes. This project will demonstrate the various functions and classes by drawing and manipulating images on screen.
    You are to use the RayLib C# 2D framework (available via the resources section for this subject on Canvas: https://aie.instructure.com/) when creating your graphical test application. 
    Once you have set up your project and integrated your maths classes, you will need to draw and manipulate images according to the requirements below. 
    - **Problem Specifications**: Draw a top-down 2D tank, and manipulate its orientation and position using your Vector and Matrix classes in response to keyboard input from the user.
        - Draw the tank
        - Rotate the tank by pressing the ‘A’ and ‘D’ keys on the keyboard
        - Move the tank forward or backwards in the direction it is currently facing by pressing the ‘W’ and ‘S’ keys on the keyboard
        - Draw the tank’s turret
        - Ensure the turret is parented to the tank such that moving or rotating the tank will also move or rotate the turret (i.e., implement a matrix hierarchy)
        - Rotate the turret independently from the base of the tank by pressing the ‘Q’ and ‘E’ keys
        - Fire a bullet
        - Press the space bar to fire a bullet
        - The bullet should spawn at the end of the turret, and travel in the direction the turret is currently facing
        - Ensure the bullet is not parented to either the tank base or the turret (i.e., moving the tank or turret should not move the bullet) 
        - Add simple collision detection so that the bullet is destroyed upon collision with the edge of the screen (or optionally another object)

2. **Input Information**:
    
    - pressing the w button moves player 1 up and rotates the tank and turret appropriately.
    - pressing the s button moves player 1 down and rotates the tank and turret appropriately.
    - pressing the d button moves player 1 right and rotates the tank and turret appropriately.
    - pressing the a button moves player 1 left and rotates the tank and turret appropriately.
    - pressing the e button rotates player 1's turret right.
    - pressing the q button rotates player 1's turret left.
    - pressing space shoots a bullet from player 1's turret.
    - pressing the 8 button on the keypad moves player 2 up and rotates the tank and turret appropriately.
    - pressing the 5 button on the keypad moves player 2 down and rotates the tank and turret appropriately.
    - pressing the 6 button on the keypad moves player 2 right and rotates the tank and turret appropriately.
    - pressing the 4 button on the keypad moves player 2 left and rotates the tank and turret appropriately.
    - pressing the 9 button rotates player 2's turret right.
    - pressing the 7 button rotates player 2's turret left.
    - pressing 0 on the keypad shoots a bullet from player 2's turret.
    - a super user can press 6 and 9 at the same time and force the Sans power up to spawn rather than waiting 1 minute.

3. **Output Information**:

    - **Starting Position**: player 1 starts in the top left corner 100 pixels from both the top and left sides, while player 2 starts in the bottom right 100 pixels from the bottom and right sides.
    ![User Interface gif](https://i.imgur.com/ul57wwJ.png)
    - **Shooting and turning**: both players have the ability to turn and shoot. Player 1 does this by using q to turn left, e to turn right, and space to shoot. Player 2 turns left with the 7 button on the keypad, turns right with 9 on the keypad, and shoots with 0 on the keypad.
    ![User Interface gif](https://i.imgur.com/kiZWXg9.png)
    - **Sans power up spawn**: after 1 minute or input from a super user, the sans power up will spawn in the center.
    ![User Interface gif](https://i.imgur.com/OQ0wT13.png)
    - **Abtained Sans power up**: When one of the players obtain the sans power up by moving into it, the sans icon will disappear and the player's barrel will be replaced with a new type of barrel that shoot and turns more rapidly.
    ![User Interface gif](https://i.imgur.com/jr0a1mQ.png)
    
## II. Design

1. _System Architecture_
|
|:-----------
Game Function Diagram
|
![User Interface gif](https://i.imgur.com/2RpDSqf.jpg)

2. Object Information

    **Class**: AABB

    Description: class used to display hitboxes; inherates from actor

        Attributes:

            - Name: Width
            Description: get and sets the width of the hitbox
            Type: float
            visibility: public

            - Name: Height
            Description: get and sets the height of the hitbox
            Type: float
            visibility: public

            - Name: canDrawHitbox
            Description: used to enable and disable shown hitboxes
            Type: bool
            visibility: public static

            - Name: _min
            Description: creates a default vector3 for the minimum dimentions of the AABB
            Type: Vector3
            visibility: private

            - Name: color
            Description: sets the default color of the hitbox to red
            Type: Raylib.Color
            visibility: private

        Operations:

            - Name: Top
            Description: Returns the Y coordinate at the top of the box
            Type: float
            visibility: public

            - Name: Bottom
            Description: Returns the Y coordinate at the bottom of the box
            Type: float
            visibility: public

            - Name: Left
            Description: Returns the X coordinate at the left of the box
            Type: float
            visibility: public

            - Name: Right
            Description: Returns the X coordinate at the right of the box
            Type: float
            visibility: public

            - Name: AABB
            Description: Creates an AABB of the specifed size
            Type: Constructer
            visibility: public

            - Name: DetectCollision
            Description: detects collisions using AABB
            Type: bool
            visibility: public

            - Name: DetectCollision
            Description: detects collision using a vector3
            Type: bool
            visibility: public

            - Name: DrawHitBoxes
            Description: draw the hitbox
            Type: void
            visibility: public

            - Name: Draw
            Description: Draw the bounding box to the screen
            Type: override void
            visibility: public

    **File**: Actor

    Description: in the Actor file but not in the Actor class; exists in the namespace GraphicalTestApp

        Attributes: 

            - Name: StartEvent
            Description: creates a delegate for when the program starts
            Type: delegate void
            visibility: private

            - Name: UpdateEvent
            Description: creates a delegate for when the program udates
            Type: delegate void
            visibility: private

            - Name: DrawEvent
            Description: creates a delegate for when the program draws
            Type: delegate void
            visibility: private

    **Class**: Actor

    Description: class for anything that can appear in the game

        Attributes:

            - Name: OnStart
            Description: instance of the StartEvent
            Type: StartEvent
            visibility: public

            - Name: OnUpdate
            Description: instance of the UpdateEvent
            Type: DrawEvent
            visibility: public

            - Name: OnDraw
            Description: instance of the DrawEvent
            Type: DrawEvent
            visibility: public
            
            - Name: _children
            Description: creates a list used to store children
            Type: List<Actor>
            visibility: private

            - Name: _additions
            Description: creates a list used to store addition
            Type: List<Actor>
            visibility: private

            - Name: _removals
            Description: creates a list used to store removals
            Type: List<Actor>
            visibility: private

            - Name: _localTransform
            Description: creates a matrix used for relative transform
            Type: Matrix3
            visibility: private

            - Name: _globalTransform
            Description: creates a matrix used for transform
            Type: Matrix3
            visibility: private

        Operations:

            - Name: Started
            Description: returns weather the game has started
            Type: bool
            visibility: public

            - Name: Parent
            Description: used to set and get an actor's parent
            Type: Actor
            visibility: public

            - Name: x
            Description: get and set X coordinate
            Type: float
            visibility: public

            - Name: XAbsolute
            Description: get the absolute X coordinate
            Type: float
            visibility: public

            - Name: y
            Description: get and set the relative Y coordinate
            Type: float
            visibility: public

            - Name: YAbsolute
            Description: get the absolute Y coordinate
            Type: float
            visibility: public

            - Name: GetRotation
            Description: get the rotation of _localTransform
            Type: float
            visibility: public

            - Name: Rotate
            Description: rotates using radians
            Type: void
            visibility: public

            - Name: SetRotate
            Description: set rotation to given value
            Type: void
            visibility: public

            - Name: GetScaled
            Description: just returns one
            Type: float
            visibility: public

            - Name: Scale
            Description: scales using _localTransform
            Type: void
            visibility: public

            - Name: AddChild
            Description: adds child after making sure the child doesn't have a parent
            Type: void
            visibility: public

            - Name: RemoveChild
            Description: removes a child
            Type: void
            visibility: public

            - Name: UpdateTranform
            Description: changes the position
            Type: void
            visibility: public

            - Name: GetChildren
            Description: returns an array containing a copy of _children
            Type: Actor[]
            visibility: public

            - Name: Start
            Description: Call the OnStart events of the Actor and its children
            Type: virtual void
            visibility: public

            - Name: inRange
            Description: checks to see if a givin value is with a givin min and max
            Type: bool
            visibility: public

            - Name: ToggleHitboxes
            Description: toggles on and off visial hitboxes
            Type: void
            visibility: public

            - Name: Update
            Description: Call the OnUpdate events of the Actor and its children
            Type: virtual void
            visibility: public

            - Name: Draw
            Description: Call the OnDraw events of the Actor and its children
            Type: virtual void
            visibility: public

    **Class**: Barrel

    Description: A type of entity that can turn and fire bullets

        Operations:

            - Name: Barrel
            Description: set on tank's barrel
            Type: constructer
            visibility: public

            - Name: Fire
            Description: creates bullet and sends it in the direction the barrel is facing
            Type: virtual void
            visibility: public

            - Name: p1BarrelConrols
            Description: p1 barrel controls
            Type: virtual void
            visibility: public

            - Name: p2BarrelConrols
            Description: p2 barrel controls
            Type: virtual void
            visibility: public

            - Name: Update
            Description: update every second
            Type: override void
            visibility: public

    **Class**: Bullet

    Description: a type of entity with a hitbox that is shot from barrels

        Attributes:

            - Name: _bSprite
            Description: declares the bullet's sprite
            Type: Sprite
            visibility: public

            - Name: _bHitbox
            Description: declares the bullet's hitbox
            Type: AABB
            visibility: public

            - Name: playerNum
            Description: declares the playerNum
            Type: float
            visibility: public

        Operations:

            - Name: Bullet
            Description: sets up everything the bullet is/has
            Type: constructer
            visibility: public

            - Name: inRange
            Description: checks to see if a givin value is with a givin min and max
            Type: bool
            visibility: public

            - Name: checkBulletPosition
            Description: make sure the bullet is on screen
            Type: void
            visibility: public

            - Name: tankOnBulletCollision
            Description: destroys tank if hit buy opponents bullet
            Type: void
            visibility: public

            - Name: bulletOnBulletCollision
            Description: destroys bullets when they hit each other
            Type: virtual void
            visibility: public

            - Name: Update
            Description: update every second
            Type: override void
            visibility: public

    **Class**: Entity

    Description: an Actor with movement capablities

        Attributes:

            - Name: _velocity
            Description: declares and innitializes velocity
            Type: Vector3
            visibility: private

            - Name: _acceleration
            Description: declares and innitializes acceleration
            Type: Vector3
            visibility: private

            - Name: _maxSpeed
            Description: sets max speed
            Type: float
            visibility: private

        Operations:

            - Name: XVelocity
            Description: gets and sets velocity on the X axis
            Type: float
            visibility: public

            - Name: XAcceleration
            Description: get and set acceleration on the X axis
            Type: float
            visibility: public

            - Name: YVelocity
            Description: gets and sets velocity on the Y axis
            Type: float
            visibility: public

            - Name: YAcceleration
            Description: get and set acceleration on the Y axis
            Type: float
            visibility: public

            - Name: Entity
            Description: Creates an Entity at the specified coordinates
            Type: constructer
            visibility: public

            - Name: getMaxSpeed
            Description: returns the value of max speed
            Type: float
            visibility: public

            - Name: Update
            Description: get acceleration and velocity
            Type: override void
            visibility: public

    **Class**: Game

    Description: sets up the basics for the game

        Attributes:

            - Name: _root
            Description: The current root Actor
            Type: Actor
            visibility: private

            - Name: _next
            Description: The next root Actor
            Type: Actor
            visibility: private

            - Name: _gameTimer
            Description: The Timer for the entire Game
            Type: Timer
            visibility: private

        Operations:

            - Name: Game
            Description: Creates a Game and new Scene instance as its active Scene
            Type: constructer
            visibility: public

            - Name: Run
            Description: Run the game loop
            Type: void
            visibility: public

            - Name: Root
            Description: The Actor we are currently running
            Type: Actor
            visibility: public

    **Class**: Input

    Description: creates inputs that can be assigned to keys

        Operations:

            - Name: IsKeyPressed
            Description: Returns whether the key was pressed since the last frame
            Type: static bool
            visibility: public

            - Name: IsKeyDown
            Description: Returns whether the key is currently down
            Type: static bool
            visibility: public

            - Name: IsKeyReleased
            Description: Returns whether the key was released since the last frame
            Type: static bool
            visibility: public

            - Name: IsKeyUp
            Description: Returns whether the key is currently up
            Type: static bool
            visibility: public

    **Class**: Matrix3

    Description: stores numbers in a 3 by 3 matrix

        Attributes:

            - Name: m11, m12, m13, m21, m22, m23, m31, m32, m33 
            Description: declares each spot in the matrix
            Type: float
            visibility: public

        Operations:

            - Name: Matrix3
            Description: sets the identity matrix to default
            Type: Constructer
            visibility: public

            - Name: Matrix3
            Description: sets matrix to inputted values
            Type: constructer
            visibility: public

            - Name: SetScaled
            Description: sets m11, m22, and m33 to inputted values in order to change the scale
            Type: void
            visibility: public

            - Name: SetScaled
            Description: sets m11, m22, and m33 using the inputted vector in order to change the scale
            Type: void
            visibility: public

            - Name: GetTransposed
            Description: returns a new matrix with values of the original
            Type: Matrix3
            visibility: public

            - Name: Matrix3
            Description: sets the values in the matrix to that of an inputted matrix
            Type: constructed
            visibility: public

            - Name: ToString
            Description: lists the values in the matrix
            Type: override string
            visibility: public

            - Name: *
            Description: makes it so multiplying matrices together works correctly
            Type: static Matrix3 operator
            visibility: public

            - Name: *
            Description: makes it so multiplying matrices by vectors works correctly
            Type: static Vector3 operator
            visibility: public

            - Name: Set
            Description: sets the values in the matrix to that of an inputted matrix
            Type: void
            visibility: public

            - Name: Set
            Description: sets matrix to inputted values
            Type: void
            visibility: public

            - Name: Scale
            Description: sets the scale of the matrix using 3 inputted values
            Type: void
            visibility: public

            - Name: Scale
            Description: sets the scale of the matrix using a inputted vector
            Type: void
            visibility: public

            - Name: SetRotateX
            Description: sets rotation on the x axis
            Type: void
            visibility: public

            - Name: SetRotateY
            Description: sets rotation on the y axis
            Type: void
            visibility: public

            - Name: SetRotateZ
            Description: sets rotation on the z axis
            Type: void
            visibility: public

            - Name: RotateX
            Description: rotates on the x axis
            Type: void
            visibility: public

            - Name: RotateY
            Description: rotates on the y axis
            Type: void
            visibility: public

            - Name: RotateZ
            Description: rotates on the z axis
            Type: void
            visibility: public

            - Name: SetEuler
            Description: sets the euler of the matrix usig pitch, yaw, and roll
            Type: void
            visibility: public

            - Name: SetTranslation
            Description: sets the translation of the matrix to the inputted value
            Type: void
            visibility: public

            - Name: Translate
            Description: translates the matrix by the inputted values
            Type: void
            visibility: public

    **Class**: Matrix4

    Description: stores numbers in a 4 by 4 matrix

        Attributes:

            - Name: m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44
            Description: //declares each spot in the matrix
            Type: float
            visibility: public

        Operations:

            - Name: Matrix4
            Description: sets the identity matrix to default
            Type: constructer
            visibility: public

            - Name: Matrix4
            Description: sets matrix to inputted values
            Type: construster
            visibility: public

            - Name:  GetTransposed
            Description: returns a new matrix with values of the original
            Type: Matrix4
            visibility: public

            - Name: Matrix4
            Description: sets the values in the matrix to that of an inputted matrix
            Type: constructer
            visibility: public

            - Name: ToString
            Description: lists the values in the matrix
            Type: override string
            visibility: public

            - Name: *
            Description: makes it so multiplying matrices together works correctly
            Type: static Matrix4 operator
            visibility: public

            - Name: *
            Description: makes it so multiplying matrices by vectors works correctly
            Type: static Vector4 operator
            visibility: public

            - Name: SetScaled
            Description: sets m11, m22, and m33 to inputted values in order to change the scale
            Type: void
            visibility: public

            - Name: SetScaled
            Description: sets m11, m22, and m33 using the inputted vector in order to change the scale
            Type: void
            visibility: public

            - Name: Set
            Description: sets the values in the matrix to that of an inputted matrix
            Type: Matrix4
            visibility: public

            - Name: Set
            Description: sets matrix to inputted values
            Type: Matrix4
            visibility: public

            - Name: Scale
            Description: sets the scale of the matrix using 3 inputted values
            Type: void
            visibility: public

            - Name: Scale
            Description: sets the scale of the matrix using a inputted vector
            Type: void
            visibility: public

            - Name: SetRotateX
            Description: sets rotation on the x axis
            Type: void
            visibility: public

            - Name: SetRotateY
            Description: sets rotation on the y axis
            Type: void
            visibility: public

            - Name: SetRotateZ
            Description: sets rotation on the z axis
            Type: void
            visibility: public

            - Name: RotateX
            Description: rotates on the x axis
            Type: void
            visibility: public

            - Name: RotateY
            Description: rotates on the y axis
            Type: void
            visibility: public

            - Name: RotateZ
            Description: rotates on the z axis
            Type: void
            visibility: public

            - Name: SetEuler
            Description: sets the euler of the matrix usig pitch, yaw, and roll
            Type: void
            visibility: public

            - Name: SetTranslation
            Description: sets the translation of the matrix to the inputted value
            Type: void
            visibility: public

            - Name: Translate
            Description: translates the matrix by the inputted values
            Type: void
            visibility: public

    **Class**: PowerUpController

    Description: controlls the spawning of power ups

        Attributes:

            - Name: _powerUpTimer
            Description: create the timer used for power ups
            Type: Timer
            visibility: private

            - Name: SpawnSansIcon
            Description: creates bool used to determine if SansIcon has spawned
            Type: static bool
            visibility: public

        Operations:

            - Name: SpawnSans
            Description: adds Sans power up
            Type: void
            visibility: public

            - Name: Update
            Description: update every second
            Type: override void
            visibility: public

    **Class**: Program

    Description: the basic program that calls the necessities for the game

        Operations: 

            - Name: Main
            Description: calls and sets up all the basics that are needed for the game to run correctly
            Type: static void
            visibility: private

    **Class**: SansBullet

    Description: a special type of bullet that can't shoot bullets belonging to the player who shot it

        Attributes:

            - Name: _bSprite
            Description: declares the SansBullet's sprite
            Type: Sprite
            visibility: private

            - Name: _bHitbox
            Description: declares the SansBullet's hit box
            Type: AABB
            visibility: private

            - Name: playerNum
            Description: declares the SansBullet's player number
            Type: float
            visibility: public

        Operations:

            - Name: SansBullet
            Description: sets up everything for the SansBullet uncluding x, y, playernumber, and sprite
            Type: constructer
            visibility: public

            - Name: bulletOnBulletCollision
            Description: destroys opponents bullets if they hit sansbullet
            Type: override void
            visibility: public

    **Class**: SansIcon

    Description: an icon that, when touch by a player, gives special abilities to that player; inherates from Entity

        Attributes:

            - Name: _sHitbox
            Description: creates a hitbox for SansIcon
            Type: AABB
            visibility: public

            - Name: _sSprite
            Description: creates a sprite for SansIcon
            Type: Sprite
            visibility: public

            - Name: SansLists
            Description: list of SansIcon
            Type: static List<SansIcon>
            visibility: public

        Operations:

            - Name: SansIcon
            Description: creates SansIcon and gives it all it's probertities
            Type: constructer
            visibility: public

    **Class**: SansUp

    Description: a special type of barrel that replaces the default barrel when a player touches the SansIcon

        Attributes:

            - Name: _bSprite
            Description: declares a sprite that will be used for the SansUp
            Type: Sprite
            visibility: private

            - Name: _bHitbox
            Description: declares a hit box that will be used for the SansUp
            Type: AABB
            visibility: private

        Operations:

            - Name: SansUp
            Description: replace barrel
            Type: constructer
            visibility: public

            - Name: Fire
            Description: creates bullet and sends it in the direction the barrel is facing
            Type: override void
            visibility: public

            - Name:  p1BarrelConrol
            Description: p1 barrel controls
            Type: override void
            visibility: public

            - Name:  p2BarrelConrol
            Description: p2 barrel controls
            Type: override void
            visibility: public

            - Name: Update
            Description: update every second
            Type: override void
            visibility: public

    **Class**: Sprite

    Description: an image that can be childed in order to make the parent visible

        Attributes:

            - Name: _texture
            Description: declares and innitaulizes a new texture
            Type: Texture2D
            visibility: private

            - Name: _image
            Description: declares and innitaulizes a new image
            Type: Image
            visibility: private

        Operations:

            - Name: Width
            Description: The width of the Sprite
            Type: float
            visibility: public

            - Name: Height
            Description: The height of the Sprite
            Type: float
            visibility: public

            - Name: Sprite
            Description: Default constructor
            Type: constructor
            visibility: public

            - Name: Draw
            Description: Draw the Sprite to the screen
            Type: override void
            visibility: public

    **Class**: Tank

    Description: the main entity controled by the player

        Attributes:

            - Name: playerNum
            Description: assigns a number value to a player
            Type: uint
            visibility: private

            - Name: PlayerList
            Description: ceates a list of players
            Type: static List<Tank>
            visibility: public

            - Name: _Sprite
            Description: declares a sprite that will be used for the tank
            Type: Sprite
            visibility: private

            - Name: _pHitbox
            Description: declares a hitbox that will be used for the tank
            Type: AABB
            visibility: private

            - Name: _pBarrel
            Description: declares a barrel that will be used for the tank
            Type: Barrel
            visibility: private

            - Name: _pBarrelSprite
            Description: declares a sprite that will be used for the barrel
            Type: Sprite
            visibility: private

        Operations:

            - Name: Tank
            Description: places tank
            Type: constructer
            visibility: public

            - Name: inRange
            Description: checks to see if a givin value is with a givin min and max
            Type: bool
            visibility: public

            - Name: checkTankPosition
            Description: make sure the player is on screen
            Type: void
            visibility: public

            - Name: getTankHitbox
            Description: returns the AABB that is the tanks hit box
            Type: AABB
            visibility: public

            - Name: MoveUp
            Description: move player up
            Type: void
            visibility: public

            - Name: MoveDown
            Description: move player down
            Type: void
            visibility: public

            - Name: MoveRight
            Description: move player right
            Type: void
            visibility: public

            - Name: MoveLeft
            Description: move player left
            Type: void
            visibility: public

            - Name: p1controls
            Description: player 1 controls
            Type: void
            visibility: public

            - Name: p2controls
            Description: player 2 controls
            Type: void
            visibility: public

            - Name: SlowDown
            Description: makes stops gradual
            Type: void
            visibility: public

            - Name: getPlayerNum
            Description: returns player number
            Type: uint
            visibility: public

            - Name: tankOnTankCollision
            Description: destroys both tanks when they collide
            Type: void
            visibility: public

            - Name: tankOnSansIconCollision
            Description: replaces regular barrel with sansUp
            Type: void
            visibility: public

            - Name: Update
            Description: update every second
            Type: void
            visibility: public

    **Class**: Timer

    Description: Controls time in the game

        Attributes:

            - Name: _stopwatch
            Description: declares and innitaulizes a new stopwatch
            Type: Stopwatch
            visibility: private

            - Name: _currentTime
            Description: declares and innitaulizes the currentTime
            Type: long
            visibility: private

            - Name: _previousTime
            Description: declares and innitaulizes the previousTime
            Type: long
            visibility: private

            - Name: _deltaTime
            Description: declares and innitaulizes deltaTime
            Type: long
            visibility: private

        Operations:

            - Name: Timer
            Description: starts the stopwatch
            Type: constructer
            visibility: public

            - Name: Restart
            Description: restarts the stopwatch
            Type: void
            visibility: public

            - Name: Seconds
            Description: The time in seconds
            Type: float
            visibility: public

            - Name: GetDeltaTime
            Description: calculates delaTime
            Type: float
            visibility: public

    **Class**: Vector3

    Description: stores 3 seperate numbers

        Attributes:

            - Name: x
            Description: declares x
            Type: float
            visibility: public

            - Name: y
            Description: declares y
            Type: float
            visibility: public

            - Name: z 
            Description: declares z
            Type: float
            visibility: public

        Operations:

            - Name: Vector3
            Description: sets the values of the vector to default to 0
            Type: constructer
            visibility: public

            - Name: Vector3
            Description: sets the values of the vector to the values it takes in
            Type: constructer
            visibility: public

            - Name: ToString
            Description: lists the values in the vector
            Type: override string
            visibility: public

            - Name: +
            Description: changes how addition between two vectors works so that it's done correctly
            Type: static Vector3 operator
            visibility: public

            - Name: -
            Description: changes how subtraction between two vectors works so that it's done correctly
            Type: static Vector3 operator
            visibility: public

            - Name: *
            Description: changes how multiplication between a vector and a number (scaler) works so that it's done correctly
            Type: static Vector3 operator
            visibility: public

            - Name: *
            Description: changes how multiplication between a number (scaler) and a vector works so that it's done correctly
            Type: static Vector3 operator
            visibility: public

            - Name: /
            Description: changes how division between a vector and a number(scaler) works so that it's done correctly
            Type: static Vector3 operator
            visibility: public

            - Name: /
            Description: changes how division between a number (scaler) and a vector works so that it's done correctly
            Type: static Vector3 operator
            visibility: public 

            - Name: Dot
            Description: returns the dot product two vectors
            Type: float
            visibility: public

            - Name: Cross
            Description: returns the crossproduct of two vectors
            Type: Vector3
            visibility: public

            - Name: MagnitudeSqr
            Description: returns the square of the magnitude of the vector
            Type: float
            visibility: public

            - Name: Magnitude
            Description: returns the magnitude of the vector
            Type: float
            visibility: public

            - Name: Distance
            Description: returns the distance between two vectors
            Type: float
            visibility: public

            - Name: DistanceSqr
            Description: returns the distance between two vectors squared
            Type: float
            visibility: public

            - Name: Normalize
            Description: divides each value in the vector by the magnitude
            Type: void
            visibility: public

            - Name: GetNormalized
            Description: returns the vector divided by the magnitude
            Type: Vector3
            visibility: public

            - Name: Perpendicular
            Description: returns the vector that is perpendicular to the vector
            Type: Vector3
            visibility: public

            - Name: Angle
            Description: returns the angle between two vectors
            Type: float
            visibility: public

            - Name: Min
            Description: returns a vector with the minimum values from each inputted vectors
            Type: static Vector3
            visibility: public

            - Name: Max
            Description: returns a vector with the maximum values from each inputted vectors
            Type: static Vector3
            visibility: public

            - Name: clamp
            Description: clamps a vector between two other vectors
            Type: static Vector3
            visibility: public

    **Class**: Vector4

    Description: stores 4 seperate numbers

        Attributes:

            - Name: x
            Description: declares x
            Type: float
            visibility: public

            - Name: y
            Description: declares y
            Type: float
            visibility: public

            - Name: z 
            Description: declares z
            Type: float
            visibility: public

            - Name: w
            Description: declares w
            Type: float
            visibility: public

        Operations:

            - Name: Vector4
            Description: sets the values of the vector to default to 0
            Type: constructer
            visibility: public

            - Name: Vector4
            Description: sets the values of the vector to the values it takes in
            Type: constructer
            visibility: public

            - Name: ToString
            Description: lists the values in the vector
            Type: override string
            visibility: public

            - Name: +
            Description: changes how addition between two vectors works so that it's done correctly
            Type: static Vector4 operator
            visibility: public

            - Name: -
            Description: changes how subtraction between two vectors works so that it's done correctly
            Type: static Vector4 operator
            visibility: public

            - Name: *
            Description: changes how multiplication between a vector and a number (scaler) works so that it's done correctly
            Type: static Vector4 operator
            visibility: public

            - Name: *
            Description: changes how multiplication between a number (scaler) and a vector works so that it's done correctly
            Type: static Vector4 operator
            visibility: public

            - Name: /
            Description: changes how division between a vector and a number(scaler) works so that it's done correctly
            Type: static Vector4 operator
            visibility: public

            - Name: /
            Description: changes how division between a number (scaler) and a vector works so that it's done correctly
            Type: static Vector4 operator
            visibility: public 

            - Name: MagnitudeSqr
            Description: returns the square of the magnitude of the vector
            Type: float
            visibility: public

            - Name: Magnitude
            Description: returns the magnitude of the vector
            Type: float
            visibility: public

            - Name: Distance
            Description: returns the distance between two vectors
            Type: float
            visibility: public

            - Name: DistanceSqr
            Description: returns the distance between two vectors squared
            Type: float
            visibility: public

            - Name: Normalize
            Description: divides each value in the vector by the magnitude
            Type: void
            visibility: public

            - Name: GetNormalized
            Description: returns the vector divided by the magnitude
            Type: Vector4
            visibility: public

            - Name: Dot
            Description: returns the dot product two vectors
            Type: float
            visibility: public

            - Name: Cross
            Description: returns the crossproduct of two vectors
            Type: Vector4
            visibility: public

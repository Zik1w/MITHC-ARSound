# MITHC-AR Sound Test

## Dependencies

Plugins/FMODStudio: The offical integration from FMOD, integrated to the game as plugin. For more information as well as how to integrated into Unreal Engine itself check https://www.fmod.com/resources/documentation-ue4?version=2.0&page=user-guide.html.



## Sound Module

Content/StarterContent/Maps: Stored the level blueprint, most of the sound trigger logics are written into this level blueprint 

Content/FMOD: Directory for Fmod banks data, including all other related data such as events, snapshots, etc. 

Content/Sound_Objects: Custermized blueprints in the Unreal that has Fmod compoenents added



## Level Blueprint 

The sound related logics are broken down into three parts:

* Create & Set Sound-related Game State/Parameter
* Constantly Check Game State/Parameter
* Mechanims for Trigger FMOD Event

![Screen Shot 2020-01-03 at 3.48.41 PM](/Users/wzq/Desktop/Screen Shot 2020-01-03 at 3.48.41 PM.png)



## Sound Events trigger logics

### Create & Set Sound-related Game State/Parameter - State Variable to be used by FMOD events

A float variable called *Modification* is created in level BP, it is the corresponding parameter that will be used by the FMOD events.  InputAction are keyboard inputs and they will modify the variable value accordingly:

* InputAction *Unmod*   - Keyboard Input of '1' : Sound events for No Modification Mode
* InputAction *Partmod* - Keyboard Input of '2' : Sound events for Partly Modification Mode 
* InputAction *Fullmod*  - Keyboard Input of '3' : Sound events for Full Modification Mode

![Screen Shot 2020-01-03 at 3.47.34 PM](/Users/wzq/Desktop/Screen Shot 2020-01-03 at 3.47.34 PM.png)



### Check Game State/Parameter - FMOD events from different sound objects that will be affected by the parameter values are each refreshed with event tick checking for the parameter value

Ambience Sound and Propo are FMOD AudioComponent that are attached to the sound BPs. They are both affected by the paramter called Modification in the FMOD event. **The input for the 'Name' parameter in the Set Parameter function must match the one that is used in FMOD.**

![Screen Shot 2020-01-03 at 3.47.49 PM](/Users/wzq/Desktop/Screen Shot 2020-01-03 at 3.47.49 PM.png)



### Trigger FMOD Event - Use Trigger box and collision logic to trigger sound events and FMOD snapshots (Auto-ducking)

The *Dialogue_SS_Trigger* is the object that trigger both sound event Propo and The snapshot when the main camera enter its trigger zone. The Dialogue_SS is a snapshot that fade down the world and ambient sounds, and turn up the supposed Dialogue/Voiceover to allow the user hear it clearly, it has the function of auto-ducking and provide loudness hiercharchy for the game.

![Screen Shot 2020-01-03 at 3.48.16 PM](/Users/wzq/Desktop/Screen Shot 2020-01-03 at 3.48.16 PM.png)
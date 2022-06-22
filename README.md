# Selfiedado Dice App

_Selfiedado Dice App is a companion app for the dice game Selfiedado. You can use this app to roll your Selfiedado dice instead using the real ones. This app is part of my mini games portfolio. The app allows you to roll dice by shaking your mobile phone._

> More info: [Selfiedado on itch.io](https://tmseldon.itch.io/selfiedado) 

_If you want to know more about the physical boardgame_
> BoardGameGeek entry: [Selfiedado on BoardGameGeek](https://boardgamegeek.com/boardgame/271842/selfiedado) 

## Game design and technical challenges

While designing and developing this game, I found some interested points that I would like to list and detail. On future versions of this document, I will get more on depth on some of these elements.

- **Main objective**: the goal of this game is to replicate the traditional dice roller that are used in tabletop RPGs. However, I wanted to do the digital version for Selfiedado. Since Selfiedado is a dice game created by my friend Claudia and myself, I thought that it could be really fun to have a digital version of our game. The idea was simple: to create a dice roller that you could shake by using the smartphone's sensors.
- **Physics**: I started using the acceleration data that the smartphone provides to move the dice. However, acceleration data was not very reliable because it was too sensitive to changes. I found also that the information has some kind of noise: when the smartphone was not moving and was laying on a flat surface, I got some readings and values different from zero. I tried to calibrate the smartphone (I tried three different devices using Unity Remote 5) but I got the same result.
After looking on Unity's documentation, I decided to test with the gyroscope data. This time, the values were far more stable and manageable. Having this option, I started to test applying forces on different places of the die. The goal was to provide enough torque to make the dice move and rotate at the same time.
- **Importing models**: the dice and wooden dice tray were modelled on Blender 2.9. At the beginning, the texture of each object was implemented using the _Mapping Node_. Even though, in Blender models looked fine, when I imported them into Unity, all the textures were no loaded. After some tests and research, I noticed that the texture should be mapped on the _UV Map_ editor in order to get the textures loaded in Unity. However, there were some inconsistencies on the angles of the projected texture of the dice tray. I suspect that it might be related with differences on how the global axis are defined in each software: on Blender the z-axis is the up-down axis but in Unity, it is the y-axis; this difference might affect the rotation transformation that internally occurs in these software. This angle difference is not very noticeable and does not affect the game, so I leave this issue for further study.

- **Google Play Store**: this app was made for Android devices. I took this opportunity to learn the whole app publishing process into Google Play Store. I built the app bundle according the requirements but I got some errors related with _il2cpp_. After several tries, I decided to reinstall the Android SDK (I was using the SDK that Unity installs by itself). After doing that, the build passed and I got the app bundle.
After uploading the required files, the other portion of the process was related with the marketing and legal stuff. It was interesting to go through this part because I did not foresee the required work and materials needed to publish an app in Google Play Store.

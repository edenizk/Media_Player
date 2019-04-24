# LASAGNA - MEDIA PLAYER

**1. The Goal**
    In the last few years, many streaming services have appeared, which
    made us create playlists with your favorite music for every media which
    we use. There are a lot of media players across the internet which you
    can use to collect into one program, but none of them allows you to that
    quickly and in an easy way. This is why we wanted to create our own
    media player, hereafter called “Lasagna”.
    
 **2. Quick presentation of usage.**
Listening and adding local files:

● Choose folder icon to open local songs

● All you have to do is choose a location on your computer to open.

● After opening the folder your mp3 and mp4 files will appear in
Lasagna

● You can click plus to add a song into a playlist you choose or by

clicking the play button to start the song you choose
Youtube

● Choose Youtube icon to open Youtube webpage

● Choose your video

● Decide if you want to download video or audio and click download
icon top right

● Your media will appear in downloads list


**3. Architecture Decisions**
    **3.1. Class Diagram**
    ![mediaplayerclassdiagram](https://user-images.githubusercontent.com/35309972/56681392-8e196780-66c9-11e9-8684-e4bfd187cc93.jpg)
    **3.2. Class inheritance and functions**
       For containing all of the playlists we used class ​ **_Playlists​_** , which has
       List of playlists(​ **_ListsOfPlaylist​_** ) and functions for saving and
       opening XML files which are used for saving playlists even after
       closing the program.
       Main functions, like ​ **_play()​_** , ​ **_pause()​_** , ​ **_next()​_** , ​ **_prev()​_** are located in
       **_Playlist ​_** class. The reason why we placed it there and not in the
       media is, that we need to operate and search files in playlists. All
       files which are visible in media player, are in at least one playlist(for
       example playlists of All files).
       This class contains a list of all media files we saved in the given
       playlist, also it has name and function ​ **_SetSourceAndPlay()​_** , which
       takes the path and then start play given media.
**_Media ​_** is abstract class which contains functions which are used in
classes ​ **_Local ​_** and ​ **_Youtube​_** , for getting path or Url to upload media



 **3.3. API**
We used NuGet for getting APIs. NugGet is a Visual Studio extension that
makes it easy to add, remove, and update libraries and tools in the project:

● **Taglib**: reading and editing the meta-data of several popular audio
and video formats.

● **YoutubeExplode**: getting metadata of Youtube videos, playlists and
channels. It doesn’t use the official API, so there is no need to use
Youtube API key. It uses AngleSharp and Newtonsoft.Json libraries.

    ○ AngleSharp: library that gives you the ability to parse angle
    bracket based on hyper-texts(HTML SVG, etc.).
    
   ○ Newtonsoft.Json: JSON framework for the .NET
   
   ● ​Nreco.VideoConverter: Video converter component for .NET.
       wrapper for FFmpeg command line tool, it can convert
       video/audio files, screen capture, etc.(everything that is
       possible with FFmpeg from the command line).

**4. Problems**

    · ​Web browser supports IE 7, and because of that Google doesn’t allow
       us to use a search engine of youtube.
       
    · ​Downloaded videos or audios from youtube duration might be 75%
       percent incorrect due to the API.
       
**5. Conclusion**


Lasagna is the media player which contains lots of standard
functions of the media player, but also gives you the possibility to collect all the
music and videos from most popular streaming services. There is a possibility to
upgrading functioning already existing and adding another one.

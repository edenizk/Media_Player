# Media_Player(Lasagna)
Used technologies: .Net/C#/XALM
 
The Goal
In the last few years, many streaming services have appeared, which made us create playlists with your favorite music for every media which we use. There are a lot of media players across the internet which you can use to collect into one program, but none of them allows you to that quickly and in an easy way.  This is why we wanted to create our own media player, hereafter called “Lasagna”.
 
     Quick presentation of usage.
 

Listening and adding local files:
Choose folder icon to open local songs
All you have to do is choose a location on your computer to open.
After opening the folder your mp3 and mp4 files will appear in Lasagna
You can click plus to add a song into a playlist you choose or by clicking the play button to start the song you choose
 Youtube
Choose Youtube icon to open Youtube webpage
Choose your video
Decide if you want to download video or audio and click download icon top right
Your media will appear in downloads list
	

API
We used NuGet for getting APIs. NugGet is a Visual Studio extension that makes it easy to add, remove, and update libraries and tools in the project:
Taglib: reading and editing the meta-data of several popular audio and video formats.
YoutubeExplode: getting metadata of Youtube videos, playlists and channels. It doesn’t use the official API, so there is no need to use Youtube API key. It uses AngleSharp and Newtonsoft.Json libraries.
AngleSharp: library that gives you the ability to parse angle bracket based on hyper-texts(HTML SVG, etc.).
Newtonsoft.Json: JSON framework for the .NET

 Nreco.VideoConverter:  Video converter component for .NET. wrapper for FFmpeg command line tool, it can convert video/audio files, screen capture, etc.(everything that is possible with FFmpeg from the command line).

Problems
·         Web browser supports IE 7,  and because of that Google doesn’t allow us to use a search engine of youtube.
·         Downloaded videos or audios from youtube duration might be 75% percent incorrect due to the API.












Instructions: (for Windows only)
* Check out the project from github
* Open project in Visual Studio and Build the project in debug mode
* copy your input files (user.txt and tweet.txt) into the folder /bin/debug/

Two Options to run the program:
First Option:
1. On the menu Click Project > TweeterFeed Properties... 
2. Select Debug on the left of the properties page.
3. Make sure Configuration: is set to Debug
4. Under Start Options type the input file names in Command line arguments: e.g. user.txt tweet.txt

Second Option:
1. Add path to C# compiler to your Environment Variables
2. Open command prompt.
3. Navigate to the project \bin\Debug\
4. Type TweeterFeed.exe <user filename> <tweet filename> and press enter.


Assumptions Made:
* A valid line in users file should have the word "follows".
* A valid line in tweet file should have the '>'
* The name of the user is the unique identifier e.g. Alan is the same person appearing 3 times in the example.
* User information and tweets will come from the same file type.
* User may later request that program be able to loader users and tweets information from other file types - which would be implemented with minimal code changes.



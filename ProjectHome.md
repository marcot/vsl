# General #
This is a testing environment used for creating visual surveillance applications.
The main idea that stand behind it is to supply the users various surveillance algorithms which they mix together to create different behaviors.

The environment supports plug-in behavior which allows to develop such algorithms in a consistent manner.
The application implements a GUI interface based on Windows forms 2.0 and is written entirely using C#.

# Motivation #
1. Anomaly detection  - This is the first motivation for such a system that comes into mind , i.e. the ability to learn somehow what is considered a normal behavior and any behavior that deviates from the normal one is considered an anomaly.
An example usage can be in an office building entrance hall were we all know that people go straight to the lobby after they enter the building, so people that decide to go to a different direction can be considered harmful.

2. Automated security - In today’s world when each security guard has to pay attention to several surveillance cameras sometimes automating the entire process can help decrease costs and increase the effectiveness of each guard (pay attention only to certain events that the system already screened for you).

3. Crowed flux statistics - How many cars are using this road, how many cars are coming from road A and how many from road B, by knowing that I can decide which road to widen.

# General structure #
A surveillance system gets a stream of images and tries to learn from this stream several important facts:

1. Are there any objects in the images, by objects I mean people, cars, suitcases, body limbs (hand, head etc...) and you can add as much as you want to this list.

2. What is the type of the objects, is it a car or a person again you can continue as much as you want.

3. What is the current position of the object in x,y coordinates (maybe even z)

4. Does the position of the object means something to me, does this car in position 10,50 is driving in a valid trajectory.

This project tries to encapsulates this structure in a consistent manner.
Each plug-in needs to implement a set of interfaces in order to allow the main program to communicate and configure it.

The project support runtime configuration and runtime information on the various algorithm implementation

# Used by #
  * The "Walk on the Sun" STEREO Space Mission Science Exhibit. For more information please visit: http://www.drsrl.com/exhibits.

# Using the code #
in case that you use vsl in your published work, please include a reference/acknowledgment to this page: http://code.google.com/p/vsl/wiki/Bibtex.
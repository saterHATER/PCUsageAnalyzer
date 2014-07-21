WindowsService1
===============

Apologies for the lousy name. This is only a prototype for my desired project:

                /////////////////////
                //WINDOWS NANNY PRO//
                /////////////////////


Windows Nanny Pro (WNP) is a project I've wanted to make for a while. Here's the project goals:


1. Giving users specific time-allowances for computer usage, rather than having 'time windows' like windows 7 uses.
2. Giving time limits for usage of specific programs, such as steam-based computer games.
                -this may be either allowance based or time-windowed, depending on user preferences.
3. Allow administrators to clearly define procrastination and productivity.
4. Give the administrator statistics of applications usage
                -Statistics of web usage would also be nice.
5. Let the admins designate programs as 'productive' or 'non-productive'
            -Let the user create an award system based upon the usage of the differently classified programs.


Here's the core functionalities of this applications:


1. Create a windows service to run on every user.

2. Logs all active UNIQUE programs

3. Is able to read the admin's preferences

4. Capable of manipulating user sessions and applications in accordance of the user's preferences.

5. gives 'heads-up' on application usage.

6. Create and interface for the admin.

7. displays statistics of other's usage

8. allows for the creation of unique and dynamic productivity schemes for each users.
      //more planning for this guy, I'm not willing to think about it right now.

TODO:
-------------------------------------------------------------------------------------------
  1. Create a service that can run on my system                                   (check)
  2. Have said service have a regularly occuring routine                          (check)
  3. Create a service that is easily installable                                  (check)
  4. Give the service an active application scanner                               ()
  5. Refine the scanner to only unique applications                               ()
  6. Design an application monitoring system                                      ()
  7. Create a client pop-up interface                                             ()
  8. Demonstrate interactivity with a configuration file (xml?) and the service   ()
  9. Demonstrate application manipulation with our service                        ()
  10. Add user distinction functionality in the service                           ()
  11. Test the service on another account                                         ()
  12. Add a UI to modify the configuration file

==========================================================================================
Game plan for this week
==========================================================================================
As of now:
I'm able to hapily debug a working service that can capture running applications at regular intervals.
What must be done:
1. A scheme for recording program run times must be tested and implemented (some sor t of log file).
2. A configuration file must be integrated into the service. I.E. the service must read configurations from a file in regular intervals
3. The service (and the config) must distinguish different users
 
Config Heiarchy:
Users-->programs-->usage points
     -->time periods-->point multipliers
...yeah, I ought to get a diagram of this stuff. 

WindowsService1
===============

Apologies for the lousy name. This is only a prototype for my desired project:

                /////////////////////
                //WINDOWS NANNY PRO//
                /////////////////////

Windows Nanny Pro (WNP) is a project I've wanted to make for a while. Here's the project goals:
1. Deliver customizable parental controls by
   *Giving users specific time-allowances for computer usage, rather than having 'time windows' like windows 7 uses.
   *Giving time limits for usage of specific programs, such as steam-based computer games.
      -this may be either allowance based or time-windowed, depending on user preferences.
2. Allow administrators to clearly define procrastination and productivity.
  *Give the administrator statistics of applications usage
      -Statistics of web usage would also be nice.
  *Let the admins designate programs as 'productive' or 'non-productive'
      -Let the user create an award system based upon the usage of the differently classified programs.

Here's the core functionalities of this applications:
1. Create a windows service to run on every user.
  *Logs all active UNIQUE programs
  *Is able to read the admin's preferences
  *Capable of manipulating user sessions and applications in accordance of the user's preferences.
  *gives 'heads-up' on application usage.
2. Create and interface for the admin.
  *displays statistics of other's usage
  *allows for the creation of unique and dynamic productivity schemes for each users.
      //more planning for this guy, I'm not willing to think about it right now.

TODO:                                                                             done?
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
  12. Add a UI to modify the configuration file                                   ()

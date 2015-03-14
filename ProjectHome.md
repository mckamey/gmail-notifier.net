## Notifier ##

This is an implementation of the Gmail Notifier in .NET/C#.  It works for both Gmail as well as Google Apps.

At the time when I wrote this (and possibly still), the basic Gmail Notifier app would not function with Google Apps.  I wrote my own in .NET to be able to add onto it but never really did. I still use it every day and have one running for each of my email accounts.

This app works identically to Gmail Notifier: sits in the system tray silently awaiting new messages. Turns blue when messages arrive and displays a notification overlay which can be clicked to continue to Gmail / Google Apps mail.


---


## [WebFeeds](http://code.google.com/p/web-feeds/) ##

Internally it simply reads the Atom feed for your Gmail / Google Apps account.  With some minor UI tweaking it could work with other email services or even a basic RSS reader.  It has a full fledged RSS/Atom library which powers it.
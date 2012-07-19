Bootstrap Mvc Helper Extensions
===============================

Many of the sites I have built lately use http://twitter.github.com/bootstrap/index.html .  
I find myself copying the same html helpers for the bootstrap form elements on the majority 
of these sites.  Worse then that I make modification in one or more of these projects and 
trying to keep them up to date has proven to be a pain in the ass.

The goal of this project is to extract out the helper extensions to a library and convert
that library into a nuget package.  Then the next site I build that needs these helpers will 
only require the installation of a nuget package.
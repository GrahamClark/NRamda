# NRamda
C# port of the [Ramda](https://github.com/ramda/ramda) functional library for Javascript.

This is just intended as an academic exercise, but it may turn out to be useful! Just a 
way to get more comfortable with Functional Programming concepts.

I've just gone through the [Ramda documentation](http://ramdajs.com/docs/), implemented a 
function, and then replicated as many of the [Ramda tests](https://github.com/ramda/ramda/tree/master/test)
as are applicable to C#.

The major difference between Ramda and NRamda is flexibility. There's no "this parameter
is a function" in C# as there is in Javascript - here we've got to be more explicit: "this
parameter is a function that takes a string and an int and returns a bool", or with generics 
"this parameter is a function that takes 2 parameters and returns something". So if an NRamda
function doesn't work with a particular function parameter, an overload will probably need
adding.

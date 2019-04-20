# Surface-Area-of-Sphere
This is a repository to hold my program of approximating the surface area of a sphere.
The program should be self explanatory if you read the comments in the code.
To summarize the project, you input a value for the number of rows and columns of trapazoids used to approximate a sphere.
The project will then output a bunch of values:
"b" represents the length of the horizontal segments of trapazoids.
"a" the distance from the center axis that the ends of segments are.

The theory behind this is that a sphere can be equally cut into 8 parts.
Note this: the 1/8 of a circle has three 1/4 circle sides.
Now think to a proof of the perimeter of a sphere involving 1/4 circles (it uses angles, the law of cosines, and the radius).
This proof is used to simulate lines that approximate the perimeter of the circle that are equal.
The length of these lines are to be called b subscript n.
Between two 1/4 circle sides, there are other 1/4 circle whose radius is >= 0 and <= 1.
To clarify, the 1/4 circles >= 0 and <= 1 are crossections of the 1/8 sphere.
The radius of these crossections can be determined by the points on the 1/4 circle sides,
specifically the ones not parallel to the cross sections.
Using the mini radii, you can determine the length of lines approximating the perimeter.
Since each point of the sphere is 1 from the orgin, they can be represented by a 1-radius 1/4 circle
and their vertical distance to the points above and below is b subscript n (a visual would help and I have commited two (one has color)).
Using everything above, you can deduce the measures of isoceles trapazoids (where "r" represents row or recursion)
with slant height b subcript n, top length b subscript r, and bottom length b subscript r+1.
The area of an isoceles trapazoid with slant height a, short side b, and long side c is ((c+b)/2) + Sqrt((a^2) - (((c-b)/2)^2))
The combined areas must be multiplied by 8 to represent the entire sphere.
Finally, a computer can be used to perform all of these calculations or they can be done manually. 
(Something to note is that, as far as I know, these series of equations can be combined or turned into a sigma equation.)
However, due to rounding problems (especially with b subscript r) the answer is increasingly inconsistent.
For example, inputing 8 returns 3.889, 9 returns 3.975*PI, 10 returns 3.979*PI, but 11 returns 3.901*PI.
A more drastic example is where 90 returns 3.9997*PI whereas 91 returns 0.0299*PI.
Actually, in the last example, the values for the area were all zero except for the final one.
From then on all values of area are locked to zero except for the largest trapazoid, because every b subscript r is equal to zero
except for b subscript n since it was not calculated with any variable "a"

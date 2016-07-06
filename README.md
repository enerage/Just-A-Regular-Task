# Just-A-Regular-Task.
Its quite boring, lets do some tasks.

------------------------------------------------------------------------
Write a console application that takes 3 command line arguments in the format:

input=<user defined input file path> alpha=<user defined alphabetic output file path> numer=<user defined numerical output file>

The application should read the input argument file and output its results to the alpha and numer files.

Parts of the input file contains information in the following format:

[<group>(<item>\<item>\<item>)<group>(<item>\<item>\)][<group>(<item>)]

Where, <group> is the name of a group containing items and <item> is the value of the item.
‘[‘ and ‘]’ characters contain groups, and ‘(‘ and ‘)’ contain items within a group.
Items can be alphabetic, alphanumeric or numeric, for example; zebra, word3 or 986.

The groups and items need to be extracted from the input file, processed, and written to the output files.

Output:
- The app should write 2 output files, one containing all the alphanumeric items, and another containing all the purely numeric items.
- The output items should be listed under their group name, each on a new line and indented by 1 space.
- There should be an empty line between groups.
- Items must be listed in increasing numerical and alphabetical order per group.
- Items should be listed only once per group even if there are duplicates in the input file.
- Groups must also be listed in increasing alphabetical and numerical order per file.
- New line and other control characters in the input file must be ignored / not included in the output.
- Duplicated groups should be listed just once per output file including items from both.
- Do not include empty items.

Example input and resulting output alpha and numer files

input file:

56T[zebra(foolish\75\toledo\wisconsin\56\)horse(\5\alien
\yelling\hello\alien\88\felt\79)]garbage[zebra(great\44\43\sold\\)byfar(1\3\2\5\m8T)]welling

Resulting alpha ouptut file:
----------------------------

byfar
 m8T

horse
 alien
 felt
 hello
 yelling

zebra
 foolish
 great
 sold
 toledo
 wisconsin


Resulting numer output file:
----------------------------

byfar
 1
 2
 3
 5

horse
 5
 79
 88

zebra
 43
 44
 56
 75

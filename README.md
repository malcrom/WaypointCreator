# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/Fire%20Elemental.png) Waypoint Creator

Used to create paths for npcs on wow private servers.
Note: This software requires a parsed packet file to work.

## Login

When you start the program you will see the following window. If you have access to a database you can connect to it so the program can provide the creatures name for the entries you have sniffed. just input the data required to connect to your database and click ok. If save values is checked it will save your data so next time you use the software you will just need to click ok. Connecting to a database is used to display creatures names and is recommended but not required and if you do not wish to you can just click cancel.

# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/login_screen.png)

## Main Window

After you login to your database, or click cancel, you will be presented with the main window. Click the import sniff button and you will see an Open file window.

# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/main_window.png)

Select a parsed pkt file on your computer to load into the program and click the Open button. The program will then collect all the movement packets from the sniff file.

# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/open_file.png)

You will now see that a file has been loaded into the program ready to examine the movement packets

# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/loaded_file.png)

You can now search through the movement packets by all, leaving the entry textbox blank, or you can input a creature entry to narrow the search as shown below.

# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/search_all.png)
# ![logo](https://github.com/malcrom/WaypointCreator/blob/master/images/search_entry.png)

You will see a list of guids the program has collected movement packets for, if any. You can then select a guid, by clicking on it, and you will be shown its collected movement packets displayed in a list and on a grid.

This group of movement packets shown here is obviously random movement and not a path But it is still useful. First note that "Gray Bear" is shown because I logged into my database. If I did not log in this would show "Entry XXXXX database not connected". Also if you are connected to a database and the sniff contains a creature not found in that database you will see "Entry XXXXX not in database".

If you look in the top right of the window you will see Wander Range. This is a calculation of the move radius based on the distance between the two farthest collected move points. This will be more accurate with more points collected. Note that if you see a spike where the creature moved into combat you may wish to delete those points for a more accurate calculation. I will get into cutting and pasting when I discuss paths. Here I would set the wander distance for this creature to 10.



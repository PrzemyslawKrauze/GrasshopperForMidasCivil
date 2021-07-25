# GrasshopperForMidasCivil
Grasshopper component for converting Rhino geometry to Midas Civil commands.

## What problem does it solve?
The lack of a link between Rhino and Midas Civil.

## How does it solve the problem?
By converting simple Rhino geometry into Midas Civil commands which can be loaded to Midas Civil.

## Why this solution?
Due to the absence of API in Midas Civil there is no possibility to create a dynamic link between Rhino and Midas Civil. However, Midas Civil allows to import/export and edit
models as text commands which can be used to create a static link from Rhino to Midas Civil.

## Features:
Converts Rhino geometries into Midas elements, such as:
- Points to Nodes
- Lines/Curves to Beams
- Meshes to Plates

Allows to add prefixes to Node and Elements for better managing the elements IDs.

## How to install?
Copy content of GHComponent folder into your Grasshopper libraries. You can find more information [here](https://parametricbydesign.com/grasshopper/tutorials/installing-grasshopper-and-plugins/).


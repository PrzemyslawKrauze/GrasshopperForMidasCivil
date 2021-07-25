# GrasshopperForMidasCivil
Grasshopper component for converting Rhino geometry to Midas Civil Command shell

What problem it solves?
Lack of link between Rhino and Midas Civil

How does it solve the problem?

By creating Grasshopper component allowing to convert simple Rhino geometry into Midas Civil commands. Which can be loaded to Midas Civil.

Why this solution?

Due to absence of API in Midas Civil there is no possibility to create dynamic link between Rhino and Midas Civil. However Midas Civil allows to import/export and edit
models as text commands, which can be used to create static link from Rhino to Midas Civil.

Features:

Converts Rhino geometries into Midas elements, such as:
- Points to Nodes
- Lines/Curves to Beams
- Meshes to Plates

Allows to add prefix to Node and Elements for better managing elements IDs.

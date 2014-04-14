#target AfterEffects

/**************************************
Scene : Scene
Resolution : 1920 x 1080
Duration : 10.416667
FPS : 24.000000
Date : 2012-06-06 22:34:11.867000
Exported with io_export_after_effects.py
**************************************/



function compFromBlender(){

var compName = prompt("Blender Comp's Name \nEnter Name of newly created Composition","BlendComp","Composition's Name");
if (compName){
var newComp = app.project.items.addComp(compName, 1920, 1080, 1.000000, 10.416667, 24);
newComp.displayStartTime = 0.083333;


// **************  CAMERA 3D MARKERS  **************


// **************  OBJECTS  **************


var _Sphere_003 = newComp.layers.addNull();
_Sphere_003.threeDLayer = true;
_Sphere_003.source.name = "_Sphere_003";
_Sphere_003.property("position").setValue([-2693.339767,66.007700,-859.960651],);
_Sphere_003.property("orientation").setValue([-90.000000,-0.000000,77.553554],);
_Sphere_003.property("scale").setValue([186.352181,186.352181,186.352181],);


// **************  LIGHTS  **************


// **************  CAMERAS  **************


var _Camera = newComp.layers.addCamera("_Camera",[0,0]);
_Camera.autoOrient = AutoOrientType.NO_AUTO_ORIENT;
_Camera.property("position").setValue([1816.072044,540.000000,0.000000],);
_Camera.property("orientation").setValue([-90.000000,-89.999996,-90.000003],);
_Camera.property("zoom").setValue(3600.000000,);



}else{alert ("Exit Import Blender animation data \nNo Comp's name has been chosen","EXIT")};}


app.beginUndoGroup("Import Blender animation data");
compFromBlender();
app.endUndoGroup();



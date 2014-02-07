// Copyright information can be found in the file named COPYING
// located in the root directory of this distribution.

datablock ShapeBaseImageData(WpnJackhammerReloadImage)
{
   // Basic Item properties
   shapeFile = "content/fr1tz/oldshapes/raptor/image/p1/TP_Raptor.DAE";
   shapeFileFP = "content/fr1tz/alux1/shapes/jackhammer/image/p1/shape.fp.dae";
   emap = true;

   imageAnimPrefix = "Rifle";
   imageAnimPrefixFP = "Rifle";

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0;
   firstPerson = true;
   animateOnServer = true;
   useEyeNode = false;
   eyeOffset = "-0.0 0.1 -0.375";

   // When firing from a point offset from the eye, muzzle correction
   // will adjust the muzzle vector to point to the eye LOS point.
   correctMuzzleVector = true;

   // Add the WeaponImage namespace as a parent, WeaponImage namespace
   // provides some hooks into the inventory system.
   class = "WeaponImage";
   className = "WeaponImage";

   useRemainderDT = false;

   // Script fields
   fireImage = WpnJackhammerImage;

   // Initial start up state
   stateName[0]                     = "ReloadStart";
   stateTransitionOnTimeout[0]      = "ReleaseMagazine";
   stateWaitForTimeout[0]           = true;
   stateTimeoutValue[0]             = 0.18;
   stateReload[0]                   = true;
   stateSequence[0]                 = "reload_start";
   stateShapeSequence[0]            = "Reload";
   //stateScaleShapeSequence[0]       = true;
   //stateSound[0]                    = WpnJackhammerReloadSound;
   
   stateName[2]                     = "ReleaseMagazine";
   stateTransitionOnTimeout[2]      = "InsertMagazine";
   stateWaitForTimeout[2]           = true;
   stateTimeoutValue[2]             = 0.72;
   stateSequence[2]                 = "reload_releasemagazine";
   stateSound[2]                    = WpnJackhammerReleaseMagazineSound;
   
   stateName[3]                     = "InsertMagazine";
   stateTransitionOnTimeout[3]      = "Chamber";
   stateWaitForTimeout[3]           = true;
   stateTimeoutValue[3]             = 0.90;
   stateSequence[3]                 = "reload_insertmagazine";
   stateSound[3]                    = WpnJackhammerInsertMagazineSound;
   
   stateName[4]                     = "Chamber";
   stateTransitionOnTimeout[4]      = "ReloadDone";
   stateWaitForTimeout[4]           = true;
   stateTimeoutValue[4]             = 1.19;
   stateSequence[4]                 = "reload_chamber";
   stateSound[4]                    = WpnJackhammerChamberSound;
   
   // Reload done
   stateName[1]                     = "ReloadDone";
   stateScript[1]                   = "onReloadDone";
   stateSequence[1]                 = "ready";
};


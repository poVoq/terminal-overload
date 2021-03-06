// Copyright information can be found in the file named COPYING
// located in the root directory of this distribution.

// Only load these shaders if an Oculus VR device is present
if(!isFunction(isOculusVRDeviceActive))
   return;

//-----------------------------------------------------------------------------
// Shader data
//-----------------------------------------------------------------------------

singleton ShaderData( OVRMonoToStereoShader )
{
   DXVertexShaderFile 	= "shaders/common/postFx/postFxV.hlsl";
   DXPixelShaderFile 	= "shaders/common/postFx/oculusvr/monoToStereoP.hlsl";
   
   //OGLVertexShaderFile  = "shaders/common/postFx/gl/postFxV.hlsl";
   //OGLPixelShaderFile   = "shaders/common/postFx/oculusvr/gl/monoToStereoP.glsl";
   
   samplerNames[0] = "$backBuffer";

   pixVersion = 2.0;   
};

singleton ShaderData( OVRBarrelDistortionShader )
{
   DXVertexShaderFile 	= "shaders/common/postFx/postFxV.hlsl";
   DXPixelShaderFile 	= "shaders/common/postFx/oculusvr/barrelDistortionP.hlsl";
   
   //OGLVertexShaderFile  = "shaders/common/postFx/gl/postFxV.glsl";
   //OGLPixelShaderFile   = "shaders/common/postFx/oculusvr/gl/barrelDistortionP.glsl";
   
   samplerNames[0] = "$backBuffer";

   pixVersion = 2.0;   
};

singleton ShaderData( OVRBarrelDistortionChromaShader )
{
   DXVertexShaderFile 	= "shaders/common/postFx/postFxV.hlsl";
   DXPixelShaderFile 	= "shaders/common/postFx/oculusvr/barrelDistortionChromaP.hlsl";

   pixVersion = 2.0;   
};

//-----------------------------------------------------------------------------
// GFX state blocks
//-----------------------------------------------------------------------------

singleton GFXStateBlockData( OVRBarrelDistortionStateBlock : PFX_DefaultStateBlock )
{
   samplersDefined = true;
   samplerStates[0] = SamplerClampLinear;
};

//-----------------------------------------------------------------------------
// Barrel Distortion PostFx
//
// To be used with the Oculus Rift.
// Expects a stereo pair to exist on the back buffer and then applies the
// appropriate barrel distortion.
//-----------------------------------------------------------------------------
singleton BarrelDistortionPostEffect( OVRBarrelDistortionPostFX )
{
   isEnabled = false;
   allowReflectPass = false;
   
   renderTime = "PFXAfterDiffuse";
   renderPriority = 100;

   // The barrel distortion   
   shader = OVRBarrelDistortionShader;
   stateBlock = OVRBarrelDistortionStateBlock;
   
   texture[0] = "$backBuffer";
   
   scaleOutput = 1.25;
};

//-----------------------------------------------------------------------------
// Barrel Distortion with Chromatic Aberration Correction PostFx
//
// To be used with the Oculus Rift.
// Expects a stereo pair to exist on the back buffer and then applies the
// appropriate barrel distortion.
// This version applies a chromatic aberration correction during the
// barrel distortion.
//-----------------------------------------------------------------------------
singleton BarrelDistortionPostEffect( OVRBarrelDistortionChromaPostFX )
{
   isEnabled = false;
   allowReflectPass = false;
   
   renderTime = "PFXAfterDiffuse";
   renderPriority = 100;

   // The barrel distortion   
   shader = OVRBarrelDistortionChromaShader;
   stateBlock = OVRBarrelDistortionStateBlock;
   
   texture[0] = "$backBuffer";
   
   scaleOutput = 1.25;
};

//-----------------------------------------------------------------------------
// Barrel Distortion Mono PostFx
//
// To be used with the Oculus Rift.
// Takes a non-stereo image and turns it into a stereo pair with barrel
// distortion applied.  Only a vertical slice around the center of the back
// buffer is used to generate the pseudo stereo pair.
//-----------------------------------------------------------------------------
singleton PostEffect( OVRBarrelDistortionMonoPostFX )
{
   isEnabled = false;
   allowReflectPass = false;
   
   renderTime = "PFXAfterDiffuse";
   renderPriority = 100;

   // Converts the mono display to a stereo one   
   shader = OVRMonoToStereoShader;
   stateBlock = OVRBarrelDistortionStateBlock;
   
   texture[0] = "$backBuffer";
   target = "$outTex";

   // The actual barrel distortion   
   new BarrelDistortionPostEffect(OVRBarrelDistortionMonoStage2PostFX)
   {
      shader = OVRBarrelDistortionShader;
      stateBlock = OVRBarrelDistortionStateBlock;
      texture[0] = "$inTex";
      target = "$backBuffer";
      
      scaleOutput = 1.25;
   };

};

function OVRBarrelDistortionMonoPostFX::setShaderConsts( %this )
{
   %HMDIndex = 0;
   
   %xOffsets = getOVRHMDEyeXOffsets(%HMDIndex);
   %this.setShaderConst( "$LensXOffsets", %xOffsets );
}

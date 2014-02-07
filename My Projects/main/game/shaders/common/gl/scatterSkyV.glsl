// Copyright information can be found in the file named COPYING
// located in the root directory of this distribution.

#include "hlslCompat.glsl"

// The scale equation calculated by Vernier's Graphical Analysis
float vernierScale(float fCos)
{
	float x = 1.0 - fCos;
	float x5 = x * 5.25;
	float x5p6 = (-6.80 + x5);
	float xnew = (3.83 + x * x5p6);
	float xfinal = (0.459 + x * xnew);
	float xfinal2 = -0.00287 + x * xfinal;
	float outx = exp( xfinal2 ); 
	return 0.25 * outx;
}

attribute vec4 vPosition;
attribute vec3 vNormal;
attribute vec4 vColor;
attribute vec2 vTexCoord0;

// This is the shader input vertex structure.
#define IN_position vPosition
#define IN_normal vNormal
#define IN_color vColor

// This is the shader output data.
varying vec4  rayleighColor;
#define OUT_rayleighColor rayleighColor
varying vec4  mieColor;
#define OUT_mieColor mieColor
varying vec3  v3Direction;
#define OUT_v3Direction v3Direction
varying float zPosition;
#define OUT_zPosition zPosition
varying vec3  pos;
#define OUT_pos pos
 
uniform mat4 modelView;
uniform vec4 misc;
uniform vec4 sphereRadii;
uniform vec4 scatteringCoeffs;
uniform vec3 camPos;
uniform vec3 lightDir;
uniform vec4 invWaveLength;
uniform vec4 colorize;

vec3 desaturate(const vec3 color, const float desaturation) 
{  
   const vec3 gray_conv = vec3 (0.30, 0.59, 0.11);  
   return mix(color, vec3(dot(gray_conv , color)), desaturation);  
}  
 
void main()
{
   // Pull some variables out:
   float camHeight = misc.x;
   float camHeightSqr = misc.y;
   
   float scale = misc.z;
   float scaleOverScaleDepth = misc.w;
   
   float outerRadius = sphereRadii.x;
   float outerRadiusSqr = sphereRadii.y;
   
   float innerRadius = sphereRadii.z;
   float innerRadiusSqr = sphereRadii.w;
   
   float rayleighBrightness = scatteringCoeffs.x; // Kr * ESun
   float rayleigh4PI = scatteringCoeffs.y; // Kr * 4 * PI

   float mieBrightness = scatteringCoeffs.z; // Km * ESun
   float mie4PI = scatteringCoeffs.w; // Km * 4 * PI
   
   // Get the ray from the camera to the vertex, 
   // and its length (which is the far point of the ray 
   // passing through the atmosphere).
   vec3 v3Pos = vec3(IN_position / 6378000.0);// / outerRadius;
   vec3 newCamPos = vec3( 0, 0, camHeight );
   v3Pos.z += innerRadius;
   vec3 v3Ray = v3Pos.xyz - newCamPos;
   float fFar = length(v3Ray);
   v3Ray /= fFar;

   // Calculate the ray's starting position, 
   // then calculate its scattering offset.
   vec3 v3Start = newCamPos;
   float fHeight = length(v3Start); 
   float fDepth = exp(scaleOverScaleDepth * (innerRadius - camHeight));
   float fStartAngle = dot(v3Ray, v3Start) / fHeight;

   float fStartOffset = fDepth * vernierScale( fStartAngle );

   // Initialize the scattering loop variables.
   float fSampleLength = fFar / 2.0;
   float fScaledLength = fSampleLength * scale;
   vec3 v3SampleRay = v3Ray * fSampleLength;
   vec3 v3SamplePoint = v3Start + v3SampleRay * 0.5;

   // Now loop through the sample rays
   vec3 v3FrontColor = vec3(0.0, 0.0, 0.0);
   for(int i=0; i<2; i++)
   {
      float fHeight = length(v3SamplePoint);
      float fDepth = exp(scaleOverScaleDepth * (innerRadius - fHeight));
      float fLightAngle = dot(lightDir, v3SamplePoint) / fHeight;
      float fCameraAngle = dot(v3Ray, v3SamplePoint) / fHeight;

      float vscale3 = vernierScale( fCameraAngle );
      float vscale2 = vernierScale( fLightAngle );

      float fScatter = (fStartOffset + fDepth*(vscale2 - vscale3));
      vec3 v3Attenuate = exp(-fScatter * (invWaveLength.xyz * rayleigh4PI + mie4PI));
      v3FrontColor += v3Attenuate * (fDepth * fScaledLength);
      v3SamplePoint += v3SampleRay;
   } 
   
   // Finally, scale the Mie and Rayleigh colors 
   // and set up the varying variables for the pixel shader.
   gl_Position = modelView * IN_position;
   OUT_mieColor.rgb = v3FrontColor * mieBrightness;
   OUT_mieColor.a = 1.0;
   OUT_rayleighColor.rgb = v3FrontColor * (invWaveLength.xyz * rayleighBrightness);
   OUT_rayleighColor.a = 1.0;
   OUT_v3Direction = newCamPos - v3Pos.xyz;
   OUT_pos = IN_position.xyz;
   
#ifdef USE_COLORIZE  
  
   OUT_rayleighColor.rgb = desaturate(OUT_rayleighColor.rgb, 1) * colorize.a;  
     
   OUT_rayleighColor.r *= colorize.r;  
   OUT_rayleighColor.g *= colorize.g;  
   OUT_rayleighColor.b *= colorize.b;  
     
#endif 
   
   correctSSP(gl_Position);
}


new Material(xa_notc_core_shapes_standardcat_footprint)
{
   diffuseMap[0] = "content/xa/notc/core/shapes/standardcat/footprint";
   vertColor[0] = true;
   translucent = true;
   castShadows = "0";
   translucentZWrite = "1";
   materialTag0 = "Player";
   mapTo = "footprint";
   glow[0] = "0";
   emissive[0] = "1";
   translucentBlendOp = "AddAlpha";
   showFootprints = "0";
   diffuseColor[0] = "1 1 1 1";
};

new Material(xa_notc_core_shapes_standardcat_slidedecalmat)
{
   diffuseMap[0] = "content/xa/notc/core/shapes/standardcat/slidedecal.png";
   vertColor[0] = true;
   translucent = true;
   castShadows = "0";
   translucentZWrite = "1";
   materialTag0 = "Player";
   mapTo = "footprint";
   glow[0] = "0";
   emissive[0] = "1";
   translucentBlendOp = "AddAlpha";
   showFootprints = "0";
   diffuseColor[0] = "1 1 1 1";
};

singleton Material(xa_notc_core_shapes_standardcat_skiddecalmat)
{
   mapTo = "xa_notc_core_shapes_standardcat_skiddecal";
   diffuseMap[0] = "content/xa/notc/core/textures/smashdecal2.png";
   emissive[0] = "1";
   translucent = "1";
   translucentBlendOp = "AddAlpha";
   castShadows = "0";
   showFootprints = "0";
   vertColor[0] = "1";
};


singleton Material(xa_notc_core_shapes_standardcat_trailsmat)
{
   translucentBlendOp = "AddAlpha";
   emissive[0] = "1";
   glow[0] = "0";
   wireframe[0] = "0";
   diffuseColor[0] = "0.992157 0.992157 0.992157 1";
   diffuseColorPaletteSlot[0] = "0";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
   translucent = "1";
   alphaRef = "0";
   showFootprints = "0";
   castShadows = "0";
   vertColor[0] = "1";
   glowOnly[0] = "0";
   mapTo = "grid.128.24.png";
   effectColor[0] = "InvisibleBlack";
};

singleton Material(xa_notc_core_shapes_standardcat_mat1)
{
   mapTo = "base";
   diffuseColor[0] = "0.415686 0.415686 0.415686 0";
   diffuseColorPaletteSlot[0] = "-1";
   showFootprints = "0";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
   translucent = "0";
   translucentZWrite = "0";
   translucentBlendOp = "None";
   emissive[0] = "0";
   glow[0] = "0";
   diffuseColor[1] = "0.403922 0.403922 0.403922 1";
   diffuseColorPaletteSlot[1] = "-1";
   glow[1] = "0";
   wireframe[1] = "1";
   emissive[1] = "0";
   specular[1] = "1 1 1 1";
};

singleton Material(xa_notc_core_shapes_standardcat_mat2)
{
   mapTo = "armor_red0024";
   emissive[0] = "0";
   glow[0] = "0";
   diffuseColor[0] = "0.992157 0.992157 0.992157 1";
   diffuseColorPaletteSlot[0] = "0";
   pixelSpecular[0] = "0";
   diffuseColor[1] = "0.439216 0.439216 0.439216 1";
   diffuseColorPaletteSlot[1] = "0";
   glow[1] = "0";
   emissive[1] = "1";
   wireframe[1] = "1";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
   translucent = "0";
   translucentZWrite = "0";
   translucentBlendOp = "AddAlpha";
   alphaRef = "0";
   showFootprints = "0";
   pixelSpecular[1] = "0";
   specularPower[0] = "1";
   diffuseMap[1] = "content/xa/notc/core/textures/grid.128.8.png";
   detailScale[0] = "16 16";
   diffuseColor[2] = "0.992157 0.996078 0.996078 1";
   emissive[2] = "1";
   wireframe[2] = "0";
   glow[2] = "1";
   glowOnly[2] = "0";
   castShadows = "0";
   animFlags[2] = "0x00000000";
   scrollDir[2] = "0 -1";
   scrollSpeed[2] = "1.059";
   diffuseColorPaletteSlot[2] = "15";
   rotSpeed[2] = "1.529";
   rotPivotOffset[2] = "-0.5 -0.5";
   waveType[2] = "Triangle";
   waveFreq[2] = "0.313";
   waveAmp[2] = "1";
   diffuseMap[2] = "content/xa/notc/core/shapes/standardcat/damagebuffer.png";
   effectColor[0] = "0 0 0 0";
   specular[1] = "1 1 1 1";
};

singleton Material(xa_notc_core_shapes_standardcat_stealthmat1)
{
   mapTo = "xa_notc_core_shapes_standardcat_stealthmat1";
   emissive[0] = "1";
   glow[0] = "1";
   diffuseColor[0] = "1 1 1 1";
   diffuseColorPaletteSlot[0] = "0";
   diffuseMap[0] = "content/xa/notc/core/shapes/standardcat/armor.png";
   pixelSpecular[0] = "0";
   diffuseColor[1] = "0.996078 0.996078 0.996078 1";
   diffuseMap[1] = "content/xa/notc/core/textures/grid128.12.png";
   diffuseColorPaletteSlot[1] = "0";
   glow[1] = "1";
   emissive[1] = "1";
   wireframe[1] = "1";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
   translucent = "1";
   translucentZWrite = "0";
   translucentBlendOp = "AddAlpha";
   alphaRef = "1";
   showFootprints = "0";
   wireframe[0] = "0";
   glowOnly[0] = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "1 1";
   scrollSpeed[0] = "1";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "1 1";
   scrollSpeed[1] = "2";
};

singleton Material(xa_notc_core_shapes_standardcat_stealthmat2)
{
   mapTo = "xa_notc_core_shapes_standardcat_stealthmat2";
   diffuseColor[0] = "0.0980392 0.0980392 0.0980392 1";
   diffuseColor[1] = "0.992157 0.992157 0.992157 1";
   diffuseColorPaletteSlot[0] = "0";
   diffuseColorPaletteSlot[1] = "0";
   diffuseMap[0] = "content/o/rotc/p.5.4/textures/rotc/armor.white.png";
   diffuseMap[1] = "content/xa/notc/core/shapes/standardcat/stealth1.png";
   glow[0] = "1";
   glow[1] = "1";
   glowOnly[0] = "1";
   emissive[0] = "1";
   emissive[1] = "1";
   wireframe[1] = "1";
   translucent = "1";
   translucentBlendOp = "AddAlpha";
   alphaRef = "0";
   showFootprints = "0";
   materialTag0 = "Miscellaneous";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "1 1";
   scrollSpeed[1] = "2";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "1 1";
   scrollSpeed[0] = "0.5";
};

singleton Material(xa_notc_core_shapes_standardcat_erasemat)
{
   mapTo = "xa_notc_core_shapes_standardcat_erasemat";
   emissive[0] = "1";
   glow[0] = "1";
   diffuseColor[0] = "0.968628 0.968628 0.968628 1";
   diffuseColorPaletteSlot[0] = "0";
   diffuseMap[0] = "content/xa/notc/core/textures/grid.128.4.h1.png";
   pixelSpecular[0] = "0";
   diffuseColor[1] = "0.996078 0.996078 0.996078 0";
   diffuseColorPaletteSlot[1] = "-1";
   glow[1] = "0";
   emissive[1] = "0";
   wireframe[1] = "0";
   materialTag0 = "Miscellaneous";
   doubleSided = "0";
   translucent = "1";
   translucentZWrite = "0";
   translucentBlendOp = "AddAlpha";
   alphaRef = "1";
   showFootprints = "0";
   wireframe[0] = "1";
   glowOnly[0] = "1";
   animFlags[0] = "0x00000009";
   scrollDir[0] = "1 1";
   scrollSpeed[0] = "10";
   animFlags[1] = "0x00000005";
   scrollDir[1] = "1 1";
   scrollSpeed[1] = "2";
   waveType[0] = "Square";
   waveFreq[0] = "10";
   waveFreq[1] = "4.531";
   waveAmp[0] = "1";
   waveAmp[1] = "0.547";
   diffuseColor[3] = "1 1 1 1";
   castShadows = "0";
};


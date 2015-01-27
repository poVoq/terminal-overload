new TerrainMaterial()
{
   detailDistance = "6000";
   internalName = "xa_notc_mis_ctf1_termat1";
   diffuseSize = "4";
   detailSize = "32";
   detailStrength = "1";
   macroStrength = "0.1";
   diffuseMap = "content/o/rotc/p.5.4/textures/eth/dark_grey_blue_grid";
   detailMap = "content/o/rotc/p.5.4/textures/eth/dark_grey_blue_grid";
};

singleton Material(xa_notc_mis_ctf1_termat1fx)
{
   mapTo = "xa_notc_mis_eth5_grid";
   footstepSoundId = "2";
   terrainMaterials = "1";
   ShowDust = "true";
   showFootprints = "1";
   materialTag0 = "Terrain";
   effectColor[0] = "0.00784314 0.94902 0.996078 1";
   effectColor[1] = "0.996078 0.00784314 0.901961 1";
   glow[0] = "0";
   emissive[0] = "0";
   detailScale[0] = "64 64";
   scrollDir[0] = "0 -0.03";
   scrollSpeed[0] = "1.647";
   castShadows = "0";
   translucentBlendOp = "None";
   parallaxScale[0] = "1";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.0235294 1 0 1";
   diffuseMap[1] = "content/xa/notc/mis/dm1/textures/grid1.png";
   glow[1] = "1";
   emissive[1] = "1";
   detailScale[2] = "64 64";
   detailScale[1] = "64 64";
   diffuseColor[2] = "0.00392157 0.00392157 0.00392157 1";
   diffuseColor[1] = "0.992157 0.992157 0.992157 1";
   impactSoundId = "2";
};

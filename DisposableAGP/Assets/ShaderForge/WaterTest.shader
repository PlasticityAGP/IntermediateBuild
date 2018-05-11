// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-5517-OUT,spec-9201-OUT,gloss-1813-OUT,normal-1-OUT;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Glossiness,ptin:_Glossiness,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.95,max:1;n:type:ShaderForge.SFN_Vector1,id:9201,x:32370,y:32774,varname:node_9201,prsc:2,v1:0;n:type:ShaderForge.SFN_Color,id:5731,x:32245,y:32441,ptovrint:False,ptlb:Color (Shallow),ptin:_ColorShallow,varname:node_5731,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:7164,x:32245,y:32269,ptovrint:False,ptlb:Color (Deep),ptin:_ColorDeep,varname:node_7164,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2745098,c2:0.2666667,c3:0.2745098,c4:1;n:type:ShaderForge.SFN_Lerp,id:5517,x:32483,y:32411,varname:node_5517,prsc:2|A-7164-RGB,B-5731-RGB,T-4477-OUT;n:type:ShaderForge.SFN_Fresnel,id:4477,x:32245,y:32589,varname:node_4477,prsc:2|NRM-1435-OUT,EXP-980-OUT;n:type:ShaderForge.SFN_NormalVector,id:1435,x:32047,y:32579,prsc:2,pt:False;n:type:ShaderForge.SFN_ValueProperty,id:2503,x:31940,y:32856,ptovrint:False,ptlb:Color Fresnel,ptin:_ColorFresnel,varname:node_2503,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.336;n:type:ShaderForge.SFN_ConstantClamp,id:980,x:32095,y:32800,varname:node_980,prsc:2,min:0,max:4|IN-2503-OUT;n:type:ShaderForge.SFN_Tex2d,id:6623,x:32353,y:33774,varname:node_6623,prsc:2,ntxv:0,isnm:False|UVIN-4623-OUT,TEX-2711-TEX;n:type:ShaderForge.SFN_Tex2d,id:1142,x:32373,y:34049,varname:node_1142,prsc:2,ntxv:0,isnm:False|UVIN-7811-OUT,TEX-2711-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2711,x:32028,y:33922,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_2711,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Lerp,id:1,x:33114,y:34167,varname:node_1,prsc:2|A-6395-OUT,B-7787-OUT,T-1092-OUT;n:type:ShaderForge.SFN_Slider,id:1092,x:32714,y:34363,ptovrint:False,ptlb:Normal Blend Strengths,ptin:_NormalBlendStrengths,varname:node_1092,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Time,id:9419,x:31585,y:33676,varname:node_9419,prsc:2;n:type:ShaderForge.SFN_FragmentPosition,id:2257,x:31366,y:33417,varname:node_2257,prsc:2;n:type:ShaderForge.SFN_Append,id:6632,x:31556,y:33439,varname:node_6632,prsc:2|A-2257-X,B-2257-Z;n:type:ShaderForge.SFN_Divide,id:8136,x:31720,y:33427,varname:node_8136,prsc:2|A-6632-OUT,B-3083-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3083,x:31456,y:33618,ptovrint:False,ptlb:UV Scale,ptin:_UVScale,varname:node_3083,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Set,id:4723,x:31853,y:33427,varname:_WorldUV,prsc:2|IN-8136-OUT;n:type:ShaderForge.SFN_Set,id:210,x:31630,y:32823,varname:_UV1,prsc:2|IN-873-OUT;n:type:ShaderForge.SFN_Get,id:7248,x:30603,y:32944,varname:node_7248,prsc:2|IN-4723-OUT;n:type:ShaderForge.SFN_Set,id:3735,x:31646,y:33071,varname:_UV2,prsc:2|IN-7633-OUT;n:type:ShaderForge.SFN_Vector4Property,id:5,x:30831,y:32741,ptovrint:False,ptlb:UV 1 Animator,ptin:_UV1Animator,varname:node_5,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:5873,x:30848,y:33286,ptovrint:False,ptlb:UV 2 Animator,ptin:_UV2Animator,varname:node_5873,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_ComponentMask,id:3796,x:31056,y:32960,varname:node_3796,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9699-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2392,x:31056,y:33115,varname:node_2392,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4006-OUT;n:type:ShaderForge.SFN_Time,id:9166,x:30850,y:33433,varname:node_9166,prsc:2;n:type:ShaderForge.SFN_Multiply,id:189,x:31056,y:32831,varname:node_189,prsc:2|A-5-Y,B-9166-TSL;n:type:ShaderForge.SFN_Multiply,id:3550,x:31056,y:32709,varname:node_3550,prsc:2|A-5-X,B-9166-TSL;n:type:ShaderForge.SFN_Add,id:1619,x:31281,y:32905,varname:node_1619,prsc:2|A-189-OUT,B-3796-G;n:type:ShaderForge.SFN_Add,id:3956,x:31239,y:32753,varname:node_3956,prsc:2|A-3550-OUT,B-3796-R;n:type:ShaderForge.SFN_Append,id:873,x:31466,y:32819,varname:node_873,prsc:2|A-3956-OUT,B-1619-OUT;n:type:ShaderForge.SFN_Add,id:4252,x:31281,y:33062,varname:node_4252,prsc:2|A-2392-R,B-5138-OUT;n:type:ShaderForge.SFN_Add,id:2902,x:31267,y:33213,varname:node_2902,prsc:2|A-2392-G,B-2218-OUT;n:type:ShaderForge.SFN_Multiply,id:5138,x:31056,y:33273,varname:node_5138,prsc:2|A-5873-X,B-9166-TSL;n:type:ShaderForge.SFN_Multiply,id:2218,x:31056,y:33402,varname:node_2218,prsc:2|A-5873-Y,B-9166-TSL;n:type:ShaderForge.SFN_Append,id:7633,x:31480,y:33075,varname:node_7633,prsc:2|A-4252-OUT,B-2902-OUT;n:type:ShaderForge.SFN_Multiply,id:9699,x:30831,y:32925,varname:node_9699,prsc:2|A-7248-OUT,B-8138-OUT;n:type:ShaderForge.SFN_Multiply,id:4006,x:30831,y:33062,varname:node_4006,prsc:2|A-7248-OUT,B-5479-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5479,x:30655,y:33124,ptovrint:False,ptlb:UV 2 Tiling,ptin:_UV2Tiling,varname:node_5479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8138,x:30655,y:33046,ptovrint:False,ptlb:UV 1 Tiling,ptin:_UV1Tiling,varname:_UV2Tiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Get,id:4623,x:32045,y:33762,varname:node_4623,prsc:2|IN-210-OUT;n:type:ShaderForge.SFN_Get,id:7811,x:32028,y:33830,varname:node_7811,prsc:2|IN-3735-OUT;n:type:ShaderForge.SFN_Multiply,id:9326,x:32714,y:33883,varname:node_9326,prsc:2|A-9843-OUT,B-6191-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9843,x:32530,y:33774,varname:node_9843,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6623-RGB;n:type:ShaderForge.SFN_Vector1,id:1152,x:32714,y:34045,varname:node_1152,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:6395,x:32905,y:33998,varname:node_6395,prsc:2|A-9326-OUT,B-1152-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7291,x:32530,y:34025,varname:node_7291,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1142-RGB;n:type:ShaderForge.SFN_Multiply,id:6558,x:32714,y:34134,varname:node_6558,prsc:2|A-7291-OUT,B-6901-OUT;n:type:ShaderForge.SFN_Slider,id:6901,x:32373,y:34224,ptovrint:False,ptlb:Normal Map 2 Strength,ptin:_NormalMap2Strength,varname:node_6901,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Append,id:7787,x:32905,y:34122,varname:node_7787,prsc:2|A-6558-OUT,B-1152-OUT;n:type:ShaderForge.SFN_Slider,id:6191,x:32373,y:33940,ptovrint:False,ptlb:Normal Map 1 Strength,ptin:_NormalMap1Strength,varname:_NormalMap2Strength_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:7164-5731-2503-1813-2711-1092-3083-5-5873-5479-8138-6901-6191;pass:END;sub:END;*/

Shader "Shader Forge/WaterTest" {
    Properties {
        _ColorDeep ("Color (Deep)", Color) = (0.2745098,0.2666667,0.2745098,1)
        _ColorShallow ("Color (Shallow)", Color) = (1,1,1,1)
        _ColorFresnel ("Color Fresnel", Float ) = 1.336
        _Glossiness ("Glossiness", Range(0, 1)) = 0.95
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _NormalBlendStrengths ("Normal Blend Strengths", Range(0, 1)) = 0
        _UVScale ("UV Scale", Float ) = 1
        _UV1Animator ("UV 1 Animator", Vector) = (0,0,0,0)
        _UV2Animator ("UV 2 Animator", Vector) = (0,0,0,0)
        _UV2Tiling ("UV 2 Tiling", Float ) = 0
        _UV1Tiling ("UV 1 Tiling", Float ) = 0
        _NormalMap2Strength ("Normal Map 2 Strength", Range(0, 1)) = 0
        _NormalMap1Strength ("Normal Map 1 Strength", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Glossiness;
            uniform float4 _ColorShallow;
            uniform float4 _ColorDeep;
            uniform float _ColorFresnel;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _NormalBlendStrengths;
            uniform float _UVScale;
            uniform float4 _UV1Animator;
            uniform float4 _UV2Animator;
            uniform float _UV2Tiling;
            uniform float _UV1Tiling;
            uniform float _NormalMap2Strength;
            uniform float _NormalMap1Strength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9166 = _Time;
                float2 _WorldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_7248 = _WorldUV;
                float2 node_3796 = (node_7248*_UV1Tiling).rg;
                float2 _UV1 = float2(((_UV1Animator.r*node_9166.r)+node_3796.r),((_UV1Animator.g*node_9166.r)+node_3796.g));
                float2 node_4623 = _UV1;
                float3 node_6623 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_4623, _NormalMap)));
                float node_1152 = 1.0;
                float2 node_2392 = (node_7248*_UV2Tiling).rg;
                float2 _UV2 = float2((node_2392.r+(_UV2Animator.r*node_9166.r)),(node_2392.g+(_UV2Animator.g*node_9166.r)));
                float2 node_7811 = _UV2;
                float3 node_1142 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_7811, _NormalMap)));
                float3 normalLocal = lerp(float3((node_6623.rgb.rg*_NormalMap1Strength),node_1152),float3((node_1142.rgb.rg*_NormalMap2Strength),node_1152),_NormalBlendStrengths);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float perceptualRoughness = 1.0 - _Glossiness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float3 diffuseColor = lerp(_ColorDeep.rgb,_ColorShallow.rgb,pow(1.0-max(0,dot(i.normalDir, viewDirection)),clamp(_ColorFresnel,0,4))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Glossiness;
            uniform float4 _ColorShallow;
            uniform float4 _ColorDeep;
            uniform float _ColorFresnel;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _NormalBlendStrengths;
            uniform float _UVScale;
            uniform float4 _UV1Animator;
            uniform float4 _UV2Animator;
            uniform float _UV2Tiling;
            uniform float _UV1Tiling;
            uniform float _NormalMap2Strength;
            uniform float _NormalMap1Strength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9166 = _Time;
                float2 _WorldUV = (float2(i.posWorld.r,i.posWorld.b)/_UVScale);
                float2 node_7248 = _WorldUV;
                float2 node_3796 = (node_7248*_UV1Tiling).rg;
                float2 _UV1 = float2(((_UV1Animator.r*node_9166.r)+node_3796.r),((_UV1Animator.g*node_9166.r)+node_3796.g));
                float2 node_4623 = _UV1;
                float3 node_6623 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_4623, _NormalMap)));
                float node_1152 = 1.0;
                float2 node_2392 = (node_7248*_UV2Tiling).rg;
                float2 _UV2 = float2((node_2392.r+(_UV2Animator.r*node_9166.r)),(node_2392.g+(_UV2Animator.g*node_9166.r)));
                float2 node_7811 = _UV2;
                float3 node_1142 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_7811, _NormalMap)));
                float3 normalLocal = lerp(float3((node_6623.rgb.rg*_NormalMap1Strength),node_1152),float3((node_1142.rgb.rg*_NormalMap2Strength),node_1152),_NormalBlendStrengths);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossiness;
                float perceptualRoughness = 1.0 - _Glossiness;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = 0.0;
                float specularMonochrome;
                float3 diffuseColor = lerp(_ColorDeep.rgb,_ColorShallow.rgb,pow(1.0-max(0,dot(i.normalDir, viewDirection)),clamp(_ColorFresnel,0,4))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Glossiness;
            uniform float4 _ColorShallow;
            uniform float4 _ColorDeep;
            uniform float _ColorFresnel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float3 diffColor = lerp(_ColorDeep.rgb,_ColorShallow.rgb,pow(1.0-max(0,dot(i.normalDir, viewDirection)),clamp(_ColorFresnel,0,4)));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float roughness = 1.0 - _Glossiness;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

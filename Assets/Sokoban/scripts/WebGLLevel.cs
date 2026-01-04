using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLLevel : MonoBehaviour{

    public static string[] levelArray = new string[999];

    public static void initLevels(){
        levelArray[0] = level01;
        levelArray[1] = level02;
        levelArray[2] = level03;
        levelArray[3] = level04;
        levelArray[4] = level05;
    }

    public static string level01  =  

"10,"+
"09,"+
"  ####    ,"+
"  #  #####,"+
"### .#   #,"+
"#@  $    #,"+
"# ## #####,"+
"#   $  #  ,"+
"### .  #  ,"+
"  #  ###  ,"+
"  ####     ";


    public static string level02 = 
"07,"+
"08,"+
"  #### ,"+
"###@ ##,"+
"#.# $ #,"+
"#     #,"+
"#     #,"+
"##### #,"+
"#.  $ #,"+
"#######";

    
    public static string level03 = 
"13,"+
"10,"+
"###########  ,"+
"#     #   ###,"+
"# $ $ # .   #,"+
"# ## ### ## #,"+
"# #     $ # #,"+
"# #   #   # #,"+
"# ###### ## #,"+
"#       . . #,"+
"####### @ ###,"+
"      #####  ";


    public static string level04 = 
"11,"+
"09,"+
"   #####   ,"+
"####   #   ,"+
"#  #$  ####,"+
"# $$      #,"+
"#@  #$ $# #,"+
"### #   # #,"+
" #  ##### #,"+
" #  ..... #,"+
" ##########";


    public static string level05 = 
"10,"+
"10,"+
"####      ,"+
"#  #######,"+
"#  .     #,"+
"#  #$$$$$#,"+
"# ##.....#,"+
"#  #  $  #,"+
"## #### ##,"+
"#        #,"+
"#   ##  @#,"+
"##########";

}

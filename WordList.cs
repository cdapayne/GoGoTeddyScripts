using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList
{
    public static int AdCount=99999999;
    public static string SightWordList = "" +
        "from,good,for,good,had,has,have,he,her,here,him,his,how,were,in" +
        "into,is,it,its,just,like,little,long,look,are,made,make,find,first" +
        "about,after,more,my,all,an,no,and,not,as,number,ask,of,at,on,away,or" +
        "be,other,been,out,before,over,big,ride,but,run,by,said,call,saw,can,see" +
        "come,she,could,six,did,so,do,some,down,stop,get,then,their,them,these,they" +
        "this,time,to,two,up,use,was,way,we,if,what,when,which,who,will,with,word,would" +
        "write,yes,now,you,your,that,the,many,may";
    public static string Colors = "black,white,brown,purple,orange,blue,red,green,yellow,pink";
    public static string ColorsShapesMore = "" +
        "pear,bear,flower,bee,fireman,fire truck,farmer,farm,nest,bird,doghouse,dog,rectangle,oval,triangle" +
        "square,circle,diamond,black,white,brown,purple,orange,blue,red,green,yellow,web,spider,ten,nine" +
        "eight,seven,six,five,four,three,two,one,right,left,up,down,log,from,hat,cat,boat,goat,snake,cake,bed,sled";
    public static string Weather = "sunny,raining,cold,windy,snowing,lightening,cloudy,foggy,cents,dollars,change";
    public static string seasons = "summer,fall,winter,spring";
    public static string clothes = "coat,sandals,shoes,T-shirt,sunglasses,gloves,hat,scarf,swimming trunks,sweater,wool hat,boots,heels,rain coat";
    public static string Wordsthatstartwith = "ant,apple,alligator,bike,bear,bus,cap,car,cactus,dragon,drum,dog,egg,elephant,engine,fox,flower,fish" +
        "giraffe,gift,guitar,hat,heart,hippo,igloo,insect,island,jacket,jewels,jet,kitten,kite,key,lizard,leaf,lion,mouse,milk,monsters,net,noodles,nine" +
        "otter,octopus,orange,pirate,pear,pony,quail,quilt,queen,rocket,robot,rabbit,saw,star,spider,tiger,truck,tree,unicorn,umbrella,volcano,vase,van,whalte,watch,wolf,x-ray,xylophone,yawn,yo-yo,yogurt,zero,zoo,zebra";
    public static string LetterSounds_S = "s,saw,sock,snail,slide,Sam saw a snail";
    public static string LetterSounds_T = "t,tiger,took,tomato,truck,The turtle took a tomato";
    public static string LetterSounds_P = "p,pig,push,puppet,pumpkin,Paul's pumpkin is pink";
    public static string LetterSounds_N = "n,nose,nuts,necklace,nap,Nine is a nice number";
    public static string LetterSounds_M = "m,mask,milk,mouse,mug,my mom met a mermaid";
    public static string LetterSounds_D = "d,deer,desk,duck,dress,ducks drink all day";
    public static string LetterSounds_G = "g,goose,good,gift,gets,Girls get good gifts";
    public static string LetterSounds_C = "c,cat,cut,cake,The cat cut the cake with his claws";
    public static string LetterSounds_K = "k,kitten,king,kick,koala,The koala loved kittens";
    public static string LetterSounds_R = "r,robot,ring,run,The rabbit ran a race";
    public static string LetterSounds_H = "h,hat,horse,hammer,Hank hammered the house";
    public static string LetterSounds_B = "b,bat,ball,blue,The bat and ball are blue";
    public static string LetterSounds_F = "f,fan,five,fish,Frank has five fans";
    public static string LetterSounds_J = "j,jet,juice,just,Julie had juice on the jet";
    public static string LetterSounds_V = "v,vase,violin,violet,Vickie visits the vet";
    public static string LetterSounds_W = "w,wood,web,worm,Worms like wet wood";
    public static string LetterSounds_Q = "q,queen,quiz,The queen was quiet";
    public static string LetterSounds_X = "x,xylophone,x-ray,ox,The ox took an x-ray";
    public static string LetterSounds_Z = "z,zebra,zoom,zoo,Some zebras live at the zoo";
    public static string SightWordsPreK = "a,and,away,big,blue,can,come,down,find,for,funny,go,help,here,I,in,is,it,jump,little,look,make,me,my,not,one,play,red,run,said,see,the,three,to,two,up,we,where,yellow,you";
    public static string SightWordsKindergarten = "all,am,are,at,ate,be,black,brown,but,came,did,do,eat,four,get,good,have,he,into,like,must,new,no,now,on,our,out,please,pretty,ran,ride,saw,say,she,so,soon,that,there,they,this,too,under,want,was,well,went";
    public static string SightWordsFirstGrade = "after,again,an,any,as,ask,by,could,every,fly,from,give,going,had,has,her,him,his,how,just,know,let,live,may,of,old,once,open,over,put,round,some,stop,take,thank,them,then,think,walk,were,when,what,white,who,will,with,yes";
    public static string SightWordsSecondGrade = "always,around,because,been,before,best,both,buy,call,cold,does,don't,fast,first,five,found,gave,goes,green,its,made,many,off,or,pull,read,right,sing,sit,sleep,tell,their,these,those,upon,us,use,very,wash,which,why,wish,work,would,write,your";
    public static string SightWordsThirdGrade = "about,better,bring,carry,clean,cut,done,draw,drink,eight,fall,far,full,got,grow,hold,hot,hurt,if,keep,kind,laugh,light,long,much,myself,never,only,own,pick,seven,shall,show,six,small,start,ten,today,together,try,warm";
    public static string Numbers = "1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,20,30,40,50,60,70,80,90,100,plus,minus,equals,0";
    public static string PhonicSounds = "xa,xb,xc,xd,xe,xf,xh,xi,xj,xk,xl,xm,xn,xo,xp,xq,xr,xs,xt,xu,xv,xx,xy,xz";
    public static string CorrectResponse = "awesome,congradulations,fantastic,fanstaticproblemsolving,goodjob,greatjob,iknewyoucould,positiveyes,sensational,terrific,thatsalright,thatsit,thatsright,wowthatsgreat,yess,youdidit,yourdoinggreat,youreamazing,yourright,yourthebest";
    public static string WrongResponse = "dontgive,itsokaytryagain,keepgoing,maybeitsomethingelse,mmmmtryagain,nookeepgoing,nothatone,oooosoclose,yourclose";
    public static string Instruction = "TouchTheLetter,WhatLetterStartsWith,TraceTheLetter,TraceTheWord,TouchThe,TouchTheColor,HowMany,DoYouSee,ThatWillBe,ThankYou,WriteYourName,WriteYourLastName,SpellYourName,SpellTheWord,LetsCountTo,TouchTheNumber,WriteTheNumber,Drag,Over,WhatComesNext,WhatTimeIsIt,HowMuchMoneyDoYouSee,WriteYourNameInCursive";
    public static string ColorItIn = "apple_red,bird_yellow,bow_pink,snowman_white,spider_black,star_blue,whale_purple,watermelon_green,scissors_brown,gloves_orange";
    public static string List1 = "the,of,and,a,to,in,is,you,that,it,he,was,for,on,are,as,with,his,they,I";
    public static string List2 = "at,be,this,have,from,or,one,had,by,words,but,not,what,all,were,we,when,your,can,said";
    public static string List3 = "there,use,an,each,which,she,do,how,their,if,will,up,other,about,out,many,then,them,these,so";
    public static string List4 = "some,her,would,make,like,him,into,time,has,look,two,more,write,go,see,number,no,way,could,people";
    public static string List5 = "my,than,first,water,been,called,who,oil,sit,now,find,long,down,day,did,get,come,made,may,part";
    public static string List6 = "over,new,sound,take,only,little,work,know,place,years,live,me,back,give,most,very,after,things,our,just";
    public static string List7 = "name,good,sentence,man,think,say,great,where,help,through,much,before,line,right,too,means,old,any,same,tell";
    public static string List8 = "boy,follow,came,want,show,also,around,form,three,small,set,put,end,does,another,well,large,must,big,even";
    public static string List9 = "such,because,turn,here,why,ask,went,men,read,need,land,different,home,us,move,try,kind,hand,picture,again";
    public static string List10 = "change,off,play,spell,air,away,animal,house,point,page,letter,mother,answer,found,study,still,learn,should,America,world";
    public static string List11 = "high,every,near,add,food,between,own,below,country,plant,last,school,father,keep,tree,never,start,city,earth,eyes";
    public static string List12 = "light,thought,head,under,story,saw,left,don't,few,while,along,might,close,something,seem,next,hard,open,example,begin";
    public static string List13 = "life,always,those,both,paper,together,got,group,often,run,important,until,children,side,feet,car,mile,night,walk,white";
    public static string List14 = "sea,began,grow,took,river,four,carry,state,once,book,hear,stop,without,second,late,miss,idea,enough,eat,face";
    public static string List15 = "watch,far,indian,real,almost,let,above,girl,sometimes,mountains,cut,young,talk,soon,list,song,being,leave,family,it's";
    //add the rest of the fry sight words from frequeency list in documents



}

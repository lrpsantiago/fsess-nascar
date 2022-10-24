private readonly string DRIVER_NAME = "Guest";
private readonly int DRIVER_NUMBER = 99;
private const string DISPLAY_NAME = "Driver LCD";
private const string BRAKELIGHT_GROUP_NAME = "Brakelight";
private const string DRAFTING_SENSOR_NAME = "Drafting Sensor";
private readonly int? COCKPIT_DISPLAY_INDEX = null;                     //If you wanna use a cockpit display to show dashboard info (0, 1, 2, 3 or null);
private readonly Color DEFAULT_FONT_COLOR = new Color(127, 127, 127);   //Font Color (R, G, B)

enum æ{ç}enum è{é,ê,ë,ì}enum í{î,ï,ñ}class ð{public int å{get;set;}public int ã{get;set;}public int Ò{get;set;}public
int Ó{get;set;}public string Ô{get;set;}="--:--.---";public string Õ{get;set;}="--:--.---";public è Ö{get;set;}=è.é;public
void Ø(string Ù){try{var Á=Ù.Split(';');Ò=Convert.ToInt32(Á[0]);å=Convert.ToInt32(Á[1]);Ô=Á[2];Õ=Á[3];ã=Convert.ToInt32(Á[4]
);Ó=Convert.ToInt32(Á[5]);Ö=(è)Convert.ToInt32(Á[6]);}catch(Exception){}}}string Ú="1.0.0 Beta 4";const int Û=3000;const
int Ü=500;const float Ý=80f;const float Þ=90;const char ß='\u2191';const char à='\u2193';const char á='\u2588';const char â
='\u2592';const char Ñ='\u2591';List<IMyMotorSuspension>ò;IMyCockpit ó;List<IMyTextSurface>Ă;IMyRadioAntenna ă;
IMySensorBlock Ą;bool ą;StringBuilder Ć;ð ć;List<IMyLightingBlock>Ĉ;æ ĉ;float Ċ=0;float ċ=100;float Č=1;float č=100;long Ď=-1;
IMyBroadcastListener ď;int Đ;int đ;DateTime Ē;float ē;í ĕ=í.ï;float Ĕ=1f;bool ā=false;bool ÿ=false;Program(){ć=new ð();F();G();O();J();M();Å
();ô();À();È();Runtime.UpdateFrequency=UpdateFrequency.Update10;Ē=DateTime.Now;}void ô(){var õ=(IMySensorBlock)
GridTerminalSystem.GetBlockWithName(DRAFTING_SENSOR_NAME);if(õ==null){return;}Ą=õ;Ą.TopExtend=50;Ą.BottomExtend=0;Ą.RightExtend=2.5f;Ą.
LeftExtend=2.5f;Ą.FrontExtend=0;Ą.BackExtend=1;Ą.DetectSmallShips=true;Ą.DetectLargeShips=false;Ą.DetectStations=false;Ą.
DetectSubgrids=false;Ą.DetectAsteroids=false;Ą.DetectPlayers=false;}void Save(){}void Main(string Ë,UpdateType ö){var ø=DateTime.Now;ē
=(float)(ø-Ē).TotalMilliseconds/1000;Echo($"Running FSESS-Nascar {Ú}");Ê(Ë);c();û();a();Q();ù();ý();Ð();E();Ē=ø;}void ù()
{var ú=ó.MoveIndicator.Z>0||ó.MoveIndicator.Y>0||ó.HandBrake;foreach(var P in Ĉ){P.Enabled=ú;}}void û(){if(Ą==null){
return;}ÿ=Ą.IsActive&&ó.GetShipSpeed()>=40;foreach(var C in ò){C.Power=º();var ü=ÿ?999:Þ;C.SetValueFloat("Speed Limit",ü*3.6f)
;}}void ý(){var þ=IGC.UnicastListener;if(!þ.HasPendingMessage){Đ-=(int)(ē*1000);if(ď.HasPendingMessage&&Đ<=0){var X=ď.
AcceptMessage();if(X.Tag=="Address"){Ď=Convert.ToInt64(X.Data.ToString());IGC.SendUnicastMessage(Ď,"Register",
$"{Me.CubeGrid.CustomName};{IGC.Me}");}}return;}while(þ.HasPendingMessage){var Ā=þ.AcceptMessage();if(Ā.Tag=="RaceData"){ć.Ø(Ā.Data.ToString());}if(Ā.Tag==
"Argument"){Ê(Ā.Data.ToString());}}Đ=Û;}void Ð(){Ć.Clear();var A=ó.GetShipSpeed();var j=((č-Ċ)/(ċ-Ċ))*100f;var R=p();var S=((int)
Math.Floor(j)).ToString();var T=$"{A:F0}m/s";var U=$"MODE: {v()}".PadLeft(20-T.Length,' ');var V=x();var W=
$"{(int)Math.Floor(Ĕ*100),3}%";var X=ą?"PIT LIMITER":ÿ?"DRAFTING":"";Ć.AppendLine($"{T}{U}");Ć.AppendLine(X);Ć.AppendLine($"FUEL {V} {W}");Ć.
AppendLine($"P:{ć.å:00}/{ć.ã:00}      L:{(ć.Ò):00}/{ć.Ó:00}");Ć.AppendLine($"TYRE .........: {S,3}%");Ć.AppendLine(
$"TIME.....: {ć.Ô}");Ć.AppendLine($"BEST.....: {ć.Õ}");if(Đ<=0){Ć.AppendLine($"NO CONNECTION");}foreach(var L in Ă){L.WriteText(Ć);var Y=
Color.Black;var Z=DEFAULT_FONT_COLOR;switch(ć.Ö){case è.ê:Y=Color.Yellow;Z=Color.Black;break;case è.ë:Y=Color.Red;Z=Color.
White;break;case è.ì:Y=Color.Blue;Z=Color.White;break;}L.BackgroundColor=Y;L.ScriptBackgroundColor=Y;L.FontColor=Z;}}void a()
{if(!ą){return;}foreach(var C in ò){C.Power=º();C.SetValueFloat("Speed Limit",26f*3.6f);}var A=ó.GetShipSpeed();ó.
HandBrake=A>24;}void c(){var e=ó.MoveIndicator.Z<0;var A=ó.GetShipSpeed();var f=w();if(A>1){ā=false;if(e){Ĕ-=f*(1f/(60*15))*ē;}}
else if(ą&&ā){Ĕ+=(1f/20)*ē;}Ĕ=MathHelper.Clamp(Ĕ,0,1);foreach(var C in ò){C.Propulsion=Ĕ>0;}}void Q(){var A=ó.GetShipSpeed()
;if(A<1){return;}var H=(float)MathHelper.Clamp(A,0,90)/90;var B=Č*H*ē;č-=B;č=MathHelper.Clamp(č,Ċ,ċ);foreach(var C in ò){
C.Friction=č;}if(č<=Ċ){if(ò.All(C=>C.IsAttached)){var D=new Random().Next(4);ò[D].Detach();}}m();}void E(){if(ă==null){
return;}ă.HudText=$"P{ć.å}";}void F(){if(DRIVER_NUMBER<=0&&DRIVER_NUMBER>99){throw new Exception(
"DRIVER_NUMBER should be between 1 and 99");}Me.CubeGrid.CustomName=$"{DRIVER_NUMBER}-{DRIVER_NAME.Trim()}";}void G(){var I=new List<IMyCockpit>();
GridTerminalSystem.GetBlocksOfType(I);ó=I.FirstOrDefault();if(ó==null){throw new Exception("No cockpit!");}}void O(){ò=new List<
IMyMotorSuspension>();GridTerminalSystem.GetBlocksOfType(ò,C=>C.CubeGrid==Me.CubeGrid);if(ò==null||ò.Count!=4){throw new Exception(
"Need 4 suspensions!");}}void J(){Ć=new StringBuilder();Ă=new List<IMyTextSurface>{Me.GetSurface(0)};var K=(IMyTextSurface)GridTerminalSystem
.GetBlockWithName(DISPLAY_NAME);if(K!=null){Ă.Add(K);}if(COCKPIT_DISPLAY_INDEX.HasValue){var L=ó.GetSurface(
COCKPIT_DISPLAY_INDEX.GetValueOrDefault());if(L!=null){Ă.Add(L);}}foreach(var L in Ă){L.ContentType=ContentType.TEXT_AND_IMAGE;L.Alignment=
TextAlignment.CENTER;L.Font="Monospace";}}void M(){var N=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlockGroupWithName(
BRAKELIGHT_GROUP_NAME).GetBlocks(N,g=>g.CubeGrid==Me.CubeGrid);Ĉ=new List<IMyLightingBlock>();foreach(var P in N){var h=(IMyLightingBlock)P;h
.Intensity=5f;h.BlinkLength=0f;h.BlinkIntervalSeconds=0f;h.Color=Color.Red;Ĉ.Add(h);}}void À(){if(string.
IsNullOrWhiteSpace(Me.CustomData)){Î(æ.ç);return;}var Á=Me.CustomData.Split(';');if(Á.Length<3){Î(æ.ç);return;}var Â=Convert.ToChar(Á[0]);
var Ã=(float)Convert.ToDouble(Á[1]);var Ä=(float)Convert.ToDouble(Á[2]);switch(Â){case'P':Î(æ.ç);break;default:Î(æ.ç);break
;}č=Ã;Ĕ=Ä;}void Å(){var Æ=new List<IMyRadioAntenna>();GridTerminalSystem.GetBlocksOfType(Æ);var Ç=Æ.FirstOrDefault();if(Ç
==null){return;}Ç.Enabled=true;Ç.Radius=5000;Ç.EnableBroadcasting=true;Ç.HudText=$"(P{ć.å}) {DRIVER_NAME}-{DRIVER_NUMBER}"
;ă=Ç;}void È(){IGC.RegisterBroadcastListener("Address");var É=new List<IMyBroadcastListener>();IGC.GetBroadcastListeners(
É);ď=É.FirstOrDefault();}void Ê(string Ë){if(Ë.Equals("LMT",StringComparison.InvariantCultureIgnoreCase)){ą=!ą;return;}if
(Ë.Equals("LMT_ON",StringComparison.InvariantCultureIgnoreCase)){ą=true;return;}if(Ë.Equals("LMT_OFF",StringComparison.
InvariantCultureIgnoreCase)){ą=false;return;}if(Ë.Equals("PIT",StringComparison.InvariantCultureIgnoreCase)){Ì(æ.ç);return;}if(Ë.Equals("ECO",
StringComparison.InvariantCultureIgnoreCase)){ĕ=í.î;return;}if(Ë.Equals("STD",StringComparison.InvariantCultureIgnoreCase)){ĕ=í.ï;return
;}if(Ë.Equals("MAX",StringComparison.InvariantCultureIgnoreCase)){ĕ=í.ñ;return;}}void Ì(æ Í){if(!ą||ó.GetShipSpeed()>1){
return;}ā=true;Î(Í);m(true);}void Î(æ Í){switch(Í){case æ.ç:ċ=100;Ċ=37.5f;Č=(ċ-Ċ)/(60*20);break;default:break;}č=ċ;ĉ=Í;foreach
(var C in ò){C.ApplyAction("Add Top Part");}}void Ï(Color u){foreach(var P in Ĉ){var h=(IMyLightingBlock)P;h.Color=u;}}
void µ(float k){foreach(var C in ò){C.SetValueFloat("Speed Limit",k*3.6f);}}void m(bool n=false){đ-=(int)(ē*1000);if(!n&&đ>0
){return;}var o=p();Me.CustomData=$"{o};{č};{Ĕ}";đ=Ü;}char p(){var o='P';switch(ĉ){case æ.ç:o='P';break;}return o;}string
q(){var r=string.Empty;switch(ć.Ö){case è.ì:r="Blue";break;case è.é:r="Green";break;case è.ë:r="Red";break;case è.ê:r=
"Yellow";break;}return r;}Color t(){var u=Color.Black;switch(ć.Ö){case è.ì:u=Color.Blue;break;case è.é:u=Color.Green;break;case
è.ë:u=Color.Red;break;case è.ê:u=Color.Yellow;break;}return u;}string v(){switch(ĕ){case í.î:return"ECO";case í.ï:return
"STD";case í.ñ:return"MAX";default:return"STD";}}float w(){switch(ĕ){case í.î:return 0.8f;case í.ï:return 1f;case í.ñ:return
2f;default:return 1f;}}string x(){var y=string.Empty;const int z=10;for(int ª=0;ª<z;ª++){var ä=1f/z;if(Ĕ>ä*ª){if(Ĕ<ä*(ª+1)
){y+=â;continue;}y+=á;}else{y+=Ñ;}}return y;}float º(){if(ą){return 20f;}if(ÿ){return 100f;}switch(ĕ){case í.î:return 60f
;case í.ï:return 80f;case í.ñ:return 100f;default:return Ý;}}
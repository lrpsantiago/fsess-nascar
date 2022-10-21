private readonly string DRIVER_NAME = "Guest";
private readonly int DRIVER_NUMBER = 99;
private const string DISPLAY_NAME = "Driver LCD";
private const string BRAKELIGHT_GROUP_NAME = "Brakelight";
private const string DRS_LIGHTS_GROUP_NAME = "DRS Lights";
private const string ERS_LIGHTS_GROUP_NAME = "ERS Lights";
private const string DRAFTING_SENSOR_NAME = "Drafting Sensor";
private readonly int? COCKPIT_DISPLAY_INDEX = null;                     //If you wanna use a cockpit display to show dashboard info (0, 1, 2, 3 or null);
private readonly Color DEFAULT_FONT_COLOR = new Color(127, 127, 127);   //Font Color (R, G, B)

enum ì{ä,å,æ,ç,è}enum é{ê,ë,í,ã}class â{public int Ö{get;set;}public int Î{get;set;}public int Ï{get;set;}public int Ð{
get;set;}public string Ñ{get;set;}="--:--.---";public string Ò{get;set;}="--:--.---";public é Ó{get;set;}=é.ê;public void Ô
(string Õ){try{var ª=Õ.Split(';');Ï=Convert.ToInt32(ª[0]);Ö=Convert.ToInt32(ª[1]);Ñ=ª[2];Ò=ª[3];Î=Convert.ToInt32(ª[4]);Ð
=Convert.ToInt32(ª[5]);Ó=(é)Convert.ToInt32(ª[6]);}catch(Exception){}}}string à="1.0.0 Beta 1";const int Ø=3000;const int
Ù=500;const float Ú=80f;const float Û=90;const char Ü='\u2191';const char Ý='\u2193';const char Þ='\u2588';const char ß=
'\u2592';const char Í='\u2591';List<IMyMotorSuspension>á;IMyCockpit î;List<IMyTextSurface>ÿ;IMyRadioAntenna Ā;IMySensorBlock ā;
bool Ă;StringBuilder ă;â Ą;List<IMyTerminalBlock>ą;List<IMyLightingBlock>Ć;List<IMyLightingBlock>ć;ì Ĉ;float ĉ=0;float Ċ=100
;float ċ=1;float Č=100;long č=-1;IMyBroadcastListener Ď;int ď;int Đ;DateTime đ;float Ē;float Ĕ=1f;bool þ=false;bool ï=
false;Program(){Ą=new â();Y();Q();B();D();G();A();M();Á();ð();z();Ã();Runtime.UpdateFrequency=UpdateFrequency.Update10;đ=
DateTime.Now;}void ð(){var ñ=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(DRAFTING_SENSOR_NAME);if(ñ==null){return;}ā=ñ;ā
.TopExtend=50;ā.BottomExtend=0;ā.RightExtend=2.5f;ā.LeftExtend=2.5f;ā.FrontExtend=0;ā.BackExtend=1;ā.DetectSmallShips=
true;ā.DetectLargeShips=false;ā.DetectStations=false;ā.DetectSubgrids=false;ā.DetectAsteroids=false;ā.DetectPlayers=false;}
void Save(){}void Main(string Æ,UpdateType ò){var ó=DateTime.Now;Ē=(float)(ó-đ).TotalMilliseconds/1000;Echo(
$"Running FSESS-Nascar {à}");Å(Æ);X();ô();V();a();õ();ù();g();đ=ó;}void ô(){if(ā==null){return;}ï=ā.IsActive;foreach(var C in á){C.Power=ï?100:80;
var ü=ï?999:Û;C.SetValueFloat("Speed Limit",ü*3.6f);}}void õ(){var ö=IGC.UnicastListener;if(!ö.HasPendingMessage){ď-=(int)(
Ē*1000);if(Ď.HasPendingMessage&&ď<=0){var S=Ď.AcceptMessage();if(S.Tag=="Address"){č=Convert.ToInt64(S.Data.ToString());
IGC.SendUnicastMessage(č,"Register",$"{Me.CubeGrid.CustomName};{IGC.Me}");}}return;}while(ö.HasPendingMessage){var ø=ö.
AcceptMessage();if(ø.Tag=="RaceData"){Ą.Ô(ø.Data.ToString());}if(ø.Tag=="Argument"){Å(ø.Data.ToString());}}ď=Ø;}void ù(){ă.Clear();
var W=î.GetShipSpeed();var ú=((Č-ĉ)/(Ċ-ĉ))*100f;var û=w();var ý=((int)Math.Floor(ú)).ToString();var Ì=$"{W:F0}m/s";var R=t(
);var P=$"{(int)Math.Floor(Ĕ*100),3}%";var S=Ă?"PIT LIMITER":ï?"DRAFTING":"";ă.AppendLine(Ì);ă.AppendLine(S);ă.AppendLine
($"FUEL {R} {P}");ă.AppendLine($"P:{Ą.Ö:00}/{Ą.Î:00}      L:{(Ą.Ï):00}/{Ą.Ð:00}");ă.AppendLine(
$"TYRE ({û})......: {ý,3}%");ă.AppendLine($"TIME.....: {Ą.Ñ}");ă.AppendLine($"BEST.....: {Ą.Ò}");if(ď<=0){ă.AppendLine($"NO CONNECTION");}foreach(
var F in ÿ){F.WriteText(ă);var T=Color.Black;var U=DEFAULT_FONT_COLOR;switch(Ą.Ó){case é.ë:T=Color.Yellow;U=Color.Black;
break;case é.í:T=Color.Red;U=Color.White;break;case é.ã:T=Color.Blue;U=Color.White;break;}F.BackgroundColor=T;F.
ScriptBackgroundColor=T;F.FontColor=U;}}void V(){if(!Ă){return;}foreach(var C in á){C.Power=20f;C.SetValueFloat("Speed Limit",26f*3.6f);}var
W=î.GetShipSpeed();î.HandBrake=W>24;}void X(){var Z=î.MoveIndicator.Z<0;var W=î.GetShipSpeed();if(W>1){þ=false;if(Z){Ĕ-=(
1f/(60*10))*Ē;}}else if(Ă&&þ){Ĕ+=(1f/20)*Ē;}Ĕ=MathHelper.Clamp(Ĕ,0,1);foreach(var C in á){C.Propulsion=Ĕ>0;}}void a(){var
W=î.GetShipSpeed();if(W<1){return;}var c=(float)MathHelper.Clamp(W,0,90)/90;var e=ċ*c*Ē;Č-=e;Č=MathHelper.Clamp(Č,ĉ,Ċ);
foreach(var C in á){C.Friction=Č;}if(Č<=ĉ){if(á.All(C=>C.IsAttached)){var f=new Random().Next(4);á[f].Detach();}}k();}void g(){
if(Ā==null){return;}Ā.HudText=$"P{Ą.Ö}";}void Y(){if(DRIVER_NUMBER<=0&&DRIVER_NUMBER>99){throw new Exception(
"DRIVER_NUMBER should be between 1 and 99");}Me.CubeGrid.CustomName=$"{DRIVER_NUMBER}-{DRIVER_NAME.Trim()}";}void Q(){var I=new List<IMyCockpit>();
GridTerminalSystem.GetBlocksOfType(I);î=I.FirstOrDefault();if(î==null){throw new Exception("No cockpit!");}}void B(){á=new List<
IMyMotorSuspension>();GridTerminalSystem.GetBlocksOfType(á,C=>C.CubeGrid==Me.CubeGrid);if(á==null||á.Count!=4){throw new Exception(
"Need 4 suspensions!");}}void D(){ă=new StringBuilder();ÿ=new List<IMyTextSurface>{Me.GetSurface(0)};var E=(IMyTextSurface)GridTerminalSystem
.GetBlockWithName(DISPLAY_NAME);if(E!=null){ÿ.Add(E);}if(COCKPIT_DISPLAY_INDEX.HasValue){var F=î.GetSurface(
COCKPIT_DISPLAY_INDEX.GetValueOrDefault());if(F!=null){ÿ.Add(F);}}foreach(var F in ÿ){F.ContentType=ContentType.TEXT_AND_IMAGE;F.Alignment=
TextAlignment.CENTER;F.Font="Monospace";}}void G(){var H=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlockGroupWithName(
BRAKELIGHT_GROUP_NAME).GetBlocks(H,J=>J.CubeGrid==Me.CubeGrid);ą=new List<IMyTerminalBlock>();foreach(var O in H){if(O is IMyLightingBlock){
var K=(IMyLightingBlock)O;K.Intensity=5f;K.BlinkLength=0f;K.BlinkIntervalSeconds=0f;}else if(O is IMyTextPanel){var L=(
IMyTextPanel)O;L.ContentType=ContentType.TEXT_AND_IMAGE;L.WriteText("",false);}ą.Add(O);}}void M(){ć=new List<IMyLightingBlock>();
var H=new List<IMyTerminalBlock>();var N=GridTerminalSystem.GetBlockGroupWithName(DRS_LIGHTS_GROUP_NAME);if(N==null){return
;}N.GetBlocks(H,J=>J.CubeGrid==Me.CubeGrid);foreach(var O in H){var K=(IMyLightingBlock)O;ć.Add(K);}}void A(){Ć=new List<
IMyLightingBlock>();var H=new List<IMyTerminalBlock>();var N=GridTerminalSystem.GetBlockGroupWithName(ERS_LIGHTS_GROUP_NAME);if(N==null)
{return;}N.GetBlocks(H,J=>J.CubeGrid==Me.CubeGrid);foreach(var O in H){var K=(IMyLightingBlock)O;K.Radius=4f;K.Intensity=
10f;K.BlinkLength=50f;K.BlinkIntervalSeconds=0.5f;Ć.Add(K);}}void z(){if(string.IsNullOrWhiteSpace(Me.CustomData)){É(ì.ä);
return;}var ª=Me.CustomData.Split(';');if(ª.Length<3){É(ì.ä);return;}var µ=Convert.ToChar(ª[0]);var º=(float)Convert.ToDouble(
ª[1]);var À=(float)Convert.ToDouble(ª[2]);switch(µ){case'U':É(ì.ä);break;case'S':É(ì.å);break;case'M':É(ì.æ);break;case
'H':É(ì.ç);break;case'X':É(ì.è);break;default:É(ì.ä);break;}Č=º;Ĕ=À;}void Á(){var Â=new List<IMyRadioAntenna>();
GridTerminalSystem.GetBlocksOfType(Â);var Ê=Â.FirstOrDefault();if(Ê==null){return;}Ê.Enabled=true;Ê.Radius=5000;Ê.EnableBroadcasting=true;
Ê.HudText=$"(P{Ą.Ö}) {DRIVER_NAME}-{DRIVER_NUMBER}";Ā=Ê;}void Ã(){IGC.RegisterBroadcastListener("Address");var Ä=new List
<IMyBroadcastListener>();IGC.GetBroadcastListeners(Ä);Ď=Ä.FirstOrDefault();}void Å(string Æ){if(Æ.Equals("LMT",
StringComparison.InvariantCultureIgnoreCase)){Ă=!Ă;return;}if(Æ.Equals("LMT_ON",StringComparison.InvariantCultureIgnoreCase)){Ă=true;
return;}if(Æ.Equals("LMT_OFF",StringComparison.InvariantCultureIgnoreCase)){Ă=false;return;}if(Æ.Equals("ULTRA",
StringComparison.InvariantCultureIgnoreCase)){Ç(ì.ä);return;}if(Æ.Equals("SOFT",StringComparison.InvariantCultureIgnoreCase)){Ç(ì.å);
return;}if(Æ.Equals("MEDIUM",StringComparison.InvariantCultureIgnoreCase)){Ç(ì.æ);return;}if(Æ.Equals("HARD",StringComparison.
InvariantCultureIgnoreCase)){Ç(ì.ç);return;}if(Æ.Equals("EXTRA",StringComparison.InvariantCultureIgnoreCase)){Ç(ì.è);return;}}void Ç(ì È){if(!Ă||î
.GetShipSpeed()>1){return;}þ=true;É(È);k(true);}void É(ì È){var Ë=Color.White;switch(È){case ì.ä:Ċ=100;ĉ=37.5f;ċ=(Ċ-ĉ)/(
60*5);Ë=Color.Magenta;break;case ì.å:Ċ=90;ĉ=40;ċ=(Ċ-ĉ)/(60*8);Ë=Color.Red;break;case ì.æ:Ċ=75;ĉ=43.75f;ċ=(Ċ-ĉ)/(60*13);Ë=
Color.Yellow;break;case ì.ç:Ċ=60;ĉ=47.5f;ċ=(Ċ-ĉ)/(60*21);Ë=Color.White;break;case ì.è:Ċ=55;ĉ=48.75f;ċ=(Ċ-ĉ)/(60*34);Ë=Color.
Cyan;break;default:break;}Č=Ċ;Ĉ=È;y(Ë);foreach(var C in á){C.ApplyAction("Add Top Part");}}void y(Color n){foreach(var O in
ą){if(O is IMyLightingBlock){var K=(IMyLightingBlock)O;K.Color=n;}else if(O is IMyTextPanel){var L=(IMyTextPanel)O;L.
BackgroundColor=n;}}}void h(float j){foreach(var C in á){C.SetValueFloat("Speed Limit",j*3.6f);}}void k(bool m=false){Đ-=(int)(Ē*1000);
if(!m&&Đ>0){return;}var o=w();Me.CustomData=$"{o};{Č};{Ĕ}";Đ=Ù;}char w(){var o='U';switch(Ĉ){case ì.ä:o='U';break;case ì.å
:o='S';break;case ì.æ:o='M';break;case ì.ç:o='H';break;case ì.è:o='X';break;}return o;}string p(){var q=string.Empty;
switch(Ą.Ó){case é.ã:q="Blue";break;case é.ê:q="Green";break;case é.í:q="Red";break;case é.ë:q="Yellow";break;}return q;}Color
r(){var n=Color.Black;switch(Ą.Ó){case é.ã:n=Color.Blue;break;case é.ê:n=Color.Green;break;case é.í:n=Color.Red;break;
case é.ë:n=Color.Yellow;break;}return n;}string t(){var u=string.Empty;const int v=10;for(int ē=0;ē<v;ē++){var x=1f/v;if(Ĕ>x
*ē){if(Ĕ<x*(ē+1)){u+=ß;continue;}u+=Þ;}else{u+=Í;}}return u;}
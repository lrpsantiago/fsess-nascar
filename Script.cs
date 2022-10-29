private readonly string DRIVER_NAME = "Guest";
private readonly int DRIVER_NUMBER = 99;
private const float DEFAULT_SUSPENSION_STRENGTH = 10f;
private const string DISPLAY_NAME = "Driver LCD";
private const string BRAKELIGHT_GROUP_NAME = "Brakelight";
private const string DRAFTING_SENSOR_NAME = "Drafting Sensor";
private readonly int? COCKPIT_DISPLAY_INDEX = null;                     //If you wanna use a cockpit display to show dashboard info (0, 1, 2, 3 or null);
private readonly Color DEFAULT_FONT_COLOR = new Color(127, 127, 127);   //Font Color (R, G, B)

enum ç{è}enum é{ê,ë,ì,í}enum î{ï,ñ,ð}class æ{public int ä{get;set;}public int Ó{get;set;}public int Ô{get;set;}public
int Õ{get;set;}public string Ö{get;set;}="--:--.---";public string Ø{get;set;}="--:--.---";public é Ù{get;set;}=é.ê;public
void Ú(string Û){try{var Â=Û.Split(';');Ô=Convert.ToInt32(Â[0]);ä=Convert.ToInt32(Â[1]);Ö=Â[2];Ø=Â[3];Ó=Convert.ToInt32(Â[4]
);Õ=Convert.ToInt32(Â[5]);Ù=(é)Convert.ToInt32(Â[6]);}catch(Exception){}}}string Ü="1.0.0";const int Ý=3000;const int Þ=
500;const float ß=80f;const float à=95;const char á='\u2191';const char â='\u2193';const char ã='\u2588';const char Ò=
'\u2592';const char ò='\u2591';List<IMyMotorSuspension>ó;IMyCockpit Ă;List<IMyTextSurface>ă;IMyRadioAntenna Ą;IMySensorBlock ą;
bool Ć;StringBuilder ć;æ Ĉ;List<IMyLightingBlock>ĉ;ç Ċ;float ċ=0;float Č=100;float č=1;float Ď=100;long ď=-1;
IMyBroadcastListener Đ;int đ;int Ē;DateTime ē;float ĕ;î Ĕ=î.ñ;float ā=1f;bool Ā=false;bool ô=false;Program(){Ĉ=new æ();G();H();J();K();N();Æ
();õ();Á();É();Runtime.UpdateFrequency=UpdateFrequency.Update10;ē=DateTime.Now;}void õ(){var ö=(IMySensorBlock)
GridTerminalSystem.GetBlockWithName(DRAFTING_SENSOR_NAME);if(ö==null){return;}ą=ö;ą.TopExtend=50;ą.BottomExtend=0;ą.RightExtend=2.5f;ą.
LeftExtend=2.5f;ą.FrontExtend=0;ą.BackExtend=1;ą.DetectSmallShips=true;ą.DetectLargeShips=false;ą.DetectStations=false;ą.
DetectSubgrids=false;ą.DetectAsteroids=false;ą.DetectPlayers=false;}void Save(){}void Main(string Ì,UpdateType ø){var ù=DateTime.Now;ĕ
=(float)(ù-ē).TotalMilliseconds/1000;Echo($"Running FSESS-Nascar {Ü}");Ë(Ì);f();ü();e();Q();ú();þ();Ñ();F();ē=ù;}void ú()
{var û=Ă.MoveIndicator.Z>0||Ă.MoveIndicator.Y>0||Ă.HandBrake;foreach(var j in ĉ){j.Enabled=û;}}void ü(){if(ą==null){
return;}ô=!ą.Closed&&ą.IsActive&&Ă.GetShipSpeed()>=60;foreach(var D in ó){D.Power=À();var ý=ô?999:à;D.Strength+=ô?(100f/2)*ĕ:-
(100f/2)*ĕ;D.Strength=MathHelper.Clamp(D.Strength,DEFAULT_SUSPENSION_STRENGTH,100);D.SetValueFloat("Speed Limit",ý*3.6f);
}}void þ(){var ÿ=IGC.UnicastListener;if(!ÿ.HasPendingMessage){đ-=(int)(ĕ*1000);if(Đ.HasPendingMessage&&đ<=0){var Z=Đ.
AcceptMessage();if(Z.Tag=="Address"){ď=Convert.ToInt64(Z.Data.ToString());IGC.SendUnicastMessage(ď,"Register",
$"{Me.CubeGrid.CustomName};{IGC.Me}");}}return;}while(ÿ.HasPendingMessage){var å=ÿ.AcceptMessage();if(å.Tag=="RaceData"){Ĉ.Ú(å.Data.ToString());}if(å.Tag==
"Argument"){Ë(å.Data.ToString());}}đ=Ý;}void Ñ(){ć.Clear();var P=Ă.GetShipSpeed();var S=((Ď-ċ)/(Č-ċ))*100f;var T=q();var U=((int)
Math.Floor(S)).ToString();var V=$"{P:F0}m/s";var W=$"MODE: {w()}".PadLeft(20-V.Length,' ');var X=y();var Y=
$"{(int)Math.Floor(ā*100),3}%";var Z=Ć?"PIT LIMITER":ô?"DRAFTING":"";ć.AppendLine($"{V}{W}");ć.AppendLine(Z);ć.AppendLine($"FUEL {X} {Y}");ć.
AppendLine($"P:{Ĉ.ä:00}/{Ĉ.Ó:00}      L:{(Ĉ.Ô):00}/{Ĉ.Õ:00}");ć.AppendLine($"TYRE .........: {U,3}%");ć.AppendLine(
$"TIME.....: {Ĉ.Ö}");ć.AppendLine($"BEST.....: {Ĉ.Ø}");if(đ<=0){ć.AppendLine($"NO CONNECTION");}foreach(var M in ă){M.WriteText(ć);var a=
Color.Black;var c=DEFAULT_FONT_COLOR;switch(Ĉ.Ù){case é.ë:a=Color.Yellow;c=Color.Black;break;case é.ì:a=Color.Red;c=Color.
White;break;case é.í:a=Color.Blue;c=Color.White;break;}M.BackgroundColor=a;M.ScriptBackgroundColor=a;M.FontColor=c;}}void e()
{if(!Ć){return;}foreach(var D in ó){D.Power=À();D.SetValueFloat("Speed Limit",26f*3.6f);}var P=Ă.GetShipSpeed();Ă.
HandBrake=P>24;}void f(){var g=Ă.MoveIndicator.Z<0;var P=Ă.GetShipSpeed();var h=x();if(P>1){Ā=false;if(g){ā-=h*(1f/(60*15))*ĕ;}}
else if(Ć&&Ā){ā+=(1f/20)*ĕ;}ā=MathHelper.Clamp(ā,0,1);foreach(var D in ó){D.Propulsion=ā>0;}}void Q(){var P=Ă.GetShipSpeed()
;if(P<1){return;}var B=(float)MathHelper.Clamp(P,0,90)/90;var C=č*B*ĕ;Ď-=C;Ď=MathHelper.Clamp(Ď,ċ,Č);foreach(var D in ó){
D.Friction=Ď;}if(Ď<=ċ){if(ó.All(D=>D.IsAttached)){var E=new Random().Next(4);ó[E].Detach();}}n();}void F(){if(Ą==null){
return;}Ą.HudText=$"P{Ĉ.ä}";}void G(){if(DRIVER_NUMBER<=0&&DRIVER_NUMBER>99){throw new Exception(
"DRIVER_NUMBER should be between 1 and 99");}Me.CubeGrid.CustomName=$"{DRIVER_NUMBER}-{DRIVER_NAME.Trim()}";}void H(){var I=new List<IMyCockpit>();
GridTerminalSystem.GetBlocksOfType(I);Ă=I.FirstOrDefault();if(Ă==null){throw new Exception("No cockpit!");}}void J(){ó=new List<
IMyMotorSuspension>();GridTerminalSystem.GetBlocksOfType(ó,D=>D.CubeGrid==Me.CubeGrid);if(ó==null||ó.Count!=4){throw new Exception(
"Need 4 suspensions!");}}void K(){ć=new StringBuilder();ă=new List<IMyTextSurface>{Me.GetSurface(0)};var L=(IMyTextSurface)GridTerminalSystem
.GetBlockWithName(DISPLAY_NAME);if(L!=null){ă.Add(L);}if(COCKPIT_DISPLAY_INDEX.HasValue){var M=Ă.GetSurface(
COCKPIT_DISPLAY_INDEX.GetValueOrDefault());if(M!=null){ă.Add(M);}}foreach(var M in ă){M.ContentType=ContentType.TEXT_AND_IMAGE;M.Alignment=
TextAlignment.CENTER;M.Font="Monospace";}}void N(){var O=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlockGroupWithName(
BRAKELIGHT_GROUP_NAME).GetBlocks(O,A=>A.CubeGrid==Me.CubeGrid);ĉ=new List<IMyLightingBlock>();foreach(var j in O){var k=(IMyLightingBlock)j;k
.Intensity=5f;k.BlinkLength=0f;k.BlinkIntervalSeconds=0f;k.Color=Color.Red;ĉ.Add(k);}}void Á(){if(string.
IsNullOrWhiteSpace(Me.CustomData)){Ï(ç.è);return;}var Â=Me.CustomData.Split(';');if(Â.Length<3){Ï(ç.è);return;}var Ã=Convert.ToChar(Â[0]);
var Ä=(float)Convert.ToDouble(Â[1]);var Å=(float)Convert.ToDouble(Â[2]);switch(Ã){case'P':Ï(ç.è);break;default:Ï(ç.è);break
;}Ď=Ä;ā=Å;}void Æ(){var Ç=new List<IMyRadioAntenna>();GridTerminalSystem.GetBlocksOfType(Ç);var È=Ç.FirstOrDefault();if(È
==null){return;}È.Enabled=true;È.Radius=5000;È.EnableBroadcasting=true;È.HudText=$"(P{Ĉ.ä}) {DRIVER_NAME}-{DRIVER_NUMBER}"
;Ą=È;}void É(){IGC.RegisterBroadcastListener("Address");var Ê=new List<IMyBroadcastListener>();IGC.GetBroadcastListeners(
Ê);Đ=Ê.FirstOrDefault();}void Ë(string Ì){if(Ì.Equals("LMT",StringComparison.InvariantCultureIgnoreCase)){Ć=!Ć;return;}if
(Ì.Equals("LMT_ON",StringComparison.InvariantCultureIgnoreCase)){Ć=true;return;}if(Ì.Equals("LMT_OFF",StringComparison.
InvariantCultureIgnoreCase)){Ć=false;return;}if(Ì.Equals("PIT",StringComparison.InvariantCultureIgnoreCase)){Í(ç.è);return;}if(Ì.Equals("ECO",
StringComparison.InvariantCultureIgnoreCase)){Ĕ=î.ï;return;}if(Ì.Equals("STD",StringComparison.InvariantCultureIgnoreCase)){Ĕ=î.ñ;return
;}if(Ì.Equals("MAX",StringComparison.InvariantCultureIgnoreCase)){Ĕ=î.ð;return;}}void Í(ç Î){if(!Ć||Ă.GetShipSpeed()>1){
return;}Ā=true;Ï(Î);n(true);}void Ï(ç Î){switch(Î){case ç.è:Č=75;ċ=43.75f;č=(Č-ċ)/(60*18.75f);break;default:break;}Ď=Č;Ċ=Î;
foreach(var D in ó){D.ApplyAction("Add Top Part");}}void Ð(Color v){foreach(var j in ĉ){var k=(IMyLightingBlock)j;k.Color=v;}}
void º(float m){foreach(var D in ó){D.SetValueFloat("Speed Limit",m*3.6f);}}void n(bool o=false){Ē-=(int)(ĕ*1000);if(!o&&Ē>0
){return;}var p=q();Me.CustomData=$"{p};{Ď};{ā}";Ē=Þ;}char q(){var p='P';switch(Ċ){case ç.è:p='P';break;}return p;}string
r(){var t=string.Empty;switch(Ĉ.Ù){case é.í:t="Blue";break;case é.ê:t="Green";break;case é.ì:t="Red";break;case é.ë:t=
"Yellow";break;}return t;}Color u(){var v=Color.Black;switch(Ĉ.Ù){case é.í:v=Color.Blue;break;case é.ê:v=Color.Green;break;case
é.ì:v=Color.Red;break;case é.ë:v=Color.Yellow;break;}return v;}string w(){switch(Ĕ){case î.ï:return"ECO";case î.ñ:return
"STD";case î.ð:return"MAX";default:return"STD";}}float x(){switch(Ĕ){case î.ï:return 0.8f;case î.ñ:return 1f;case î.ð:return
2f;default:return 1f;}}string y(){var z=string.Empty;const int ª=10;for(int µ=0;µ<ª;µ++){var R=1f/ª;if(ā>R*µ){if(ā<R*(µ+1)
){z+=Ò;continue;}z+=ã;}else{z+=ò;}}return z;}float À(){if(Ć){return 20f;}if(ô){return 100f;}switch(Ĕ){case î.ï:return 60f
;case î.ñ:return 80f;case î.ð:return 100f;default:return ß;}}
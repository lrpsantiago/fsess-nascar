private readonly string DRIVER_NAME = "Guest";
private readonly int DRIVER_NUMBER = 99;
private const string DISPLAY_NAME = "Driver LCD";
private const string BRAKELIGHT_GROUP_NAME = "Brakelight";
private const string DRS_LIGHTS_GROUP_NAME = "DRS Lights";
private const string ERS_LIGHTS_GROUP_NAME = "ERS Lights";
private const string DRAFTING_SENSOR_NAME = "Drafting Sensor";
private readonly int? COCKPIT_DISPLAY_INDEX = null;                     //If you wanna use a cockpit display to show dashboard info (0, 1, 2, 3 or null);
private readonly Color DEFAULT_FONT_COLOR = new Color(127, 127, 127);   //Font Color (R, G, B)

enum ê{ô,ë,ì,í,î}enum ï{ð,ñ,ò,ó}enum õ{è,Ò,æ}class Ó{public int Ô{get;set;}public int Õ{get;set;}public int Ö{get;set;}
public int Ø{get;set;}public string Ù{get;set;}="--:--.---";public string Ú{get;set;}="--:--.---";public ï Û{get;set;}=ï.ð;
public void Ü(string Ý){try{var À=Ý.Split(';');Ö=Convert.ToInt32(À[0]);Ô=Convert.ToInt32(À[1]);Ù=À[2];Ú=À[3];Õ=Convert.ToInt32
(À[4]);Ø=Convert.ToInt32(À[5]);Û=(ï)Convert.ToInt32(À[6]);}catch(Exception){}}}string Þ="1.0.0 Beta 2";const int ß=3000;
const int à=500;const float á=80f;const float â=90;const char ã='\u2191';const char ä='\u2193';const char å='\u2588';const
char é='\u2592';const char ö='\u2591';List<IMyMotorSuspension>Ē;IMyCockpit Ĉ;List<IMyTextSurface>ĉ;IMyRadioAntenna Ċ;
IMySensorBlock ċ;bool Č;StringBuilder č;Ó Ď;List<IMyTerminalBlock>ď;List<IMyLightingBlock>Đ;List<IMyLightingBlock>đ;ê ē;float ĝ=0;
float Ĕ=100;float ĕ=1;float Ė=100;long ė=-1;IMyBroadcastListener Ę;int ę;int Ě;DateTime ě;float Ĝ;õ Ğ=õ.Ò;float ć=1f;bool ø=
false;bool ą=false;Program(){Ď=new Ó();Q();P();C();E();H();A();N();Ä();ù();º();Ï();Runtime.UpdateFrequency=UpdateFrequency.
Update10;ě=DateTime.Now;}void ù(){var ú=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(DRAFTING_SENSOR_NAME);if(ú==null){
return;}ċ=ú;ċ.TopExtend=50;ċ.BottomExtend=0;ċ.RightExtend=2.5f;ċ.LeftExtend=2.5f;ċ.FrontExtend=0;ċ.BackExtend=1;ċ.
DetectSmallShips=true;ċ.DetectLargeShips=false;ċ.DetectStations=false;ċ.DetectSubgrids=false;ċ.DetectAsteroids=false;ċ.DetectPlayers=
false;}void Save(){}void Main(string Ê,UpdateType û){var ü=DateTime.Now;Ĝ=(float)(ü-ě).TotalMilliseconds/1000;Echo(
$"Running FSESS-Nascar {Þ}");É(Ê);Y();ý();W();c();ÿ();Ă();g();ě=ü;}void ý(){if(ċ==null){return;}ą=ċ.IsActive;foreach(var D in Ē){D.Power=µ();var þ=
ą?999:â;D.SetValueFloat("Speed Limit",þ*3.6f);}}void ÿ(){var Ā=IGC.UnicastListener;if(!Ā.HasPendingMessage){ę-=(int)(Ĝ*
1000);if(Ę.HasPendingMessage&&ę<=0){var T=Ę.AcceptMessage();if(T.Tag=="Address"){ė=Convert.ToInt64(T.Data.ToString());IGC.
SendUnicastMessage(ė,"Register",$"{Me.CubeGrid.CustomName};{IGC.Me}");}}return;}while(Ā.HasPendingMessage){var ā=Ā.AcceptMessage();if(ā.
Tag=="RaceData"){Ď.Ü(ā.Data.ToString());}if(ā.Tag=="Argument"){É(ā.Data.ToString());}}ę=ß;}void Ă(){č.Clear();var X=Ĉ.
GetShipSpeed();var ă=((Ė-ĝ)/(Ĕ-ĝ))*100f;var Ą=p();var Ć=((int)Math.Floor(ă)).ToString();var Ñ=$"{X:F0}m/s";var R=$"MODE: {v()}".
PadLeft(20-Ñ.Length,' ');var Æ=x();var S=$"{(int)Math.Floor(ć*100),3}%";var T=Č?"PIT LIMITER":ą?"DRAFTING":"";č.AppendLine(
$"{Ñ}{R}");č.AppendLine(T);č.AppendLine($"FUEL {Æ} {S}");č.AppendLine($"P:{Ď.Ô:00}/{Ď.Õ:00}      L:{(Ď.Ö):00}/{Ď.Ø:00}");č.
AppendLine($"TYRE ({Ą})......: {Ć,3}%");č.AppendLine($"TIME.....: {Ď.Ù}");č.AppendLine($"BEST.....: {Ď.Ú}");if(ę<=0){č.AppendLine(
$"NO CONNECTION");}foreach(var G in ĉ){G.WriteText(č);var U=Color.Black;var V=DEFAULT_FONT_COLOR;switch(Ď.Û){case ï.ñ:U=Color.Yellow;V=
Color.Black;break;case ï.ò:U=Color.Red;V=Color.White;break;case ï.ó:U=Color.Blue;V=Color.White;break;}G.BackgroundColor=U;G.
ScriptBackgroundColor=U;G.FontColor=V;}}void W(){if(!Č){return;}foreach(var D in Ē){D.Power=µ();D.SetValueFloat("Speed Limit",26f*3.6f);}var
X=Ĉ.GetShipSpeed();Ĉ.HandBrake=X>24;}void Y(){var Z=Ĉ.MoveIndicator.Z<0;var X=Ĉ.GetShipSpeed();var a=w();if(X>1){ø=false;
if(Z){ć-=a*(1f/(60*15))*Ĝ;}}else if(Č&&ø){ć+=(1f/20)*Ĝ;}ć=MathHelper.Clamp(ć,0,1);foreach(var D in Ē){D.Propulsion=ć>0;}}
void c(){var X=Ĉ.GetShipSpeed();if(X<1){return;}var e=(float)MathHelper.Clamp(X,0,90)/90;var f=ĕ*e*Ĝ;Ė-=f;Ė=MathHelper.Clamp
(Ė,ĝ,Ĕ);foreach(var D in Ē){D.Friction=Ė;}if(Ė<=ĝ){if(Ē.All(D=>D.IsAttached)){var h=new Random().Next(4);Ē[h].Detach();}}
m();}void g(){if(Ċ==null){return;}Ċ.HudText=$"P{Ď.Ô}";}void Q(){if(DRIVER_NUMBER<=0&&DRIVER_NUMBER>99){throw new
Exception("DRIVER_NUMBER should be between 1 and 99");}Me.CubeGrid.CustomName=$"{DRIVER_NUMBER}-{DRIVER_NAME.Trim()}";}void P(){
var B=new List<IMyCockpit>();GridTerminalSystem.GetBlocksOfType(B);Ĉ=B.FirstOrDefault();if(Ĉ==null){throw new Exception(
"No cockpit!");}}void C(){Ē=new List<IMyMotorSuspension>();GridTerminalSystem.GetBlocksOfType(Ē,D=>D.CubeGrid==Me.CubeGrid);if(Ē==
null||Ē.Count!=4){throw new Exception("Need 4 suspensions!");}}void E(){č=new StringBuilder();ĉ=new List<IMyTextSurface>{Me.
GetSurface(0)};var F=(IMyTextSurface)GridTerminalSystem.GetBlockWithName(DISPLAY_NAME);if(F!=null){ĉ.Add(F);}if(
COCKPIT_DISPLAY_INDEX.HasValue){var G=Ĉ.GetSurface(COCKPIT_DISPLAY_INDEX.GetValueOrDefault());if(G!=null){ĉ.Add(G);}}foreach(var G in ĉ){G.
ContentType=ContentType.TEXT_AND_IMAGE;G.Alignment=TextAlignment.CENTER;G.Font="Monospace";}}void H(){var I=new List<
IMyTerminalBlock>();GridTerminalSystem.GetBlockGroupWithName(BRAKELIGHT_GROUP_NAME).GetBlocks(I,J=>J.CubeGrid==Me.CubeGrid);ď=new List<
IMyTerminalBlock>();foreach(var K in I){if(K is IMyLightingBlock){var L=(IMyLightingBlock)K;L.Intensity=5f;L.BlinkLength=0f;L.
BlinkIntervalSeconds=0f;}else if(K is IMyTextPanel){var M=(IMyTextPanel)K;M.ContentType=ContentType.TEXT_AND_IMAGE;M.WriteText("",false);}ď.
Add(K);}}void N(){đ=new List<IMyLightingBlock>();var I=new List<IMyTerminalBlock>();var O=GridTerminalSystem.
GetBlockGroupWithName(DRS_LIGHTS_GROUP_NAME);if(O==null){return;}O.GetBlocks(I,J=>J.CubeGrid==Me.CubeGrid);foreach(var K in I){var L=(
IMyLightingBlock)K;đ.Add(L);}}void A(){Đ=new List<IMyLightingBlock>();var I=new List<IMyTerminalBlock>();var O=GridTerminalSystem.
GetBlockGroupWithName(ERS_LIGHTS_GROUP_NAME);if(O==null){return;}O.GetBlocks(I,J=>J.CubeGrid==Me.CubeGrid);foreach(var K in I){var L=(
IMyLightingBlock)K;L.Radius=4f;L.Intensity=10f;L.BlinkLength=50f;L.BlinkIntervalSeconds=0.5f;Đ.Add(L);}}void º(){if(string.
IsNullOrWhiteSpace(Me.CustomData)){Í(ê.ô);return;}var À=Me.CustomData.Split(';');if(À.Length<3){Í(ê.ô);return;}var Á=Convert.ToChar(À[0]);
var Â=(float)Convert.ToDouble(À[1]);var Ã=(float)Convert.ToDouble(À[2]);switch(Á){case'U':Í(ê.ô);break;case'S':Í(ê.ë);break
;case'M':Í(ê.ì);break;case'H':Í(ê.í);break;case'X':Í(ê.î);break;default:Í(ê.ô);break;}Ė=Â;ć=Ã;}void Ä(){var Å=new List<
IMyRadioAntenna>();GridTerminalSystem.GetBlocksOfType(Å);var Ç=Å.FirstOrDefault();if(Ç==null){return;}Ç.Enabled=true;Ç.Radius=5000;Ç.
EnableBroadcasting=true;Ç.HudText=$"(P{Ď.Ô}) {DRIVER_NAME}-{DRIVER_NUMBER}";Ċ=Ç;}void Ï(){IGC.RegisterBroadcastListener("Address");var È=
new List<IMyBroadcastListener>();IGC.GetBroadcastListeners(È);Ę=È.FirstOrDefault();}void É(string Ê){if(Ê.Equals("LMT",
StringComparison.InvariantCultureIgnoreCase)){Č=!Č;return;}if(Ê.Equals("LMT_ON",StringComparison.InvariantCultureIgnoreCase)){Č=true;
return;}if(Ê.Equals("LMT_OFF",StringComparison.InvariantCultureIgnoreCase)){Č=false;return;}if(Ê.Equals("ULTRA",
StringComparison.InvariantCultureIgnoreCase)){Ë(ê.ô);return;}if(Ê.Equals("SOFT",StringComparison.InvariantCultureIgnoreCase)){Ë(ê.ë);
return;}if(Ê.Equals("MEDIUM",StringComparison.InvariantCultureIgnoreCase)){Ë(ê.ì);return;}if(Ê.Equals("HARD",StringComparison.
InvariantCultureIgnoreCase)){Ë(ê.í);return;}if(Ê.Equals("EXTRA",StringComparison.InvariantCultureIgnoreCase)){Ë(ê.î);return;}if(Ê.Equals("ECO",
StringComparison.InvariantCultureIgnoreCase)){Ğ=õ.è;return;}if(Ê.Equals("STD",StringComparison.InvariantCultureIgnoreCase)){Ğ=õ.Ò;return
;}if(Ê.Equals("MAX",StringComparison.InvariantCultureIgnoreCase)){Ğ=õ.æ;return;}}void Ë(ê Ì){if(!Č||Ĉ.GetShipSpeed()>1){
return;}ø=true;Í(Ì);m(true);}void Í(ê Ì){var Î=Color.White;switch(Ì){case ê.ô:Ĕ=100;ĝ=37.5f;ĕ=(Ĕ-ĝ)/(60*5);Î=Color.Magenta;
break;case ê.ë:Ĕ=90;ĝ=40;ĕ=(Ĕ-ĝ)/(60*8);Î=Color.Red;break;case ê.ì:Ĕ=75;ĝ=43.75f;ĕ=(Ĕ-ĝ)/(60*13);Î=Color.Yellow;break;case ê.
í:Ĕ=60;ĝ=47.5f;ĕ=(Ĕ-ĝ)/(60*21);Î=Color.White;break;case ê.î:Ĕ=55;ĝ=48.75f;ĕ=(Ĕ-ĝ)/(60*34);Î=Color.Cyan;break;default:
break;}Ė=Ĕ;ē=Ì;Ð(Î);foreach(var D in Ē){D.ApplyAction("Add Top Part");}}void Ð(Color u){foreach(var K in ď){if(K is
IMyLightingBlock){var L=(IMyLightingBlock)K;L.Color=u;}else if(K is IMyTextPanel){var M=(IMyTextPanel)K;M.BackgroundColor=u;}}}void j(
float k){foreach(var D in Ē){D.SetValueFloat("Speed Limit",k*3.6f);}}void m(bool n=false){Ě-=(int)(Ĝ*1000);if(!n&&Ě>0){return
;}var o=p();Me.CustomData=$"{o};{Ė};{ć}";Ě=à;}char p(){var o='U';switch(ē){case ê.ô:o='U';break;case ê.ë:o='S';break;case
ê.ì:o='M';break;case ê.í:o='H';break;case ê.î:o='X';break;}return o;}string q(){var r=string.Empty;switch(Ď.Û){case ï.ó:r
="Blue";break;case ï.ð:r="Green";break;case ï.ò:r="Red";break;case ï.ñ:r="Yellow";break;}return r;}Color t(){var u=Color.
Black;switch(Ď.Û){case ï.ó:u=Color.Blue;break;case ï.ð:u=Color.Green;break;case ï.ò:u=Color.Red;break;case ï.ñ:u=Color.Yellow
;break;}return u;}string v(){switch(Ğ){case õ.è:return"ECO";case õ.Ò:return"STD";case õ.æ:return"MAX";default:return"STD"
;}}float w(){switch(Ğ){case õ.è:return 0.8f;case õ.Ò:return 1f;case õ.æ:return 2f;default:return 1f;}}string x(){var y=
string.Empty;const int z=10;for(int ª=0;ª<z;ª++){var ç=1f/z;if(ć>ç*ª){if(ć<ç*(ª+1)){y+=é;continue;}y+=å;}else{y+=ö;}}return y;
}float µ(){if(Č){return 20f;}if(ą){return 100f;}switch(Ğ){case õ.è:return 60f;case õ.Ò:return 80f;case õ.æ:return 100f;
default:return á;}}
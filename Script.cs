private readonly string DRIVER_NAME = "Guest";
private readonly int DRIVER_NUMBER = 99;
private const float DEFAULT_SUSPENSION_STRENGTH = 10f;
private const string DISPLAY_NAME = "Driver LCD";
private const string BRAKELIGHT_GROUP_NAME = "Brakelight";
private const string DRAFTING_SENSOR_NAME = "Drafting Sensor";
private readonly int? COCKPIT_DISPLAY_INDEX = null;                     //If you wanna use a cockpit display to show dashboard info (0, 1, 2, 3 or null);
private readonly Color DEFAULT_FONT_COLOR = new Color(127, 127, 127);   //Font Color (R, G, B)

enum é{ò}enum ê{ë,ì,í,î}enum ï{ð,ñ,ó}class ç{public int Ó{get;set;}public int å{get;set;}public int Ô{get;set;}public
int Õ{get;set;}public string Ö{get;set;}="--:--.---";public string Ø{get;set;}="--:--.---";public ê Ù{get;set;}=ê.ë;public
void Ú(string Û){try{var Ä=Û.Split(';');Ô=Convert.ToInt32(Ä[0]);Ó=Convert.ToInt32(Ä[1]);Ö=Ä[2];Ø=Ä[3];å=Convert.ToInt32(Ä[4]
);Õ=Convert.ToInt32(Ä[5]);Ù=(ê)Convert.ToInt32(Ä[6]);}catch(Exception){}}}string Ü="2.0.0";const int Ý=3000;const int Þ=
1000;const int ß=1000;const float à=80f;const float á=96f;const char â='\u2191';const char ã='\u2193';const char ä='\u2588';
const char è='\u2592';const char æ='\u2591';Color ô=new Color(32,0,0);List<IMyMotorSuspension>Ć;IMyCockpit ć;List<
IMyTextSurface>Ĉ;IMyRadioAntenna ĉ;IMySensorBlock Ċ;bool ċ;StringBuilder Č;ç č;List<IMyLightingBlock>Ď;é Đ;float ę=0;float đ=100;float
Ē=1;float ē=100;long Ĕ=-1;IMyBroadcastListener ĕ;int Ė;int ė;DateTime Ę;float Ě;ï ď=ï.ñ;float ą=1f;bool û=false;bool ö=
false;int ø;Program(){č=new ç();G();H();J();K();N();È();ù();Ã();Ë();Runtime.UpdateFrequency=UpdateFrequency.Update1;Ę=
DateTime.Now;}void ù(){var ú=(IMySensorBlock)GridTerminalSystem.GetBlockWithName(DRAFTING_SENSOR_NAME);if(ú==null){return;}Ċ=ú;Ċ
.TopExtend=50;Ċ.BottomExtend=0;Ċ.RightExtend=2.5f;Ċ.LeftExtend=2.5f;Ċ.FrontExtend=0;Ċ.BackExtend=1;Ċ.DetectSmallShips=
true;Ċ.DetectLargeShips=false;Ċ.DetectStations=false;Ċ.DetectSubgrids=false;Ċ.DetectAsteroids=false;Ċ.DetectPlayers=false;}
void Save(){}void Main(string Í,UpdateType ü){var ă=DateTime.Now;Ě=(float)(ă-Ę).TotalMilliseconds/1000;Echo(
$"Running FSESS-Nascar {Ü}");Ò(Í);g();ÿ();f();A();ý();Ă();Q();F();Ę=ă;}void ý(){var þ=ć.MoveIndicator.Z>0||ć.MoveIndicator.Y>0||ć.HandBrake;foreach
(var k in Ď){k.Color=þ?Color.Red:ô;}}void ÿ(){if(Ċ==null){return;}var Ā=!Ċ.Closed&&Ċ.IsActive&&ć.GetShipSpeed()>=60;if(Ā)
{ø=ß;}if(ċ){ø=0;}ö=ø>0;foreach(var D in Ć){var ā=Á();D.SetValueFloat("Speed Limit",ā*3.6f);D.Power=õ();D.Strength+=ö?(
100f/2)*Ě:-(100f/2)*Ě;D.Strength=MathHelper.Clamp(D.Strength,DEFAULT_SUSPENSION_STRENGTH,100);}ø-=(int)(Ě*1000);}void Ă(){
var Ą=IGC.UnicastListener;if(!Ą.HasPendingMessage){Ė-=(int)(Ě*1000);if(ĕ.HasPendingMessage&&Ė<=0){var a=ĕ.AcceptMessage();
if(a.Tag=="Address"){Ĕ=Convert.ToInt64(a.Data.ToString());IGC.SendUnicastMessage(Ĕ,"Register",
$"{Me.CubeGrid.CustomName};{IGC.Me}");}}return;}while(Ą.HasPendingMessage){var R=Ą.AcceptMessage();if(R.Tag=="RaceData"){č.Ú(R.Data.ToString());}if(R.Tag==
"Argument"){Ò(R.Data.ToString());}}Ė=Ý;}void Q(){Č.Clear();var P=ć.GetShipSpeed();var S=((ē-ę)/(đ-ę))*100f;var T=q();var U=((int)
Math.Floor(S)).ToString();var V=$"{P:F0}m/s";var W=$"MODE: {w()}".PadLeft(20-V.Length,' ');var X=y();var Y=
$"{(int)Math.Floor(ą*100),3}%";var a=ċ?"PIT LIMITER":ö?"DRAFTING":"";Č.AppendLine($"{V}{W}");Č.AppendLine(a);Č.AppendLine($"FUEL {X} {Y}");Č.
AppendLine($"P:{č.Ó:00}/{č.å:00}      L:{(č.Ô):00}/{č.Õ:00}");Č.AppendLine($"TYRE .........: {U,3}%");Č.AppendLine(
$"TIME.....: {č.Ö}");Č.AppendLine($"BEST.....: {č.Ø}");if(Ė<=0){Č.AppendLine($"NO CONNECTION");}foreach(var M in Ĉ){M.WriteText(Č);var c=
Color.Black;var e=DEFAULT_FONT_COLOR;switch(č.Ù){case ê.ì:c=Color.Yellow;e=Color.Black;break;case ê.í:c=Color.Red;e=Color.
White;break;case ê.î:c=Color.Blue;e=Color.White;break;}M.BackgroundColor=c;M.ScriptBackgroundColor=c;M.FontColor=e;}}void f()
{if(!ċ){return;}foreach(var D in Ć){D.Power=õ();D.SetValueFloat("Speed Limit",26f*3.6f);}var P=ć.GetShipSpeed();ć.
HandBrake=P>24;}void g(){var h=ć.MoveIndicator.Z<0;var P=ć.GetShipSpeed();var j=x();if(P>1){û=false;if(h){ą-=j*(1f/(60*15))*Ě;}}
else if(ċ&&û){ą+=(1f/20)*Ě;}ą=MathHelper.Clamp(ą,0,1);foreach(var D in Ć){D.Propulsion=ą>0;}}void A(){var P=ć.GetShipSpeed()
;if(P<1){return;}var B=(float)MathHelper.Clamp(P,0,90)/90;var C=Ē*B*Ě;ē-=C;ē=MathHelper.Clamp(ē,ę,đ);foreach(var D in Ć){
D.Friction=ē;}if(ē<=ę){if(Ć.All(D=>D.IsAttached)){var E=new Random().Next(4);Ć[E].Detach();}}n();}void F(){if(ĉ==null){
return;}ĉ.HudText=$"P{č.Ó}";}void G(){if(DRIVER_NUMBER<=0&&DRIVER_NUMBER>99){throw new Exception(
"DRIVER_NUMBER should be between 1 and 99");}Me.CubeGrid.CustomName=$"{DRIVER_NUMBER:00}-{DRIVER_NAME.Trim()}";}void H(){var I=new List<IMyCockpit>();
GridTerminalSystem.GetBlocksOfType(I);ć=I.FirstOrDefault();if(ć==null){throw new Exception("No cockpit!");}}void J(){Ć=new List<
IMyMotorSuspension>();GridTerminalSystem.GetBlocksOfType(Ć,D=>D.CubeGrid==Me.CubeGrid);if(Ć==null||Ć.Count!=4){throw new Exception(
"Need 4 suspensions!");}}void K(){Č=new StringBuilder();Ĉ=new List<IMyTextSurface>{Me.GetSurface(0)};var L=(IMyTextSurface)GridTerminalSystem
.GetBlockWithName(DISPLAY_NAME);if(L!=null){Ĉ.Add(L);}if(COCKPIT_DISPLAY_INDEX.HasValue){var M=ć.GetSurface(
COCKPIT_DISPLAY_INDEX.GetValueOrDefault());if(M!=null){Ĉ.Add(M);}}foreach(var M in Ĉ){M.ContentType=ContentType.TEXT_AND_IMAGE;M.Alignment=
TextAlignment.CENTER;M.Font="Monospace";}}void N(){var O=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlockGroupWithName(
BRAKELIGHT_GROUP_NAME).GetBlocks(O,Z=>Z.CubeGrid==Me.CubeGrid);Ď=new List<IMyLightingBlock>();foreach(var k in O){var Â=(IMyLightingBlock)k;Â
.Enabled=true;Â.Intensity=10f;Â.BlinkLength=0f;Â.BlinkIntervalSeconds=0f;Â.Color=Color.Black;Ď.Add(Â);}}void Ã(){if(
string.IsNullOrWhiteSpace(Me.CustomData)){Ð(é.ò);return;}var Ä=Me.CustomData.Split(';');if(Ä.Length<3){Ð(é.ò);return;}var Å=
Convert.ToChar(Ä[0]);var Æ=(float)Convert.ToDouble(Ä[1]);var Ç=(float)Convert.ToDouble(Ä[2]);switch(Å){case'P':Ð(é.ò);break;
default:Ð(é.ò);break;}ē=Æ;ą=Ç;}void È(){var É=new List<IMyRadioAntenna>();GridTerminalSystem.GetBlocksOfType(É);var Ê=É.
FirstOrDefault();if(Ê==null){return;}Ê.Enabled=true;Ê.Radius=5000;Ê.EnableBroadcasting=true;Ê.HudText=
$"(P{č.Ó}) {DRIVER_NAME}-{DRIVER_NUMBER}";ĉ=Ê;}void Ë(){IGC.RegisterBroadcastListener("Address");var Ì=new List<IMyBroadcastListener>();IGC.GetBroadcastListeners
(Ì);ĕ=Ì.FirstOrDefault();}void Ò(string Í){if(Í.Equals("LMT",StringComparison.InvariantCultureIgnoreCase)){ċ=!ċ;return;}
if(Í.Equals("LMT_ON",StringComparison.InvariantCultureIgnoreCase)){ċ=true;return;}if(Í.Equals("LMT_OFF",StringComparison.
InvariantCultureIgnoreCase)){ċ=false;return;}if(Í.Equals("PIT",StringComparison.InvariantCultureIgnoreCase)){Î(é.ò);return;}if(Í.Equals("ECO",
StringComparison.InvariantCultureIgnoreCase)){ď=ï.ð;return;}if(Í.Equals("STD",StringComparison.InvariantCultureIgnoreCase)){ď=ï.ñ;return
;}if(Í.Equals("MAX",StringComparison.InvariantCultureIgnoreCase)){ď=ï.ó;return;}}void Î(é Ï){if(!ċ||ć.GetShipSpeed()>1){
return;}û=true;Ð(Ï);n(true);}void Ð(é Ï){switch(Ï){case é.ò:đ=75;ę=43.75f;Ē=(đ-ę)/(60*18.75f);break;default:break;}ē=đ;Đ=Ï;
foreach(var D in Ć){D.ApplyAction("Add Top Part");}}void Ñ(Color v){foreach(var k in Ď){var Â=(IMyLightingBlock)k;Â.Color=v;}}
void m(float À){foreach(var D in Ć){D.SetValueFloat("Speed Limit",À*3.6f);}}void n(bool o=false){ė-=(int)(Ě*1000);if(!o&&ė>0
){return;}var p=q();Me.CustomData=$"{p};{ē};{ą}";ė=Þ;}char q(){var p='P';switch(Đ){case é.ò:p='P';break;}return p;}string
r(){var t=string.Empty;switch(č.Ù){case ê.î:t="Blue";break;case ê.ë:t="Green";break;case ê.í:t="Red";break;case ê.ì:t=
"Yellow";break;}return t;}Color u(){var v=Color.Black;switch(č.Ù){case ê.î:v=Color.Blue;break;case ê.ë:v=Color.Green;break;case
ê.í:v=Color.Red;break;case ê.ì:v=Color.Yellow;break;}return v;}string w(){switch(ď){case ï.ð:return"ECO";case ï.ñ:return
"STD";case ï.ó:return"MAX";default:return"STD";}}float x(){switch(ď){case ï.ð:return 0.8f;case ï.ñ:return 1f;case ï.ó:return
2f;default:return 1f;}}string y(){var z=string.Empty;const int ª=10;for(int µ=0;µ<ª;µ++){var º=1f/ª;if(ą>º*µ){if(ą<º*(µ+1)
){z+=è;continue;}z+=ä;}else{z+=æ;}}return z;}float õ(){if(ċ){return 20f;}if(ö){return 100f;}switch(ď){case ï.ð:return 60f
;case ï.ñ:return 80f;case ï.ó:return 100f;default:return à;}}float Á(){if(ċ){return 26;}if(č.Ù==ê.ì){return 45;}if(ö){
return 999;}switch(ď){case ï.ð:return 95f;case ï.ó:return 98f;case ï.ñ:default:return á;}}